using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Point
{
    public class Point_Pass_Object
    {
        public Int64 point_id { get; set; } //(PK)
        public String point_amount { get; set; }
        public Int64 user_id { get; set; } //(FK)
    }
}
