using CreditCardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInfrastructure
{
    public interface ICreditCardService
    {
        public CreditCardDTO GetByCardId(int cardNumber);
    }
}
