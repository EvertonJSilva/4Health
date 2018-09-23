using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.Domain.Filters
{
    public class BeneficiarioFilter
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

    }
}
