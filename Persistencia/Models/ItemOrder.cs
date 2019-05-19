using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public class ItemOrder
    {
        public string qtd { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public string identifier { get; set; }
    }
}
