using System;
namespace BookTrackingWebAPI.Controllers
{
    public class BookReadTrackController
    {
        private readonly ILogger<BookQuoteController> _logger;

        private readonly BookTrackingWebContext _db;


        public BookQuoteController(ILogger<CategoryController> logger, BookTrackingWebContext db)
        {
            _logger = (ILogger<BookQuoteController>)logger;
            _db = db;
        }
    }
}
