using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Comment:BaseEntity
    {
        public virtual User User{ get; set; }
        [MaxLength(1000, ErrorMessage = "Ad Alanı 50 karakterden uzun olamaz!")]
        public string Message { get; set; }
    }
}
