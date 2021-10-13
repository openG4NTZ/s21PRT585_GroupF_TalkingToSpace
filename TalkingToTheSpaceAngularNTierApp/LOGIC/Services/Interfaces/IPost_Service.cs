using LOGIC.Services.Models;
using LOGIC.Services.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IPost_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Post_ResultSet>>> GetAllPosts();
        Task<Generic_ResultSet<Post_ResultSet>> GetPostById(Int64 id);

        //Task<Generic_ResultSet<Post_ResultSet>> GetPostByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Post_ResultSet>> AddPost(string post_name, string post_detail);
        Task<Generic_ResultSet<Post_ResultSet>> UpdatePost(Int64 id, string post_name, string post_detail);
        Task<Generic_ResultSet<bool>> DeletePost(Int64 id);

    }
}

