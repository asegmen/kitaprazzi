using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Content: BaseEntity
    {
        [MaxLength(100, ErrorMessage = "Kitap Adı Alanı 50 karakterden uzun olamaz!")]
        public string Title { get; set; }
        [MaxLength(250, ErrorMessage = "Spot Alanı 100 karakterden uzun olamaz!")]
        public string Spot { get; set; }
        [MaxLength(5000, ErrorMessage = "Açıklama Alanı 500 karakterden uzun olamaz!")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Type { get; set; }
        public virtual ICollection<MediaItem> MediaItems { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public int? PublisherID { get; set; }
        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }
        public int? LessonID { get; set; }
        [ForeignKey("LessonID")]
        public virtual Lesson Lesson { get; set; }
        public int? ContentTypeID { get; set; }
        [ForeignKey("ContentTypeID")]
        public virtual ContentType ContentType { get; set; }
        public float EditorPoint { get; set; }
        public float UserPoint { get; set; }
        public float KitaprazziPoint { get; set; }

    }
}
