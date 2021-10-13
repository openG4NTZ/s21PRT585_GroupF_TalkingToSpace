using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Functions.Interfaces
{
    public interface IUser_Operations
    {
        Task<User> Create(User userToAdd);
        Task<User> Read(Int64 userId);
        Task<List<User>> ReadAll();
        Task<User> Update(User userToUpdate, Int64 userId);
        Task<bool> Delete(Int64 userId);
    }
}

