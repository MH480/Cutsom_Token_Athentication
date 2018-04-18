using System;

namespace CustomTokenAuth.ApplicationEnum
{
    public class SignInSecurityKeyAttr : Attribute
    {
        public SignInSecurityKeyAttr(string key)
        {
            SecurityKey = key;
        }

        public string SecurityKey { get; private set; }
    }
}