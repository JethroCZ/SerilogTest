using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SerilogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            startup.Run();
        }
    }
}
