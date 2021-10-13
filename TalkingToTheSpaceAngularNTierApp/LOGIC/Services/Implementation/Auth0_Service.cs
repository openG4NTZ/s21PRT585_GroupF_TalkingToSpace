﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Auth0_Service
    {
        public async void Auth0Post()
        {
            var client = new RestClient("https://dev-om53k5ag.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"Eq54gdPB6yDfhHTB8OM9BqMR4c8YPbNu\",\"client_secret\":\"-xGe0vdswBk6qGKf2zSLTMM6bNQkUxc8PBxqhDprl-eeovVXlLFXYaWFmnJZX8DK\",\"audience\":\"https://talking-to-the-space/user/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //return response.Content.ToString();
            Console.WriteLine(response.Content.ToString());
        }
    }
}
