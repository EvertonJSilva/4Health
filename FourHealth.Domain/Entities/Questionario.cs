﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Entities
{
    public class Questionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Pergunta> Perguntas { get; set; }
    }

}
