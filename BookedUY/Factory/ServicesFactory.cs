using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SessionInterface;
using System;
using System.ComponentModel.Design;
using System.Text;

namespace Factory
{
    public class ServicesFactory
    {
        public static void AddMyServices(IServiceCollection services)
        {

            services.AddScoped<IRepository<Booking>, BookingRepository>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IBookingStageRepository, BookingStageRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Region>, RegionRepository>();
            services.AddScoped<ITouristRepository, TouristRepository>();
            services.AddScoped<ITouristicSpotRepository, TouristicSpotRepository>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IBookingLogic, BookingLogic>();
            services.AddScoped<IAdministratorLogic, AdministratorLogic>();
            services.AddScoped<IAccommodationLogic, AccommodationLogic>();
            services.AddScoped<IRegionLogic, RegionLogic>();
            services.AddScoped<ITouristicSpotLogic, TouristicSpotLogic>();
            services.AddScoped<ISessionLogic, SessionLogic>();
        }

        public static void AddAuthentication(IServiceCollection services, string v)
        {
            
        }

        public static void AddDbContextServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, BookedUYContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
