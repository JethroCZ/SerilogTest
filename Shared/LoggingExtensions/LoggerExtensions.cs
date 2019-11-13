using System;
using Serilog;
using Serilog.Configuration;
using Shared.Enrichers;

namespace Shared.LoggingExtensions
{
    public static class LoggerExtensions
    {
        public static LoggerConfiguration WithOperationSystem(
            this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
            {
                throw new ArgumentNullException(nameof(enrich));
            }

            return enrich.With<OperationSystemEnricher>();
        }

        public static LoggerConfiguration WithServerStart(
            this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
            {
                throw new ArgumentNullException(nameof(enrich));
            }

            return enrich.With<ServerStartEnricher>();
        }

        public static LoggerConfiguration WithLoggedUser(
            this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
            {
                throw new ArgumentNullException(nameof(enrich));
            }

            return enrich.With<LoggedUserEnricher>();
        }
    }
}