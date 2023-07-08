using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using project6._1Api.Entities;
using project6._1Api.Model;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;
using System.Net;
using System.Xml.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project6._1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class TransactionController : ControllerBase
    {
        private readonly database _dbContext;

        public TransactionController(database dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ValuesController>
        [HttpGet("GetAllJson")]
        public IActionResult GetJson()
        {
            IEnumerable<Transaction> transactions = _dbContext.Transactions
                .Select(t => new Transaction
                {
                    id = t.Id,
                    account = t.Account,
                    closingAvailableBalance = t.ClosingAvailableBalance,
                    closingBalance = t.ClosingBalance,
                    description = t.Description,
                    forwardAvailableBalance = t.ForwardAvailableBalance,
                    openingBalance = t.OpeningBalance,
                    relatedMessage = t.RelatedMessage,
                    sequenceNumber = t.SequenceNumber,
                    statementNumber = t.StatementNumber,
                    transactionReference = t.TransactionReference,
                    transactionType = t.TransactionType,
                    transactionDate = t.TransactionDate,

                });

            if (transactions == null)
            {
                return null;
            }
            else
            {
                return Ok(transactions);
            }
        }

        // GET: api/<ValuesController>
        [HttpGet("GetAllXml")]
        [Produces("application/xml")]
        public IActionResult GetXml()
        {
            List<Transaction> transactions = _dbContext.Transactions
                .Select(t => new Transaction
                {
                    id = t.Id,
                    account = t.Account,
                    closingAvailableBalance = t.ClosingAvailableBalance,
                    closingBalance = t.ClosingBalance,
                    description = t.Description,
                    forwardAvailableBalance = t.ForwardAvailableBalance,
                    openingBalance = t.OpeningBalance,
                    relatedMessage = t.RelatedMessage,
                    sequenceNumber = t.SequenceNumber,
                    statementNumber = t.StatementNumber,
                    transactionReference = t.TransactionReference,
                    transactionType = t.TransactionType,
                    transactionDate = t.TransactionDate,

                })
                .ToList();

            if (transactions.Count > 0)
            {
                string xmlContent = ToXmlParser(transactions);
                return Content(xmlContent, "application/xml");
            }
            else
            {
                return NotFound();
            }
        }

        private string ToXmlParser(List<Model.Transaction> transactions)
        {
            XDocument xmlDocument = new XDocument();

            XElement rootElement = new XElement("Transactions");

            foreach (Model.Transaction transaction in transactions)
            {
                XElement transactionElement = new XElement("Transaction",
                    new XElement("id", transaction.id),
                    new XElement("account", transaction.account),
                    new XElement("closingAvailableBalance", transaction.closingAvailableBalance),
                    new XElement("closingBalance", transaction.closingBalance),
                    new XElement("description", transaction.description),
                    new XElement("forwardAvailableBalance", transaction.forwardAvailableBalance),
                    new XElement("openingBalance", transaction.openingBalance),
                    new XElement("relatedMessage", transaction.relatedMessage),
                    new XElement("sequenceNumber", transaction.sequenceNumber),
                    new XElement("statementNumber", transaction.statementNumber),
                    new XElement("transactionReference", transaction.transactionReference),
                    new XElement("transactionType", transaction.transactionType),
                    new XElement("transactionDate", transaction.transactionDate)
                );
                rootElement.Add(transactionElement);
            }

            xmlDocument.Add(rootElement);

            return xmlDocument.ToString();
        }

        // POST api/<ValuesController>
        [HttpPost("PostJson")]
        [Consumes("application/json")]
        public IActionResult PostJson([FromBody] Model.Transaction transactionModel)
        {
            if (ModelState.IsValid)
            {
                Entities.Transactions newTransaction = new Entities.Transactions()
                {
                    Id = transactionModel.id,
                    Account = transactionModel.account,
                    ClosingAvailableBalance = transactionModel.closingAvailableBalance,
                    ClosingBalance = transactionModel.closingBalance,
                    Description = transactionModel.description,
                    ForwardAvailableBalance = transactionModel.forwardAvailableBalance,
                    OpeningBalance = transactionModel.openingBalance,
                    RelatedMessage = transactionModel.relatedMessage,
                    SequenceNumber = transactionModel.sequenceNumber,
                    StatementNumber = transactionModel.statementNumber,
                    TransactionReference = transactionModel.transactionReference,
                    TransactionType = transactionModel.transactionType,
                    TransactionDate = transactionModel.transactionDate
                };

                int comparator = string.Compare(transactionModel.id, sqlitedb.GetTransactionCount());
                if (comparator > 0)
                {
                    _dbContext.Transactions.Add(newTransaction);
                    _dbContext.SaveChanges();

                    return StatusCode(201, "Transaction created successfully.");
                }
                else
                {
                    return StatusCode(406, $"ID must be greater than {sqlitedb.GetTransactionCount()}.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/<ValuesController>
        [HttpPost("PostlXml")]
        [Consumes("application/xml")]
        public IActionResult PostXml(Model.Transaction transactionModel)
        {
            if (ModelState.IsValid)
            {
                Entities.Transactions newTransaction = new Entities.Transactions()
                {
                    Id = transactionModel.id,
                    Account = transactionModel.account,
                    ClosingAvailableBalance = transactionModel.closingAvailableBalance,
                    ClosingBalance = transactionModel.closingBalance,
                    Description = transactionModel.description,
                    ForwardAvailableBalance = transactionModel.forwardAvailableBalance,
                    OpeningBalance = transactionModel.openingBalance,
                    RelatedMessage = transactionModel.relatedMessage,
                    SequenceNumber = transactionModel.sequenceNumber,
                    StatementNumber = transactionModel.statementNumber,
                    TransactionReference = transactionModel.transactionReference,
                    TransactionType = transactionModel.transactionType,
                    TransactionDate = transactionModel.transactionDate
                };

                int comparator = string.Compare(transactionModel.id, sqlitedb.GetTransactionCount());
                if (comparator > 0)
                {
                    _dbContext.Transactions.Add(newTransaction);
                    _dbContext.SaveChanges();

                    return StatusCode(201, "Transaction created successfully.");
                }
                else
                {
                    return StatusCode(406, $"ID must be greater than {sqlitedb.GetTransactionCount()}.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("UpdateJson{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateJson(string id, [FromBody] Model.Transaction transactionModel)
        {
            if (ModelState.IsValid)
            {
                Entities.Transactions existingTransaction = _dbContext.Transactions.FirstOrDefault(t => t.Id == id);

                if (existingTransaction != null)
                {
                    existingTransaction.Account = transactionModel.account;
                    existingTransaction.ClosingAvailableBalance = transactionModel.closingAvailableBalance;
                    existingTransaction.ClosingBalance = transactionModel.closingBalance;
                    existingTransaction.Description = transactionModel.description;
                    existingTransaction.ForwardAvailableBalance = transactionModel.forwardAvailableBalance;
                    existingTransaction.OpeningBalance = transactionModel.openingBalance;
                    existingTransaction.RelatedMessage = transactionModel.relatedMessage;
                    existingTransaction.SequenceNumber = transactionModel.sequenceNumber;
                    existingTransaction.StatementNumber = transactionModel.statementNumber;
                    existingTransaction.TransactionReference = transactionModel.transactionReference;
                    existingTransaction.TransactionType = transactionModel.transactionType;
                    existingTransaction.TransactionDate = transactionModel.transactionDate;

                    _dbContext.SaveChanges();

                    return Ok("Transaction updated successfully.");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("UpdateXml{id}")]
        [Consumes("application/xml")]
        public IActionResult UpdateXml(string id, [FromBody] Model.Transaction transactionModel)
        {
            if (ModelState.IsValid)
            {
                Entities.Transactions existingTransaction = _dbContext.Transactions.FirstOrDefault(t => t.Id == id);

                if (existingTransaction != null)
                {
                    existingTransaction.Account = transactionModel.account;
                    existingTransaction.ClosingAvailableBalance = transactionModel.closingAvailableBalance;
                    existingTransaction.ClosingBalance = transactionModel.closingBalance;
                    existingTransaction.Description = transactionModel.description;
                    existingTransaction.ForwardAvailableBalance = transactionModel.forwardAvailableBalance;
                    existingTransaction.OpeningBalance = transactionModel.openingBalance;
                    existingTransaction.RelatedMessage = transactionModel.relatedMessage;
                    existingTransaction.SequenceNumber = transactionModel.sequenceNumber;
                    existingTransaction.StatementNumber = transactionModel.statementNumber;
                    existingTransaction.TransactionReference = transactionModel.transactionReference;
                    existingTransaction.TransactionType = transactionModel.transactionType;
                    existingTransaction.TransactionDate = transactionModel.transactionDate;

                    _dbContext.SaveChanges();

                    return Ok("Transaction updated successfully.");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }



        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public IActionResult Delete(string Id)
        {
            Entities.Transactions transaction = new Entities.Transactions()
            {
                Id = Id,
            };
            _dbContext.Transactions.Attach(transaction);
            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChangesAsync();
            return StatusCode(201, "Transaction deleted successfully.");
        }
    }
}
