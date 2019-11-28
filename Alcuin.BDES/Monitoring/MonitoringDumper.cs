using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;

namespace Alcuin.BDES.Monitoring
{
    public class MonitoringDumper : IMonitoringDumper
    {
        private readonly IFileSystem fileSystem;

        private Dictionary<Step, string> stepMapper;

        public MonitoringDumper(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.stepMapper = GetStepMapper();
        }

        private static Dictionary<Step, string> GetStepMapper()
        {
            var mapper = new Dictionary<Step, string>();
            mapper.Add(Step.FileAnalyzing, "Vérification du format du fichier");
            mapper.Add(Step.DataAnalyzing, "Vérification du format des données");
            mapper.Add(Step.IndicatorComputing, "Calcul des indicateurs");
            mapper.Add(Step.OutputGeneration, "Génération des fichiers de sortie");
            return mapper;
        }


        public void Dump(Request request)
        {
            var logFilePath = this.GetLogPath(request);
            var logFileLines = this.GetLogLines(request);
            this.CreateFile(logFileLines, logFilePath);
        }

        private void CreateFile(List<string> logLines, string logFilePath)
        {
            try
            {
                this.fileSystem.File.AppendAllLines(logFilePath, logLines);
            }
            catch (Exception)
            {
            }
        }

        private string GetLogLine(MonitoringMessage monitoringMessage)
        {
            var step = this.stepMapper[monitoringMessage.Step];
            return $"{step} | {monitoringMessage.Message}";
        }

        private List<string> GetLogLines(Request request)
        {
            var log = new List<string>();
            var errorCount = request.PublishedMessages.TryGetValue(MonitoringType.Error, out var errors) ? errors.Count : 0;
            var warrningCount = request.PublishedMessages.TryGetValue(MonitoringType.Warrning, out var warrnings) ? warrnings.Count : 0;
            log.Add($"Le programme a détecté {errorCount} erreur(s) et {warrningCount} avertissement(s) dans votre fichier.");

            if (errorCount > 0)
            {
                log.Add("ERREUR(S)");
                log.AddRange(errors.Select(this.GetLogLine));
            }

            if (warrningCount > 0)
            {
                log.Add("AVERTISSEMENT(S)");
                log.AddRange(warrnings.Select(this.GetLogLine));
            }

            return log;
        }

        private string GetLogPath(Request request)
        {
            var logFileName = $"Log-{Path.GetFileNameWithoutExtension(request.FilePath)}.txt";
            var workingDirectory = Path.GetDirectoryName(request.FilePath);
            return Path.Combine(workingDirectory, logFileName);
        }
    }
}
