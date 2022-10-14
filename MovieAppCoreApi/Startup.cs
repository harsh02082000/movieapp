using BookMyShowBussiness.services;
using BookMyShowData.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookMyShowData.MovieDAL;

namespace MovieAppCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStr = Configuration.GetConnectionString("sqlconnection");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddTransient<MovieService,MovieService>();
            services.AddTransient<IMovieRepository,MovieRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie API",
                    Description = "Movie Management System API",
                });
            });
            services.AddTransient<TheatreService, TheatreService>();
            services.AddTransient<ITheatreRepository, TheatreRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Theatre API",
                    Description = "Theatre Management System API",
                });
            });
            services.AddTransient<ShowTimingService, ShowTimingService>();
            services.AddTransient<IShowTimingRepository, ShowTimingRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "ShowTiming API",
                    Description = "ShowTiming Management System API",
                });
            });
            services.AddTransient<UserService,UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v4", new OpenApiInfo
                {
                    Version = "v4",
                    Title = "User API",
                    Description = "User Management System API",
                });
            });
            services.AddTransient<LocationService, LocationService>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v5", new OpenApiInfo
                {
                    Version = "v5",
                    Title = "Location API",
                    Description = "Location Management System API",
                });
            });
            services.AddTransient<BookingService, BookingService>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v6", new OpenApiInfo
                {
                    Version = "v6",
                    Title = "Booking API",
                    Description = "Booking Management System API",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
