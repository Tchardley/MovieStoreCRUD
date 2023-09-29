using Microsoft.EntityFrameworkCore;
using MovieStoreCRUD.Models;

namespace MovieStoreCRUD.Data
{
    public class MovieDataContext : DbContext
    {
        public MovieDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
