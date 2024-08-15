using FlashCardDotNet.Entities;
using Microsoft.Data.SqlClient;

namespace FlashCardDotNet.Repositories
{
    public class CardDAOsqlClient : CardDAOInterface
    {
        public static string dataSource = "data source=PC-202405111557;initial catalog=FlashcardDB;trusted_connection=true";
        public Card EditCard(Card card)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAllCards()
        {
            List<Card> cards = new List<Card>();
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Flashcard;", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Card card = new Card();
                    card.cardId = new Guid(reader["cardId"].ToString());
                    card.question = reader["question"].ToString();
                    card.answer = reader["answer"].ToString();
                    card.status = reader["status"].ToString();
                    cards.Add(card);
                }

            }
            Console.WriteLine("Get all cards. ", cards);
            return cards;
        }

        public Card GetCardById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Card InsertCard(Card card)
        {
            Card cardAdded = new Card(card);
            using(SqlConnection connection = new SqlConnection(dataSource))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.uspInsertCard", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@question", card.question);
                cmd.Parameters.AddWithValue("@answer", card.answer);
                cmd.Parameters.AddWithValue("@status", card.status);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Insert Card succuess. ", cardAdded);
            }

            return cardAdded;

        }

        public Card RemoveCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
