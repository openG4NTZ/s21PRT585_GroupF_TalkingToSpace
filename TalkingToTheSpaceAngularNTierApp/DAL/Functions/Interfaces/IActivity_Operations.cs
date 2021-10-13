using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IActivity_Operations
    {
        Task<Activity> Create(Activity objectToAdd);
        Task<Activity> Read(Int64 entityId);
        Task<List<Activity>> ReadAll();
        Task<Activity> Update(Activity objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
