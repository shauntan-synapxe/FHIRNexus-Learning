﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FhirNexusShaun.IntegrationTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "Environment:Integration")]
    public partial class InventoryFeature : object, Xunit.IClassFixture<InventoryFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Environment:Integration"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "inventory.feature"
#line hidden
        
        public InventoryFeature(InventoryFeature.FixtureData fixtureData, FhirNexusShaun_IntegrationTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Inventory", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "HeaderName",
                        "Value"});
            table39.AddRow(new string[] {
                        "X-Ihis-SourceApplication",
                        "testapp"});
#line 5
    testRunner.And("a new HttpClient as httpClient", ((string)(null)), table39, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Reading a newly created inventory resource returns exactly the same inventory")]
        [Xunit.TraitAttribute("FeatureTitle", "Inventory")]
        [Xunit.TraitAttribute("Description", "Reading a newly created inventory resource returns exactly the same inventory")]
        public void ReadingANewlyCreatedInventoryResourceReturnsExactlyTheSameInventory()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading a newly created inventory resource returns exactly the same inventory", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 10
    testRunner.Given("a Resource is created from Samples/Inventory.json as createdInv", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 11
    testRunner.When("getting Inventory/{createdInv.Id} as readInv", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
    testRunner.Then("createdInv and readInv are exactly the same", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Reading a nonexistent inventory returns 404 status code")]
        [Xunit.TraitAttribute("FeatureTitle", "Inventory")]
        [Xunit.TraitAttribute("Description", "Reading a nonexistent inventory returns 404 status code")]
        public void ReadingANonexistentInventoryReturns404StatusCode()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading a nonexistent inventory returns 404 status code", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 15
    testRunner.When("getting Inventory/{newguid} as readEdu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value"});
                table40.AddRow(new string[] {
                            "statusCode",
                            "404"});
#line 16
    testRunner.Then("readEdu is a Fhir OperationOutcome with data", ((string)(null)), table40, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Updating a newly created inventory resource returns an inventory with an incremen" +
            "ted versionId")]
        [Xunit.TraitAttribute("FeatureTitle", "Inventory")]
        [Xunit.TraitAttribute("Description", "Updating a newly created inventory resource returns an inventory with an incremen" +
            "ted versionId")]
        public void UpdatingANewlyCreatedInventoryResourceReturnsAnInventoryWithAnIncrementedVersionId()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating a newly created inventory resource returns an inventory with an incremen" +
                    "ted versionId", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 21
    testRunner.Given("a Resource is created from Samples/Inventory.json as createdInv", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value",
                            "FhirType"});
                table41.AddRow(new string[] {
                            "active",
                            "false",
                            "boolean"});
#line 22
    testRunner.When("updating createdInv with data as updatedInv", ((string)(null)), table41, "When ");
#line hidden
#line 25
    testRunner.And("getting Inventory/{createdInv.Id}/_history/2 as readUpdatedInv", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
    testRunner.Then("updatedInv and readUpdatedInv are exactly the same", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value"});
                table42.AddRow(new string[] {
                            "statusCode",
                            "200"});
                table42.AddRow(new string[] {
                            "headers.eTag",
                            "W/\"2\""});
#line 27
    testRunner.And("updatedInv is a Fhir Inventory with data", ((string)(null)), table42, "And ");
#line hidden
                TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value",
                            "FhirType"});
                table43.AddRow(new string[] {
                            "active",
                            "false",
                            "boolean"});
                table43.AddRow(new string[] {
                            "meta.versionId",
                            "2",
                            "string"});
#line 31
    testRunner.And("readUpdatedInv is a Fhir Inventory with data", ((string)(null)), table43, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Updating an inventory resource with a mismatch of id in the body and path returns" +
            " 400 status code")]
        [Xunit.TraitAttribute("FeatureTitle", "Inventory")]
        [Xunit.TraitAttribute("Description", "Updating an inventory resource with a mismatch of id in the body and path returns" +
            " 400 status code")]
        public void UpdatingAnInventoryResourceWithAMismatchOfIdInTheBodyAndPathReturns400StatusCode()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating an inventory resource with a mismatch of id in the body and path returns" +
                    " 400 status code", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 37
    testRunner.Given("a Resource is created from Samples/Inventory.json as createdInv", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value",
                            "FhirType"});
                table44.AddRow(new string[] {
                            "active",
                            "false",
                            "boolean"});
                table44.AddRow(new string[] {
                            "id",
                            "{newguid}",
                            "id"});
#line 38
    testRunner.When("updating createdInv with data as updatedInv", ((string)(null)), table44, "When ");
#line hidden
                TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path",
                            "Value",
                            "FhirType"});
                table45.AddRow(new string[] {
                            "statusCode",
                            "400",
                            ""});
                table45.AddRow(new string[] {
                            "issue[0].diagnostics",
                            "Resource ID in resource does not match with Resource ID in path.",
                            "string"});
#line 42
    testRunner.Then("updatedInv is a Fhir OperationOutcome with data", ((string)(null)), table45, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                InventoryFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                InventoryFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
