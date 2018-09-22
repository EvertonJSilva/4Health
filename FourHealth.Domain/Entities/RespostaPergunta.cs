using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Entities
{
    public class RespostaPergunta
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
    }
}