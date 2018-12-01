using System.Reflection;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Serialization;
//using FourHealth.Domain.Filters;

namespace Logs
{

  [PSerializable]
  [LinesOfCodeAvoided(6)]
  public sealed class LogMethodAttribute : OnMethodBoundaryAspect
  {

    public override void OnEntry(MethodExecutionArgs args)
    {
            if (args.Method.DeclaringType.Name.ToString().Contains("BeneficiarioController") && !args.Method.IsConstructor)
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append("Controller chamado: ");

                if (args.Arguments.Count > 0) { 
                var valor = args.Arguments.GetArgument(0);
                stringBuilder.Append(valor);
            }
            

            AppendCallInformation(args, stringBuilder);
            Logger.WriteLine(stringBuilder.ToString());

            Logger.Indent();
         }
    }


    public override void OnSuccess(MethodExecutionArgs args)
    {
        if (args.Method.DeclaringType.Name.ToString().Contains("BeneficiarioController") && !args.Method.IsConstructor)
        {
            Logger.Unindent();

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(" Saindo do controler: ");
            AppendCallInformation(args, stringBuilder);

            stringBuilder.Append(" Com o retorno: ");
            stringBuilder.Append(args.ReturnValue);

            Logger.WriteLine(stringBuilder.ToString());
        }
    }

    public override void OnException(MethodExecutionArgs args)
    {
        if (args.Method.DeclaringType.Name.ToString().Contains("BeneficiarioController") && !args.Method.IsConstructor)
        {
            Logger.Unindent();

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Saindo do controller: ");
            AppendCallInformation(args, stringBuilder);

            stringBuilder.Append(" com erro  ");
            stringBuilder.Append(args.Exception.GetType().Name);
  
            Logger.WriteLine(stringBuilder.ToString());
        }
    }

    private static void AppendCallInformation(MethodExecutionArgs args, StringBuilder stringBuilder)
    {
      var declaringType = args.Method.DeclaringType;
      Formatter.AppendTypeName(stringBuilder, declaringType);
      stringBuilder.Append('.');
      stringBuilder.Append(args.Method.Name);

      if (args.Method.IsGenericMethod)
      {
        var genericArguments = args.Method.GetGenericArguments();
        Formatter.AppendGenericArguments(stringBuilder, genericArguments);
      }

      var arguments = args.Arguments;

      Formatter.AppendArguments(stringBuilder, arguments);
    }
  }
}