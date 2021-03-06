using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace EbaniyServer.Auth
{
    internal static class AuthOptions
    {
        internal const int LifeTime = 1;
        internal const string Issuer = "MyIssuer";
        internal const string Audience = "MyServer";
        
        public const string PublicKeyString = "MIIBCgKCAQEAuM1nHDCERx6ZshlMVkRQE06uJKp39YBMjcG80v1rU2qZCvl9G\u002BoccAy1nn5BW\u002BVCY5ZNqJIlhYiNvn2aJxhKjNltGdgQT5jbmtkj666wV1oY39/k37QmjfEqm6kfTlxkh2lXVs4x5ifvR9CFx443efVG/pKIm1hKJ12GGNZ6L\u002BBPoWM8nI\u002BHSM4BrIVJgx\u002BGk11DY0oKdniKr/O8McyjTc9SXQdy0nxPneY/Y5gYaW1e54J\u002BPKvW7k4axv4duOf/S4cWhqEE/ZuEyZqh73RtQOfAiRyx/jL0XEdAtMPMIz/8EKqI3ssW6KZR/9XxuQbKhX7OmhTwVSWVk\u002Bqwn7p9sQIDAQAB";
        private const string privateKeyString = "MIIEpAIBAAKCAQEAuM1nHDCERx6ZshlMVkRQE06uJKp39YBMjcG80v1rU2qZCvl9G\u002BoccAy1nn5BW\u002BVCY5ZNqJIlhYiNvn2aJxhKjNltGdgQT5jbmtkj666wV1oY39/k37QmjfEqm6kfTlxkh2lXVs4x5ifvR9CFx443efVG/pKIm1hKJ12GGNZ6L\u002BBPoWM8nI\u002BHSM4BrIVJgx\u002BGk11DY0oKdniKr/O8McyjTc9SXQdy0nxPneY/Y5gYaW1e54J\u002BPKvW7k4axv4duOf/S4cWhqEE/ZuEyZqh73RtQOfAiRyx/jL0XEdAtMPMIz/8EKqI3ssW6KZR/9XxuQbKhX7OmhTwVSWVk\u002Bqwn7p9sQIDAQABAoIBAFclfZ88fdRv6Lik12vC8SP5sYNW5BTgeLlMiDfTC56doSgcuNPGFbz9MVRZY4brWOBPi7WXnZwX5gfTgTM4cEd1bM6IJkDy63RdO2Qzz7KRqTNBiNO5R4keFiKroTi5typoEai8uak4Yc0y1zNgrGaVtPHttf/TpbxkjQz/b0VNq7qGUQWuaqwkcam3L3Ljlh4EeIrLebi2rxmJGxfwk0W1m4xwT4XQOfV4W/7gVznpprSpJofxHmzALPz2LHGobfbPwpvABfJrD0fDXOcjjfjpqVnydayEsw\u002BcOvrwxxdS0LRvGmKgI62NC7eJnFaTFpsags5AQ1KnmtSmLvLLQgUCgYEA5JeoYn5aH40G3w45Afhf7X8yxyTkbFsB\u002B\u002BX8\u002BQYZKSBKeyOSr/IBjECA1bXy22I/9K1\u002BYT04w\u002BKr5cU\u002BaF9oJaeEAdDQu9fcR9EIYEXULxteDtvCw6Uao4CP7cNcMUFWsS48PxErNBTHyHFdHj5QfHxA2bbGWBsJ7CiYnAlfUJcCgYEAzvWqwLRTcCUVmx/pDPgW9IXmsF6JXVy92t7eoKL6KpzoTmXl4V4CTp7TELQtpj4ICw40wqhksxdO7WuNURrNk69YmIMhV3\u002B/JCncXO10kC6aXc97DSmi0ZBeEJ/QkpcDXDx7VhLA/hMOxyW92mT9SMIJWWJ7c/qy58AEzrVVpPcCgYEArARoBP46CYYRhqboRVBHt6vBZVSgw91UR9\u002BRFz/8jRMsmS9ywg4mFgmwKaIKyAZORGyOLtRoNBgN7REZ3mb1M2i0kL03ZjORI0XsvK2vd2drx1ieXqWOvz0OkggyByq49wno8jiUP1Pn5zFPtmOEI7lI/8xnw4NNWzZNaRYwcK8CgYBsZfQXltuVA3d7lo0kQ9USIgggHIPqKKcwOkd076gEJcbvOSPclLa0oy99skGurxLbZ4du5XBI9U5bwFd2QYmnbtICn7wY7koZEOvgqGbDFgW4WPHkhQhIp0r9fhdqkDosV2lqPcxjx2uYF0aHWxnmv\u002BrRrGlo58hI5iQeeI/xJQKBgQC7ct0xzFpiBY\u002B3yL/eWx\u002Bj/CJtLpvqT\u002B2Ihhw7Rn3anXFmgt/Hj8K\u002BVY6nKoyyG14akopz85vtXJ/hhu2QF9SmN0lVivULv55l5eqwtq46HXGYnEX0L7wsuStUbxmwPWN4ZTc/31xhkEKoTc1A3q/yPV08yIWCr6du/yuvNt/3Sg==";

        internal static SecurityKey PublicKey = GetPublicKey();
        internal static SecurityKey PrivateKey = GetPrivateKey();

        private static SecurityKey GetPublicKey()
        {
            var key = RSA.Create();
            key.ImportRSAPublicKey(source: Convert.FromBase64String(PublicKeyString), bytesRead: out var _);
            return new RsaSecurityKey(key);
        }
        
        private static SecurityKey GetPrivateKey()
        {
            var key = RSA.Create();
            key.ImportRSAPrivateKey(source: Convert.FromBase64String(privateKeyString), bytesRead: out var _);
            return new RsaSecurityKey(key);
        }
    }
}