using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.DAL;
using TaskManager.Filters;
using TaskManager.Service;

namespace TaskManager.Controllers
{
    public class QuoteController : ApiController
    {
        private IQuoteService quoteService = new QuoteService();

        [CacheFilter(TimeDuration = 10)]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(quoteService.getQuotes());
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(Quote q)
        {
            if(!quoteService.Add(q))
            {
                return BadRequest("Bad Request. Creation requires at least a body containing the string values for QuoteType, Contact, and Task.");
            }
            return Ok("New Task created");
        }

        [CacheFilter(TimeDuration = 10)]
        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            Quote q = quoteService.Find(Id);
            if (q == null)
            {
                return NotFound();
            }
            return Ok(q);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Update(Quote q)
        {
            if(!quoteService.Update(q))
            {
                return Ok("Nothing updated, no Task with the ID found");
            }
            return Ok("Task " + q.Id + " updated");
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateRecord(int Id, [FromBody] Quote q)
        {
            if(q == null)
            {
                return Ok("Nothing updated, empty body");
            }
            q.Id = Id;
            if (!quoteService.Update(q))
            {
                return Ok("Nothing updated, no Task with the ID found");
            }
            return Ok("Task " + q.Id + " updated");
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            quoteService.Delete(Id);
            return Ok("Task " + Id + " is deleted, or was never here");
        }
    }
}