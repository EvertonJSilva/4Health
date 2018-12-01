using System.Reflection;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Serialization;
using FourHealth.AppServices.DTOs;
using FourHealth.Logs.Controllers;

namespace Logs
{
  [PSerializable]
  [LinesOfCodeAvoided(6)]
  public sealed class LogMethodAttribute : OnMethodBoundaryAspect
  {

    public override void OnEntry(MethodExecutionArgs args)
    {
            if(args.Method.IsConstructor){ return; }

            switch (args.Method.DeclaringType.Name.ToString())
            {
                case "BeneficiarioController":
                    BeneficiarioLogger.Log(args);
                    break;
                default:
                    break;
            }
    }


    public override void OnSuccess(MethodExecutionArgs args)
    {
        if (args.Method.IsConstructor) { return; }

        switch (args.Method.DeclaringType.Name.ToString())
        {
            case "BeneficiarioController":
                BeneficiarioLogger.LogRetorno(args);
                break;
            default:
                break;
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