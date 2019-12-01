using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class SheetControlCommand : Command
    {
        private readonly List<Sheet> tabs;

        public SheetControlCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager, 3)
        {
            this.tabs = new List<Sheet>
            {
                new Sheet(FileTab.Effectifs, true),
                new Sheet(FileTab.Absences),
                new Sheet(FileTab.Maladies),
            };
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var availableTabNames = processingContext.Workbook.Worksheets.ToDictionary(x => x.Name.ToLowerInvariant());

            foreach (var tab in this.tabs)
            {
                if (availableTabNames.TryGetValue(tab.Name, out var worksheet))
                {
                    this.PublishSucces($"L’onglet '{tab.Name}' est bien pris en compte.");
                    tab.RawSheet = worksheet;
                    processingContext.AvailableSheets.Add(tab);
                    availableTabNames.Remove(tab.Name);
                }
                else
                {
                    if (tab.IsMandatory)
                    {
                        throw new ProcessingException(this.GetMessageForMessingMandatoryTab(tab.Name));
                    }

                    this.PublishWarning(this.GetMessageForMessingOptionalTab(tab.Name));
                }

                request.ProgressRate++;
            }

            if (availableTabNames.Count > 0)
            {
                this.PublishWarning("D’autres onglets existent dans votre fichier, ils ne seront pas pris en compte.");
            }
        }

        private string GetMessageForMessingMandatoryTab(string tabName)
        {
            return $"L'onglet '{tabName}' n'est pas présent dans le fichier, cet onglet est obligatoire. Veuillez vérifier que cet onglet est bien nommé ainsi et qu'il est présent dans votre fichier.";
        }

        private string GetMessageForMessingOptionalTab(string tabName)
        {
            return $"L'onglet '{tabName}' n'est pas présent dans votre fichier, aucun indicateur lié aux {tabName} ne sera calculé lors de la conversion.";
        }
    }
}