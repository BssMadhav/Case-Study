using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using BigSmallSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace BigSmallSpecFlow.CommonMethodObjects
{
    public class LoginObjects
    {
        public void VerifyHome()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            bool visible;
            IWebElement signUpNow = BaseClass.driver.FindElement(By.XPath("//button[@name = 'commit']"));
            visible = signUpNow.Displayed;
            Assert.AreEqual(visible, true);
        }

        public void ClickSignIn()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement signIn = BaseClass.driver.FindElement(By.LinkText("sign in"));
            signIn.Click();
        }

        public void EnterEmail(string email)
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement emailBox = BaseClass.driver.FindElement(By.XPath("//input[@id = 'CustomerEmail']"));
            emailBox.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement pwd = BaseClass.driver.FindElement(By.XPath("//input[@id = 'CustomerPassword']"));
            pwd.SendKeys(password);
        }

        public void ClickSignInBtn()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement signInBtn = BaseClass.driver.FindElement(By.XPath("//input[@value = 'Sign In']"));
            signInBtn.Click();
        }

        public void VerifyInvalidInput()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            bool visible;
            IWebElement errMsg = BaseClass.driver.FindElement(By.XPath("//li[.= 'Incorrect email or password.']"));
            visible = errMsg.Displayed;
            Assert.AreEqual(visible, true);
        }
    }
}
