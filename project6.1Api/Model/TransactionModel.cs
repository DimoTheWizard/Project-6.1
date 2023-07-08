using System.ComponentModel.DataAnnotations;

namespace project6._1Api.Model
{
    public class TransactionModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Account { get; set; }
        [Required]
        public string ClosingAvailableBalance { get; set; }
        [Required]
        public string ClosingBalance { get; set; }
        public string Description { get; set; }
        [Required]
        public string ForwardAvailableBalance { get; set; }
        [Required]
        public string OpeningBalance { get; set; }
        public string RelatedMessage { get; set; }
        [Required]
        public string SequenceNumber { get; set; }
        [Required]
        public string StatementNumber { get; set; }
        [Required]
        public string TransactionReference { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string TransactionDate { get; set; }
        
    }
}
