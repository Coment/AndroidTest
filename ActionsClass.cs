using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AndroidTest
{
    public static class ActionsClass
    {
        public enum SwipeDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public static string tapActionString = "SINGLE TAP CONFIRMED";
        public static string doubleTapActionString = "ON DOUBLE TAP EVENT";
        public static string flickActionString = "FLICK";
        public static string longPressActionString = "LONG PRESS";
        public static string scrollActionString = "SCROLL";

        public static void scrollToElement(this AndroidDriver<AndroidElement> driver, By locator)
        {
            var element = driver.FindElement(locator);
            TouchAction action = new TouchAction(driver);
            Size size = driver.Manage().Window.Size;
            action.Press(size.Width / 2, 70).Wait(100).MoveTo(element.Location.X, element.Location.Y);
            action.Perform();
        }

        public static void tapOnElement(this AndroidDriver<AndroidElement> driver, IWebElement element)
        {            
            TouchAction touchAction = new TouchAction(driver);
            touchAction.Tap(element).Perform();
        }

        public static void longPressOnElement(this AndroidDriver<AndroidElement> driver, IWebElement element)
        {
            TouchAction touchAction = new TouchAction(driver);
            touchAction.LongPress(element).Perform();
        }

        public static void Click(this IWebElement element, IWebDriver driver)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
        }


        public static void SwipeInDirection(this AndroidDriver<AndroidElement> driver, SwipeDirection direction)
        {
            Size size = driver.Manage().Window.Size;
            var action = new TouchAction(driver);
            //double startx, starty, endx, endy = 0;
            switch (direction)
            {
                case SwipeDirection.Up:
                    swipeAction(driver, size.Width / 2, 50, size.Width / 2, (int)(size.Height * 0.9) - 50, 100);
                    break;
                case SwipeDirection.Down:
                    swipeAction(driver, size.Width / 2, 100, size.Width / 2, (int)(size.Height * 0.9) - 50, 100);
                    break;
                case SwipeDirection.Right:
                    swipeAction(driver, 200, size.Height / 2, (int)(size.Width * 0.9) - 50, size.Height / 2, 100);
                    break;
            }

            driver.PerformTouchAction(action);
        }

        public static void swipeAction(this AndroidDriver<AndroidElement> driver, double startX, double startY, double endX, double endY, int duration)
        {
            var action = new TouchAction(driver);
            action.Press(startX, startY).Wait(duration).MoveTo(endX, endY).Release().Perform();
        }

        public static void swipeVertical(this AndroidDriver<AndroidElement> driver, double startPercentage, double finalPercentage)
        {
            Size size = driver.Manage().Window.Size;
            int width = (int)(size.Width / 2);
            int startPoint = (int)(size.Height * startPercentage);
            int endPoint = (int)(size.Height * finalPercentage);
            new TouchAction(driver)
                .Press(width, startPoint)
                .Wait(100)
                .MoveTo(width, endPoint)
                .Release()
                .Perform();
        }

        public static void SwipeTest(this AndroidDriver<AndroidElement> driver)
        {
            var element = driver.FindElement(By.Id("gesture_type_text_view"));
            Point point = element.Location;
            Size size = element.Size;
            new TouchAction(driver)
                .Press(point.X + 5, point.Y + 5)
                .Wait(200)
                .MoveTo(point.X + size.Width - 5, point.Y + size.Height - 5)
                .Release()
                .Perform();
        }
    }
}
