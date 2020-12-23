using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Kahoot.NET.Structs;

namespace Kahoot.NET
{
    public static partial class Helpers
    {
        public static string DecodeToken(KahootInfo info)
        {
            Regex exp = new Regex(@"[a-zA-Z0-9]{100}");
            string challengeCode = exp.Match(info.challenge).Value;
            string offsetEval = info.challenge.Substring(161);
            offsetEval = offsetEval.Substring(0, offsetEval.IndexOf(";"));
            string cleanOffsetEval = "";
            foreach (char c in offsetEval)
            {
                List<char> goodChars = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')' };
                if (goodChars.Contains(c)) cleanOffsetEval += c;
            }
            int offset = Convert.ToInt32(new DataTable().Compute(cleanOffsetEval, null));

            string challengeToken = "";
            for (int i = 0; i < challengeCode.Length; i++)
            {
                challengeToken += (char)(((((int)(char)challengeCode[i] * i) + offset) % 77) + 48);
            }
            string token = "";
            info.header = Encoding.UTF8.GetString(Convert.FromBase64String(info.header));
            for (int i = 0; i < info.header.Length; i++)
            {
                int c = (int)info.header[i];
                int mod = (int)challengeToken[i % challengeToken.Length];
                int decodedChar = c ^ mod;
                token += (char)decodedChar;
            }
            return token;
        }
    }

}