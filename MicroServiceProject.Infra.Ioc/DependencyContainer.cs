using MicroServiceProject.BookingFlight.Application.Interfaces;
using MicroServiceProject.BookingFlight.Data.Context;
using MicroServiceProject.BookingFlight.Data.Repositorry;
using MicroServiceProject.BookingFlight.Domain.Interfaces;
using MicroServiceProject.Domain.Core.Bus;
using MicroServiceProject.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain bus 
            services.AddTransient<IEventBus, RabitMQBus>();


            // Application services

            services.AddTransient<IFeedBackService, IFeedBackService>();


            //Data

            services.AddTransient<IFeedBackRepository, FeedBackRepository>();
            services.AddTransient<BookingFlightDBContext>();

        }
    }
}
