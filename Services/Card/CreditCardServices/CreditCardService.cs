using CreditCardInfrastructure;
using CreditCardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardServices
{
    public class CreditCardService : ICreditCardService
    {
        public CreditCardDTO GetByCardId(int cardNumber)
        {
            return new CreditCardDTO()
            {
                CardNumber = cardNumber,
                CardOwnerFullName = "Sefer Mirza",
                Balance = 100,
            };
        }
    }
}
