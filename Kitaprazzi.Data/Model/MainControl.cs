using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaprazzi.Data.Model
{
    public class MainControl
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        public string Sequence { get; set; }
        public int Order { get; set; }
    }
}
