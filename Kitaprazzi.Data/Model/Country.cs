using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class Country
    {
        public int ID{ get; set; }

        [MaxLength(75)]
        [Required]
        public string Name { get; set; }
    }
}
