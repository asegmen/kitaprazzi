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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MediaItem Get(Expression<Func<MediaItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MediaItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public MediaItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MediaItem> GetMany(Expression<Func<MediaItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(MediaItem obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(MediaItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
