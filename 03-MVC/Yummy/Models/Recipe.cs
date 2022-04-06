using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Difficulty { get; set; }
        [Display(Name = "Favourite")]
        public int NumberOfLikes { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        [Display(Name = "Tricks & Tips")]
        public string TricksAndTips { get; set; }
    }
}