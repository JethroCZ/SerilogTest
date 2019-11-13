using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Serilog.Core;
using Serilog.Events;

namespace Shared.Enrichers
{
    public class OperationSystemEnricher : ILogEventEnricher
    {
        private LogEventProperty m_cachedProperty;

        public const string PropertyName = "OperationSystem";

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));
        }

        private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory)
        {
            // Don't care about thread-safety, in the worst case the field gets overwritten and one property will be GCed
            if (m_cachedProperty == null)
            {
                m_cachedProperty = CreateProperty(propertyFactory);
            }

            return m_cachedProperty;
        }

        // Qualify as uncommon-path
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
        {
            var value = RuntimeInformation.OSDescription;
            return propertyFactory.CreateProperty(PropertyName, value);
        }
    }
}