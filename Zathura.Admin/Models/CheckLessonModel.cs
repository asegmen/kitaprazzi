using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zathura.Admin.Models
{
    public class CheckLessonModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public bool IsCheck { get; set; }
    }
}