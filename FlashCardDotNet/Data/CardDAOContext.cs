using FlashCardDotNet.Entities;
using FlashCardDotNet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlashCardDotNet.Data
{
    public class CardDAOContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CardDAOsqlClient.dataSource);
        }
        public DbSet<Card> Cards { get; set; }
    }
}
