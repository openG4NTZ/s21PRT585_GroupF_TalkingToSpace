using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Post post Data
    /// </summary>
    public class Post_Service : IPost_Service
    {
        //Reference to our crud functions
        private IPost_Operations _post_operations = new Post_Operations();

        /// <summary>
        /// Obtains all the Post postes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Post_ResultSet>>> GetAllPosts()
        {
            Generic_ResultSet<List<Post_ResultSet>> result = new Generic_ResultSet<List<Post_ResultSet>>();
            try
            {
                //GET ALL Post postES
                List<Post> Postes = await _post_operations.ReadAll();
                //MAP DB Post RESULTS
                result.result_set = new List<Post_ResultSet>();
                Postes.ForEach(s =>
                {
                    result.result_set.Add(new Post_ResultSet
                    {
                        post_id = s.Post_ID,
                        post_name = s.Post_Name,
                        post_detail = s.Post_Detail
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Post postes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Post_Service: GetAllPosts() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Post postes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Post_Service: GetAllPosts(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Post_ResultSet>> GetPostById(long id)
        {
            Generic_ResultSet<Post_ResultSet> result = new Generic_ResultSet<Post_ResultSet>();
            try
            {
                //GET by ID Post 
                var Post = await _post_operations.Read(id);

                //MAP DB Post RESULTS
                result.result_set = new Post_ResultSet
                {
                    post_id = Post.Post_ID,
                    post_name = Post.Post_Name,
                    post_detail = Post.Post_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Post  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Post_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Post  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Post_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new post to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Post_ResultSet>> AddPost(string post_name, string post_detail)
        {
            Generic_ResultSet<Post_ResultSet> result = new Generic_ResultSet<Post_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Post
                Post Post = new Post
                {
                    Post_Name = post_name,
                    Post_Detail = post_detail
                };

                //ADD Post TO DB
                Post = await _post_operations.Create(Post);

                //MANUAL MAPPING OF RETURNED Post VALUES TO OUR Post_ResultSet
                Post_ResultSet postAdded = new Post_ResultSet
                {
                    post_name = Post.Post_Name,
                    post_detail = Post.Post_Detail,
                    post_id = Post.Post_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Post post {0} was added successfully", post_name);
                result.internalMessage = "LOGIC.Services.Implementation.Post_Service: AddPost() method executed successfully.";
                result.result_set = postAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Post post supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Post_Service: AddPost(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Post posts name.
        /// </summary>
        /// <param name="post_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Post_ResultSet>> UpdatePost(Int64 post_id, string post_name, string post_detail)
        {
            Generic_ResultSet<Post_ResultSet> result = new Generic_ResultSet<Post_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Post
                Post Post = new Post
                {
                    Post_ID = post_id,
                    Post_Name = post_name,
                    Post_Detail = post_detail
                    //Post_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Post IN DB
                Post = await _post_operations.Update(Post, post_id);

                //MANUAL MAPPING OF RETURNED Post VALUES TO OUR Post_ResultSet
                Post_ResultSet postUpdated = new Post_ResultSet
                {
                    post_name = Post.Post_Name,
                    post_id = Post.Post_ID,
                    post_detail = Post.Post_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Post post {0} was updated successfully", post_id);
                result.internalMessage = "LOGIC.Services.Implementation.Post_Service: UpdatePost() method executed successfully.";
                result.result_set = postUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Post post supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Post_Service: UpdatePost(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeletePost(long post_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {               
                //delete Post IN DB
                var postDeleted= await _post_operations.Delete(post_id);
                
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Post post {0} was deleted successfully", post_id);
                result.internalMessage = "LOGIC.Services.Implementation.Post_Service: DeletePost() method executed successfully.";
                result.result_set = postDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Post post supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Post_Service: DeletePost(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
