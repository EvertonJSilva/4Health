using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using PostSharp.Serialization;
using Logs;

namespace FourHealth.Logs.Controllers
{
    public class BeneficiarioLogger
    {
        static StringBuilder stringBuilder = new StringBuilder();

        public static void Log(MethodExecutionArgs args)
        {
            stringBuilder.Clear();
            stringBuilder.Append("BeneficiarioController-> ");

            switch (args.Method.Name)
            {
                case "Get":
                    LogGet(args);
                    break;
                case "Put":
                    LogPut(args);
                    break;
                case "Post":
                    LogPost(args);
                    break;

                default:
                    break;
            }
        }

        public static void LogRetorno(MethodExecutionArgs args)
        {
            Logger.Unindent();
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Retorno do método");
            Logger.WriteLine(stringBuilder.ToString());
            return;
        }

        public static void LogGet(MethodExecutionArgs args)
        {
            stringBuilder.Append("Método GET-> ");

            if (args.Arguments.Count > 0)
            {
                var valor = (BeneficiarioFilterDTO)args.Arguments.GetArgument(0);
                stringBuilder.Append(" CPF: " + valor.CPF);
                stringBuilder.Append(" Nome: " + valor.Nome);
                stringBuilder.Append(" ID: " + valor.Id);
            }

            Logger.WriteLine(stringBuilder.ToString());

            Logger.Indent();
        }

        public static void LogPut(MethodExecutionArgs args)
        {
            stringBuilder.Append("Método PUT-> ");
            if (args.Arguments.Count > 0)
            {
                var valor = (BeneficiarioDTO)args.Arguments.GetArgument(0);
                stringBuilder.Append(" CPF: " + valor.Cpf);
                stringBuilder.Append(" Nome: " + valor.Nome);
                stringBuilder.Append(" ID: " + valor.Id);
            }

            Logger.WriteLine(stringBuilder.ToString());

            Logger.Indent();
        }

        public static void LogPost(MethodExecutionArgs args)
        {
            stringBuilder.Append("Método POST-> ");
            if (args.Arguments.Count > 0)
            {
                var valor = (BeneficiarioDTO)args.Arguments.GetArgument(0);
                stringBuilder.Append(" CPF: " + valor.Cpf);
                stringBuilder.Append(" Nome: " + valor.Nome);
                stringBuilder.Append(" ID: " + valor.Id);
            }

            Logger.WriteLine(stringBuilder.ToString());

            Logger.Indent();
        }
    }
}
