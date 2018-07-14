using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Api.Controller;
using Common.constantes;
using Customer.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Security.application;
using System.Text;

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
              var token = GenerateToken(customer.User);
                return Ok(this.responseHandler.getOkCommandResponse("bearer " + token, Constantes.HttpStatus.Success, customerDtoResponse));
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

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var TokenSecret = Environment.GetEnvironmentVariable("BankingAPITokenSecret");
            Console.WriteLine(TokenSecret);

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret)), 
                                             SecurityAlgorithms.HmacSha256)),
                    new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}