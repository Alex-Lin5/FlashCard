﻿using FlashCardDotNet.Data;
using FlashCardDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCardDotNet.Repositories
{
    public class CardRepository : CardRepositoryInterface
    {
        private readonly CardContext context;
        public CardRepository(CardContext context) { 
            this.context = context;
        }
        public async Task<Card> AddCard(Card card)
        {
            card.cardId = Guid.NewGuid();
            context.FlashCards.Add(card);
            await context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> DeleteCardById(Guid id)
        {
            Card card = await context.FlashCards.FindAsync(id);
            if(card != null)
            {
                context.FlashCards.Remove(card);
                await context.SaveChangesAsync();
                return card;
            }
            return new Card();
        }

        public async Task<Card> EditCard(Card card)
        {
            Card cardFound = await context.FlashCards.FindAsync(card.cardId);
            if (cardFound != null)
            {
                cardFound.question = card.question;
                cardFound.answer = card.answer;
                cardFound.status = card.status;
                await context.SaveChangesAsync();
                return card;
            }
            return new Card();
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await context.FlashCards.ToListAsync();
        }

        public async Task<Card> GetCardById(Guid id)
        {
            return await context.FlashCards.FindAsync(id);
        }
    }
}
