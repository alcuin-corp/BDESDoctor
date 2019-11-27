using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Monitoring
{
    internal class MonitoringManager : IMonitoringManager
    {
        private readonly IFileSystem fileSystem;

        public MonitoringManager(Request requestResult)
        {
            ServiceLocator.Resolve(out this.fileSystem);
            this.Request = requestResult;
        }

        public Request Request { get; }

        public void AppendMessage(string monitoringCode, string monitoringMessage)
        {
            this.Request.AppendMessage(monitoringCode, monitoringMessage);
        }

        public void Dump(string logPath)
        {
            try
            {
                this.fileSystem.File.AppendAllLines(logPath, this.GetLogLines());
            }
            catch (Exception)
            {
            }
        }

        private List<string> GetLogLines()
        {
            var log = new List<string>();
            var errorCount = this.Request.PublishedMessages.TryGetValue(MonitoringCodes.Error, out var errors) ? errors.Count : 0;
            var warrningCount = this.Request.PublishedMessages.TryGetValue(MonitoringCodes.Warrning, out var warrnings) ? warrnings.Count : 0;
            log.Add($"Le programme a détecté {errorCount} erreur(s) et {warrningCount} avertissement(s) dans votre fichier.");

            if (errorCount > 0)
            {
                log.Add("ERREUR(S)");
                log.AddRange(errors.Select(x => $"{x.Step}|{x.Message}"));
            }

            if (warrningCount > 0)
            {
                log.Add("AVERTISSEMENT(S)");
                log.AddRange(warrnings.Select(x => $"{x.Step}|{x.Message}"));
            }

            return log;
        }
    }
}
