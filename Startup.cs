using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlzrQuiz.Areas.Identity;
using BlzrQuiz.ServiceLayer;
using BlzrQuiz.Data;
using Blazored.Modal;
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
            Debug.WriteLine("");
            Debug.Write("()-------------------------> ");
            Debug.WriteLine(Configuration.GetValue<string>("DefaultConnection"));
            Debug.WriteLine("");
            var minPasswordLength = Configuration.GetValue<int>("PasswordLength");
            services.AddDbContext<BlzrQuizContext>(options =>
                  options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                      mySqlOptions =>
                      {
                          mySqlOptions.EnableRetryOnFailure();
                      }
                  ).EnableDetailedErrors()
              );
            services.AddDefaultIdentity<IdentityUser>(
                                o =>
                                {
                                    o.Password.RequireDigit = false;
                                    o.Password.RequireLowercase = false;
                                    o.Password.RequireUppercase = false;
                                    o.Password.RequiredLength = minPasswordLength;
                                    o.Password.RequireNonAlphanumeric = false;
                                    // User settings.
                                    o.User.AllowedUserNameCharacters =
                                               "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                                    o.SignIn.RequireConfirmedAccount = true;
                                })
                               .AddRoles<IdentityRole>()
                               .AddEntityFrameworkStores<BlzrQuizContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<QuizService>();
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddBlazoredModal();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            ConfigureDB(app);
            app.UseAuthentication();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
        private void ConfigureDB(IApplicationBuilder app)
        {
           
            var rebuild = Configuration.GetValue<bool>("rebuild");
            if (rebuild)
            {
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                using var context = serviceScope.ServiceProvider.GetRequiredService<BlzrQuizContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                if (context.QuizQuestions.Count() == 0)
                {
                    var q = new QuizService(context);
                    _ = q.CreateQuiz();
                    _ = q.CreateMultipleSelectionQuiz();
                }
            }
        }
    }
}
