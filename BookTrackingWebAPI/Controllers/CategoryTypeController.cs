using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class CategoryTypeController : Controller
    {
        private readonly ILogger<CategoryTypeController> _logger;

        private readonly BookTrackingWebContext _db;


        public CategoryTypeController(ILogger<CategoryTypeController> logger, BookTrackingWebContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost("category-type")]
        public ActionResult saveCategoryType([FromBody] CategoryType categoryType)
        {
            if (categoryType.CategoryTypeName != null)
            {
                _db.Add(categoryType);
                _db.SaveChangesAsync();
                return Ok(categoryType);
            }
            else
            {
                return BadRequest("Invalid input data in the request");
            }


        }

        [HttpGet("category-types")]
        public ActionResult fetchCategoryTypes()
        {
            List<CategoryType> categoryTypes = new List<CategoryType>();

            categoryTypes = _db.CategoryTypies.ToList();

            return Ok(categoryTypes);
        }

        [HttpGet("category-type")]
        public ActionResult fetchCategoryType(int id)
        {
            try
            {
                CategoryType categoryType = _db.CategoryTypies.Single(categoryType => categoryType.CategoryTypeId == id);

                return Ok(categoryType);

            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the requested category type");
            }

        }

        [HttpDelete("category-type")]
        public ActionResult deleteCategoryType(int id)
        {

            try
            {
                CategoryType categoryType = _db.CategoryTypies.Single(categoryType => categoryType.CategoryTypeId == id);

                _db.Remove(categoryType);
                _db.SaveChangesAsync();
                return Ok("Deleted successfully");

            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the category type to delete");
            }

        }


        [HttpPut("category-type")]
        public ActionResult updateCategoryType([FromBody] CategoryType update)
        {
            try
            {
                CategoryType existing = _db.CategoryTypies.Single(a => a.CategoryTypeId == update.CategoryTypeId);

                existing.CategoryTypeName = update.CategoryTypeName;

                _db.Update(existing);
                _db.SaveChangesAsync();
                return Ok(existing);

            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the category type to update");
            }

        }

    }
}