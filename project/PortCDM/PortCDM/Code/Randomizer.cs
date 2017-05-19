using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public static class Randomizer
    {
        private static readonly Random random = new Random();

        public static string genRandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string genRandomStringAF(int length)
        {
            const string chars = "ABCDEFabcdef0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string genRandomStringAB89(int length)
        {
            const string chars = "ABab89";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string genRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}