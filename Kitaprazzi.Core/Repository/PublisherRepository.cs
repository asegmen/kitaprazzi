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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Publisher Get(Expression<Func<Publisher, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Publisher> GetMany(Expression<Func<Publisher, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(Publisher obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Publisher obj)
        {
            throw new NotImplementedException();
        }
    }
}
