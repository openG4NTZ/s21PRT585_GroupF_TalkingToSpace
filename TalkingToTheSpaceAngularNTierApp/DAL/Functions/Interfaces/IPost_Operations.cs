using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IPost_Operations
    {
        Task<Post> Create(Post objectToAdd);
        Task<Post> Read(Int64 entityId);
        Task<List<Post>> ReadAll();
        Task<Post> Update(Post objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
