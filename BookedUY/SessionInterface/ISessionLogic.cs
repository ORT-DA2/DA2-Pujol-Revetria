using System;

namespace SessionInterface
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(string token);
    }
}
