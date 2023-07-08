using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace project6._1Api.Entities
{
    public partial class Transaction
    {
        public Transaction() { 
        
        }

        public string id { get; set; }

        public string account { get; set; }
     
        public string closingAvailableBalance { get; set; }
     
        public string closingBalance { get; set; }
        public string description { get; set; }
     
        public string forwardAvailableBalance { get; set; }
        public string openingBalance { get; set; }
        public string relatedMessage { get; set; }
     
        public string sequenceNumber { get; set; }
     
        public string statementNumber { get; set; }
     
        public string transactionReference { get; set; }
     
        public string transactionType { get; set; }
     
        public string transactionDate { get; set; }
    }

}
