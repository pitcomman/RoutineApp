#pragma checksum "D:\Temporary File\RoutineApp\Views\Home\ChangeProcessCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15747493274a2e8bdba766101d517fda0a58ecfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ChangeProcessCode), @"mvc.1.0.view", @"/Views/Home/ChangeProcessCode.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Temporary File\RoutineApp\Views\_ViewImports.cshtml"
using RoutineApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Temporary File\RoutineApp\Views\_ViewImports.cshtml"
using RoutineApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15747493274a2e8bdba766101d517fda0a58ecfe", @"/Views/Home/ChangeProcessCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f17935f7075e8fec3185a7e268b598ac7cb307dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ChangeProcessCode : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoutineApp.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Temporary File\RoutineApp\Views\Home\ChangeProcessCode.cshtml"
  
    ViewData["Title"] = "Change ProcessCode";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br><br>
<h1 class = ""text-center text-uppercase font-weight-bolder"">Change ProcessCode</h1>
<hr></hr>


<div class = ""text-center"">
    <div class = ""row"">
        <label class = ""col-md-3"">Upload an Excel</label>
        <div class = ""col-md6"">
            <input type = ""file"" id = ""fuExcel""/>
        </div>
        <div class = ""col-md-3"">
            <button id = ""btnUpload"" class = ""btn btn-success"">Upload</button>
        </div>
    </div>


    <div class = ""Search"">

        <div class=""input-field"">
            <input id = ""op-input"" type=""opid"" placeholder=""Operator ID"" autocomplete=""nope"">
        </div>
        <button id = ""btnGetOp"" class = ""btn btn-success"">Search Operator</button>
    </div>


");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n    <a>");
#nullable restore
#line 60 "D:\Temporary File\RoutineApp\Views\Home\ChangeProcessCode.cshtml"
  Write(ViewData["City"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
</div>

<script>
    $(document).ready(function(){
        $(""#btnUpload"").click(function(){

            var formData = new FormData();
            var fuUploadFile = document.getElementById(""fuExcel"");
            var myFile = fuUploadFile.files[0];
            formData.append(""myExcelData"", myFile);

            $.ajax({
                type:'POST',
                url:'");
#nullable restore
#line 74 "D:\Temporary File\RoutineApp\Views\Home\ChangeProcessCode.cshtml"
                Write(Url.Action("ImportExcel", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                contentType: false,
                processData: false,
                data: formData,
                dataType: 'Json',
                success:function(data){
                    console.log(data)
                    console.log(data.value[0].name)
                    console.log(data.value[0])

                    var column = data.value[0]

                    for(var key in column){
                        console.log(key)
                    }


");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"                }
            })
        })

        $(""#btnGetOp"").click(function(){

            var formData = new FormData();
            formData.append(""opid"", ""010130"")
            console.log(document.getElementById(""op-input"").value)
            

            var opid = document.getElementById(""op-input"").value

            $.ajax({
                type:'GET',
                url:'");
#nullable restore
#line 117 "D:\Temporary File\RoutineApp\Views\Home\ChangeProcessCode.cshtml"
                Write(Url.Action("GetOperatorDetail", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                data: {opid:opid},\r\n                success:function(data){\r\n                    console.log(data)\r\n                }\r\n\r\n            })\r\n        })\r\n\r\n\r\n");
            WriteLiteral("\r\n    })\r\n</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoutineApp.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
