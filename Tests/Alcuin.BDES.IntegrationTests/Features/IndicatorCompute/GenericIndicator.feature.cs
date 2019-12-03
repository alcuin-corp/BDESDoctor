// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Alcuin.BDES.IntegrationTests.Features.IndicatorCompute
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Generic indicator computation")]
    public partial class GenericIndicatorComputationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "GenericIndicator.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Generic indicator computation", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matricule",
                        "Structure",
                        "Sexe",
                        "CSP",
                        "Nationalité",
                        "Type de contrat",
                        "Nature de la fin de contrat",
                        "Date de naissance",
                        "Durée du temps de travail hebdomadaire"});
            table9.AddRow(new string[] {
                        "1254",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1986",
                        "40"});
            table9.AddRow(new string[] {
                        "1255",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/04/1987",
                        "40"});
            table9.AddRow(new string[] {
                        "1256",
                        "CGI",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1987",
                        "40"});
            table9.AddRow(new string[] {
                        "1257",
                        "CGI",
                        "Femme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1987",
                        "40"});
            table9.AddRow(new string[] {
                        "1235",
                        "Alcuin",
                        "Femme",
                        "ouvrier",
                        "Autre",
                        "CDI",
                        "dem",
                        "16/03/1983",
                        "40"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table9, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute simple generic indicators")]
        public virtual void LoadAndComputeSimpleGenericIndicators()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute simple generic indicators", null, ((string[])(null)));
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table10.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Nombre de [CSP]",
                            "Cadre",
                            "Count [matricule] par [structure] dont [CSP] est \'Enum\'"});
#line 14
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table10, "Given ");
#line hidden
#line 17
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("I should compute 5 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Indicator",
                            "Group",
                            "Count"});
                table11.AddRow(new string[] {
                            "Nombre de Cadre",
                            "Alcuin",
                            "2"});
                table11.AddRow(new string[] {
                            "Nombre de Cadre",
                            "CGI",
                            "2"});
#line 19
 testRunner.And("I should found the following indicators", ((string)(null)), table11, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute generic indicators")]
        public virtual void LoadAndComputeGenericIndicators()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute generic indicators", null, ((string[])(null)));
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table12.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Nombre de [CSP] [sexe]",
                            "Cadre",
                            "Count [matricule] par [structure] dont [CSP] est \'Enum\' et [Sexe] est \'Enum\'"});
#line 25
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table12, "Given ");
#line hidden
#line 28
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.Then("I should compute 10 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute generic complexe indicators")]
        public virtual void LoadAndComputeGenericComplexeIndicators()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute generic complexe indicators", null, ((string[])(null)));
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table13.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Nombre de [CSP] par [Nature de la fin de contrat] et [Sexe]",
                            "Cadre",
                            "Count [matricule] par [structure] dont [CSP] est \'Enum\' et [Sexe] est \'Enum\' et [" +
                                "Nature de la fin de contrat] est \'Enum\'"});
#line 32
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table13, "Given ");
#line hidden
#line 35
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 36
 testRunner.Then("I should compute 70 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Custom Scenario")]
        public virtual void CustomScenario()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Custom Scenario", null, ((string[])(null)));
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table14.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Effectif total au 31/12",
                            "[CSP]",
                            "Nombre [matricule] par [structure] dont [CSP] est \'Enum\'"});
                table14.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Effectif permanent",
                            "[CSP]",
                            "Nombre [matricule] par [structure] dont [type de contrat] est \'CDI\' et [Durée du " +
                                "temps de travail hebdomadaire] >= \'35\' et [CSP] est \'Enum\'"});
                table14.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Nombre de salariés titulaires d\'un contrat de travail à durée déterminée au 31/12" +
                                "",
                            "[CSP]",
                            "Nombre [matricule] par [structure] dont [type de contrat] est \'CDD\' et [CSP] est " +
                                "\'Enum\'"});
                table14.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Répartition de l\'effectif total au 31/12 pour les [Sexe]s",
                            "[CSP]",
                            "Nombre [matricule] par [structure] dont [Sexe] est \'Enum\' et [CSP] est \'Enum\'"});
                table14.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Répartition de l\'effectif total au 31/12 de nationalité [Nationalité]",
                            "[CSP]",
                            "Nombre [matricule] par [structure] dont [Nationalité] est \'Enum\' et [CSP] est \'En" +
                                "um\'"});
#line 39
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table14, "Given ");
#line hidden
#line 46
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
 testRunner.Then("I should compute 35 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
