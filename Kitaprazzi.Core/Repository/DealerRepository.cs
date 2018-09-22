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
    public class DealerRepository : IDealerRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            return _context.Dealers.Count();
        }

        public void Delete(int id)
        {

            var item = GetById(id);
            if (item != null)
            {
                _context.Dealers.Remove(item);
            }
        }

        public Dealer Get(Expression<Func<Dealer, bool>> expression)
        {
            return _context.Dealers.FirstOrDefault(expression);
        }

        public IEnumerable<Dealer> GetAll()
        {
            return _context.Dealers.Select(x => x);
        }

        public Dealer GetById(int id)
        {
            return _context.Dealers.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Dealer> GetMany(Expression<Func<Dealer, bool>> expression)
        {
            return _context.Dealers.Where(expression);
        }

        public void Insert(Dealer obj)
        {
            _context.Dealers.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Dealer obj)
        {
            _context.Dealers.AddOrUpdate(obj);
        }
    }
}
