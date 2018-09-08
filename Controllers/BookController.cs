using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnc_bookservice.Models;

namespace dnc_bookservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        
        public BookController(BookContext context)
        {
            _context = context;

            if (_context.Books.Count() == 0)
            {
                // if there are no items then add one so we always start with data as we are using an in memory database
                _context.Books.Add(new Book { Title = "Goodbye Emily", Author = "Michael Murphy", Genre = "Historical Fiction" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> GetById(long id)
        {
            var item = _context.Books.Find(id);
            if (item == null) 
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
