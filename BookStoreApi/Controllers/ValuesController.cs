using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("{id:int:min(3)}")]
        [HttpGet]
        public string GetAll(int id)
        {
            return "Hello from get";
        }
        [Route("{id}")]
        [HttpGet]
        public string GetAllAuthors(string id)
        {
            return "Hello from get " + id ;
        }
    }
}