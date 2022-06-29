using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using BigSmallSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace BigSmallSpecFlow.CommonMethodObjects
{
    public class SearchProductObject
    {
        public void EnterProductToSearch()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement search = BaseClass.driver.FindElement(By.XPath("//input[@class = 'snize-input-style']"));
            search.SendKeys("harry potter");
            search.Submit();
        }

        public void VerifyProductSearch()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement numberOfProducts = BaseClass.driver.FindElement(By.XPath("//span[@class = 'snize-products-tab-total']"));
            string s = numberOfProducts.Text;
            int x = Convert.ToInt32(s);

            if (x > 0)
            {
                Console.WriteLine("Test Passed");
            }

            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
