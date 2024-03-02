using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using CourseApi.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ClientApp.Controllers
{
        public class LoginController : Controller
    {
        HttpClient _httpClient;
        //private readonly HttpClient _httpClient;
        //public LoginController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async Task<ActionResult> Login()
        {

            return View();
        }
        public class JWT
        {
            public string Token { get; set; }
        }
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            string baseUrl = "http://localhost:5164";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string stringData = JsonConvert.SerializeObject(user);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync
        ("/api/login", contentData).Result;
            string stringJWT = response.Content.
        ReadAsStringAsync().Result;
            JWT jwt = JsonConvert.DeserializeObject
        <JWT>(stringJWT);

            HttpContext.Session.SetString("token", jwt.Token);
            ViewBag.Message = HttpContext.Session.GetString("token");   
            ViewBag.Message += "User logged in successfully!";

            
            return View();
        }
    
    }
    }
    //public async Task<AccessToken> AuthenticateAsync()
    //{
    //    var token = RetrieveCachedToken();
    //    if (!string.IsNullOrWhiteSpace(token))
    //        return new() { Token = token };
    //    var result = await _httpClient.PostAsync("api/auth/login", GenerateBody());

    //    result.EnsureSuccessStatusCode();

    //    var response = await result.Content.ReadAsStringAsync();

    //    var deserializedToken = DeserializeResponse<AccessToken>(response);

    //    SetCacheToken(deserializedToken);

    //    return deserializedToken;
    //}

  