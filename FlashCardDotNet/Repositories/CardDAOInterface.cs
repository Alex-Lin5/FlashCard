using FlashCardDotNet.Entities;

namespace FlashCardDotNet.Repositories
{
    public interface CardDAOInterface
    {
        public Card InsertCard(Card card);
        public Card RemoveCard(Card card);
        public Card EditCard(Card card);
        public List<Card> GetAllCards();
        public Card GetCardById(Guid id);
    }
}
