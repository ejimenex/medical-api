using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMedical.Dtos;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IAccount acc;
        public AccountController(IAccount _acc) 
        {
            acc = _acc;
        }
        [HttpPost]
        public  IActionResult GetUser([FromBody] AccountDto dto)
        {
            try
            {
                var data = acc.VerifyUser(dto.Password,dto.UserName);
                string token = CreateToken(data);
                var datos = new
                {
                    AccessToken = token,
                    ExpireInSeconds = (DateTime.UtcNow.AddDays(1) - DateTime.UtcNow).Seconds,
                    UserName = data.UserName,
                    Id = data.Id,
                    Language=data.LanguageId

                };
                return Ok(datos);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
           
        }
        [HttpPut]
        public IActionResult ChangePassword([FromBody]AccountDto dto)
        {
            try
            {
                var data = acc.ChangePassword(dto.Password,dto.OldPassword, dto.UserName);
                return Ok(data);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

        }

        private string CreateToken(Users user)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetClaims(user));

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://visitas.mardom.com/", audience: "http://visitas.mardom.com/",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        IEnumerable<Claim> GetClaims(Users usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.Email, usuario.UserName),
                new Claim(ClaimTypes.GivenName, usuario.UserName),
                new Claim(ClaimTypes.Actor, usuario.UserName),
            };



            return claims;

        }
    }
}