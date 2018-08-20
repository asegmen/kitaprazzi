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
    public class LessonRepository : ILessonRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();

        public int Count()
        {
            return _context.Lessons.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Lessons.Remove(item);
            }
        }

        public Lesson Get(Expression<Func<Lesson, bool>> expression)
        {
            return _context.Lessons.FirstOrDefault(expression);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _context.Lessons.Select(x=> x);
        }

        public Lesson GetById(int id)
        {
            return _context.Lessons.FirstOrDefault(x=> x.ID == id);
        }

        public IQueryable<Lesson> GetMany(Expression<Func<Lesson, bool>> expression)
        {
            return _context.Lessons.Where(expression);
        }

        public void Insert(Lesson obj)
        {
            _context.Lessons.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Lesson obj)
        {
            _context.Lessons.AddOrUpdate(obj);
        }
    }
}
