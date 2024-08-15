using FlashCardDotNet.Data;
using FlashCardDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCardDotNet.Repositories
{
    public class CardRepository : CardRepositoryInterface
    {
        private readonly CardRepositoryContext context;
        public CardRepository(CardRepositoryContext context) { 
            this.context = context;
        }
        public async Task<Card> AddCard(Card card)
        {
            card.cardId = Guid.NewGuid();
            context.Cards.Add(card);
            await context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> DeleteCardById(Guid id)
        {
            Card card = await context.Cards.FindAsync(id);
            if(card != null)
            {
                context.Cards.Remove(card);
                await context.SaveChangesAsync();
            }
            return card;
        }

        public async Task<Card> EditCard(Card card)
        {
            context.Entry(card).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return card;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await context.Cards.ToListAsync();
        }

        public async Task<Card> GetCardById(Guid id)
        {
            return await context.Cards.FindAsync(id);
        }
    }
}
