using LOGIC.Services.Models;
using LOGIC.Services.Models.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IPoint_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Point_ResultSet>>> GetAllPoints();
        Task<Generic_ResultSet<Point_ResultSet>> GetPointByPointId(Int64 point_id);

        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Point_ResultSet>> AddPoint(string point_amount, Int64 user_id);
        Task<Generic_ResultSet<Point_ResultSet>> UpdatePoint(Int64 point_id, string point_amount, Int64 user_id);
        Task<Generic_ResultSet<bool>> DeletePoint(Int64 point_id);


    }
}
