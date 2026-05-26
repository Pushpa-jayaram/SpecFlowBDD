using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class CartPage
    {
        IWebDriver driver;

        By shoppingCart = By.LinkText("Shopping Cart");
        By productName = By.LinkText("MacBook");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenCart()
        {
            driver.FindElement(
                By.XPath("//span[text()='Shopping Cart']")).Click();
        }

        public bool VerifyProduct()
        {
            return driver.PageSource.Contains("MacBook");
            Console.WriteLine(driver.PageSource);
        }
    }
}
