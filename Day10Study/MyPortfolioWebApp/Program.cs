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

            // 최대파일 용량 제한
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
            // DB연결 초기화 설정
=======
            // DB�뿰寃� 珥덇린�솕 �꽕�젙
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("SmartHomeConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SmartHomeConnection"))
            ));

            // ASP.NET Core Identity 설정
            // 원본은 IdentityUser -> CustomUser 로 변경
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Program.cs
            // 패스워드 정책
            // 변경 전. 최대 6자리 이상, 특수문자 1개 포함, 영어대소문자 포함
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // 이런 암호 간단화는 되도록 하지말 것
                options.Password.RequiredLength = 4; // 최소길이 4자리
                options.Password.RequireNonAlphanumeric = false; // 특수문자 사용안함
                options.Password.RequireUppercase = false; // 대문자 사용안함
                options.Password.RequireLowercase = false; // 소문자 사용안함
                options.Password.RequireDigit = false; // 숫자필수 여부
=======
            // �뙣�뒪�썙�뱶 �젙梨�
            // 蹂�寃� �쟾. 理쒕�� 6�옄由� �씠�긽, �듅�닔臾몄옄 1媛� �룷�븿, �쁺�뼱����냼臾몄옄 �룷�븿

            // 蹂�寃� �썑. 理쒕�� 4�옄由� �씠�긽, �닽�옄 �룷�븿, �듅�닔臾몄옄 �젣�쇅
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // �뙣�뒪�썙�뱶 �젙梨� �꽕�젙 Require(�븘�닔)
                options.Password.RequireDigit = true; // �닽�옄 �룷�븿 
                options.Password.RequireLowercase = false; // �냼臾몄옄 �룷�븿
                options.Password.RequireUppercase = false; // ���臾몄옄 �룷�븿
                options.Password.RequiredLength = 4; // 理쒖냼 湲몄씠 4
                options.Password.RequireNonAlphanumeric = false; // �듅�닔臾몄옄 �룷�븿 �뿬遺�
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
            app.UseAuthentication();  // ASP.NET Core Identity 계정
            app.UseAuthorization();   // 권한
=======
            app.UseAuthentication();  // ASP.NET Core Identity 怨꾩젙
            app.UseAuthorization();   // 沅뚰븳
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
