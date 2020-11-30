#define __IOS__
#define __ANDROID__

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestGitProject.Classes;
using TestGitProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestGitProject.DataService
{
    public class AuthenticationService : IAuthenticationService
    {
        HttpClient client;
        static string role = "none";
        static bool isFirstLogIn = true;
        //readonly Uri baseUri = new Uri(Constants.BaseURL); //Constants is a class

        readonly string serverBase = "https://cmctracker-test.chpc.utah.edu/scripts/App/";


        public AuthenticationService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task Register(string phoneNumber)
        {
        }

        public async Task<System.Net.HttpStatusCode> AuthorizeUser(string username, string verificationCode)
        {
            var postBody = new Dictionary<string, string>()
                {
                    {"username", username},
                    {"password", verificationCode},
                    {"grant_type", "password"}
                };
            var data = JsonConvert.SerializeObject(postBody);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync((serverBase + "token.php"), content);
            if (response.IsSuccessStatusCode)
            {
                //Set the last login
                await client.GetStringAsync(serverBase + "User.php?uname=" + username);

                var result = response.Content.ReadAsStringAsync().Result;
                if (result.ToLower().StartsWith("done", StringComparison.CurrentCulture)) //result is null if valid query
                {
                    var isFirstTimeLogin = "false";
                    //not the first time login
                    if(isFirstTimeLogin == "") { isFirstLogIn = true; }
                    else { isFirstLogIn = true; }

                    return response.StatusCode;
                }
                else{
                    return response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                }
            }
            return response.StatusCode;
        }

        public bool isFirsttimeLogIn(string userName) {
            return isFirstLogIn; 
        }

        public async Task<bool> SendEmailIfUserExists(string email)
        {
            var response = await client.GetStringAsync(serverBase + "X.php?name=" + email);
            return true;
        }

        public async Task<bool> RequestPassword(string username)
        {
            var response = await client.GetStringAsync(serverBase + "X.php?name=" + username);
            return true;
        }

        public async Task<string> SubmitLoginInfo(Dictionary<string, string> loginInfo)
        {
            var data = JsonConvert.SerializeObject(loginInfo);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync((serverBase + "X.php"), content);
            var placesJson = response.Content.ReadAsStringAsync().Result;
            return placesJson.ToLower().Substring(placesJson.Length - 4);
        }
    }
}
