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
    public class MainSliderRepository : IMainSliderRepository
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
                _context.MainSliders.Remove(item);
            }
        }

        public MainSlider Get(Expression<Func<MainSlider, bool>> expression)
        {
            return _context.MainSliders.FirstOrDefault(expression);
        }

        public IEnumerable<MainSlider> GetAll()
        {
            return _context.MainSliders.Select(x => x);
        }

        public MainSlider GetById(int id)
        {
            return _context.MainSliders.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MainSlider> GetMany(Expression<Func<MainSlider, bool>> expression)
        {
            return _context.MainSliders.Where(expression);
        }

        public void Insert(MainSlider obj)
        {
            _context.MainSliders.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MainSlider obj)
        {
            _context.MainSliders.AddOrUpdate(obj);
        }
    }
}
