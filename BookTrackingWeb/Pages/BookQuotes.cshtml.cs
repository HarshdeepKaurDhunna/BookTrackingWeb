using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookTrackingWeb.Pages
{
    public class BookQuotesModel : PageModel
    {
        private readonly BookTrackingWebData.Data.BookTrackingWebContext _context;

        public BookQuotesModel(BookTrackingWebData.Data.BookTrackingWebContext context)
        {
            _context = context;
        }



        [BindProperty]
        public BookQuote bookQuote { get; set; }
        public IList<BookQuote> BookQuoteList { get; set; }

        public async Task OnGetAsync(int id, string action)
        {
            BookQuoteList = await _context.BookQuotes
                     .Include(b => b.Book)
                         .AsNoTracking()
                     .ToListAsync();
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookTitle");

            if (action == "Edit" || action == "Status")
            {
                await OnGetEditAsync(id);
            }
            if (action == "Delete")
            {
                await OnGetDeleteAsync(id);
            }


        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookQuote updatedBookQuote = _context.BookQuotes.SingleOrDefault(b => b.BookQuoteId == id);

            if (updatedBookQuote != null)
            {
                _context.BookQuotes.Remove(updatedBookQuote);
                await _context.SaveChangesAsync();
            }
            return Page();
        }

        /*
         @method: get the item from list and binding the global bind object
           
         */
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bookQuote = await _context.BookQuotes.FirstOrDefaultAsync(b => b.BookQuoteId == id);

            if (bookQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(BookQuote bookQuote, string action)
        {

            if (bookQuote.BookQuoteId != 0)
            {
                BookQuote existingbookQuote = _context.BookQuotes.Single(b => b.BookQuoteId == bookQuote.BookQuoteId);
                if (existingbookQuote != null)
                {
                    existingbookQuote.BookQuoteDescription = bookQuote.BookQuoteDescription;
                    existingbookQuote.BookPageNumber = bookQuote.BookPageNumber;
                    existingbookQuote.BookId = bookQuote.BookId;

                }
                else
                {
                    return NotFound();
                }

                try
                {
                    _context.Update(existingbookQuote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookQuoteExists(bookQuote.BookQuoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                _context.BookQuotes.Add(bookQuote);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/BookQuotes");
        }

        private bool BookQuoteExists(int id)
        {
            return _context.BookQuotes.Any(e => e.BookQuoteId == id);
        }
    }
}
