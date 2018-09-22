using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.DomainServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(DomainServices.Interfaces.IBeneficiarioDomainService), typeof(BeneficiarioDomainServices));
            dic.Add(typeof(DomainServices.Interfaces.IProgramaDomainService), typeof(ProgramaDomainService));
            dic.Add(typeof(DomainServices.Interfaces.IQuestionarioDomainService), typeof(QuestionarioDomainService));
            dic.Add(typeof(DomainServices.Interfaces.IPerguntaDomainService), typeof(PerguntaDomainService));

            return dic;
        }
    }
}
