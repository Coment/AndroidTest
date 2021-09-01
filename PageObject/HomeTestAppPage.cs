using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace AndroidTest
{
    public class HomeTestAppPage : BasePage
    {
        public HomeTestAppPage(AndroidDriver<AndroidElement> driver) : base(driver)
        {           
        }

        public IWebElement RegistrationButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "startUserRegistration");
        public IWebElement EnButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "buttonTest");
        public IWebElement PopupEnText => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.TextView[@text='This will end the activity']");
        public IWebElement PopupEnYesButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.Button[@text='I agree']");
        public IWebElement PopupEnNoButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.Button[@text='No, no']");
        public IWebElement AcceptAddsCheckBox => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "input_adds_check_box");
        public IWebElement ProgressBarButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "waitingButtonTest"); 
        public IWebElement PopupProgressBarDialog => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.TextView[@text='Waiting Dialog']");
        public IWebElement DisplayTextViewButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "visibleButtonTest");
        public IWebElement VisibleTextViewText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "visibleTextView");
        public IWebElement DisplayAndFocusLayoutButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "topLevelElementTest");
        public IWebElement StartInputTextField => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "my_text_field");
        public IWebElement DisplayAndFocusLayoutTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "focusedText");
        public IWebElement TouchActionsButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "touchTest");
        public IWebElement BrowserButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "buttonStartWebview");
        public IWebElement DisplayToastButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "showToastButton");
        public IWebElement DisplayPopupWindowButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "showPopupWindowButton");

        
        public IWebElement ToastMessage
        {
            get 
            {
                WebDriverWait waitForToast = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                waitForToast.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("/hierarchy/android.widget.Toast")));
                return driver.FindElement((By.XPath("/hierarchy/android.widget.Toast"))); 
            }
        }         
    }
}
