using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Post;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPost_Service _Post_Service;

        public PostController(IPost_Service Post_Service)
        {
            _Post_Service = Post_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPost(string post_name, string post_detail)
        {
            var result = await _Post_Service.AddPost(post_name, post_detail);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _Post_Service.GetAllPosts();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePost(Post_Pass_Object post)
        {
            var result = await _Post_Service.UpdatePost(post.id ,post.post_name, post.post_detail);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeletePost(Post_Pass_Object post)
        {
            var result = await _Post_Service.DeletePost(post.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
