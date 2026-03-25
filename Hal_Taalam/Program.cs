using Hal_Taalam.Models.DBcontext;
using Hal_Taalam.Repository;
using Hal_Taalam.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hal_Taalam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
            {
                options.Password.RequiredUniqueChars =0;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<HalTaalamContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IQusetionRepository, QuestionRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(Options=>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(30);
                Options.Cookie.IsEssential = true;
                Options.Cookie.HttpOnly = true;
            
            });

            builder.Services.AddDbContext<HalTaalamContext>(Options =>

               Options.UseSqlServer(builder.Configuration.GetConnectionString("HalTaalamDB"))

           );



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseSession();
             

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=GameMenu}/{action=StartPage}/{id?}");

            app.Run();
        }
    }
}
