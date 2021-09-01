using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidTest.PageObject
{
    class TouchActionsPage : BasePage
    {
        public TouchActionsPage(AndroidDriver<AndroidElement> driver) : base(driver)
        { 
        }
        
        public IWebElement LastGesture => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "last_gesture_text_view");
        public AndroidElement GestureTypeTextView => FindElementIgnoreException(driver, BasePage.SearchVariant.Id, "gesture_type_text_view");
    }
}
