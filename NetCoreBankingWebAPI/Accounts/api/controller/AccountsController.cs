using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreBankingWebAPI.Accounts
{
    [Route("api/[controller]")]
    public class AccountsController {

                // GET api/Accounts
        [HttpGet]
        public string Get()
        {
             return "Hola Mundo";
        }
    }
}
