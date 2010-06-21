using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
//http://www.aspheute.com/english/20040105.asp

namespace FinalProject
{
    class MyHashAlg
    {
        public static int CreateRandomSalt()
        {
            Byte[] _saltBytes = new Byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(_saltBytes);

            return ((((int)_saltBytes[0]) << 24) + (((int)_saltBytes[1]) << 16) +
              (((int)_saltBytes[2]) << 8) + ((int)_saltBytes[3]));
        }

        public string Hash(int _salt, string _password)
        {
            // Create Byte array of password string
            ASCIIEncoding encoder = new ASCIIEncoding();
            Byte[] _secretBytes = encoder.GetBytes(_password);

            // Create a new salt
            Byte[] _saltBytes = new Byte[4];
            _saltBytes[0] = (byte)(_salt >> 24);
            _saltBytes[1] = (byte)(_salt >> 16);
            _saltBytes[2] = (byte)(_salt >> 8);
            _saltBytes[3] = (byte)(_salt);

            // append the two arrays
            Byte[] toHash = new Byte[_secretBytes.Length + _saltBytes.Length];
            Array.Copy(_secretBytes, 0, toHash, 0, _secretBytes.Length);
            Array.Copy(_saltBytes, 0, toHash, _secretBytes.Length, _saltBytes.Length);

            SHA1Managed sha1 = new SHA1Managed();
            Byte[] computedHash = sha1.ComputeHash(toHash);

            return encoder.GetString(computedHash);
        }
        public static string Hash(string _password)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            Byte[] _secretBytes = encoder.GetBytes(_password);

            // append the two arrays
            Byte[] toHash = new Byte[_secretBytes.Length];
            Array.Copy(_secretBytes, 0, toHash, 0, _secretBytes.Length);

            SHA1Managed sha1 = new SHA1Managed();
            Byte[] computedHash = sha1.ComputeHash(toHash);

            return encoder.GetString(computedHash);
        }
    }
}
