namespace MovieStoreCRUD.Models
{
    public class MovieViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string MovieLength { get; set; } = string.Empty;

        public DateTime Year { get; set; }

        public string StarRating { get; set; } = string.Empty;
    }
}
