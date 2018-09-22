using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Entities
{
    public class ProgramaContratado
    {
        public int Id { get; set; }
        public Programa Programa { get; set; }
        public List<RespostaPergunta> Respostas {get;set;}
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}