using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using model;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] Message value)
        {
            try
            {
                var message = $"{Guid.NewGuid()}:{value.name}";
                CacheDbService db = new CacheDbService("host.docker.internal");
                db.AddValue(message);

                // BloggingContext context = new BloggingContext();
                // Blog entity = new Blog { Message = $"{DateTime.Now.ToShortTimeString()}:{value.name}" };
                // context.Blogs.Add(entity);
                // await context.SaveChangesAsync();
                return message;
            }
            catch (System.Exception ex)
            {

                return ex.ToString();
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
