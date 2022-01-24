using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardModels
{
    public class CreditCardDTO
    {
        public int CardNumber { get; set; }
        public float Balance { get; set; }
        public string CardOwnerFullName { get; set; }
    }
}
