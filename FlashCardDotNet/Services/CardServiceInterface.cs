using FlashCardDotNet.Entities;

namespace FlashCardDotNet.Services
{
    public interface CardServiceInterface
    {
        public Task<IEnumerable<Card>> GetAllCards();
        public Task<Card> GetACard(Card card);
        public Task<Card> EditACard(Card card);
        public Task<Card> AddACard(Card card);
        public Task<Card> DeleteACard(Card card);
    }
}
