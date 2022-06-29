using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace BigSmallSpecFlow.Utilities
{
    [Binding]
   public class BaseClass
    {
        public static ExtentReports extents;
        public static ExtentTest feature;
        public static ExtentTest scenario;
        public static IWebDriver driver;

        [BeforeFeature]
        public static void featureBrowser(FeatureContext featureContext)
        {
            feature = extents.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
        }

        public static void TakeScreenShot(string ssName)
        {
            string localpath = "";

            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();

                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory;
               // DirectoryInfo di = Directory.CreateDirectory(dir + "\\Screenshots\\");
                string finalpath = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Screenshots\\" + ssName + ".png";

                if (File.Exists(finalpath))
                {
                    File.Delete(finalpath);
                }

                localpath = new Uri(finalpath).LocalPath;

                screenshot.SaveAsFile(localpath);
            }

            catch (Exception e)
            {
                throw (e);
            }
        }

        [BeforeScenario]
        public static void LaunchBrowser(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bigsmall.in/");
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public static void CleanUp()
        {
            driver.Quit();
        }

        [BeforeTestRun]
        public static void GenerateReport()
        {
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\mindtreefeb84\source\repos\BigSmallSpecFlow\BigSmallSpecFlow\index.html");
            htmlReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extents = new ExtentReports();
            extents.AttachReporter(htmlReport);

        }

        [AfterTestRun]
        public static void CloseExtentReport()
        {
            extents.Flush();
        }


        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }

            if (scenarioContext.TestError != null)
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }


        }


    }
}
