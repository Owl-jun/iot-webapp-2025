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
        private readonly ApplicationDbContext _context; // DB¿¬µ¿

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
            // Á¤Àû HTMLÀ» DB µ¥ÀÌÅÍ·Î µ¿ÀûÃ³¸®
            // DB¿¡¼­ µ¥ÀÌÅÍ¸¦ ºÒ·¯¿Â µÚ About, Skill °´Ã¼¿¡ µ¥ÀÌÅÍ ´ã¾Æ¼­ ºä·Î ³Ñ°ÜÁÜ
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();
            // FirstAsync´Â µ¥ÀÌÅÍ°¡ ¾øÀ¸¸é ¿¹¿Ü¹ß»ý. FirstOrDefaultAsync µ¥ÀÌÅÍ°¡ ¾øÀ¸¸é ³Î°ª
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount; // ex. 7ÀÌ ³Ñ¾î°¨
=======
            // ì •ì  HTMLì„ DB ë°ì´í„°ë¡œ ë™ì ì²˜ë¦¬
            // DBì—ì„œ ë°ì´í„°ë¥¼ ë¶ˆëŸ¬ì˜¨ ë’¤ About, Skill ê°ì²´ì— ë°ì´í„° ë‹´ì•„ì„œ ë·°ë¡œ ë„˜ê²¨ì¤Œ
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();
            // FirstAsyncëŠ” ë°ì´í„°ê°€ ì—†ìœ¼ë©´ ì˜ˆì™¸ë°œìƒ. FirstOrDefaultAsync ë°ì´í„°ê°€ ì—†ìœ¼ë©´ ë„ê°’
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount; // ex. 7ì´ ë„˜ì–´ê°
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
            if (ModelState.IsValid) // Model¿¡ µé¾î°£ ³×°³ °ªÀÌ Á¦´ë·Î µé¾î°¬À¸¸é
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.mail.nate.com") // GmailÀ» »ç¿ëÇÏ¸é 
                    {
                        Port = 465, // ¸ÞÀÏ SMPT ¼­ºñ½ºÆ÷Æ® º¯°æÇÊ¿ä
                        Credentials = new NetworkCredential("personar95@gmail.com", "ºñ¹Ð¹øÈ£"),
                        EnableSsl = true,
=======
            if(ModelState.IsValid) // ëª¨ë¸ì— ë“¤ì–´ê°„ ë„¤ê°œì˜ ê°’ì´ ì œëŒ€ë¡œ ë“¤ì–´ê°”ë‹¤ë©´
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gamil.com") // Gmailì„ ì‚¬ìš©í•˜ë©´
                    {
                        Port = 465, // ë©”ì¼ SMTP ì„œë¹„ìŠ¤í¬íŠ¸ ë³€ê²½í•„ìš”
                        Credentials = new NetworkCredential("fake4131@naver.com", "ë¹„ë°€ë²ˆí˜¸ë…¸ì¶œ"),
                        EnableSsl = true, // SSL ì‚¬ìš©
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                    };

                    var mailMessage = new MailMessage
                    {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                        From = new MailAddress(model.Email),  // ¹®ÀÇÇÏ±â¿¡ ÀÛ¼ºÇÑ ¸ÞÀÏÁÖ¼Ò
                        Subject = model.Subject ?? "[Á¦¸ñ¾øÀ½]",
                        Body = $"º¸³½ »ç¶÷ : {model.Name} ({model.Email})\n\n¸Þ½ÃÁö : {model.Message}",
                        IsBodyHtml = false,  // ¸ÞÀÏ º»¹®¿¡ HTMLÅÂ±×¸¦ »ç¿ë¿©ºÎ
                    };

                    mailMessage.To.Add("personar95@naver.com");  // ¹ÞÀ» ¸ÞÀÏÁÖ¼Ò

                    await smtpClient.SendMailAsync(mailMessage); // À§ »ý¼ºµÈ ¸ÞÀÏ°´Ã¼¸¦ Àü¼Û!
                    ViewBag.Success = true;
=======
                        From = new MailAddress(model.Email), // ë³´ë‚´ëŠ” ì‚¬ëžŒ ë¬¸ì˜í•˜ê¸°ì— ìž‘ì„±í•œ ë©”ì¼ì£¼ì†Œ
                        Subject = model.Subject ?? "[ì œëª©ì—†ìŒ]", // ì œëª©
                        Body = $"ë³´ë‚¸ì‚¬ëžŒ : {model.Name} ì´ë©”ì¼ : {model.Email} ë‚´ìš© : {model.Message}",
                        IsBodyHtml = false, // ë©”ì¼ ë³¸ë¬¸ì— HTML í˜•ì‹ìœ¼ë¡œ ë©”ì¼ ë‚´ìš© ìž‘ì„±
                    };

                    mailMessage.To.Add("fake5378@naver.com"); // ë°›ì„ ë©”ì¼ ì£¼ì†Œ

                    await smtpClient.SendMailAsync(mailMessage); // ìœ„ ìƒì„±ëœ ë©”ì¼ì„ ë¹„ë™ê¸° ë©”ì¼ ì „ì†¡

>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                }
                catch (Exception ex)
                {
                    ViewBag.Success = false;
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/HomeController.cs
                    ViewBag.Error = $"¸ÞÀÏÀü¼Û ½ÇÆÐ! {ex.Message}";
                }                
=======
                    ViewBag.Error = $"ë©”ì¼ì „ì†¡ ì‹¤íŒ¨! {ex.Message}";
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
