using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Category: BaseEntity
    {
        [MaxLength(75, ErrorMessage = "Ad Alanı 50 karakterden uzun olamaz!")]
        public string Name { get; set; }
        [MaxLength(75, ErrorMessage = "Url Alanı 50 karakterden uzun olamaz!")]
        public string Url { get; set; }
        public int CategoryID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public int? IsMenu { get; set; }

    }
}
