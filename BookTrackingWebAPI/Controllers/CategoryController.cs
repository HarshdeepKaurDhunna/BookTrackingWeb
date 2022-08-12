using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly BookTrackingWebContext _db;


        public CategoryController(ILogger<CategoryController> logger, BookTrackingWebContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost("category")]
        public ActionResult saveCategory([FromBody] Category category)
        {
            try
            {
                if (category.CategoryName != null && category.CategoryName != "" && category.CategoryTypeId != 0)
                {
                    CategoryType categoryType = _db.CategoryTypies.Single(categoryType => categoryType.CategoryTypeId == category.CategoryTypeId);
                    _db.Add(category);
                    _db.SaveChangesAsync();
                    return Ok(category);
                }
                else
                {
                    return BadRequest("Invalid input data in the request");
                }
            }
            catch
            {
                return BadRequest("Invalid input data in the request");
            }
        }

        [HttpGet("categories")]
        public ActionResult fetchCategories()
        {
            List<Category> Categories = new List<Category>();

            Categories = _db.Categories.ToList();

            return Ok(Categories);
        }

        [HttpGet("category")]
        public ActionResult fetchCategory(int id)
        {
            try
            {
                Category category = _db.Categories.Single(category => category.CategoryId == id);
                return Ok(category);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Could not find the requested category");
            }
        }

        [HttpDelete("category")]
        public ActionResult deleteCategory(int id)
        {
            try
            {
                Category category = _db.Categories.Single(category => category.CategoryId == id);

                if (category != null)
                {
                    _db.Remove(category);
                    _db.SaveChangesAsync();
                }
                return Ok("Deleted successfully");
            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the category to delete");
            }

        }


        [HttpPut("category")]
        public ActionResult updateCategory([FromBody] Category update)
        {
            try
            {
                Category existing = _db.Categories.Single(a => a.CategoryId == update.CategoryId);

                if (existing != null)
                {
                    existing.CategoryName = update.CategoryName;
                    existing.CategoryTypeId = update.CategoryTypeId;
                    _db.Update(existing);
                    _db.SaveChangesAsync();
                }
                return Ok(existing);
            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the category to update");
            }
        }

    }
}
