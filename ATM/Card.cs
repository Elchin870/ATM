using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Card
    {
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public string Expire_Date { get; set; }
        public decimal Balans { get; set; }

    }
}
