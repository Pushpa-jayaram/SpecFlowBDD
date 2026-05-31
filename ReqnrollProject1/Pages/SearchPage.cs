using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class SearchPage
    {
        IWebDriver driver;

        By product = By.LinkText("MacBook");
        By addToCart = By.Id("button-cart");

        public object ExpectedConditions { get; private set; }

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenProduct()
        {
            driver.FindElement(product).Click();
        }

        public void AddProductToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement button = wait.Until(d => d.FindElement(addToCart));
            button.Click();
        }
    }
}
