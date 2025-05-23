using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Entities
{
    public class TransactionSummary
    {
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
        public int Count { get; set; }
    }

}
