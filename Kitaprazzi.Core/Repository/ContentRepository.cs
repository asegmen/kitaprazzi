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
    public class ContentRepository : IContentRepository
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

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Content> GetAll()
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(Content obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Content obj)
        {
            throw new NotImplementedException();
        }
    }
}
