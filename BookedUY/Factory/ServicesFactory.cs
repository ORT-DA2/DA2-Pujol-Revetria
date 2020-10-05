using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
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
            services.AddScoped<IAdministratorLogic, AdministratorLogic>();
            services.AddScoped<IAccommodationLogic, AccommodationLogic>();
            services.AddScoped<IRegionLogic, RegionLogic>();
            services.AddScoped<ITouristicSpotLogic, TouristicSpotLogic>();
            services.AddScoped<IRepository<Booking>, BookingRepository>();
            services.AddScoped<IRepository<Accommodation>, AccommodationRepository>();
            services.AddScoped<IRepository<BookingStage>, BookingStageRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Region>, RegionRepository>();
            services.AddScoped<IRepository<Tourist>, TouristRepository>();
            services.AddScoped<IRepository<TouristicSpot>, TouristicSpotRepository>();
            services.AddScoped<IRepository<Administrator>, AdministratorRepository>();
        }

        public static void AddDbContextServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, BookedUYContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
