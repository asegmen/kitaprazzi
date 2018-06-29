using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kitaprazzi.Data.Model
{
    public class BaseEntity
    {
        public int ID{ get; set; }
        private DateTime _createdDate = DateTime.Now;
        private DateTime _updateDate = DateTime.Now;


        public DateTime CreatedDate {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        [Display(Name ="Aktif / Pasif Durumu")]
        public int Status{ get; set; }
    }
}
