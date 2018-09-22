using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.AppServices.DTOs
{
    public class QuestionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<PerguntaDTO> Perguntas { get; set; }
    }
}
