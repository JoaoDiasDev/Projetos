using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/value/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value 5";
        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody] string value) { }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        [HttpDelete("{id}")]
        public void Delete(int id) { }

    }
}
