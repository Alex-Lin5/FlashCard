using System.ComponentModel.DataAnnotations;

namespace FlashCardDotNet.Entities
{
    public class Card
    {
        [Key]
        public Guid cardId { get; set; }
        [Required(ErrorMessage ="question is required to put in")]
        public string question { get; set; }
        [Required(ErrorMessage ="answer is required to put in")]
        public string answer { get; set; }
        public string status { get; set; }

        public Card() {
            this.question = "None";
            this.answer = "None";
            this.status = "None";
        }
        public Card(Guid id) { 
            this.cardId = id;
            this.question = "None";
            this.answer = "None";
            this.status = "None";
        }
        public Card(Card card)
        {
            this.cardId = card.cardId;
            this.question = card.question;
            this.answer = card.answer;
            this.status = card.status;
        }
        public Card(string question, string answer, string status)
        {
            this.cardId = new Guid();
            this.question = question;
            this.answer = answer;
            this.status = status;
        }
        public Card(Guid cardId, string question, string answer, string status)
        {
            this.cardId = cardId;
            this.question = question;
            this.answer = answer;
            this.status = status;
        }
        public override string ToString() {
            return $"cardId={cardId}, question={question}, answer={answer}, status={status}.\n";
        }
    }
}
