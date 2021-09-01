using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidTest.PageObject
{
    public class AppWebBrowserPage : BasePage
    {
        public AppWebBrowserPage(AndroidDriver<AndroidElement> driver) : base(driver)
        { }

        public IWebElement WebViewButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "buttonStartWebview");
        public IWebElement WebDriverTestFileDropDownButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "spinner_webdriver_test_data");
        public IWebElement AlertTitleTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.LinearLayout/android.widget.TextView");
        public IWebElement EnterNameTextInput => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.view.View[2]/android.widget.EditText");
        public IWebElement PreferedCarDropDownButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.Spinner[@index='2']");
        public IWebElement SendYourNameButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.Button[@content-desc='Send me your name!']");
        public IWebElement WebDrivertestFileDropDownButtonText => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.Spinner/android.widget.TextView");
        public IWebElement EnteredNameTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.view.View[@index='3']");
        public IWebElement PreferedCarTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.view.View[@index='5']");
        public IWebElement ClickHereLink => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.view.View[@index='9']");


        public virtual IWebElement GetWebDriverTestFileTextView(string preferedTestFile)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//android.widget.ListView/android.widget.TextView[contains(@text,'{preferedTestFile}')]")));
            return driver.FindElement(By.XPath($"//android.widget.ListView/android.widget.TextView[contains(@text,'{preferedTestFile}')]"));
        }

        public virtual IWebElement GetPrefferedCarCheckedTextView(string preferedCar)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//android.widget.ListView/android.widget.CheckedTextView[@text='{preferedCar}']")));
            return driver.FindElement(By.XPath($"//android.widget.ListView/android.widget.CheckedTextView[@text='{preferedCar}']"));
        }
    }
}

