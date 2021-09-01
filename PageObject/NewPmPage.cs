using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidTest.PageObject
{
    public class NewPmPage : BasePage
    {
        public NewPmPage(AndroidDriver<AndroidElement> driver) : base(driver)
        { }

        public IWebElement UserNameInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "username");
        public IWebElement PasswordInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "password"); 
        public IWebElement SignInButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.LinearLayout/android.widget.Button[2]");
        public IWebElement SearchButton 
        {
            get 
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.view.View/android.widget.Button")));
                return driver.FindElement(By.XPath("//android.view.View/android.widget.Button"));
            }
        } 
    }
}
