using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Auth0_Service
    {
        public string Auth0Post()
        {
            var client = new RestClient("https://dev-om53k5ag.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"Eq54gdPB6yDfhHTB8OM9BqMR4c8YPbNu\",\"client_secret\":\"-xGe0vdswBk6qGKf2zSLTMM6bNQkUxc8PBxqhDprl-eeovVXlLFXYaWFmnJZX8DK\",\"audience\":\"https://talking-to-the-space/user/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content.ToString());
            LoadJson(response.Content.ToString());
            return response.Content.ToString();
        }

        public void LoadJson(string json)
        {
            Token token = JsonConvert.DeserializeObject<Token>(json);
            Console.WriteLine(token.access_token);
        }


        public async void SearchUserByUserId(string user_id)
        {
            var client = new RestClient("https://YOUR_DOMAIN/api/v2/users/"+user_id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer YOUR_MGMT_API_ACCESS_TOKEN");
            IRestResponse response = client.Execute(request);
        }
    }

    public class Token
    {
        public string access_token;
        public string scope;
        public string expires_in;
        public string token_type;
    }


}
