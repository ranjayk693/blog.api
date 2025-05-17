using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Helper
{
    public static class EncodingDecoding
    {
        // Encode
        public static string EncodePasswordToBase64(string txt1)
        {
            byte[] encData_byte = new byte[txt1.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(txt1);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        // Decode
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        // Hashing
        public static string HashPassword(string password)
        {
            return Argon2.Hash(password);
        }

        public static bool VerifyPassword(string hash, string password)
        {
            return Argon2.Verify(hash, password);
        }
    }
}