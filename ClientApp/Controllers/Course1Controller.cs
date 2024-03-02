using CourseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;
using static ClientApp.Controllers.LoginController;

namespace ClientApp.Controllers
{
    public class Course1Controller : Controller
    {
        // GET: CourseController

        public async Task<ActionResult> Index()
        {
            string ErrorMsg = string.Empty;

            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string token = string.Empty;
                if(HttpContext.Session.GetString("token") != null)
                {
                   token = HttpContext.Session.GetString("token").ToString();
                }
                if(token!=null)
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    List<Student> student = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);
                    return View(student);

                }
                else
                {
                    ErrorMsg = response.ReasonPhrase;
                    ViewBag.msg = ErrorMsg;
                    return View();
                }

            }

        }


         

        // GET: CourseController/Details/5
        
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/id");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return View(student);

                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine("Internal server Error");
                }

            }

            return View();

        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5164/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    JsonConvert.SerializeObject(collection);
                    string token = string.Empty;
                    if (HttpContext.Session.GetString("token") != null)
                    {
                        token = HttpContext.Session.GetString("token").ToString();
                    }
                    if (token != null)

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var requestContent = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/Student", requestContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        string ErrorMsg = response.ReasonPhrase;
                        ViewBag.msg = ErrorMsg;
                        return View();
                    }
                }
            }

            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/id");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return View(student);

                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine("Internal server Error");
                    return View();
                }

            }


        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5164/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    JsonConvert.SerializeObject(collection);
                    var requestContent = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync("api/Student/id", requestContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                        return RedirectToAction(nameof(Index));

                    }
                    else
                        return View();
                }
            }

            catch
            {
                return View();
            }
        }
          
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/id");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return View(student);

                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine("Internal server Error");
                    return View();
                }

            }


        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5164/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  

                    //var requestContent = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.DeleteAsync("api/Student/id");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        Student student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                        return RedirectToAction(nameof(Index));

                    }
                    else
                        return View();
                }
            }

            catch
            {
                return View();
            }
        }

    }
}

