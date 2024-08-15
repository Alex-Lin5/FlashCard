using FlashCardDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCardDotNet.Data
{
    public class CardRepositoryContext: DbContext
    {
        public CardRepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
