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
using Microsoft.AspNetCore.Http.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookTrackingWeb.Pages
{
    public class BooksModel : PageModel
    {
        private readonly BookTrackingWebContext _context;

        public BooksModel(BookTrackingWebContext context)
        {
            _context = context;
            PopulateDepartmentsDropDownList(_context);
        }

        public IList<Book> Books { get; set; }
        [BindProperty]
        public Book book { get; set; }


        public SelectList CategoryTypiesSL { get; set; }

        public void PopulateDepartmentsDropDownList(BookTrackingWebContext _context,
            object selectedCategoryTypies = null)
        {

            var categoriesQuery = from ct in _context.Categories
                                  orderby ct.CategoryName // Sort by name.
                                  select ct;

            CategoryTypiesSL = new SelectList(categoriesQuery.AsNoTracking(),
                        "CategoryId", "CategoryName", selectedCategoryTypies);
        }

        public List<Book> GetBooksList()
        {
            List<Book> BooksList = _context.Books
                   .Include(b => b.Category)
                       .ThenInclude(c => c.CategoryType)
                   .ToList();

            return BooksList;
        }
        public async Task OnGetAsync(int id, string action)
        {
            Books = await _context.Books
                     .Include(b => b.Category)
                         .ThenInclude(c => c.CategoryType)
                     .AsNoTracking()
                     .ToListAsync();

            if (action == "Edit" || action == "Status")
            {
                await OnGetEditAsync(id);
            }
            if (action == "Delete")
            {
                await OnGetDeleteAsync(id);
            }


        }
        public async Task<IActionResult> OnPostAsync(Book book, string action)
        {
            if (book.BookId != 0)
            {
                Book existingBook = _context.Books.Single(b => b.BookId == book.BookId);
                if (existingBook != null)
                {

                    if (action.Equals("Status"))
                    {
                        existingBook.BookStatus = book.BookStatus;
                    }
                    if (action.Equals("Edit"))
                    {
                        existingBook.BookAuthor = book.BookAuthor;
                        existingBook.BookAddedDate = book.BookAddedDate;
                        existingBook.BookStatus = book.BookStatus;
                        existingBook.BookTitle = book.BookTitle;


                    }
                }
                else
                {
                    return NotFound();
                }

                try
                {
                    _context.Update(existingBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Books");
        }

        /*
       @method: Delete item from list 

       */

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            if (id == null)
            {
                return Page();
            }

            Book updatedBook = _context.Books.SingleOrDefault(b => b.BookId == id);

            if (updatedBook != null)
            {
                _context.Books.Remove(updatedBook);
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
                return Page();
            }

            book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }
            return Page();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

    }
}

