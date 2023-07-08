using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using project6._1Api.Entities;
using project6._1Api.Model;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;
using System.Net;


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
            IEnumerable<TransactionModel> transactions = _dbContext.Transactions
                .Select(t => new TransactionModel
                {
                    Id = t.id,
                    Account = t.account,
                    ClosingAvailableBalance = t.closingAvailableBalance,
                    ClosingBalance = t.closingBalance,
                    Description = t.description,
                    ForwardAvailableBalance = t.forwardAvailableBalance,
                    OpeningBalance = t.openingBalance,
                    RelatedMessage = t.relatedMessage,
                    SequenceNumber = t.sequenceNumber,
                    StatementNumber = t.statementNumber,
                    TransactionReference = t.transactionReference,
                    TransactionType = t.transactionType,
                    TransactionDate = t.transactionDate,
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
            string[] xmlContent = sqlitedb.GetTransactionXml();
            if (xmlContent.Length > 0)
            {
                return Content(xmlContent[0], "application/xml");
            }
            else
            {
                return NotFound();
            }
        }
    
        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] TransactionModel transactionModel)
        {
            Transaction newTransaction = new Transaction()
            {
                id = transactionModel.Id,
                account = transactionModel.Account,
                closingAvailableBalance = transactionModel.ClosingAvailableBalance,
                closingBalance = transactionModel.ClosingBalance,
                description = transactionModel.Description,
                forwardAvailableBalance = transactionModel.ForwardAvailableBalance,
                openingBalance = transactionModel.OpeningBalance,
                relatedMessage = transactionModel.RelatedMessage,
                sequenceNumber = transactionModel.SequenceNumber,
                statementNumber = transactionModel.StatementNumber,
                transactionReference = transactionModel.TransactionReference,
                transactionType = transactionModel.TransactionType,
                transactionDate = transactionModel.TransactionDate
            };
            int comparator = string.Compare(transactionModel.Id, sqlitedb.GetTransactionCount());
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

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public IActionResult Delete(string Id)
        {
            Transaction transaction = new Transaction()
            {
                id = Id,
            };
            _dbContext.Transactions.Attach(transaction);
            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChangesAsync();
            return StatusCode(201, "Transaction deleted successfully.");
        }
    }
}
