using System;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Models;

namespace API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public TransactionController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        
        [HttpGet]
        public async Task<List<Transaction>> Get() 
        {
            return await _mongoDBService.GetAsync();        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            await _mongoDBService.CreateAsync(transaction);
            return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
        }
    }
}