using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingFeedBack.MVC.Models;
using BookingFeedBack.MVC.Services;
using BookingFeedBack.MVC.Models.DTO;

namespace BookingFeedBack.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedBackService _feedBackService;

        public HomeController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> FeedBack(FeedBackView model)
        {
            FeedBackDTO feedBackDTO = new FeedBackDTO();
            {
                feedBackDTO.FirstName = model.FirstName;
                feedBackDTO.LastName = model.LastName;
                feedBackDTO.Email = model.Email;
                feedBackDTO.Description = model.Description;
            };

            await _feedBackService.FeebBack(feedBackDTO);
            return View("Index");
            
        }
    }
}
