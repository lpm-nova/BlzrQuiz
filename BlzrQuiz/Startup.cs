using BlzrQuiz.Data;
using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlzrAuth.Areas.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using BlzrQuiz.Core;
using System.Diagnostics;

namespace BlzrQuiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //services.AddDbContext<BlzrQuizContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<BlzrQuizContext>(options => options.UseSqlServer(Configuration.GetConnectionString($"{Environment.MachineName}Sql")));
            services.AddDefaultIdentity<IdentityUser>(
             o =>
             {
                 o.Password.RequireDigit = false;
                 o.Password.RequireLowercase = false;
                 o.Password.RequireUppercase = false;
                 o.Password.RequiredLength = 20;
                 o.Password.RequireNonAlphanumeric = false;
             })
             .AddEntityFrameworkStores<BlzrQuizContext>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<QuizService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<BlzrQuizContext>())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                    if(context.QuizQuestions.Count() == 0)
                    {
                        var q = new QuizService(context);
                        q.CreateQuiz();
                    }
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub<App>(selector: "app");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
