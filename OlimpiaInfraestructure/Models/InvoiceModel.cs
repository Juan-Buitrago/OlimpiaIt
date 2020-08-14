using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaInfraestructure.Models
{
    public class InvoiceModel
    {
        public int Id;
        public string Nit;
        public string Description;
        public double TotalValue;
        public int VatPercentage;
    }
}
