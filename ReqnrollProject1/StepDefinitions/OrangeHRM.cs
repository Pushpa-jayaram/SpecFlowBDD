using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnrollProject1.Drivers;
using System;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class OrangeHRM
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public OrangeHRM(DriverContext driverContext)
        {
            this.driver = driverContext.driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"the user navigates to ""([^""]*)""")]
        public void GivenTheUserNavigatesTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            wait.Until(d => d.FindElement(By.Name("username")).Displayed);
        }

        [When(@"the user logs in with username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenTheUserLogsInWithUsernameAndPassword(string username, string password)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//span[text()='Admin']")).Displayed);
        }

        [When(@"the user navigates to the ""([^""]*)"" tab")]
        public void WhenTheUserNavigatesToTheTab(string tabName)
        {
            driver.FindElement(By.XPath($"//span[text()='{tabName}']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//h6[contains(.,'System Users')]")).Displayed);
        }

        [When(@"the user selects User Role ""([^""]*)"" and Status ""([^""]*)""")]
        public void WhenTheUserSelectsUserRoleAndStatus(string userRole, string status)
        {
            wait.Until(d => d.FindElement(By.XPath("//label[text()='User Role']/../following-sibling::div//div[@role='button']"))).Click();
            wait.Until(d => d.FindElement(By.XPath($"//div[@role='listbox']//span[text()='{userRole}']"))).Click();

            wait.Until(d => d.FindElement(By.XPath("//label[text()='Status']/../following-sibling::div//div[@role='button']"))).Click();
            wait.Until(d => d.FindElement(By.XPath($"//div[@role='listbox']//span[text()='{status}']"))).Click();
        }

        [When(@"the user clicks ""([^""]*)""")]
        public void WhenTheUserClicks(string buttonText)
        {
            wait.Until(d => d.FindElement(By.XPath($"//button[normalize-space()='{buttonText}']"))).Click();
            wait.Until(d => d.FindElement(By.XPath("//div[contains(@class,'oxd-table')]")).Displayed);
        }

        [Then(@"the user ""([^""]*)"" should be displayed in the results")]
        public void ThenTheUserShouldBeDisplayedInTheResults(string expectedUser)
        {
            var element = wait.Until(d => d.FindElement(By.XPath($"//div[@role='table']//*[text()='{expectedUser}']")));
            Assert.That(element.Displayed, Is.True, $"Expected user '{expectedUser}' to be visible in the results");
        }
    }
}