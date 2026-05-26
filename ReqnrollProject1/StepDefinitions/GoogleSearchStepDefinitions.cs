using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using ReqnrollProject1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        private readonly DriverContext _driverContext;

        public GoogleSearchStepDefinitions(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        [Given(@"I launch google")]
        public void GivenILaunchGoogle()
        {

        }

        [Given(@"enter youtube url")]
        public void GivenEnterYoutubeUrl()
        {
            _driverContext.driver.Navigate().GoToUrl("https://www.youtube.com");
        }

        [When(@"search ""([^""]*)""")]
        public void WhenSearch(string searchText)
        {
            WebDriverWait wait = new WebDriverWait(_driverContext.driver, TimeSpan.FromSeconds(10));

            IWebElement searchBox = wait.Until(d =>
                d.FindElement(By.Name("search_query")));

            searchBox.SendKeys(searchText);
            searchBox.SendKeys(Keys.Enter);
        }

        [Then(@"click on the result")]
        public void ThenClickOnTheResult()
        {
            WebDriverWait wait = new WebDriverWait(_driverContext.driver, TimeSpan.FromSeconds(10));

            IWebElement video = wait.Until(d =>
                d.FindElement(By.XPath("(//*[@id='video-title'])[1]")));

            video.Click();
        }
    }
}
