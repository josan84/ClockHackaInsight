using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSBroadcastController : ControllerBase
    {
        // GET: api/SMS
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // POST: api/SMS
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SMS/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
