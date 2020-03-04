using MovieShop.Data;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        private  readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie GetMovieDetails(int id)
        {
            return _movieRepository.GetById(id);
         
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public List<Movie> GetMoviesByPagination(int PageSize, int PageNumber, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetTopRenevueMovie()
        {
            return _movieRepository.GetTopRenevueMovie();
        }
    }
    public interface IMovieService 
    {
        
        List<Movie> GetTopRenevueMovie();
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetMoviesByPagination(int PageSize, int PageNumber, int skip, int take);
        Movie GetMovieDetails(int id);
    }

}
