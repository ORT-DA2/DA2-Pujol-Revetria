using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;

namespace Factory
{
    public class ServicesFactory
    {
        public static void AddMyServices(IServiceCollection services)
        {
            services.AddScoped<IBookingLogic, BookingLogic>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IBookingStageRepository, BookingStageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITouristicSpotRepository, TouristicSpotRepository>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
        }

        public static void AddDbContextServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, BookedUYContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
