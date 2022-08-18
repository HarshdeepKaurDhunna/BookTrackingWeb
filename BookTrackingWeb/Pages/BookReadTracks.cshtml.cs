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

namespace BookTrackingWeb.Pages
{
    public class BookReadTracksModel : PageModel
    {
        private readonly BookTrackingWebData.Data.BookTrackingWebContext _context;
        [BindProperty]
        public BookReadTrack bookReadTrack { get; set; }

        public IList<BookReadTrack> BookTrackList { get; set; }
        public BookReadTracksModel(BookTrackingWebData.Data.BookTrackingWebContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id, string action)
        {
            BookTrackList = await _context.BookReadTracks
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

            BookReadTrack updatedBookTracks = _context.BookReadTracks.SingleOrDefault(b => b.BookReadTrackId == id);

            if (updatedBookTracks != null)
            {
                _context.BookReadTracks.Remove(updatedBookTracks);
                await _context.SaveChangesAsync();
            }
            return Page();
        }

        /*
         @method: get the item from list and bind the global bind object
           
         */
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bookReadTrack = await _context.BookReadTracks.FirstOrDefaultAsync(b => b.BookReadTrackId == id);

            if (bookReadTrack == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(BookReadTrack bookReadTrack)
        {

            if (bookReadTrack.BookReadTrackId != 0)
            {
                BookReadTrack existingbookTrack = _context.BookReadTracks.Single(b => b.BookReadTrackId == bookReadTrack.BookReadTrackId);
                if (existingbookTrack != null)
                {
                    existingbookTrack.BookReadDate = bookReadTrack.BookReadDate;
                    existingbookTrack.BookTotalPagesRead = bookReadTrack.BookTotalPagesRead;
                    existingbookTrack.BookFromPage = bookReadTrack.BookFromPage;
                    existingbookTrack.BookToPage = bookReadTrack.BookToPage;
                    existingbookTrack.BookId = bookReadTrack.BookId;

                }
                else
                {
                    return NotFound();
                }

                try
                {
                    _context.Update(existingbookTrack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTrackExists(bookReadTrack.BookReadTrackId))
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

                _context.BookReadTracks.Add(bookReadTrack);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/BookReadTracks");
        }
        private bool BookTrackExists(int id)
        {
            return _context.BookReadTracks.Any(e => e.BookReadTrackId == id);
        }
    }
}
