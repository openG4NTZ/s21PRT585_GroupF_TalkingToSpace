using LOGIC.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class Auth0Controller
    {
        private Auth0_Service _auth0_Service;
        public Auth0Controller(Auth0_Service auth0_Service)
        {
            _auth0_Service = auth0_Service;
        }

        [HttpPost]
        public async void Auth0Post()
        {
            _auth0_Service.Auth0Post();     
        }

    }
}
