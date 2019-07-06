using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using model;

namespace Company.Function
{
    public static class HttpTriggerCSharp
    {
        [FunctionName("HttpTriggerCSharp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Message data = JsonConvert.DeserializeObject<Message>(requestBody);
            name = name ?? data?.name;
try
{
    
            BloggingContext context = new BloggingContext();
            context.Blogs.Add(new Blog {Message= $"{DateTime.Now.ToShortTimeString()}:{name}" });
            await context.SaveChangesAsync();
}
catch (System.Exception ex)
{
    
    name=ex.ToString();
}

            return name != null
                ? (ActionResult)new OkObjectResult($"{name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
