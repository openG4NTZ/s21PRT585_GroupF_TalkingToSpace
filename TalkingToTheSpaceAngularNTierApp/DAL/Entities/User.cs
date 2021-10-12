using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public Int64 User_ID { get; set; } //(PK)
        public String Username { get; set; }
        public String User_Token { get; set; }
        public String User_Profile_Name { get; set; }
        public String User_Email { get; set; }
        public DateTime User_Creation_Date { get; set; }
        //RELATIONSHIPS
        // An user can have many messages.
        // A message though belongs to only 1 user at a time.
        public ICollection<Message> Messages { get; set; }
        // Todo:
        // An user can reply many messages.
        // A reply must belong to the reply author. 
        public ICollection<Reply> Replies { get; set; }
        // An user must start with a point from point_zero.
        // A point must belong to an user.
        public Point Point { get; set; }
    }
}
