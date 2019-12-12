using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServiceProject.BookingFlight.Application.Interfaces;
using MicroServiceProject.BookingFlight.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceProject.BookingFlight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService _feedbackService;

       
            public FeedBackController(IFeedBackService feedbackService)
            {
            _feedbackService = feedbackService;
            }
        // GET api/BookingFlight
        [HttpGet]
        public ActionResult<IEnumerable<FeedBack>> Get()
        {
            return Ok(_feedbackService.GetFeedbacks());
        }

       
    }
}
