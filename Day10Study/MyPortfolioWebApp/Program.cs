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

            // �ִ����� �뷮 ����
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
            // DB���� �ʱ�ȭ ����
=======
            // DB연결 초기화 설정
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("SmartHomeConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SmartHomeConnection"))
            ));

            // ASP.NET Core Identity ����
            // ������ IdentityUser -> CustomUser �� ����
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Program.cs
            // �н����� ��å
            // ���� ��. �ִ� 6�ڸ� �̻�, Ư������ 1�� ����, �����ҹ��� ����
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // �̷� ��ȣ ����ȭ�� �ǵ��� ������ ��
                options.Password.RequiredLength = 4; // �ּұ��� 4�ڸ�
                options.Password.RequireNonAlphanumeric = false; // Ư������ ������
                options.Password.RequireUppercase = false; // �빮�� ������
                options.Password.RequireLowercase = false; // �ҹ��� ������
                options.Password.RequireDigit = false; // �����ʼ� ����
=======
            // 패스워드 정책
            // 변경 전. 최대 6자리 이상, 특수문자 1개 포함, 영어대소문자 포함

            // 변경 후. 최대 4자리 이상, 숫자 포함, 특수문자 제외
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // 패스워드 정책 설정 Require(필수)
                options.Password.RequireDigit = true; // 숫자 포함 
                options.Password.RequireLowercase = false; // 소문자 포함
                options.Password.RequireUppercase = false; // 대문자 포함
                options.Password.RequiredLength = 4; // 최소 길이 4
                options.Password.RequireNonAlphanumeric = false; // 특수문자 포함 여부
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
            app.UseAuthentication();  // ASP.NET Core Identity ����
            app.UseAuthorization();   // ����
=======
            app.UseAuthentication();  // ASP.NET Core Identity 계정
            app.UseAuthorization();   // 권한
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Program.cs

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
