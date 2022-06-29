using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using BigSmallSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace BigSmallSpecFlow.CommonMethodObjects
{
    public class AddToCartObjects
    {
        public void AddItemToCart()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IWebElement addCartBtn = BaseClass.driver.FindElement(By.XPath("//button[@name = 'add']"));
            addCartBtn.Click();
        }

        public void VerifyCartItem()
        {
            bool visible1;
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IWebElement cartItem = BaseClass.driver.FindElement(By.LinkText("Harry Potter Plush Soft Toy"));
            visible1 = cartItem.Displayed;
            Assert.AreEqual(visible1, true);

            bool visible2;
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IWebElement checkoutBtn = BaseClass.driver.FindElement(By.XPath("//button[@name = 'checkout']"));
            visible2 = checkoutBtn.Displayed;
            Assert.AreEqual(visible2, true);
        }
    }
}
