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
    public class CategoriesModel : PageModel
    {
        private readonly BookTrackingWebContext _context;
        public SelectList CategorySL { get; set; }
        public SelectList CategoryTypiesQuerySL { get; set; }


        [BindProperty]
        public Category category { get; set; }
        public IList<Category> Categories { get; set; } = new List<Category>();
        public IList<CategoryType> CategoryTypies { get; set; } = new List<CategoryType>();
        public CategoriesModel(BookTrackingWebContext context)
        {
            _context = context;
            PopulateCategoriesDropDownList(_context);
        }

        public void PopulateCategoriesDropDownList(BookTrackingWebContext _context,
           object selectedCategory = null)
        {
            var CategoryTypiesQuery = _context.CategoryTypies.ToList();

            CategoryTypiesQuerySL = new SelectList(CategoryTypiesQuery,
                        "CategoryTypeId", "CategoryTypeName", selectedCategory);

        }
        public async Task OnGetAsync(int id, string action)
        {
            Categories = await _context.Categories
                .Include(ct => ct.CategoryType)
                 .AsNoTracking()
               .ToListAsync();
            if (action == "Edit")
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

            Category updatedCategory = _context.Categories.SingleOrDefault(b => b.CategoryId == id);

            if (updatedCategory != null)
            {
                _context.Categories.Remove(updatedCategory);
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
            category = await _context.Categories.FirstOrDefaultAsync(b => b.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (category.CategoryId != 0)
            {

                Category updatedCategory = _context.Categories.FirstOrDefault(b => b.CategoryId == category.CategoryId);
                if (updatedCategory != null)
                {
                    /* updatedCategory.CategoryTypeNum = categoryType.CategoryTypeNum;
                     updatedCategory.Description = categoryType.Description;
                     updatedCategory.CategoryTypeCode = categoryType.CategoryTypeCode;*/
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryExists(category.CategoryId))
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
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        private bool categoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

    }
}
