using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWEBApi.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("get-all-authors")]
        public string GetAll()
        {
            return "Hello from get";
        }
        [Route("get-all-authors")]
        public string GetAllAuthors()
        {
            return "Hello from get";
        }
    }
}