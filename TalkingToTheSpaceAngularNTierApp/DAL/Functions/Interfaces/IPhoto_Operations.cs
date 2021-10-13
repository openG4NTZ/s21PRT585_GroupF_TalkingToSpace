using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IPhoto_Operations
    {
        Task<Photo> Create(Photo objectToAdd);
        Task<Photo> Read(Int64 entityId);
        Task<List<Photo>> ReadAll();
        Task<Photo> Update(Photo objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
