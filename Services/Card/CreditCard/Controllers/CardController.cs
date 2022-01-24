using CreditCardInfrastructure;
using CreditCardModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        public CardController(ICreditCardService cardService)
        {
            _creditCardService = cardService;
        }

        //asekron yapılabilir
        [HttpGet("{Id}")]
        public CreditCardDTO Get(int Id)
        {
            return _creditCardService.GetByCardId(Id);
        }
    }
}
