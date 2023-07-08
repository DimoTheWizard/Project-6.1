using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace project6._1Api.Model
{
    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [Key]
        [XmlElement(ElementName = "id")]
        public string id { get; set; }

        [Required]
        [XmlElement(ElementName = "account")]
        public string account { get; set; }

        [Required]
        [XmlElement(ElementName = "closingAvailableBalance")]
        public string closingAvailableBalance { get; set; }

        [Required]
        [XmlElement(ElementName = "closingBalance")]
        public string closingBalance { get; set; }

        [XmlElement(ElementName = "description")]
        public string description { get; set; }

        [Required]
        [XmlElement(ElementName = "forwardAvailableBalance")]
        public string forwardAvailableBalance { get; set; }

        [Required]
        [XmlElement(ElementName = "openingBalance")]
        public string openingBalance { get; set; }

        [XmlElement(ElementName = "relatedMessage")]
        public string relatedMessage { get; set; }

        [Required]
        [XmlElement(ElementName = "sequenceNumber")]
        public string sequenceNumber { get; set; }

        [Required]
        [XmlElement(ElementName = "statementNumber")]
        public string statementNumber { get; set; }

        [Required]
        [XmlElement(ElementName = "transactionReference")]
        public string transactionReference { get; set; }

        [Required]
        [XmlElement(ElementName = "transactionType")]
        public string transactionType { get; set; }

        [Required]
        [XmlElement(ElementName = "transactionDate")]
        public string transactionDate { get; set; }

    }
}
