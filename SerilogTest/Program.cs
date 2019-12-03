using System.Diagnostics;
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
