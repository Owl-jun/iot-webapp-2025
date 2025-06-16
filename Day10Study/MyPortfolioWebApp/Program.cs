using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;
using System.Runtime;

namespace MyPortfolioWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ÃÖ´ëÆÄÀÏ ¿ë·® Á¦ÇÑ
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 200 * 1024 * 1024;
            });

            builder.WebHost.ConfigureKestrel(options =>
            {
                // 1024(MB) , 1024(KB)
                options.Limits.MaxRequestBodySize = 200 * 1024 * 1024;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Program.cs
            // DB¿¬°á ÃÊ±âÈ­ ¼³Á¤
=======
            // DBì—°ê²° ì´ˆê¸°í™” ì„¤ì •
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("SmartHomeConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SmartHomeConnection"))
            ));

            // ASP.NET Core Identity ¼³Á¤
            // ¿øº»Àº IdentityUser -> CustomUser ·Î º¯°æ
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Program.cs
            // ÆĞ½º¿öµå Á¤Ã¥
            // º¯°æ Àü. ÃÖ´ë 6ÀÚ¸® ÀÌ»ó, Æ¯¼ö¹®ÀÚ 1°³ Æ÷ÇÔ, ¿µ¾î´ë¼Ò¹®ÀÚ Æ÷ÇÔ
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // ÀÌ·± ¾ÏÈ£ °£´ÜÈ­´Â µÇµµ·Ï ÇÏÁö¸» °Í
                options.Password.RequiredLength = 4; // ÃÖ¼Ò±æÀÌ 4ÀÚ¸®
                options.Password.RequireNonAlphanumeric = false; // Æ¯¼ö¹®ÀÚ »ç¿ë¾ÈÇÔ
                options.Password.RequireUppercase = false; // ´ë¹®ÀÚ »ç¿ë¾ÈÇÔ
                options.Password.RequireLowercase = false; // ¼Ò¹®ÀÚ »ç¿ë¾ÈÇÔ
                options.Password.RequireDigit = false; // ¼ıÀÚÇÊ¼ö ¿©ºÎ
=======
            // íŒ¨ìŠ¤ì›Œë“œ ì •ì±…
            // ë³€ê²½ ì „. ìµœëŒ€ 6ìë¦¬ ì´ìƒ, íŠ¹ìˆ˜ë¬¸ì 1ê°œ í¬í•¨, ì˜ì–´ëŒ€ì†Œë¬¸ì í¬í•¨

            // ë³€ê²½ í›„. ìµœëŒ€ 4ìë¦¬ ì´ìƒ, ìˆ«ì í¬í•¨, íŠ¹ìˆ˜ë¬¸ì ì œì™¸
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // íŒ¨ìŠ¤ì›Œë“œ ì •ì±… ì„¤ì • Require(í•„ìˆ˜)
                options.Password.RequireDigit = true; // ìˆ«ì í¬í•¨ 
                options.Password.RequireLowercase = false; // ì†Œë¬¸ì í¬í•¨
                options.Password.RequireUppercase = false; // ëŒ€ë¬¸ì í¬í•¨
                options.Password.RequiredLength = 4; // ìµœì†Œ ê¸¸ì´ 4
                options.Password.RequireNonAlphanumeric = false; // íŠ¹ìˆ˜ë¬¸ì í¬í•¨ ì—¬ë¶€
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Program.cs
            app.UseAuthentication();  // ASP.NET Core Identity °èÁ¤
            app.UseAuthorization();   // ±ÇÇÑ
=======
            app.UseAuthentication();  // ASP.NET Core Identity ê³„ì •
            app.UseAuthorization();   // ê¶Œí•œ
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
