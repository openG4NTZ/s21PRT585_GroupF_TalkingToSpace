using System;

namespace LOGIC.Services.Models.Point
{
    public class Point_ResultSet
    {
        public Int64 point_id { get; set; } //(PK)
        public String point_amount { get; set; }
        public Int64 user_id { get; set; } //(FK)
    }
}
