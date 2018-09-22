using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(Domain.Repositories.IBeneficiarioRepository), typeof(Repositories.BeneficiarioRepository));
            dic.Add(typeof(Domain.Repositories.IProgramaRepository), typeof(Repositories.ProgramaRepository));
            dic.Add(typeof(Domain.Repositories.IQuestionarioRepository), typeof(Repositories.QuestionarioRepository));
            dic.Add(typeof(Domain.Repositories.IPerguntaRepository), typeof(Repositories.PerguntaRepository));


            return dic;
        }
    }
}
