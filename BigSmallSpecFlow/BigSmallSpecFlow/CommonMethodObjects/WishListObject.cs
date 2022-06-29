using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using BigSmallSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace BigSmallSpecFlow.CommonMethodObjects
{
    public class WishListObject
    {
        public void selectItem()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement item = BaseClass.driver.FindElement(By.XPath("//span[.= 'Harry Potter Plush Soft Toy']"));
            item.Click();
        }

        public void AddToWishlist()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement wishlistBtn = BaseClass.driver.FindElement(By.XPath("//span[.= 'Add to Wishlist']"));
            wishlistBtn.Click();
        }

        public void VerifyWishlistNotify()
        {
            bool visible;
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement wishlistNotify = BaseClass.driver.FindElement(By.XPath("//span[.= 'The item has been added to your wishlist ']"));
            visible = wishlistNotify.Displayed;
            Assert.AreEqual(visible, true);
        }

        public void ClickWishList()
        {
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement wishlist = BaseClass.driver.FindElement(By.LinkText("wish list"));
            wishlist.Click();
        }

        public void VerifyWishlistItem()
        {
            bool visible;
            BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement wishlistItem = BaseClass.driver.FindElement(By.LinkText("Harry Potter Plush Soft Toy - Ron"));
            visible = wishlistItem.Displayed;
            Assert.AreEqual(visible, true);
        }

    }
}
