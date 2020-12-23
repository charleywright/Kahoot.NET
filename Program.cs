using System;

namespace Kahoot.NET
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Kahoot test = new Kahoot(135336, "test");
            test.Join().Wait();
        }
    }
}
