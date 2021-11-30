using System;
using EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authorization;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Database;
using EASV.CS20B.FW.WorkScheduleProject.Database.Repositories;
using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authorization;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }
        private IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            using (var rngCsp = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(secretBytes);
            }

            services.AddHttpClient();
            
            //Add JWT authentication
            //The settings below match the settings when we create our TOKEN:
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    //ValidAudience = "CoMetaApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "CoMetaApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            
            // adding DB info
            services.AddDbContext<ScheduleApplicationContext>(
                opt => opt.UseLoggerFactory(loggerFactory)
                    .UseSqlite("Data source = ScheduleProject.db"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EASV.CS20B.FW.WorkScheduleProject.WebApi", Version = "v1" });
            });
            // setting up the Dependency Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<UserAuthConfig>();
            
            services.AddTransient<IAuthorizableOwnerIdentity, UserResourceOwnerAuthorizationService>();
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("UserPolicy",
                    policy => { policy.Requirements.Add(new ResourceOwnerRequirement()); });
            });
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddTransient<IUserAuthenticator, UserAuthenticator>();
            
            services.AddCors(opt =>
            {
                opt.AddPolicy("UserPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ScheduleApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EASV.CS20B.FW.WorkScheduleProject.WebApi v1"));
            

            app.UseCors("UserPolicy");
            var dbSeeder = new DbSeeder(context);
            dbSeeder.SeedDevelopment();
            }
            else
            {
                app.UseCors("Prod.cors");
                // when we out of develop mode then create a new DB
                new DbSeeder(context).SeedProduction();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
