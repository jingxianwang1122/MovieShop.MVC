using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repositories
{
    //create the class is to reimplement
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbSet<T> _dbSet;  
        protected MovieShopDbContext _context;
        public Repository(MovieShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); //T-placeholder: typically replace by dbset classes
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            // add movie entity into the DbContext 
            //call savechanges()-only when u call savechanges will actually insert data into t
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified; //telling entity framework, we are updating
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
                _context.SaveChanges();

        }
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual T Get(Expression<Func<T, bool>> where) //Linq (extention methods) base interface: IEnumerable
        {
            return _dbSet.Where(where).FirstOrDefault();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList(); 
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }
    }
}
