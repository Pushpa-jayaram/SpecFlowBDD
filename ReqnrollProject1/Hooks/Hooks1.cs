using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReqnrollProject1.Drivers;
using ReqnrollProject1.Screenshots;
using ReqnrollProject1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    public class Hooks1
    {
        private readonly DriverContext _driverContext;
        private readonly ScenarioContext _scenarioContext;

        public Hooks1(
            DriverContext driverContext,
            ScenarioContext scenarioContext)
        {
            _driverContext = driverContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportHelper.InitializeReport();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverContext.driver = new ChromeDriver();

            _driverContext.driver.Manage().Window.Maximize();

            _driverContext.driver.Navigate()
                .GoToUrl("https://tutorialsninja.com/demo/");

            ExtentReportHelper.test =
                ExtentReportHelper.extent
                .CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType =
                _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            var stepName =
                _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                ExtentReportHelper.test.Log(
                    Status.Pass,
                    stepType + " - " + stepName);
            }
            else
            {
                string screenshotPath =
                    ScreenshotHelper.CaptureScreenshot(
                        _driverContext.driver,
                        "Failure_" + DateTime.Now.Ticks);

                ExtentReportHelper.test.Fail(
                    stepType + " - " + stepName);

                ExtentReportHelper.test.AddScreenCaptureFromPath(
                    screenshotPath);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverContext.driver.Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportHelper.FlushReport();
        }
    }
}
