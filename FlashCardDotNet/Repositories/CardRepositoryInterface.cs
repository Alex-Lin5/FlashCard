using FlashCardDotNet.Entities;

namespace FlashCardDotNet.Repositories
{
    public interface CardRepositoryInterface
    {
        public Task<IEnumerable<Card>> GetAllCards();
        public Task<Card> GetCardById(Guid id);
        public Task<Card> EditCard(Card card);
        public Task<Card> AddCard(Card card);
        public Task<Card> DeleteCardById(Guid id);
    }
}
