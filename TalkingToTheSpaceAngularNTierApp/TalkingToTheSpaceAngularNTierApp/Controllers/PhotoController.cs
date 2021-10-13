using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Photo;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private IPhoto_Service _Photo_Service;

        public PhotoController(IPhoto_Service Photo_Service)
        {
            _Photo_Service = Photo_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPhoto(string photo_name, string photo_detail)
        {
            var result = await _Photo_Service.AddPhoto(photo_name, photo_detail);
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
        public async Task<IActionResult> GetAllPhotos()
        {
            var result = await _Photo_Service.GetAllPhotos();
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
        public async Task<IActionResult> UpdatePhoto(Photo_Pass_Object photo)
        {
            var result = await _Photo_Service.UpdatePhoto(photo.id ,photo.photo_name, photo.photo_detail);
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
        public async Task<IActionResult> DeletePhoto(Photo_Pass_Object photo)
        {
            var result = await _Photo_Service.DeletePhoto(photo.id);
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
