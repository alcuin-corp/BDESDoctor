﻿// <copyright file="SheetColumnControlCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Linq;
using Alcuin.Parser.Domain;
using Alcuin.Parser.Helper;
using Alcuin.Parser.Monitoring;
using Alcuin.Parser.Workflow;
using Aspose.Cells;

namespace Alcuin.BDES.Commands
{
    internal class ColumnControlCommand : Command
    {
        private readonly ColumnProviderFactory columnProviderFactory;

        public ColumnControlCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager)
        {
            this.columnProviderFactory = new ColumnProviderFactory();
        }

        public override void Process(ProcessingContext processingContext)
        {
            var foundedSheets = processingContext.AvailableSheets;
            foreach (var sheet in foundedSheets)
            {
                var columnProvider = this.columnProviderFactory.Create(sheet.FileTab);
                var headerInSheet = sheet.Cells.Rows[0]
                        .OfType<Cell>()
                        .ToDictionary(x => x.Value.ToLowerString());

                foreach (var column in columnProvider.GetColumns())
                {
                    if (headerInSheet.TryGetValue(column.Header.ToLowerInvariant(), out var cell))
                    {
                        column.HeaderCell = cell;
                        sheet.AvailableColumns.Add(column);
                        headerInSheet.Remove(column.Header);
                        this.PublishSucces(GetColumnFoundMessage(column.Header, sheet.Name));
                    }
                    else
                    {
                        if (column.IsMandatory)
                        {
                            var message = GetMessingMandatoryColumnMessage(column.Header, sheet.Name);
                            throw new ProcessingException(message, this.CurrentStep);
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
