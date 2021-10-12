using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Point
    {
        public Int64 Point_ID{ get; set; } // (PK)
        public String Point_Amount { get; set; }
        public Int64 User_ID { get; set; } //(FK)


        //RELATIONSHIPS
        public User User { get; set; }
    }
}
