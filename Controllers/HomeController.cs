using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RoutineApp.Models;


using System.Drawing;
using OfficeOpenXml;
using RoutineApp.Models;


using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;



// using EPPlus.Core;

// using System.Data;p
// using System.Data.OleDb;
// using System.IO.Path;
// using System.Web;
// using OfficeOpenXml;






namespace RoutineApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChangeProcessCode()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetOperatorDetail(string opid)
        {   

            Console.WriteLine("OPID" + opid);
            RoutineApp.Process.OperatorDetail_API API = new RoutineApp.Process.OperatorDetail_API();
            // API.API_GetOperatorDetailById("010130");
            // return Ok("Ok");
            return Ok(Json(API.API_GetOperatorDetailById(opid)));
        }


        [HttpPost]
        public IActionResult ImportExcel(IFormFile  myExcelData)
        {

            if(myExcelData?.Length > 0)
            {
                // convert to a stream
                var stream = myExcelData.OpenReadStream();

                List<User> users = new List<User>();

                try
                {
                    using(var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;

                        for(var row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                var name = worksheet.Cells[row, 1].Value?.ToString();
                                var email = worksheet.Cells[row, 2].Value?.ToString();
                                // var phone = worksheet.Cells[row, 3].Value?.ToString();

                                var user = new User()
                                {
                                    Email = email,
                                    Name = name,
                                    // Phone = phone
                                };

                                users.Add(user);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }

                    return Ok(Json(users));
                    // return Ok(JsonConvert.SerializeObject(users));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return NotFound();
                }
            }
            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
