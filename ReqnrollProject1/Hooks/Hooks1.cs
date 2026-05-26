using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReqnrollProject1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly DriverContext _driverContext;

        public Hooks1(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverContext.driver = new ChromeDriver();

            _driverContext.driver.Manage().Window.Maximize();

            _driverContext.driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverContext.driver.Quit();
        }

    }
}
