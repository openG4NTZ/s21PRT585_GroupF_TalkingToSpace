using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Photo
    {
        [Key]
        public Int64 Photo_ID { get; set; } // (PK)
        public String Photo_Name { get; set; }
        public String Photo_Detail { get; set; }

    }
}
