using System.Collections.Generic;
using System.Text;

namespace Alcuin.BDES.Monitoring
{
    internal class MonitoringDumper
    {
        public void Dump(Dictionary<string, List<MonitoringMessage>> allMessages)
        {
            var stringBuilder = new StringBuilder();
            var errorCount = allMessages.TryGetValue(MonitoringCode.Error, out var errors) ? errors.Count : 0;
            var warrningCount = allMessages.TryGetValue(MonitoringCode.Warrning, out var warrnings) ? warrnings.Count : 0;
            stringBuilder.AppendLine($"Le programme a détecté {errorCount} erreur(s) et {warrningCount} avertissement(s) dans votre fichier.");

            if (errorCount > 0)
            {
                stringBuilder.AppendLine("ERREUR(S)");
                AppendMessages(stringBuilder, errors);
            }

            if (warrningCount > 0)
            {
                stringBuilder.AppendLine("AVERTISSEMENT(S)");
                AppendMessages(stringBuilder, warrnings);
            }
        }

        private static void AppendMessages(StringBuilder stringBuilder, List<MonitoringMessage> messages)
        {
            foreach (var message in messages)
            {
                stringBuilder.AppendLine($"{message.Step}|{message.Message}");
            }
        }
    }
}
