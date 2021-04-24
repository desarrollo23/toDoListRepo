using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ToDoList.Infraestructure.Utils.Security
{
    public class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder sb = new StringBuilder();
            var stream = sha256.ComputeHash(encoding.GetBytes(password));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
