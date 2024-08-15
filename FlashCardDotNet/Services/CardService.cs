using FlashCardDotNet.Entities;
using FlashCardDotNet.Repositories;

namespace FlashCardDotNet.Services
{
    public class CardService : CardServiceInterface
    {
        private readonly CardRepositoryInterface cardRepository;
        public CardService(CardRepositoryInterface cardRepository) {
            this.cardRepository = cardRepository;
        }
        public async Task<Card> AddACard(Card card)
        {
            return await cardRepository.AddCard(card);
        }

        public async Task<Card> DeleteACard(Card card)
        {
            Card cardDel = await cardRepository.GetCardById(card.cardId);
            if (cardDel != null)
            {
                await cardRepository.DeleteCardById(card.cardId);
                return cardDel;
            }
            return new Card();
        }

        public async Task<Card> EditACard(Card card)
        {
            Card cardEdit = await cardRepository.GetCardById(card.cardId);
            if (cardEdit != null)
            {
                await cardRepository.EditCard(card);
                return cardEdit;
            }
            return new Card();
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await cardRepository.GetAllCards();
        }

        public async Task<Card> GetACard(Card card)
        {
            return await cardRepository.GetCardById(card.cardId);
        }
    }
}
