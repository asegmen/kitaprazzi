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
    public class ContentTypeRepository : IContentTypeRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            return _context.ContentTypes.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.ContentTypes.Remove(item);
            }
        }

        public ContentType Get(Expression<Func<ContentType, bool>> expression)
        {
            return _context.ContentTypes.FirstOrDefault(expression);

        }

        public IEnumerable<ContentType> GetAll()
        {
            return _context.ContentTypes.Select(x => x);
        }

        public ContentType GetById(int id)
        {
            return _context.ContentTypes.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<ContentType> GetMany(Expression<Func<ContentType, bool>> expression)
        {
            return _context.ContentTypes.Where(expression);
        }

        public void Insert(ContentType obj)
        {
            _context.ContentTypes.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ContentType obj)
        {
            _context.ContentTypes.AddOrUpdate(obj);
        }
    }
}
