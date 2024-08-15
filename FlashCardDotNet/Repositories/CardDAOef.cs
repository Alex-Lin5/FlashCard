using FlashCardDotNet.Data;
using FlashCardDotNet.Entities;

namespace FlashCardDotNet.Repositories
{
    public class CardDAOef : CardDAOInterface
    {
        // code first approach
        public Card GetCardById(Guid id)
        {
            Card card;
            using (var context = new CardDAOContext())
            {
                card = context.Cards.FirstOrDefault(
                    c => c.cardId == id
                    );
            }
            return card;
        }

        public Card InsertCard(Card card)
        {
            Card cardAdd = new Card(card);
            using (var context = new CardDAOContext())
            {
                Guid cardId = Guid.NewGuid();
                cardAdd.cardId = cardId;
                context.Add(cardAdd);
                context.SaveChanges();
            }
            return cardAdd;
        }

        public Card EditCard(Card card)
        {
            Card cardEdit = new Card(card);
            using (var context = new CardDAOContext())
            {
                context.Update(card);
                context.SaveChanges();
            }
            return cardEdit;
        }

        public List<Card> GetAllCards()
        {
            List<Card> cards = new List<Card>();
            return cards;
        }


        public Card RemoveCard(Card card)
        {
            Card cardRemove = new Card(card);
            using (var context = new CardDAOContext()) {
                context.Remove(card);
                context.SaveChanges();
            }
            return cardRemove;
        }
    }
}
