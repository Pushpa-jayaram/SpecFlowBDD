using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        By searchBox = By.Name("search");
        By searchButton = By.XPath("//button[contains(@class,'btn-default')]");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchProduct(string product)
        {
            driver.FindElement(searchBox).SendKeys(product);
            driver.FindElement(searchButton).Click();
        }
    }
}
