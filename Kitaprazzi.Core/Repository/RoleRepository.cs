using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.DataContext;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;


namespace Kitaprazzi.Core.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly KitaprazziContext _context = new KitaprazziContext();
        public int Count()
        {
            return _context.Roles.Count();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.Select(x => x);
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x=> x.ID == id);
        }

        public IQueryable<Role> GetMany(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Where(expression);
        }

        public void Insert(Role obj)
        {
            _context.Roles.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Role obj)
        {
            _context.Roles.AddOrUpdate(obj);
        }
    }
}
