using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndroidTest
{
    public class BasePage
    {
        public AndroidDriver<AndroidElement> driver;
        protected IWebElement _webElement;
        protected By _condition;

        public BasePage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public enum SearchVariant
        {
            Id,
            Class,
            Xpath,
            CssSelector
        }

        public  AndroidElement FindElementIgnoreException(IWebDriver driver, SearchVariant variant, string searchPath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.IgnoreExceptionTypes(typeof(InvalidOperationException));
                    switch (variant)
                    {
                        case SearchVariant.Class:
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(searchPath)));
                        return (AndroidElement)driver.FindElement(By.ClassName(searchPath));
                        case SearchVariant.Id:
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(searchPath)));
                        return (AndroidElement)driver.FindElement(By.Id(searchPath));
                        case SearchVariant.Xpath:
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(searchPath)));
                        return (AndroidElement)driver.FindElement(By.XPath(searchPath));
                        default:
                            throw new Exception("current search variant is not support");
                    }             
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public bool IsVisible(IWebDriver driver, IWebElement element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            try
            {
                return element != null && element.Displayed;
            }
            catch (ElementNotVisibleException var1)
            {
                return false;
            }
            catch (NoSuchElementException var2)
            {
                return false;
            }
            catch (StaleElementReferenceException var3)
            {
                return false;
            }
        }

        public bool isElementDisplayed(IWebDriver driver, By by)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
        }

        public bool isElementDisappeared(IWebDriver driver, SearchVariant variant, string searchPath, double waitDuration )
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitDuration));
                switch (variant)
                {
                    case SearchVariant.Class:
                        new WebDriverWait(driver, TimeSpan.FromSeconds(waitDuration)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName(searchPath)));
                        return true;
                    case SearchVariant.Id:
                        new WebDriverWait(driver, TimeSpan.FromSeconds(waitDuration)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(searchPath)));
                        return true;
                    case SearchVariant.Xpath:
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(searchPath)));
                        return true;
                    default:
                        throw new Exception("current search variant is not support");
                }
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public void chechkIsAlertPresent(IWebDriver driver) 
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {

            }
        }

        public void waitFor(int miliseconds)
        {
            try
            {
                Thread.Sleep(miliseconds);
            }
            catch (ThreadInterruptedException e)
            {
            }
        }
    }
}
