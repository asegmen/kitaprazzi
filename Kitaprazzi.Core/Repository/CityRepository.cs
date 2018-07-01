using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.DataContext;
using System.Data.Entity.Migrations;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Core.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public City Get(Expression<Func<City, bool>> expression)
        {
            return _context.Cities.FirstOrDefault(expression);
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities.Select(x=> x);
        }

        public City GetById(int id)
        {
            return _context.Cities.FirstOrDefault(x=> x.ID == id);
        }

        public IQueryable<City> GetMany(Expression<Func<City, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(City obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(City obj)
        {
            throw new NotImplementedException();
        }
    }
}
