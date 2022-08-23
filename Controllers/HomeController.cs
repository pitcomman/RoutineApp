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
using Newtonsoft.Json;


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
        public JsonResult GetOperatorDetail(String opid, String operatorName)
        {   

            Console.WriteLine("OPID" + opid);
            RoutineApp.Process.OperatorDetail_API API = new RoutineApp.Process.OperatorDetail_API();
            // Json(API.API_GetOperatorDetailById(opid))
            // API.API_GetOperatorDetailById("010130");
            // return Ok("Ok");

            // List<User> users = new List<User>();

            // var user = new User()
            // {
            //     Email = email,
            //     Name = name,
            //     // Phone = phone
            // };
            Console.WriteLine(API.API_GetOperatorDetailById(opid, operatorName));
            return Json(API.API_GetOperatorDetailById(opid, operatorName));
        }

        // [HttpPost]
        // public JsonResult ImportExcel(IFormFile  myExcelData)
        // {


        //     if(myExcelData?.Length > 0)
        //         {
        //             // convert to a stream
        //             var stream = myExcelData.OpenReadStream();

        //             try
        //             {
        //                 using(var package = new ExcelPackage(stream))
        //                 {
        //                     var worksheet = package.Workbook.Worksheets.First();
        //                     var rowCount = worksheet.Dimension.Rows;
        //                     var columnCount = worksheet.Dimension.Columns;

        //                     for(var row = 2; row <= rowCount; row++)
        //                     {

        //                         DataTable  dtTemp = new DataTable ();

        //                         // DataRow dtRow = new DataRow();
                                
        //                         DataRow dtRow = dtTemp.NewRow();

        //                         for(var column = 1; column <= columnCount; column++)
        //                         {
        //                             DataColumn dtColumn = new DataColumn();
        //                             dtColumn.DataType = typeof(String);
        //                             dtColumn.ColumnName = worksheet.Cells[1, column].Value?.ToString();
        //                             dtTemp.Columns.Add(dtColumn);

        //                             dtRow[dtColumn.ColumnName] = worksheet.Cells[row, column].Value?.ToString();

        //                             // dictTemp.Add(dtColumn.ColumnName, worksheet.Cells[row, column].Value?.ToString());

        //                         }

        //                     }

        //                 }


        //                 Console.WriteLine(JsonConvert.SerializeObject(Json(dtRow)));
        //                 return Json(JsonConvert.SerializeObject(Json(dtRow)));
        //                 // return Ok(JsonConvert.SerializeObject(users));
        //             }
        //             catch(Exception ex)
        //             {
        //                 Console.WriteLine(ex.Message);
        //                 return Json(null);
        //             }
        //         }



        //     return null;
        // }

        [HttpPost]
        public JsonResult ImportExcel(IFormFile  myExcelData)
        {

            if(myExcelData?.Length > 0)
            {
                // convert to a stream
                var stream = myExcelData.OpenReadStream();

                List<User> users = new List<User>();
                List<DataTable> datatables = new List<DataTable>();
                List<DataRow> dataRows = new List<DataRow>();
                DataSet dtSet = new DataSet();


                try
                {
                    using(var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;
                        var columnCount = worksheet.Dimension.Columns;

                        // for(var column = 1; column <= columnCount; column++)
                        // {
                        //     DataColumn dtColumn = new DataColumn();
                        //     dtColumn.DataType = typeof(String);
                        //     dtColumn.ColumnName = worksheet.Cells[1, column].Value?.ToString();
                        //     dtTemp.Columns.Add(dtColumn);
                        // }

                        for(var row = 2; row <= rowCount; row++)
                        {

                            DataTable  dtTemp = new DataTable ();

                            // DataRow dtRow = new DataRow();
                            
                            DataRow dtRow = dtTemp.NewRow();

                            for(var column = 1; column <= columnCount; column++)
                            {
                                DataColumn dtColumn = new DataColumn();
                                dtColumn.DataType = typeof(String);
                                dtColumn.ColumnName = worksheet.Cells[1, column].Value?.ToString();
                                dtTemp.Columns.Add(dtColumn);

                                dtRow[dtColumn.ColumnName] = worksheet.Cells[row, column].Value?.ToString();
                            }
                            
                            dtTemp.Rows.Add(dtRow);
                            dataRows.Add(dtRow);
                            datatables.Add(dtTemp);
                            dtSet.Tables.Add(dtTemp);

                        }

                    }


                    Console.WriteLine(JsonConvert.SerializeObject(Json(datatables)));
                    return Json(JsonConvert.SerializeObject(Json(datatables)));
                    // return Ok(JsonConvert.SerializeObject(users));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Json(null);
                }
            }
            return Json(null);
        }

        // [HttpPost]
        // public JsonResult ImportExcel(IFormFile  myExcelData)
        // {

        //     if(myExcelData?.Length > 0)
        //     {
        //         // convert to a stream
        //         var stream = myExcelData.OpenReadStream();

        //         List<User> users = new List<User>();


        //         try
        //         {
        //             using(var package = new ExcelPackage(stream))
        //             {
        //                 var worksheet = package.Workbook.Worksheets.First();
        //                 var rowCount = worksheet.Dimension.Rows;

        //                 for(var row = 2; row <= rowCount; row++)
        //                 {
        //                     try
        //                     {
        //                         var name = worksheet.Cells[row, 1].Value?.ToString();
        //                         var email = worksheet.Cells[row, 2].Value?.ToString();
        //                         // var phone = worksheet.Cells[row, 3].Value?.ToString();

        //                         var user = new User()
        //                         {
        //                             Email = email,
        //                             Name = name,
        //                             // Phone = phone
        //                         };

        //                         users.Add(user);
        //                     }
        //                     catch(Exception ex)
        //                     {
        //                         Console.WriteLine(ex.Message);
        //                     }
        //                 }
        //             }


        //             Console.WriteLine(JsonConvert.SerializeObject(Json(users)));
        //             return Json(users);
        //             // return Ok(JsonConvert.SerializeObject(users));
        //         }
        //         catch(Exception ex)
        //         {
        //             Console.WriteLine(ex.Message);
        //             return Json(null);
        //         }
        //     }
        //     return Json(null);
        // }


        // [HttpGet]
        // public IActionResult GetOperatorDetail(string opid)
        // {   

        //     Console.WriteLine("OPID" + opid);
        //     RoutineApp.Process.OperatorDetail_API API = new RoutineApp.Process.OperatorDetail_API();
        //     // API.API_GetOperatorDetailById("010130");
        //     // return Ok("Ok");
        //     return Ok(Json(API.API_GetOperatorDetailById(opid)));
        // }


        // [HttpPost]
        // public IActionResult ImportExcel(IFormFile  myExcelData)
        // {

        //     if(myExcelData?.Length > 0)
        //     {
        //         // convert to a stream
        //         var stream = myExcelData.OpenReadStream();

        //         List<User> users = new List<User>();

        //         try
        //         {
        //             using(var package = new ExcelPackage(stream))
        //             {
        //                 var worksheet = package.Workbook.Worksheets.First();
        //                 var rowCount = worksheet.Dimension.Rows;

        //                 for(var row = 2; row <= rowCount; row++)
        //                 {
        //                     try
        //                     {
        //                         var name = worksheet.Cells[row, 1].Value?.ToString();
        //                         var email = worksheet.Cells[row, 2].Value?.ToString();
        //                         // var phone = worksheet.Cells[row, 3].Value?.ToString();

        //                         var user = new User()
        //                         {
        //                             Email = email,
        //                             Name = name,
        //                             // Phone = phone
        //                         };

        //                         users.Add(user);
        //                     }
        //                     catch(Exception ex)
        //                     {
        //                         Console.WriteLine(ex.Message);
        //                     }
        //                 }
        //             }

        //             return Ok(Json(users));
        //             // return Ok(JsonConvert.SerializeObject(users));
        //         }
        //         catch(Exception ex)
        //         {
        //             Console.WriteLine(ex.Message);
        //             return NotFound();
        //         }
        //     }
        //     return NotFound();
        // }

        [HttpPost]
        public JsonResult AddMCROperator(String opid)
        {

            Console.WriteLine("Welcome AddMCROperator : " + opid);
            RoutineApp.Process.OperatorDetail_API API = new RoutineApp.Process.OperatorDetail_API();
            DataSet empDetail = (DataSet)JsonConvert.DeserializeObject(API.API_GetOperatorDetailById(opid, ""), (typeof(DataSet)));

            // DataTable dbTemp = empDetail.datatables[0]

            

            Console.WriteLine("TableDetail:" + empDetail.Tables[0]);

            Console.WriteLine("Winwin");
                        // if (!string.IsNullOrEmpty(opId))

            

            // RoutineApp.Process.MCR_AddOperator mcrOperator = new RoutineApp.Process.MCR_AddOperator();
            // mcrOperator.MCR_AddOperator_ProcessControl(empDetail);


            return Json(JsonConvert.SerializeObject(empDetail));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
