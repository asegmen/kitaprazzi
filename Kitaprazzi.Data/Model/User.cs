using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Kitaprazzi.Data.Model
{
    public class User: BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Ad Alanı 50 karakterden uzun olamaz!")]
        [Required]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Soyad Alanı 50 karakterden uzun olamaz!")]
        [Required]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Geçerli bir e-mail adresi giriniz!")]
        public string Email { get; set; }

        [MaxLength(16, ErrorMessage = "Şifre Alanı 16 karakterden uzun olamaz!")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [Required]
        public int? RoleID { get; set; }
    }
}
