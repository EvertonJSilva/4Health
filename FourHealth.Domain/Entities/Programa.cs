using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Entities
{
    public class Programa
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Questionario Questionario { get; set; }
        public int IdadeMinima {get;set;}
        public int IdadeMaxima { get; set; }
        public char Sexo { get; set; }
        public int Cidade { get; set; }

    }


}
