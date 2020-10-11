using SessionInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class SessionLogic : ISessionLogic
    {
        public bool IsCorrectToken(string token)
        {
            return true;
        }
    }
}
