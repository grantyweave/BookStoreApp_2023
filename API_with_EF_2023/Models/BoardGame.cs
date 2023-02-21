namespace API_with_EF_2023.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearPublished { get; set; }
        public int RecommendedPlayerCount { get; set; }
    }
}
