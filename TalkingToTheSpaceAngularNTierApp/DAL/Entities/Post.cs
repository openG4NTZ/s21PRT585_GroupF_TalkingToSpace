using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Post
    {
        [Key]
        public Int64 Post_ID { get; set; } // (PK)
        public String Post_Name { get; set; }
        public String Post_Detail { get; set; }

    }
}
