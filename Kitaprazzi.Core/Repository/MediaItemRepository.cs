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
    public class MediaItemRepository : IMediaItemRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            return _context.MediaItems.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.MediaItems.Remove(item);
            }
        }

        public MediaItem Get(Expression<Func<MediaItem, bool>> expression)
        {
            return _context.MediaItems.FirstOrDefault(expression);
        }

        public IEnumerable<MediaItem> GetAll()
        {
            return _context.MediaItems.Select(x => x);
        }

        public MediaItem GetById(int id)
        {
            return _context.MediaItems.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MediaItem> GetMany(Expression<Func<MediaItem, bool>> expression)
        {
            return _context.MediaItems.Where(expression);
        }

        public void Insert(MediaItem obj)
        {
            _context.MediaItems.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MediaItem obj)
        {
            _context.MediaItems.AddOrUpdate(obj);
        }
    }
}
