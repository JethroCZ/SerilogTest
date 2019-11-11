using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SerilogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření konfigurace z JSON souboru (může být i zanořená ve webapi.json, serilog si vezme svoji část)
            var configuration = new ConfigurationBuilder().AddJsonFile("serilog_cfg.json").Build();

            // using zde používám jen pro nanucení dispose aby se odeslal ten email hnedka
            using (var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger())
            {
                // Otestování jednotlivých záznamů, podle nastavení v JSON se budou zapisovat 
                // pouze do konzole
                logger.Verbose("Zapisuji: Verbose");
                logger.Debug("Zapisuji: Debug");
                
                // do konzole a do souboru
                logger.Information("Zapisuji: Information");
                logger.Warning("Zapisuji: Warning");
                logger.Error("Zapisuji: Error");

                // do konzole, souboru, a odešle se i email
                logger.Fatal("Zapisuji: Fatal");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
