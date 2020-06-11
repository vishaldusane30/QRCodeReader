using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using QRCODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace QRCODE.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        //public IActionResult Read()
        public async System.Threading.Tasks.Task<HttpResponseMessage> Read(IFormFile file)
        {
            string url = $"http://goqr.me/api/doc/read-qr-code/";

            IFormFile file2 = file;
            try
            {
                if (file2 != null || file2.Length != 0)
                {
                    using (var client = new HttpClient())
                    {

                        Uri u = new Uri(url);
                        var payload = "{\"file\":" + file2 + "}";

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                        var t = await Task.Run(() => client.PostAsync(u, c));
                        HttpResponseMessage responseBody = await client.PostAsync(u, c);

                        Console.WriteLine(responseBody);
                        Console.ReadLine();


                    }
                }
            }
            catch (Exception ex)
            { }
            return null;

        }
    }
}