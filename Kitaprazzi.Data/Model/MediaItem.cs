using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class MediaItem: BaseEntity
    {
        [MaxLength(100, ErrorMessage = "Ad Alanı 50 karakterden uzun olamaz!")]
        public string Url { get; set; }
        public int Type { get; set; }
        public virtual Content Content { get; set; }
    }
}
