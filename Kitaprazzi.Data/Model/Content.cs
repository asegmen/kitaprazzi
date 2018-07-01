using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Content: BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Kitap Adı Alanı 50 karakterden uzun olamaz!")]
        public string Title { get; set; }
        [MaxLength(100, ErrorMessage = "Spot Alanı 100 karakterden uzun olamaz!")]
        public string Spot { get; set; }
        [MaxLength(500, ErrorMessage = "Açıklama Alanı 500 karakterden uzun olamaz!")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Type { get; set; }
        public virtual ICollection<MediaItem> MediaItems { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } 

    }
}
