using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MyPortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context; // DB연동

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
            // 정적 HTML을 DB 데이터로 동적처리
            // DB에서 데이터를 불러온 뒤 About, Skill 객체에 데이터 담아서 뷰로 넘겨줌
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();
            // FirstAsync는 데이터가 없으면 예외발생. FirstOrDefaultAsync 데이터가 없으면 널값
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount; // ex. 7이 넘어감
=======
            // �젙�쟻 HTML�쓣 DB �뜲�씠�꽣濡� �룞�쟻泥섎━
            // DB�뿉�꽌 �뜲�씠�꽣瑜� 遺덈윭�삩 �뮘 About, Skill 媛앹껜�뿉 �뜲�씠�꽣 �떞�븘�꽌 酉곕줈 �꽆寃⑥쨲
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();
            // FirstAsync�뒗 �뜲�씠�꽣媛� �뾾�쑝硫� �삁�쇅諛쒖깮. FirstOrDefaultAsync �뜲�씠�꽣媛� �뾾�쑝硫� �꼸媛�
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount; // ex. 7�씠 �꽆�뼱媛�
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
            ViewBag.ColNum = (skillCount / 2) + (skillCount % 2); // 3(7/2) + 1(7%2)

            var model = new AboutModel();
            model.About = about;
            model.Skill = skill;

            return View(model);
        }
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Contact(ContactModel model)
        {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
            if (ModelState.IsValid) // Model에 들어간 네개 값이 제대로 들어갔으면
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.mail.nate.com") // Gmail을 사용하면 
                    {
                        Port = 465, // 메일 SMPT 서비스포트 변경필요
                        Credentials = new NetworkCredential("personar95@gmail.com", "비밀번호"),
                        EnableSsl = true,
=======
            if(ModelState.IsValid) // 紐⑤뜽�뿉 �뱾�뼱媛� �꽕媛쒖쓽 媛믪씠 �젣���濡� �뱾�뼱媛붾떎硫�
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gamil.com") // Gmail�쓣 �궗�슜�븯硫�
                    {
                        Port = 465, // 硫붿씪 SMTP �꽌鍮꾩뒪�룷�듃 蹂�寃쏀븘�슂
                        Credentials = new NetworkCredential("fake4131@naver.com", "鍮꾨��踰덊샇�끂異�"),
                        EnableSsl = true, // SSL �궗�슜
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                    };

                    var mailMessage = new MailMessage
                    {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                        From = new MailAddress(model.Email),  // 문의하기에 작성한 메일주소
                        Subject = model.Subject ?? "[제목없음]",
                        Body = $"보낸 사람 : {model.Name} ({model.Email})\n\n메시지 : {model.Message}",
                        IsBodyHtml = false,  // 메일 본문에 HTML태그를 사용여부
                    };

                    mailMessage.To.Add("personar95@naver.com");  // 받을 메일주소

                    await smtpClient.SendMailAsync(mailMessage); // 위 생성된 메일객체를 전송!
                    ViewBag.Success = true;
=======
                        From = new MailAddress(model.Email), // 蹂대궡�뒗 �궗�엺 臾몄쓽�븯湲곗뿉 �옉�꽦�븳 硫붿씪二쇱냼
                        Subject = model.Subject ?? "[�젣紐⑹뾾�쓬]", // �젣紐�
                        Body = $"蹂대궦�궗�엺 : {model.Name} �씠硫붿씪 : {model.Email} �궡�슜 : {model.Message}",
                        IsBodyHtml = false, // 硫붿씪 蹂몃Ц�뿉 HTML �삎�떇�쑝濡� 硫붿씪 �궡�슜 �옉�꽦
                    };

                    mailMessage.To.Add("fake5378@naver.com"); // 諛쏆쓣 硫붿씪 二쇱냼

                    await smtpClient.SendMailAsync(mailMessage); // �쐞 �깮�꽦�맂 硫붿씪�쓣 鍮꾨룞湲� 硫붿씪 �쟾�넚

>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                }
                catch (Exception ex)
                {
                    ViewBag.Success = false;
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                    ViewBag.Error = $"메일전송 실패! {ex.Message}";
                }                
=======
                    ViewBag.Error = $"硫붿씪�쟾�넚 �떎�뙣! {ex.Message}";
                }
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
