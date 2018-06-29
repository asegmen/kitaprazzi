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
            return _context.Contents.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Contents.Remove(item);
            }
        }

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.FirstOrDefault(expression);
        }

        public IEnumerable<Content> GetAll()
        {
            return _context.Contents.Select(x => x);
        }

        public Content GetById(int id)
        {
            return _context.Contents.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Where(expression);
        }

        public void Insert(Content obj)
        {
            _context.Contents.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Content obj)
        {
            _context.Contents.AddOrUpdate(obj);
        }
    }
}
