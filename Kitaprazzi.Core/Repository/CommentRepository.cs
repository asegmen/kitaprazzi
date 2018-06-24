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
    public class CommentRepository : ICommentRepository
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

        public Comment Get(Expression<Func<Comment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetMany(Expression<Func<Comment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
