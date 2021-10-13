using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Activity;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivity_Service _Activity_Service;

        public ActivityController(IActivity_Service Activity_Service)
        {
            _Activity_Service = Activity_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddActivity(string creation_time, string creation_detail)
        {
            var result = await _Activity_Service.AddActivity(creation_time, creation_detail);
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
        public async Task<IActionResult> GetAllActivitys()
        {
            var result = await _Activity_Service.GetAllActivitys();
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
        public async Task<IActionResult> UpdateActivity(Activity_Pass_Object activity)
        {
            var result = await _Activity_Service.UpdateActivity(activity.id ,activity.creation_time, activity.creation_detail);
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
        public async Task<IActionResult> DeleteActivity(Activity_Pass_Object activity)
        {
            var result = await _Activity_Service.DeleteActivity(activity.id);
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
