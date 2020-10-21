﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace ApiMedical.Common.Token
{
   public class TokenService: ITokenService
    {
        private readonly IHttpContextAccessor contextAccessor;
        public TokenService(IHttpContextAccessor _contextAccessor)
        {
            this.contextAccessor = _contextAccessor;
        }
        public string GetCurrentUser() {
            var user = contextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(user);
            var tokenS = handler.ReadToken(user) as JwtSecurityToken;
            var userName = tokenS.Claims.FirstOrDefault().Value;
            return userName;
        }
    }
}
