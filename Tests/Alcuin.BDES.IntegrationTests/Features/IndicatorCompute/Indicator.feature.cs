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
    [NUnit.Framework.DescriptionAttribute("Indicator computation")]
    public partial class IndicatorComputationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Indicator.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Indicator computation", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute indicators")]
        public virtual void LoadAndComputeIndicators()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute indicators", null, ((string[])(null)));
#line 3
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
                            "Date de naissance"});
                table9.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "Homme",
                            "Cadre",
                            "Francaise",
                            "CDI",
                            "dem",
                            "16/03/1986"});
                table9.AddRow(new string[] {
                            "1255",
                            "Alcuin",
                            "Homme",
                            "Cadre",
                            "Francaise",
                            "CDI",
                            "dem",
                            "16/04/1987"});
                table9.AddRow(new string[] {
                            "1256",
                            "CGI",
                            "Homme",
                            "Cadre",
                            "Francaise",
                            "CDI",
                            "dem",
                            "16/03/1987"});
                table9.AddRow(new string[] {
                            "1257",
                            "CGI",
                            "Femme",
                            "Cadre",
                            "Francaise",
                            "CDI",
                            "dem",
                            "16/03/1987"});
                table9.AddRow(new string[] {
                            "1235",
                            "Alcuin",
                            "Femme",
                            "ouvrier",
                            "Autre",
                            "CDI",
                            "dem",
                            "16/03/1983"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table9, "And ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table10.AddRow(new string[] {
                            "Effectif",
                            "Effectif au 31/12",
                            "Naissance 1986",
                            "Cadre",
                            "∑ [matricule] par [structure] dont [CSP] est \'Cadre\' et année[date de naissance] " +
                                ">> reference"});
                table10.AddRow(new string[] {
                            "Effectif",
                            "Effectif au 31/12",
                            "total des cadres",
                            "Agent de Maitrise",
                            "∑ [matricule] par [structure] dont [CSP] est \'Cadre\'"});
                table10.AddRow(new string[] {
                            "Effectif",
                            "Effectif au 31/12",
                            "total des ouvrier",
                            "Agent de Maitrise",
                            "∑ [matricule] par [structure] dont [CSP] est \'ouv\'"});
                table10.AddRow(new string[] {
                            "Effectif",
                            "Effectif au 31/12",
                            "indicateur 1",
                            "Agent de Maitrise",
                            "∑ [matricule] par [structure] dont [CSP] est \'Cadre\' et [sexe] est \'H\'"});
                table10.AddRow(new string[] {
                            "Effectif",
                            "Effectif au 31/12",
                            "indicateur 2",
                            "Agent de Maitrise",
                            "∑ [matricule] par [structure] dont [CSP] est \'Cadre\' et [Salaire mensuel brut] ==" +
                                " \'3500\'"});
#line 12
 testRunner.And("I have the folowing indicators definition", ((string)(null)), table10, "And ");
#line hidden
#line 19
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Indicator",
                            "Group",
                            "Count"});
                table11.AddRow(new string[] {
                            "Naissance 1986",
                            "Alcuin",
                            "1"});
                table11.AddRow(new string[] {
                            "Naissance 1986",
                            "CGI",
                            "2"});
                table11.AddRow(new string[] {
                            "total des cadres",
                            "Alcuin",
                            "2"});
                table11.AddRow(new string[] {
                            "total des cadres",
                            "CGI",
                            "2"});
                table11.AddRow(new string[] {
                            "total des ouvrier",
                            "Alcuin",
                            "1"});
                table11.AddRow(new string[] {
                            "total des ouvrier",
                            "CGI",
                            "0"});
                table11.AddRow(new string[] {
                            "indicateur 1",
                            "Alcuin",
                            "2"});
                table11.AddRow(new string[] {
                            "indicateur 1",
                            "CGI",
                            "1"});
#line 20
 testRunner.Then("I should found the following indicators", ((string)(null)), table11, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table12.AddRow(new string[] {
                            "L\'indicateur \'indicateur 2\' ne sera pas calculé, il se base sur la colonne \'salai" +
                                "re mensuel brut\' qui est manquante dans l\'onglet \'effectifs\'."});
#line 30
 testRunner.And("I should found the following Avertissement messages", ((string)(null)), table12, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
