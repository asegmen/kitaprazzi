using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kitaprazzi.Data.Model
{
    public class Role:BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Role Alanı 50 karakterden uzun olamaz!")]
        [Required]
        public string Name { get; set; }
    }
}
