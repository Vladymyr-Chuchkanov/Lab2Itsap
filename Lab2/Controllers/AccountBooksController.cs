using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBooksController : ControllerBase
    {
        private readonly DBLab2Context _context;

        public AccountBooksController(DBLab2Context context)
        {
            _context = context;
        }

        // GET: api/AccountBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountBook>>> GetAccountBooks()
        {
            return await _context.AccountBooks.ToListAsync();
        }

        // GET: api/AccountBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountBook>> GetAccountBook(int id)
        {
            var accountBook = await _context.AccountBooks.FindAsync(id);

            if (accountBook == null)
            {
                return NotFound();
            }

            return accountBook;
        }

        // PUT: api/AccountBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountBook(int id, AccountBook accountBook)
        {
            if (id != accountBook.Id)
            {
                return BadRequest();
            }
            var temp = _context.Books.FirstOrDefault(a => a.Id == accountBook.BookId);
            var temp2 = _context.AccountBooks.Include(a=>a.Rating).FirstOrDefault(a => a.Id == id);
            temp.RatingSum -= temp2.Rating.mark;
            await _context.SaveChangesAsync();
            _context.Entry(accountBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AccountBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountBook>> PostAccountBook(AccountBook accountBook)
        {
            _context.AccountBooks.Add(accountBook);
            await _context.SaveChangesAsync();
            var temp = _context.Books.FirstOrDefault(a => a.Id == accountBook.BookId);
            temp.RatingSum += accountBook.Rating.mark;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAccountBook", new { id = accountBook.Id }, accountBook);
        }

        // DELETE: api/AccountBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountBook(int id)
        {
            var accountBook = await _context.AccountBooks.FindAsync(id);
            if (accountBook == null)
            {
                return NotFound();
            }

            _context.AccountBooks.Remove(accountBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountBookExists(int id)
        {
            return _context.AccountBooks.Any(e => e.Id == id);
        }
    }
}
