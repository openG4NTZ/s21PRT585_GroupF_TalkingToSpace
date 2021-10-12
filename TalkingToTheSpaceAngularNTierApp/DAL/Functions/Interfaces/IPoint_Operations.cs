using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Functions.Interfaces
{
    public interface IPoint_Operations
    {
        Task<Point> Create(Point pointToAdd);
        Task<Point> Read(Int64 pointId);
        Task<List<Point>> ReadAll();
        Task<Point> Update(Point pointToUpdate, Int64 pointId);
        Task<bool> Delete(Int64 pointId);
    }
}
