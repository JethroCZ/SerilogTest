using System;
using System.Runtime.CompilerServices;
using Serilog.Core;
using Serilog.Events;

namespace Shared.Enrichers
{
    public class LoggedUserEnricher : ILogEventEnricher
    {
        private LogEventProperty m_cachedProperty;
        private string m_user;

        public const string PropertyName = "LoggedUser";

        /// <summary>
        /// tady budu muset ve fisnetu načíst správného uživatele
        /// </summary>
        private const string pomocny_uzivatel = "annonymouse";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));
        }

        private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory)
        {
            // Don't care about thread-safety, in the worst case the field gets overwritten and one property will be GCed
            if (string.IsNullOrEmpty(m_user) || m_user != pomocny_uzivatel)
            {
                m_cachedProperty = CreateProperty(propertyFactory);
            }

            return m_cachedProperty;
        }

        // Qualify as uncommon-path
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
        {
            var value = pomocny_uzivatel;
            return propertyFactory.CreateProperty(PropertyName, value);
        }
    }
}