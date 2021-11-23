using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using SmartLock.Context;
using Microsoft.EntityFrameworkCore;
using SmartLock.Services.Users;
using SmartLock.Handler.Users;
using SmartLock.Services.Locks;
using SmartLock.Handler.Locks;

namespace SmartLock
{
    public class Startup
    {
        public string ConnectionString {get; set;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("Mssql");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(20);
                options.Cookie.Name = "SmartLock.Session";
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<DatabaseContext>(options => 
                options.UseSqlServer(ConnectionString));
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(x => x.First());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartLock", Version = "v1" });
            });
            
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<ILogoutHandler, LogoutHandler>();
            services.AddScoped<ISignupHandler, SignupHandler>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILockAddAccessHandler, LockAddAccessHandler>();
            services.AddScoped<ILockDetailsHandler, LockDetailsHandler>();
            services.AddScoped<ILockRemoveAccessHandler, LockRemoveAccessHandler>();
            services.AddScoped<INewLockHandler, NewLockHandler>();
            services.AddScoped<IUpdateLockStateHandler, UpdateLockStateHandler>();
            services.AddScoped<IUserLocksHandler, UserLocksHandler>();
            services.AddScoped<ILockService, LockService>();
            services.AddScoped<ISessionContext, SessionContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartLock v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
