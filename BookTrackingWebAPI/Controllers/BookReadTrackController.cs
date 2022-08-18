using System;
using BookTrackingWebData.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class BookReadTrackController: Controller
    {
        private readonly ILogger<BookReadTrackController> _logger;

        private readonly BookTrackingWebContext _db;


        public BookReadTrackController(ILogger<BookReadTrackController> logger, BookTrackingWebContext db)
        {
            _logger = (ILogger<BookReadTrackController>)logger;
            _db = db;
        }
    }
}
