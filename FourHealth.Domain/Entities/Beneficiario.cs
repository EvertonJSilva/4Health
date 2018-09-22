using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Entities
{
    public class Beneficiario
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Cpf { get; set; }
        public List<ProgramaContratado> programas { get; set; }
    }
}
