using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kitaprazzi.Data.DataContext;
using System.Data.Entity.Migrations;

namespace Kitaprazzi.Core.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            return _context.Publishers.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Publishers.Remove(item);
            }
        }

        public Publisher Get(Expression<Func<Publisher, bool>> expression)
        {
            return _context.Publishers.FirstOrDefault(expression);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.Select(x => x);
        }

        public Publisher GetById(int id)
        {
            return _context.Publishers.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Publisher> GetMany(Expression<Func<Publisher, bool>> expression)
        {
            return _context.Publishers.Where(expression);
        }

        public void Insert(Publisher obj)
        {
            _context.Publishers.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Publisher obj)
        {
            _context.Publishers.AddOrUpdate(obj);
        }
    }
}
