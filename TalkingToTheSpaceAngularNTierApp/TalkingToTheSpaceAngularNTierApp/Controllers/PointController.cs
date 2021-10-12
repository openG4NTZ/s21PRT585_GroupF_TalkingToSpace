using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Point;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private IPoint_Service _Point_Service;

        public PointController(IPoint_Service Point_Service)
        {
            _Point_Service = Point_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPoint(string point_amount, Int64 user_id)
        {
            var result = await _Point_Service.AddPoint(point_amount, user_id);
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
        public async Task<IActionResult> GetAllPoints()
        {
            var result = await _Point_Service.GetAllPoints();
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
        public async Task<IActionResult> UpdatePoint(Int64 point_id, string point_amount, Int64 user_id)
        {
            var result = await _Point_Service.UpdatePoint(point_id, point_amount, user_id);
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
        public async Task<IActionResult> DeletePoint(Point_Pass_Object point)
        {
            var result = await _Point_Service.DeletePoint(point.point_id);
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
