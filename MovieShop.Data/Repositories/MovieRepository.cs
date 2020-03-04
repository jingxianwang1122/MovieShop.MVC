using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext context) : base(context)
        {
            
        }

        //public List<Movie> GetMovieById(int movieId)
        //{
        //    var movie = _context.Movies.Where(m => m.Id == movieId).ToList();
        //    return movie;
        //}


        public override Movie GetById(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieCasts.Select(c => c.Cast)).Include(m => m.Genres)
                                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = _context.Reviews.Where(r => r.MovieId == id).Average(r => r.Rating);
            if (movieRating > 0) movie.Rating = Math.Ceiling(movieRating * 100) / 100;
            return movie;
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            var movie = _context.Genres.Where(g => g.ID == genreId).SelectMany(m=>m.Movies).ToList(); 
            return movie;
        }


        public List<Movie> GetMoviesByPagination(int PageNumber, int PageSize = 20)
        {
            return _context.Movies.OrderBy(m => m.Title).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }

        public List<Movie> GetTopRenevueMovie()
        {
            var movie=_context.Movies.OrderByDescending(m=>m.Revenue).Include(m=>m.Genres).Take(20).ToList();
            return movie;
        }
    }
    public interface IMovieRepository : IRepository<Movie>
    {
       
        List<Movie> GetTopRenevueMovie();
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetMoviesByPagination( int PageNumber, int PageSize = 20);
    }
}
