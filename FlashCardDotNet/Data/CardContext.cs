using FlashCardDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCardDotNet.Data
{
    public class CardContext: DbContext
    {
        public CardContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> FlashCards { get; set; }
    }
}
