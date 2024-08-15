using FlashCardDotNet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardDotNet.Controllers
{
    public interface CardControllerInterface
    {
        Task<ActionResult<IEnumerable<Card>>> GetAllCards();
        Task<ActionResult<Card>> GetCardById(Guid id);
        Task<ActionResult<Card>> AddCard(Card card);
        Task<ActionResult<Card>> EditCard(Card card);
        Task<ActionResult<Card>> DeleteCardById(Guid id);
    }
}
