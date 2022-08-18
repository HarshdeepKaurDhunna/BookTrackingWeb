using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class BookQuoteController
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
