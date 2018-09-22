using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.AppServices.DTOs
{
    public class PerguntaDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int TipoPergunta { get; set; }
    }
}
