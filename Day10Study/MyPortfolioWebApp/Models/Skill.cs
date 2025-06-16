using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Models/Skill.cs
        public string Langauge {  get; set; }
=======
        public string Language {  get; set; }
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Models/Skill.cs

        public float Level { get; set; }
    }
}
