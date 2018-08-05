using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Core.Helper
{
    public class GenericHelper
    {
        private readonly IContentRepository _contentRepository;
        public GenericHelper(IContentRepository contentRepository) {
            _contentRepository = contentRepository;
        }

        public List<Content> GetContentsWithByCategory(int categoryId, int limit = 4) {
            var contentList = _contentRepository.GetMany(x=> x.CategoryID == categoryId && x.Status == (int)Status.Active).OrderByDescending(x=>x.CreatedDate).Take(limit).ToList();
            return contentList;
        }
        public List<Content> GetMostPopularContents(int limit = 4)
        {
            var contentList = _contentRepository.GetMany(x =>x.Status == (int)Status.Active).OrderByDescending(x=>x.KitaprazziPoint).Take(limit).ToList();
            return contentList;
        }
    }
}
