using BookingFeedBack.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingFeedBack.MVC.Services
{
   public interface IFeedBackService
    {
        Task FeebBack(FeedBackDTO feedBackDTO);
    }
}
