using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private PaymentsDbContext _quotesDbContext;

        public PaymentsController(PaymentsDbContext quotesDbContext)
        {
            this._quotesDbContext = quotesDbContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IActionResult Get()
        {
            //return StatusCode(StatusCodes.Status200OK);
            var result = _quotesDbContext.Payments;
            if (result == null)
                return NotFound($"Not records found for this transaction");

            return Ok(result);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quotes = _quotesDbContext.Payments.Find(id);
            if (quotes == null)
                return NotFound($"Not records found with this id: {id}");

            return Ok(quotes);
        }

        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            _quotesDbContext.Payments.Add(payment);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Payment payment)
        {
            var entity = _quotesDbContext.Payments.Find(id);
            if (entity == null)
                return NotFound($"No record found against this id: {id}");

            entity.Date = payment.Date;
            entity.Description = payment.Description;
            entity.Amount = payment.Amount;
            entity.Type = payment.Type;
            entity.CreatedAt = payment.CreatedAt;

            _quotesDbContext.SaveChanges();
            return Ok("Record updated succesfully...");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _quotesDbContext.Payments.Find(id);
            if (entity == null)
                return NotFound($"Not record found against this id: {id}");

            _quotesDbContext.Remove(entity);
            _quotesDbContext.SaveChanges();
            return Ok("Payment deleted");
        }
    }
}
