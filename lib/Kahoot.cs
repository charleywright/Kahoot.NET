using System;
using System.Threading.Tasks;
using static Kahoot.NET.Helpers;
using Kahoot.NET.Structs;

namespace Kahoot.NET
{
    class Kahoot
    {
        private int Pin;
        private string Username;
        private KahootInfo KahootInfo;
        public Kahoot(int Pin, string Username)
        {
            this.Pin = Pin;
            this.Username = Username;
        }

        public Task Join()
        {
            this.KahootInfo = GetKahootInfo(this.Pin);
            this.KahootInfo.token = DecodeToken(this.KahootInfo);
            Console.Write(this.KahootInfo.token);
            return Task.CompletedTask;
        }
    }
}