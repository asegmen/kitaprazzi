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
    public class CountryRepository : ICountryRepository
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

        public Country Get(Expression<Func<Country, bool>> expression)
        {
            return _context.Countries.FirstOrDefault(expression);
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries.Select(x => x);
        }

        public Country GetById(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Country> GetMany(Expression<Func<Country, bool>> expression)
        {
            return _context.Countries.Where(expression);
        }

        public void Insert(Country obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
