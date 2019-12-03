using System;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Debugging;

namespace SerilogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
#if DEBUG
            SelfLog.Enable(msg => Debug.WriteLine(msg));
#endif
            startup.Run();
        }
    }
}
