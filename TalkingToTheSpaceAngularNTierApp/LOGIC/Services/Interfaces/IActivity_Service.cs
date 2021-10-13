using LOGIC.Services.Models;
using LOGIC.Services.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IActivity_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Activity_ResultSet>>> GetAllActivitys();
        Task<Generic_ResultSet<Activity_ResultSet>> GetActivityById(Int64 id);

        //Task<Generic_ResultSet<Activity_ResultSet>> GetActivityByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Activity_ResultSet>> AddActivity(string creation_time, string detail);
        Task<Generic_ResultSet<Activity_ResultSet>> UpdateActivity(Int64 id, string creation_time, string detail);
        Task<Generic_ResultSet<bool>> DeleteActivity(Int64 id);

    }
}

