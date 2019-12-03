using System;
using Castle.Core.Logging;

namespace SerilogTest
{
    public class App : IApp
    {
        private readonly ILogger m_logger;
        private string m_ndc = string.Empty;

        public App(ILogger logger)
        {
            m_logger = logger;
        }

        public void RunApplication()
        {
            ShowDebug();
            ShowError();
        }

        private void ShowDebug()
        {
            Console.WriteLine("Zápis do logu: typ Debug.");
            m_logger.Debug("Toto je Debugovací zpráva.");
        }

        private void ShowError()
        {
            Console.WriteLine("Zápis do logu: typ Error.");
            m_logger.Error("Toto je Chybová zpráva.");
        }
    }
}