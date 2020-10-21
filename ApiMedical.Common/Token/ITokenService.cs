using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Common.Token
{
   public interface ITokenService
    {
        string GetCurrentUser();
    }
}
