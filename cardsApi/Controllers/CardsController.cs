using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cardsApi.Providers;
using cardsApi.Requests;

namespace cardsApi.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IcardsProvider cardsProvider;

		public CardsController(IcardsProvider cardsProvider)		
		{
            this.cardsProvider = cardsProvider;
        }

        [HttpGet]
        public List<String> getAllCards()
        { 
            return this.cardsProvider.getCardList();
        }

       [HttpGet]
       [Route("playerCards")]
       public List<String> getPlayerCards(int players)
       {
           return this.cardsProvider.getPlayerCardList(players);
       }

        [HttpPost]
        [Route("sortCards")]
       public List<String> sortCards([FromBody]cardrequest request)
       { 
            List<String> cardList = request.cards;
            return this.cardsProvider.splitCards(cardList);
       }


    }
}