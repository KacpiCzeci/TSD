namespace YummyAPI.Models
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Difficulty { get; set; }
        public int? NumberOfLikes { get; set; } = 0;
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string? TricksAndTips { get; set; } = "";
    }
}