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


namespace RoutineApp.Process
{
    public class OperatorDetail_API{

        public OperatorDetail_API(){

        }

        public String API_GetOperatorDetailById(String opId, String opName)
        {
            WebClient request = new WebClient();

            String operatorDetailUrl = "http://localhost/PitAPI/HRMS/EmployeeDetail?" ;
            if (!string.IsNullOrEmpty(opId))
            {
                operatorDetailUrl += "&opid="+ opId;
            }

            if (!string.IsNullOrEmpty(opName))
            {
                operatorDetailUrl += "&opName="+ opName;
            }
            
            Console.WriteLine(operatorDetailUrl);

            try
            {
                String json = request.DownloadString(operatorDetailUrl);
                // Byte[] b = System.IO.File.ReadAllBytes(ImageUrl);
                
                return json;
                //return Ok(JsonConvert.SerializeObject(ImageUrl));

            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

            return null;
        }
        
    }

}