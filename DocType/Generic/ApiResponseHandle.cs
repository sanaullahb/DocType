using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Xml.Linq;




namespace DocType.Generic
{
    public class ApiResponseModel : IResult
    {


        public bool IsApiHandled { get; set; }
        public bool IsRequestSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = "";
        public Object Data { get; set; } = new object();
        public Object Exception { get; set; } = new List<string>();
        public async Task ExecuteAsync(HttpContext httpContext)
        {
            var response = httpContext.Response;
            response.StatusCode = StatusCode;
            response.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            await response.WriteAsync(json);
        }
    }
}




