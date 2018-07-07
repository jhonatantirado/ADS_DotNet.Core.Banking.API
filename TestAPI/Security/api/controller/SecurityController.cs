using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Api.Controller;
using Common.constantes;
using Customer.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Security.application;

namespace Security.api.controller
{
    [Route("api")]
    public class SecurityController : Controller
    {
        ResponseHandler responseHandler;
        ISecurityApplicationService _securityApplicationServic;

        public SecurityController(ISecurityApplicationService SecurityApplicationService)
        {
            _securityApplicationServic = SecurityApplicationService;
            responseHandler = new ResponseHandler();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] CustomerDto customer)
        {
            try
            {
              var customerDtoResponse =   _securityApplicationServic.login(customer);
                return Ok(this.responseHandler.getOkCommandResponse("Is Login!", Constantes.HttpStatus.Success, customerDtoResponse));
            }
            catch (ArgumentException ex)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }
    }
}