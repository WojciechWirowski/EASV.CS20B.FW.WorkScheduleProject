using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Database;
using EASV.CS20B.FW.WorkScheduleProject.Database.Repositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using EASV.CS20B.FW.WorkScheduleProject.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.Security.Authorization;
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
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EASV.CS20B.FW.WorkScheduleProject.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            
            Byte[] secretBytes = new byte[40];
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            using (var rngCsp = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(secretBytes);
            }
            //Add JWT authentication
            //The settings below match the settings when we create our TOKEN:
            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("UserPolicy",
                    policy => { policy.Requirements.Add(new ResourceOwnerRequirement()); });
            });
            
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            
            // adding DB info
            services.AddDbContext<ScheduleApplicationContext>(
                opt => opt.UseLoggerFactory(loggerFactory)
                    .UseSqlite("Data source = ScheduleProject.db"));

            // setting up the Dependency Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkingScheduleRepository, WorkingScheduleRepository>();
            services.AddScoped<IWorkingScheduleService, WorkingScheduleService>();
            services.AddScoped<IWorkingRecordRepository, RecordsRepository>();
            services.AddScoped<IWorkingRecordService, WorkingRecordService>();
            
            services.AddScoped<UserAuthConfig>();
            
            services.AddTransient<IAuthorizableOwnerIdentity, UserResourceOwnerAuthorizationService>();
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
                
                opt.AddPolicy("Pro-Cors", policy =>
                {
                    policy
                        .WithOrigins(
                            "https://workscheduleprojecteasvcs20b.firebaseapp.com",
                            "https://workscheduleprojecteasvcs20b.web.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
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
                app.UseCors("Pro-Cors");
                // when we out of develop mode then create a new DB
                new DbSeeder(context).SeedProduction();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
