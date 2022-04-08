using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage="You need to put name for your Recipe.")]
        [RegularExpression(@"^.*[a-zA-Z].*$", ErrorMessage="You need to have some text not only digest xd.")]
        public string Name { get; set; }

        [Required(ErrorMessage="You need to put time for your Recipe.")]
        [RegularExpression(@"^-?[0-9]+$", ErrorMessage="Time need to be a number.")]
        [Range(0, Int32.MaxValue, ErrorMessage="Time should be positive.")]
        public int Time { get; set; }

        [Required(ErrorMessage="You need to put difficulty for your Recipe.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage="Only text ranges are allowed.")]
        public string Difficulty { get; set; }

        [Display(Name = "Favourite")]
        [RegularExpression(@"^-?[0-9]+$", ErrorMessage="Likes need to be a numbers.")]
        [Range(0, Int32.MaxValue, ErrorMessage="Likes should be positive.")]
        public int? NumberOfLikes { get; set; } = 0;

        [Required(ErrorMessage="You need to put ingredients for your Recipe.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage="You need to put process for your Recipe.")]
        public string Process { get; set; }

        [Display(Name = "Tricks & Tips")]
        public string? TricksAndTips { get; set; } = "";
    }
}