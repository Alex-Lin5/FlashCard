using FlashCardDotNet.Entities;
using FlashCardDotNet.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase, CardControllerInterface
    {
        private readonly CardServiceInterface cardService;
        public CardController(CardServiceInterface cardService)
        {
            this.cardService = cardService;
        }
        [HttpPost]
        public async Task<ActionResult<Card>> AddCard(Card card)
        {
            Card cardAdd = await cardService.AddACard(card);
            return Ok(cardAdd);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult<Card>> DeleteCardById(Guid id)
        {
            Card card = new Card(id);
            Card cardDel = await cardService.DeleteACard(card);
            return Ok(cardDel);
        }

        [HttpPut]
        public async Task<ActionResult<Card>> EditCard(Card card)
        {
            Card cardEdit = await cardService.EditACard(card);
            return Ok(cardEdit);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
        {
            IEnumerable<Card> cards = await cardService.GetAllCards();
            return Ok(cards);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Card>> GetCardById(Guid id)
        {
            Card card = new Card(id);
            Card cardGet = await cardService.GetACard(card);
            return Ok(cardGet);
        }
    }
}
