using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhantasiaEngine.Auth.Contexts;
using PhantasiaEngine.Auth.Filters;
using PhantasiaEngine.Auth.Repositories;
using PhantasiaEngine.Auth.Services;
using PhantasiaEngine.Auth.Validators;

namespace PhantasiaEngine.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            
            // Add Singleton Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Add Singleton Services
            services.AddScoped<IUserService, UserService>();
            
            services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(configuration => 
                    configuration.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            services.AddDbContext<AuthContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}