using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calc.WebApi.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace calc.WebApi
{
    [Route("api/[controller]")]
    public class CalcController : ControllerBase
    {
        CalcFacade calc;
        public CalcController()
        {
            calc = new CalcFacade();
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]string value)
        {
            var result = calc.Action(value);

            return result;
        }

    }
}
