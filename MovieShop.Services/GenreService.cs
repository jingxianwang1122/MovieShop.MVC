using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;
using MovieShop.Data;
using MovieShop.Data.Repositories;
using MovieShop.Services;
using static MovieShop.Data.Repositories.GenreRepository;

namespace MovieShop.Services
{

    public class GenreService : IGenreService
    {
        /*private GenreRepository _genreRepository;
        public GenreService()
        {
            
            _genreRepository = new GenreRepository(new MovieShopDbContext());
        }
        */
        private IGenreRepository _genreRepository;
        public GenreService( IGenreRepository genreServices)
        {
            _genreRepository = genreServices;

        }

        public IEnumerable<Genre> GetAllGenres()
        {
            var genres = _genreRepository.GetAll();
            return genres;
        }
    }

    public interface IGenreService //methods put into the interface are based on requirement/ what to do in the mvc
    {
        IEnumerable<Genre> GetAllGenres();
         //any interface methods are by default public
    
    }
}
