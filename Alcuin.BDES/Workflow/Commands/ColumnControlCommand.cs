﻿using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;
using Aspose.Cells;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class ColumnControlCommand : Command
    {
        private readonly ColumnProviderFactory columnProviderFactory;

        public ColumnControlCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager, 5)
        {
            ServiceLocator.Resolve(out this.columnProviderFactory);
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var foundedSheets = processingContext.AvailableSheets;
            foreach (var sheet in foundedSheets)
            {
                var columnProvider = this.columnProviderFactory.Create(sheet.SheetName);
                var headerInSheet = sheet.Cells.Rows[0]
                        .OfType<Cell>()
                        .Where(x => x.StringValue.IsNotEmpty())
                        .ToDictionary(x => x.StringValue.ToLowerInvariant());

                foreach (var column in columnProvider.GetColumns())
                {
                    sheet.ExpectedColumns.Add(column);
                    if (headerInSheet.TryGetValue(column.Header.ToLowerInvariant(), out var cell))
                    {
                        column.HeaderCell = cell;
                        column.Sheet = sheet;
                        sheet.AvailableColumns.Add(column);
                        headerInSheet.Remove(column.Header);
                        this.PublishSucces(GetColumnFoundMessage(column.Header, sheet.Name));
                    }
                    else
                    {
                        if (column.IsMandatory)
                        {
                            var message = GetMessingMandatoryColumnMessage(column.Header, sheet.Name);
                            this.PublishError(message);
                        }
                        else
                        {
                            this.PublishWarning(GetMessingOptionalColumnMessage(column.Header, sheet.Name));
                        }
                    }
                }

                if (headerInSheet.Count > 0)
                {
                    this.PublishWarning("Des colonnes non reconnues sont présentes dans votre fichier, elles ne seront pas prises en compte. Veuillez vérifier que les colonnes sont bien nommées.");
                }
            }
        }

        private static string GetMessingMandatoryColumnMessage(string columnName, string sheetName)
        {
            return $"Dans l'onglet '{sheetName}' la colonne '{columnName}' n'est pas présente."
                + " Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet.";
        }

        private static string GetMessingOptionalColumnMessage(string columnName, string sheetName)
        {
            return $"La colonne '{columnName}' n'est pas présente dans L'onglet '{sheetName}', "
                + "aucun indicateur lié à cette colonne ne sera calculé lors de la conversion.";
        }

        private static string GetColumnFoundMessage(string columnName, string sheetName)
        {
            return $"La colonne '{columnName}' de l’onglet '{sheetName}' est bien prise en compte.";
        }
    }
}