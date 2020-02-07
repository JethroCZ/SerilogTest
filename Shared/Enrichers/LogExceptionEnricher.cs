using System;
using System.Runtime.CompilerServices;
using Serilog.Core;
using Serilog.Events;

namespace Shared.Enrichers
{
    public class LogExceptionEnricher : ILogEventEnricher
    {
        public const string PropertyName = "LogException";
        private LogEventProperty m_cachedProperty;
        private Exception _e;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _e = logEvent.Exception;
            //if (logEvent.Level == LogEventLevel.Error || logEvent.Level == LogEventLevel.Fatal)
            if (logEvent.Exception != null)
            {
                logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));
            }
        }

        private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory)
        {
            // Don't care about thread-safety, in the worst case the field gets overwritten and one property will be GCed
            return (m_cachedProperty = CreateProperty(propertyFactory));
        }

        // Qualify as uncommon-path
        [MethodImpl(MethodImplOptions.NoInlining)]
        private LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
        {
            return propertyFactory.CreateProperty(PropertyName, Environment.NewLine + " Exception:" + Environment.NewLine + _e?.GetType() + ": " +_e?.Message + Environment.NewLine + _e?.StackTrace);
        }
    }
}