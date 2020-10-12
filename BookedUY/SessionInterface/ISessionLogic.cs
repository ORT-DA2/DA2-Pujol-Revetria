using Domain;
using System;

namespace SessionInterface
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(string token);
        string GenerateToken(Administrator admin);
    }
}
