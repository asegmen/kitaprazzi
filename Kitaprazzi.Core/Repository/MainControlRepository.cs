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
    public class MainControlRepository : IMainControlRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.MainControls.Remove(item);
            }
        }

        public MainControl Get(Expression<Func<MainControl, bool>> expression)
        {
            return _context.MainControls.FirstOrDefault(expression);
        }

        public IEnumerable<MainControl> GetAll()
        {
            return _context.MainControls.Select(x => x);
        }

        public MainControl GetById(int id)
        {
            return _context.MainControls.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MainControl> GetMany(Expression<Func<MainControl, bool>> expression)
        {
            return _context.MainControls.Where(expression);
        }

        public void Insert(MainControl obj)
        {
            _context.MainControls.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MainControl obj)
        {
            _context.MainControls.AddOrUpdate(obj);
        }
    }
}
