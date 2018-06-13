using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class City
    {
        public int ID { get; set; }
        [MaxLength(50, ErrorMessage = "Şehir Alanı 50 karakterden uzun olamaz!")]
        public string Name { get; set; }
    }
}
