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
    [NUnit.Framework.DescriptionAttribute("Age indicator computation")]
    public partial class AgeIndicatorComputationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "AgeIndicator.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Age indicator computation", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matricule",
                        "Structure",
                        "Sexe",
                        "CSP",
                        "Date de naissance",
                        "Date de sortie"});
            table15.AddRow(new string[] {
                        "1254",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "16/03/1985",
                        ""});
            table15.AddRow(new string[] {
                        "1255",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "16/03/1978",
                        ""});
            table15.AddRow(new string[] {
                        "1256",
                        "CGI",
                        "Homme",
                        "Cadre",
                        "16/03/1986",
                        ""});
            table15.AddRow(new string[] {
                        "1257",
                        "CGI",
                        "Femme",
                        "Cadre",
                        "16/03/1988",
                        ""});
            table15.AddRow(new string[] {
                        "1235",
                        "Alcuin",
                        "Femme",
                        "ouvrier",
                        "16/03/1990",
                        ""});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table15, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute indicator withing \'Age equals value\' computation in filter crete" +
            "ria")]
        public virtual void LoadAndComputeIndicatorWithingAgeEqualsValueComputationInFilterCreteria()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute indicator withing \'Age equals value\' computation in filter crete" +
                    "ria", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table16.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Jeunes de 34 ou 33 ans",
                            "Cadre",
                            "∑ [matricule] par [structure] dont age > 20 ou Age >= \'31\' ou Age <> \'33\' ou age " +
                                "= 20"});
#line 14
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table16, "Given ");
#line hidden
#line 17
 testRunner.When("I start processing the file mybook.xlsx for the period of 2019", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Indicator",
                            "Group",
                            "Count"});
                table17.AddRow(new string[] {
                            "Jeunes de 34 ou 33 ans",
                            "Alcuin",
                            "0"});
                table17.AddRow(new string[] {
                            "Jeunes de 34 ou 33 ans",
                            "CGI",
                            "2"});
#line 18
 testRunner.Then("I should found the following indicators", ((string)(null)), table17, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load and compute indicator withing \'Age less than value\' computation in filter cr" +
            "eteria")]
        public virtual void LoadAndComputeIndicatorWithingAgeLessThanValueComputationInFilterCreteria()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load and compute indicator withing \'Age less than value\' computation in filter cr" +
                    "eteria", null, ((string[])(null)));
#line 23
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
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table18.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Jeunes de plus de 33 ans",
                            "Cadre",
                            "Count [matricule] par [structure] dont  Age >= \'33\'"});
                table18.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Jeunes de moins de 33 ans",
                            "Cadre",
                            "Count [matricule] par [structure] dont  Age << \'33\'"});
#line 24
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table18, "Given ");
#line hidden
#line 28
 testRunner.When("I start processing the file mybook.xlsx for the period of 2019", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Indicator",
                            "Group",
                            "Count"});
                table19.AddRow(new string[] {
                            "Jeunes de plus de 33 ans",
                            "Alcuin",
                            "2"});
                table19.AddRow(new string[] {
                            "Jeunes de plus de 33 ans",
                            "CGI",
                            "1"});
                table19.AddRow(new string[] {
                            "Jeunes de moins de 33 ans",
                            "Alcuin",
                            "1"});
                table19.AddRow(new string[] {
                            "Jeunes de moins de 33 ans",
                            "CGI",
                            "1"});
#line 29
 testRunner.Then("I should found the following indicators", ((string)(null)), table19, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
