using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MovieStoreCRUD.Data;
using MovieStoreCRUD.Models;


namespace MovieStoreCRUD.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDataContext _movieDataContext;

        public MovieController(MovieDataContext movieDataContext)
        {
            _movieDataContext = movieDataContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
          var movie =  await _movieDataContext.Movies.ToListAsync();
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieViewModel movieRequest)
        {
            var movie = new Movie()
            {
               
                Name = movieRequest.Name,
                MovieLength = movieRequest.MovieLength,
                Year = movieRequest.Year,
                StarRating = movieRequest.StarRating,
            };
            await _movieDataContext.Movies.AddAsync(movie);
            await _movieDataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var movie = await _movieDataContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if(movie != null)
            {
                var viewModel = new UpdateMovieViewModel()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    MovieLength = movie.MovieLength,
                    Year = movie.Year,
                    StarRating = movie.StarRating,

                };

                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
           
            

        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateMovieViewModel model)
        {
            var movie = await _movieDataContext.Movies.FindAsync(model.Id);
            if(movie != null) 
            {
                movie.Name = model.Name;
                movie.MovieLength = model.MovieLength;
                movie.Year = model.Year;
                movie.StarRating = model.StarRating;
                await _movieDataContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMovieViewModel model)
        {
            var movie = await _movieDataContext.Movies.FindAsync(model.Id);

            if(movie != null)
            {
                 _movieDataContext.Movies.Remove(movie);
                await _movieDataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
