using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookingFeedBack.MVC.Models.DTO;
using Newtonsoft.Json;

namespace BookingFeedBack.MVC.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly HttpClient _apiClient;

        public FeedBackService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task FeebBack(FeedBackDTO feedBackDTO)
        {
            var uri = "https://localhost:5001/api/BookingFlight";
            var transferContent = new StringContent(JsonConvert.SerializeObject(feedBackDTO),
                                       System.Text.Encoding.UTF8, "application/Json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
