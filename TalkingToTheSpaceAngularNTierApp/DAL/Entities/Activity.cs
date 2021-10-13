using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Activity
    {
        [Key]
        public Int64 Activity_ID { get; set; } // (PK)
        public String Activity_Creation_Time { get; set; }
        public String Activity_Detail { get; set; }

    }
}
