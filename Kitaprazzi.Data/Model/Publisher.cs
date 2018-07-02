using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Publisher : BaseEntity
    {
        [MaxLength(100, ErrorMessage = "Yayınevi Alanı 100 karakterden uzun olamaz!")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
    }
}
