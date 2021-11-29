using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            using var rsa = RSA.Create();

            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());

            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());

            var json = JsonSerializer.Serialize(new
            {
                Public = publicKey,
                Private = privateKey
            }, new JsonSerializerOptions{ WriteIndented = true});
            
            File.WriteAllText("resaKey.json", json); 
        }
    }
}