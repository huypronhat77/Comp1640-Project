using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkProject.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ChatBox ChatBox { get; set; }
    }
}