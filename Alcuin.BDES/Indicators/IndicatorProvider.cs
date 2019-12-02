using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators.Criterias;
using Alcuin.BDES.Indicators.Parser;
using Alcuin.BDES.Interfaces;

namespace Alcuin.BDES.Indicators
{
    internal class IndicatorProvider : IIndicatorProvider
    {
        private readonly IColumnProviderFactory columnProviderFactory;
        private readonly IRawIndicatorReader rawIndicatorReader;

        public IndicatorProvider(IRawIndicatorReader rawIndicatorReader, IColumnProviderFactory columnProviderFactory)
        {
            columnProviderFactory.IsNotNull(nameof(columnProviderFactory));
            rawIndicatorReader.IsNotNull(nameof(columnProviderFactory));

            this.columnProviderFactory = columnProviderFactory;
            this.rawIndicatorReader = rawIndicatorReader;
        }

        public Dictionary<string, List<Indicator>> Load()
        {
            var result = new Dictionary<string, List<Indicator>>();

            // Get assembly path
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var assemblyPath = Path.GetDirectoryName(path);

            var indicatorDefinitions = this.rawIndicatorReader
                .LoadInidcatorFromFile(Path.Combine(assemblyPath, @"Ressources\RawIndicators.csv"))
                .Select(x => new IndicatorDefinition(x))
                .ToList();

            var groupedIndicators = indicatorDefinitions.GroupBy(x => x.SheetName);
            foreach (var group in groupedIndicators)
            {
                var list = result[group.Key.ToLowerInvariant()] = new List<Indicator>();
                var genericIndicators = new List<IndicatorDefinition>();
                var expectedColumns = this.GetColumns(group);
                foreach (var indicatorDefinition in group)
                {
                    if (IsNotGeneric(indicatorDefinition, expectedColumns, out var criterias))
                    {
                        var indicator = new Indicator(indicatorDefinition, criterias);
                        indicator.ColumnToAgregate = expectedColumns[indicatorDefinition.AgregateColumnHeader];
                        indicator.GroupColumn = expectedColumns[indicatorDefinition.GroupColumnHeader];
                        list.Add(indicator);
                    }
                    else
                    {
                        foreach (var indicator in HandleGenericIndicator(indicatorDefinition, expectedColumns))
                        {
                            list.Add(indicator);
                        }
                    }
                }
            }

            return result;
        }

        private static IEnumerable<Indicator> HandleGenericIndicator(IndicatorDefinition indicatorDefinition, Dictionary<string, Column> expectedColumns)
        {
            var listOfCriteria = new List<ICriteria>();
            foreach (var criteriaDef in indicatorDefinition.CriteriaDefinitions)
            {
                var column = expectedColumns[criteriaDef.ColumnName];
                if (criteriaDef.Values.Contains("Enum"))
                {
                    var genericArgument = column.GetType().GetGenericArguments().First();
                    foreach (var name in Enum.GetNames(genericArgument))
                    {
                        var criteriaClone = criteriaDef.Clone();
                        criteriaClone.Values = criteriaDef.Values.Select(x => x.Replace("Enum", name)).ToList();
                        var clone = indicatorDefinition.Clone();
                        clone.Name = clone.Name.Replace($"[{column.Header}]", name.GetEnumDescription(genericArgument));
                        var index = clone.CriteriaDefinitions.IndexOf(criteriaDef);
                        clone.CriteriaDefinitions[index] = criteriaClone;
                        foreach (var indicator in HandleGenericIndicator(clone, expectedColumns))
                        {
                            yield return indicator;
                        }
                    }

                    break;
                }
                else
                {
                    listOfCriteria.Add(column.GetCriteria(criteriaDef));
                }
            }

            if (listOfCriteria.Count == indicatorDefinition.CriteriaDefinitions.Count)
            {
                var indicator = new Indicator(indicatorDefinition, listOfCriteria);
                indicator.ColumnToAgregate = expectedColumns[indicatorDefinition.AgregateColumnHeader];
                indicator.GroupColumn = expectedColumns[indicatorDefinition.GroupColumnHeader];
                yield return indicator;
            }
        }

        private static bool IsNotGeneric(IndicatorDefinition indicatorDefinition, Dictionary<string, Column> expectedColumns, out List<ICriteria> criterias)
        {
            criterias = new List<ICriteria>();
            foreach (var criteriaDef in indicatorDefinition.CriteriaDefinitions)
            {
                var column = expectedColumns[criteriaDef.ColumnName];
                if (criteriaDef.Values.Contains("Enum") && column.GetType().IsGenericType)
                {
                    return false;
                }
                else
                {
                    var criteria = column.GetCriteria(criteriaDef);
                    criterias.Add(criteria);
                }
            }

            return true;
        }

        private Dictionary<string, Column> GetColumns(IGrouping<string, IndicatorDefinition> groupedIndicator)
        {
            var columnProvider = this.columnProviderFactory.Create(groupedIndicator.Key);
            var expectedColumns = columnProvider.GetColumns().ToDictionary(x => x.Header.ToLowerInvariant());
            return expectedColumns;
        }
    }
}