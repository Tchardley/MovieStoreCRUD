namespace MovieStoreCRUD.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string MovieLength { get; set; } = string.Empty;

        public DateTime Year { get; set; }

        public string StarRating { get; set; } = string.Empty;
    }
}
