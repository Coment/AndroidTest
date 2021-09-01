using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;
using AndroidTest.PageObject;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Interactions;

namespace AndroidTest
{
    [TestFixture]
    public class Tests
    {
        private static AndroidDriver<AndroidElement> driver;
        class Person
        {
            public string Name { get; set; }
            public Person(string name)
            {
                Name = name;
            }
            public void Display1()
            {
                Console.WriteLine(Name+"1");
            }
            public virtual void Display()
            {
                Console.WriteLine(Name);
            }
        }
        class Employee : Person
        {
            public string Company { get; set; }
            public Employee(string name, string company)
                : base(name)
            {
                Company = company;
            }

            public void Display2()
            {
                Console.WriteLine(Name + "2");
            }
            public override void Display()
            {
                Console.WriteLine($"{Name} work {Company}");
            }
        }

        [SetUp]
        public void BeforeAll()
        {
            //AppiumOptions options = new AppiumOptions();
            //options.PlatformName = "Android";

            //options.AddAdditionalCapability("deviceName", "My Phone");
            //options.AddAdditionalCapability("udid", "emulator-5554");
            //options.AddAdditionalCapability("platformVersion", "8.0");
            //options.AddAdditionalCapability("automationName", "UiAutomator2");
            ////options.AddAdditionalCapability("browserName", "Chrome");
            //options.AddAdditionalCapability("appPackage", "io.selendroid.testapp");
            //options.AddAdditionalCapability("appActivity", "io.selendroid.testapp.HomeScreenActivity");

            //Uri url = new Uri("http://127.0.0.1:4723/wd/hub");

            //driver = new AndroidDriver<AndroidElement>(url, options);
        }

        [Test]
        public void Test1_EnButtonVerification()
        {
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.EnButton.Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(homePage.IsVisible(driver, homePage.PopupEnText), "Text 'This will end the activity' is absent");
                Assert.IsTrue(homePage.IsVisible(driver, homePage.PopupEnYesButton), "'I agree' button is absent");
                Assert.IsTrue(homePage.IsVisible(driver, homePage.PopupEnNoButton),"'No, no' button is absent");
            });

            homePage.PopupEnNoButton.Click();
            Assert.IsTrue(homePage.isElementDisappeared(driver, BasePage.SearchVariant.Xpath, "//android.widget.Button[@text='I agree']", 5), "'I agree' button is displayed");
        }

        [Test]
        public void Test2_RegistrationVerification()
        {
            var userData = UserDataModel.DefaultData;
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.RegistrationButton.Click();
            registrationPage.UserNameInputText.SendKeys(userData.UserName);
            registrationPage.EmailInputText.SendKeys(userData.Email);
            registrationPage.PasswordInputText.SendKeys(userData.Password);
            registrationPage.NameInputText.Clear();
            registrationPage.NameInputText.SendKeys(userData.Name);
            driver.HideKeyboard();
            registrationPage.ProgrammingLanguageButton.Click();
            registrationPage.GetProrammingLanguageCheckedTextView(userData.PreferedProgrammingLanguage).Click();
            registrationPage.AcceptAddsCheckBox.Click();
            registrationPage.RegisterVerifyButton.Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.UserVerifyTextView), "Text view 'Verify user' isn't displayed");
                Assert.AreEqual(registrationPage.UserVerifyName.Text, userData.Name, "Expected Name and actual Name aren't equal");
                Assert.AreEqual(registrationPage.UserVerifyUserName.Text, userData.UserName, "Expected UserName and actual UserName aren't equal");
                Assert.AreEqual(registrationPage.UserVerifyEmail.Text, userData.Email, "Expected E-mail and actual E-mail aren't equal");
                Assert.AreEqual(registrationPage.UserVerifyPassword.Text, userData.Password, "Expected Password and actual Password aren't equal");
                Assert.AreEqual(registrationPage.UserVerifyProgrammingLanguage.Text, userData.PreferedProgrammingLanguage, "Expected Programming language and actual Programming language aren't equal");
                Assert.AreEqual(registrationPage.UserVerifyAcceptAdds.Text, userData.AcceptAdds, "Expected 'I accept adds' check status and actual 'I accept adds' check status aren't equal");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.RegisterUserButton), "'Register User' button isn't displayed");
            });
            registrationPage.RegisterUserButton.Click();
            Assert.AreEqual("true", homePage.AcceptAddsCheckBox.GetAttribute("checked"), "'I accept adds'  isn't checked");
        }

        [Test]
        public void Test3_ProgressBarVerification()
        {
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.ProgressBarButton.Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(homePage.IsVisible(driver, homePage.PopupProgressBarDialog), "Text 'This will end the activity' is absent");
                Assert.IsFalse(homePage.isElementDisappeared(driver, BasePage.SearchVariant.Xpath, "//android.widget.TextView[@text='Waiting Dialog']", 15), "'I agree' button is displayed");
            });

            driver.HideKeyboard();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.UserNameInputText), "'Username' input field isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.EmailInputText), "'Email' input field isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.PasswordInputText), "'Password' input field isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.NameInputText), "'Name' input field isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.ProgrammingLanguageButton), "'Programming Language' isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.AcceptAddsCheckBox), "'I accept adds' checkbox isn't displayed");
                Assert.IsTrue(registrationPage.IsVisible(driver, registrationPage.RegisterVerifyButton), "'Register User' button isn't displayed");
            });
        }

        [Test]
        public void Test4_TextViewVerification()
        {
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.DisplayTextViewButton.Click();
            Assert.IsTrue(homePage.IsVisible(driver, homePage.VisibleTextViewText), "Text 'This will end the activity' is absent");
        }

        [Test]
        public void Test5_FocusVerification()
        {
            string stringForTest = "Should only be found once";
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);      
            Assert.AreEqual("true", homePage.StartInputTextField.GetAttribute("focused"), "'Start input text field' is out of focus");
            homePage.DisplayAndFocusLayoutButton.Click();
            Assert.AreEqual("false", homePage.StartInputTextField.GetAttribute("focused"), "'Start input text field' is in focus");
            Assert.AreEqual(stringForTest, homePage.DisplayAndFocusLayoutTextView.Text, "Strings are not equal");
            homePage.DisplayAndFocusLayoutButton.Click();
            Assert.AreEqual("true", homePage.StartInputTextField.GetAttribute("focused"), "'Start input text field' is out of focus");
        }

        [Test]
        public void Test6_TouchActionsVerification()
        {
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.TouchActionsButton.Click();
            TouchActionsPage actionsPage = new TouchActionsPage(driver);
            actionsPage.waitFor(1000);
            Actions act = new Actions(driver);
            act.DoubleClick(actionsPage.GestureTypeTextView).Build().Perform();
            //Assert.IsTrue(actionsPage.IsVisible(driver, actionsPage.GestureTypeTextView), "'Gesture Type' text view isn't displayed");
            //ActionsClass.tapOnElement(driver, actionsPage.GestureTypeTextView);
            //Assert.AreEqual(ActionsClass.tapActionString, actionsPage.GestureTypeTextView.Text, "Expected 'Single Tap' text and actual gesture type aren't equal");
            //ActionsClass.SwipeInDirection(driver, ActionsClass.SwipeDirection.Right);
            //Assert.AreEqual(ActionsClass.flickActionString, actionsPage.GestureTypeTextView.Text, "Expected 'Flick' text and actual gesture type aren't equal");
            //ActionsClass.longPressOnElement(driver, actionsPage.GestureTypeTextView);
            //Assert.AreEqual(ActionsClass.longPressActionString, actionsPage.GestureTypeTextView.Text, "Expected 'Long Press' text and actual gesture type aren't equal");
            //ActionsClass.SwipeInDirection(driver, ActionsClass.SwipeDirection.Down);
            //Assert.AreEqual(ActionsClass.scrollActionString, actionsPage.GestureTypeTextView.Text, "Expected 'Scroll' text and actual gesture type aren't equal");

        }

        [Test]
        public void Test7_SayHelloPageVerification()
        {
            int numberOfPreferedTestFile = 1;
            UserDataModel userData = UserDataModel.DefaultData;
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            AppWebBrowserPage browserPage = new AppWebBrowserPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.BrowserButton.Click();
            browserPage.waitFor(1000);
            browserPage.WebDriverTestFileDropDownButton.Click();
            Assert.IsTrue(browserPage.IsVisible(driver, browserPage.AlertTitleTextView), "'Webdriver Test File' text view is absent");
            browserPage.GetWebDriverTestFileTextView("Demo").Click();
            Assert.Multiple(() =>
            {
                Assert.AreEqual("'Say Hello'-Demo", browserPage.WebDrivertestFileDropDownButtonText.Text, "'Say Hello Demo' button is absent");
                Assert.IsTrue(browserPage.IsVisible(driver, browserPage.PreferedCarDropDownButton), "'Preffered Car' dropdown button is absent");
                Assert.IsTrue(browserPage.IsVisible(driver, browserPage.SendYourNameButton), "'Send me your name!' button is absent");
            });
            browserPage.EnterNameTextInput.Clear();
            browserPage.EnterNameTextInput.SendKeys(userData.Name);
            browserPage.PreferedCarDropDownButton.Click();
            browserPage.GetPrefferedCarCheckedTextView(userData.PreferedCar).Click();
            browserPage.SendYourNameButton.Click();
            Assert.Multiple(() =>
            {
                Assert.AreEqual($"\"{userData.Name}\"", browserPage.EnteredNameTextView.GetAttribute("content-desc"), "Entered 'Name' and displayed 'Name' are not equal");
                Assert.AreEqual($"\"{userData.PreferedCar}\"".ToLower(), browserPage.PreferedCarTextView.GetAttribute("content-desc"), "Entered 'Prefered car' and displayed 'Prefered car' are not equal");
            });

            browserPage.ClickHereLink.Click();
            Assert.IsTrue(browserPage.IsVisible(driver, browserPage.WebDriverTestFileDropDownButton), "'Say Hello Demo' button is absent");
        }

        [Test]
        public void Test8_VerifyToastMessageAppearance()
        {
            string toastMessage = "Hello selendroid toast!";
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.DisplayToastButton.Click();         
            Assert.AreEqual(toastMessage, homePage.ToastMessage.Text, $"Toast message didn't appear");
        }

        [Test]
        public void Test9_LoginWebNewPM()
        {
            string testUrl = "https://newpm.dataart.com/Index";
            NewPmPage newPmPage = new NewPmPage(driver);
            driver.Navigate().GoToUrl(testUrl);
            var currentContexts = driver.Contexts;
            driver.Context = currentContexts[0];
            newPmPage.UserNameInputText.SendKeys("Ydemchenko");
            newPmPage.PasswordInputText.SendKeys("Ghjcnjz@70");
            newPmPage.SignInButton.Click();
            Assert.IsTrue(newPmPage.SearchButton.Displayed, $"'Search' button isn't displayed");
        }

        [Test]
        public void Test10_PopupWindowVerification()
        {
            string toastMessage = "Hello selendroid toast!";
            HomeTestAppPage homePage = new HomeTestAppPage(driver);
            homePage.chechkIsAlertPresent(driver);
            homePage.DisplayPopupWindowButton.Click();
            var cont = driver.Contexts;
            var source = driver.PageSource;
            homePage.DisplayPopupWindowButton.Click();
        }
    }
}
