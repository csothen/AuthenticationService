using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using auth_server.Repositories;
using auth_server.Services;
using auth_server.Repositories.OrganizationContext;
using auth_server.Repositories.CountryContext;
using auth_server.Repositories.UserTemplateContext;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace auth_server
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
            // Setup Database
            services.AddDbContext<Context>(options =>
            options.UseSqlServer(Configuration["ConnectionString"]));

            // Others
            services.AddCors(options =>
            {
                options.AddPolicy("ServerPolicy", builder =>
                 {
                     builder.AllowAnyHeader().AllowAnyMethod().WithOrigins(Configuration["FrontendOrigin"]);

                 });
            });
            services.AddMvc();

            // JWT Authentication
            var key = Encoding.ASCII.GetBytes(Configuration["JWTSecret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            // Services
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IUserTemplateService, UserTemplateService>();

            // Repositories
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IUserTemplateRepository, UserTemplateRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context ctx, ICountryService countries)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseCors("ServerPolicy");

            app.UseAuthentication();
            app.UseAuthorization();


            //ctx.Database.EnsureDeleted();
            countries.Setup();

            // RUN "dotnet ef migrations add NAME_OF_ACTION" to update DB
            ctx.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
