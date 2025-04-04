using Hotels.Application.Interafces;
using Hotels.Application.Services;
using Hotels.Infrastructure.Persistent;
using Hotels.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("hotelsDb"));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            return services;
        }

    }
}
