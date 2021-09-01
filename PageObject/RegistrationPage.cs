using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace AndroidTest.PageObject
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(AndroidDriver<AndroidElement> driver) : base(driver)
        {
        }

        public IWebElement UserNameInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "inputUsername");
        public IWebElement EmailInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "inputEmail");
        public IWebElement PasswordInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "inputPassword");
        public IWebElement NameInputText => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "inputName");
        public IWebElement ProgrammingLanguageButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "input_preferedProgrammingLanguage");
        public IWebElement AcceptAddsCheckBox => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "input_adds");
        public IWebElement RegisterVerifyButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "btnRegisterUser"); 
        public IWebElement UserVerifyTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Xpath, "//android.widget.TextView[@text='Verify user']");
        public IWebElement UserVerifyName => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_name_data");
        public IWebElement UserVerifyUserName => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_username_data");
        public IWebElement UserVerifyEmail => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_email_data");
        public IWebElement UserVerifyPassword => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_password_data");
        public IWebElement UserVerifyProgrammingLanguage => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_preferedProgrammingLanguage_data");
        public IWebElement UserVerifyAcceptAdds => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "label_acceptAdds_data");
        public IWebElement RegisterUserButton => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "buttonRegisterUser");
        
        public virtual IWebElement GetProrammingLanguageCheckedTextView(string preferedProgrammingLanguage)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//android.widget.CheckedTextView[@text='{preferedProgrammingLanguage}']")));
            return driver.FindElement(By.XPath($"//android.widget.CheckedTextView[@text='{preferedProgrammingLanguage}']"));
        }
    }
}
