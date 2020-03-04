using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MovieShop.Data.Repositories.GenreRepository;

namespace MovieShop.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository //repository is inheritance, while IGenreRepository is interface
    {
        public GenreRepository(MovieShopDbContext context) : base(context) //base class 
        {

        }

        public Genre getGenreByName(string name)
        {
            // method 1: 
            var genre = _context.Genres.FirstOrDefault(g=>g.Name==name);//select * from Genre where name = "Adam", the result might have multiple records, when only expect 1 item, we should use  Linq method(Single, SingleOrdeFault, First, FirstOrDefault). 
            //method 2:
            //var genre = _context.Genres.Where(g => g.Name == name).FirstOrDefault(); // where returns multiple results, we only want the first record.
            //var genre = _context.Genres.Where(g => g.Name == name).OrderByDescending(g=>g.ID).FirstOrDefault(); //filter result
            return genre;
        }

        //there are 8 methods in the Resopitory, how to add extra methods for this repository?
        //1. add method here
        //2. to create loosely coupled code
        public interface IGenreRepository:IRepository<Genre> //create interface first, then add it to the class, 
                                                             //how to make the 9 methods coming from IGenreRepository
                                                             //who ever implemented the IGenreRepository, it will implement total 9 methods
        {
            Genre getGenreByName(string name);

        }

       
        
    }
}
