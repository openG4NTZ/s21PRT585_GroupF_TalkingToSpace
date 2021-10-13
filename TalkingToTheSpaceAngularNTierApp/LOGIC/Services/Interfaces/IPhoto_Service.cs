using LOGIC.Services.Models;
using LOGIC.Services.Models.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IPhoto_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Photo_ResultSet>>> GetAllPhotos();
        Task<Generic_ResultSet<Photo_ResultSet>> GetPhotoById(Int64 id);

        //Task<Generic_ResultSet<Photo_ResultSet>> GetPhotoByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Photo_ResultSet>> AddPhoto(string photo_name, string photo_tail);
        Task<Generic_ResultSet<Photo_ResultSet>> UpdatePhoto(Int64 id, string photo_name, string photo_detail);
        Task<Generic_ResultSet<bool>> DeletePhoto(Int64 id);

    }
}

