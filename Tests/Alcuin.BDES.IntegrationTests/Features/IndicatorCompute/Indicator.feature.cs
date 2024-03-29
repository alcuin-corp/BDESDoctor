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
    [NUnit.Framework.DescriptionAttribute("Indicator computations")]
    public partial class IndicatorComputationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Indicator.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Indicator computations", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matricule",
                        "Structure",
                        "Sexe",
                        "CSP",
                        "Nationalité",
                        "Type de contrat",
                        "Nature de la fin de contrat",
                        "Date de naissance",
                        "Durée du temps de travail hebdomadaire",
                        "Date d\'entrée",
                        "Date de sortie"});
            table25.AddRow(new string[] {
                        "1254",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1986",
                        "15",
                        "12/12/2012",
                        ""});
            table25.AddRow(new string[] {
                        "1255",
                        "Alcuin",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/04/1987",
                        "40",
                        "12/12/2012",
                        "13/05/2013"});
            table25.AddRow(new string[] {
                        "1256",
                        "CGI",
                        "Homme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1987",
                        "33",
                        "12/12/2012",
                        "16/03/1986"});
            table25.AddRow(new string[] {
                        "1257",
                        "CGI",
                        "Femme",
                        "Cadre",
                        "Francaise",
                        "CDI",
                        "dem",
                        "16/03/1987",
                        "40",
                        "12/12/2012",
                        "30/06/2019"});
            table25.AddRow(new string[] {
                        "1235",
                        "Alcuin",
                        "Femme",
                        "ouvrier",
                        "Autre",
                        "CDI",
                        "dem",
                        "16/03/1983",
                        "40",
                        "12/12/2012",
                        ""});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table25, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Effectif total au 31/12")]
        public virtual void GeneratingIndicatorEffectifTotalAu3112()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Effectif total au 31/12", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table26.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Effectif total au 31/12",
                            "[CSP]",
                            "Count [matricule] group by [structure] where [CSP] is \'Enum\'"});
#line 14
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table26, "Given ");
#line hidden
#line 17
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("I should compute 5 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Effectif permanent")]
        public virtual void GeneratingIndicatorEffectifPermanent()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Effectif permanent", null, ((string[])(null)));
#line 20
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
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table27.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Effectif permanent",
                            "[CSP]",
                            "Count [matricule] group by [structure] where [type de contrat] is \'CDI\' and [Duré" +
                                "e du temps de travail hebdomadaire] >= \'35\' and [CSP] = \'Enum\'"});
#line 21
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table27, "Given ");
#line hidden
#line 24
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.Then("I should compute 5 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Nombre de salariés titulaires d\'un contrat de travail à du" +
            "rée déterminée au 31/12")]
        public virtual void GeneratingIndicatorNombreDeSalariesTitulairesDunContratDeTravailADureeDetermineeAu3112()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Nombre de salariés titulaires d\'un contrat de travail à du" +
                    "rée déterminée au 31/12", null, ((string[])(null)));
#line 27
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
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table28.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Effectif au 31/12",
                            "Nombre de salariés titulaires d\'un contrat de travail à durée déterminée au 31/12" +
                                "",
                            "[CSP]",
                            "Count [matricule] group by [structure] where [type de contrat] is \'CDD\' and [CSP]" +
                                " is \'Enum\'"});
#line 28
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table28, "Given ");
#line hidden
#line 31
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 32
 testRunner.Then("I should compute 5 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Répartition de l\'effectif total au 31/12 par sexe")]
        public virtual void GeneratingIndicatorRepartitionDeLeffectifTotalAu3112ParSexe()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Répartition de l\'effectif total au 31/12 par sexe", null, ((string[])(null)));
#line 34
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
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table29.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Répartition de l\'effectif total au 31/12 pour les [Sexe]s",
                            "[CSP]",
                            "Count [matricule] group by [structure] where [Sexe] is \'Enum\' and [CSP] is \'Enum\'" +
                                ""});
#line 35
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table29, "Given ");
#line hidden
#line 38
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 39
 testRunner.Then("I should compute 10 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Répartition de l\'effectif total au 31/12 par nationalité")]
        public virtual void GeneratingIndicatorRepartitionDeLeffectifTotalAu3112ParNationalite()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Répartition de l\'effectif total au 31/12 par nationalité", null, ((string[])(null)));
#line 41
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
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table30.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Répartition de l\'effectif total au 31/12 de nationalité [Nationalité]",
                            "[CSP]",
                            "Count [matricule] group by [structure] where [Nationalité] is \'Enum\' and [CSP] is" +
                                " \'Enum\'"});
#line 42
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table30, "Given ");
#line hidden
#line 45
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.Then("I should compute 10 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Nombre de salariés employés en autres formes de temps part" +
            "iel")]
        public virtual void GeneratingIndicatorNombreDeSalariesEmployesEnAutresFormesDeTempsPartiel()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Nombre de salariés employés en autres formes de temps part" +
                    "iel", null, ((string[])(null)));
#line 48
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
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table31.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Nombre de salariés employés en autres formes de temps partiel",
                            "Cadre",
                            "Count [matricule] group by [structure] where [Durée du temps de travail hebdomada" +
                                "ire] between \'30\' and \'35\' and [CSP] is \'Cadre\'"});
#line 49
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table31, "Given ");
#line hidden
#line 52
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.Then("I should compute 1 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Nombre d\'embauche de l\'année")]
        public virtual void GeneratingIndicatorNombreDembaucheDeLannee()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Nombre d\'embauche de l\'année", null, ((string[])(null)));
#line 55
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
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table32.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Nombre d\'embauche",
                            "Cadre",
                            "Count [matricule] group by [structure] where Yearof[Date d\'entrée] is \'reference\'" +
                                " and [CSP] is \'Cadre\'"});
#line 56
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table32, "Given ");
#line hidden
#line 59
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
 testRunner.Then("I should compute 1 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator : Nombre de sorties de l\'année")]
        public virtual void GeneratingIndicatorNombreDeSortiesDeLannee()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator : Nombre de sorties de l\'année", null, ((string[])(null)));
#line 62
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
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table33.AddRow(new string[] {
                            "Effectifs",
                            "Effectif",
                            "Répartition de l\'effectif",
                            "Nombre d\'embauche",
                            "Cadre",
                            "Count [matricule] Group by [structure] where YearOf[Date de sortie] In (\'referenc" +
                                "e\',\'null\') and [CSP] is \'Cadre\'"});
#line 63
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table33, "Given ");
#line hidden
#line 66
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 67
 testRunner.Then("I should compute 1 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator :  Nombre de salariés en temps partiel (autres formes de tem" +
            "ps partiel)")]
        public virtual void GeneratingIndicatorNombreDeSalariesEnTempsPartielAutresFormesDeTempsPartiel()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator :  Nombre de salariés en temps partiel (autres formes de tem" +
                    "ps partiel)", null, ((string[])(null)));
#line 69
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
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table34.AddRow(new string[] {
                            "Effectifs",
                            "Conditions générales d\'emploi",
                            "Durée et organisation du travail",
                            "Nombre de salariés en temps partiel (autres formes de temps partiel)",
                            "[Sexe]",
                            "count [matricule] group by [structure] where [Durée du temps de travail hebdomada" +
                                "ire] between \'30\' and \'35\' or [Durée du temps de travail hebdomadaire] < \'20\' an" +
                                "d [Sexe] is \'Enum\' and YearOf[Date de sortie] in (\'reference\',\'null\')"});
#line 70
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table34, "Given ");
#line hidden
#line 73
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 74
 testRunner.Then("I should compute 2 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generating indicator :  Nombre de salariés")]
        public virtual void GeneratingIndicatorNombreDeSalaries()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generating indicator :  Nombre de salariés", null, ((string[])(null)));
#line 76
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
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Onglet",
                            "Domaine",
                            "Sous Domaine",
                            "Indicateur",
                            "Champs",
                            "Formule"});
                table35.AddRow(new string[] {
                            "Effectifs",
                            "Conditions générales d\'emploi",
                            "Durée et organisation du travail",
                            "Nombre de salariés",
                            "salariés",
                            "Count [matricule] Group by [structure]"});
#line 77
 testRunner.Given("I have the folowing indicators definition", ((string)(null)), table35, "Given ");
#line hidden
#line 80
 testRunner.When("I start processing the file mybook.xlsx for the period of 1986", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 81
 testRunner.Then("I should compute 1 indicators", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
