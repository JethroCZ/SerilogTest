using System;
using System.Threading.Tasks;
using Castle.Core.Logging;

namespace SerilogTest
{
    public class App : IApp
    {
        private readonly ILogger m_logger;

        public App(ILogger logger)
        {
            m_logger = logger;
        }

        public void RunApplication()
        {
            // Vytvoření konfigurace z JSON souboru (může být i zanořená ve webapi.json, serilog si vezme svoji část)
            Parallel.For(0, 10, (iteration) =>
                {
                    // Otestování jednotlivých záznamů, podle nastavení v JSON se budou zapisovat 
                    // pouze do konzole
                    m_logger.Trace($"Zapisuji iteraci {iteration}: Trace");
                    m_logger.Debug($"Zapisuji iteraci {iteration}: Debug");


                    // do konzole a do souboru
                    m_logger.Info($"Zapisuji iteraci {iteration}: Information");
                    m_logger.Warn($"Zapisuji iteraci {iteration}: Warning");
                    m_logger.Error($"Zapisuji iteraci {iteration}: Error");

                    //// do konzole, souboru, a odešle se i email
                    m_logger.Fatal($"Zapisuji iteraci {iteration}: Fatal");
                }
            );
            
            Console.WriteLine("Hello World!");
        }
    }
}