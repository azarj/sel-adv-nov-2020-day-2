using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvancedNov2020.Framework
{
    public static class WebElement
    {
        private static bool Available(IWebElement element)
        {
            return element != null && element.Displayed && element.Enabled;
        }

        public static Func<IWebDriver, bool> AvailabilityTest(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    //Log.Info($"Is element {element.GetAttribute("innerHTML")} interactive with: {Available(element)}");
                    return Available(element);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            };
        }

        public static void WaitForElement(this IWebElement element)
        {
            var wait = new DefaultWait<IWebDriver>(BrowserInstance.Browser.Instance)
            {
                Timeout = TimeSpan.FromSeconds(20),
                PollingInterval = TimeSpan.FromMilliseconds(30)

            };
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(NotFoundException));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until
            (
                driver =>
                {
                    try
                    {
                        wait.Until(AvailabilityTest(element));
                        return true;
                    }
                    catch (StaleElementReferenceException e)
                    {

                        //log this exception
                    }
                    return false;
                }
            );
        }

        public static void HighLightElement(IWebElement element)
        {
            var jsExecutor = (BrowserInstance.Browser.Instance as IJavaScriptExecutor);
            var color = @"arguments[0].style.outline = '2px dashed green';";
            jsExecutor.ExecuteScript(color, element);
        }

        public static IWebElement Element(IWebElement element)
        {
            WaitForElement(element);
            HighLightElement(element);
            return element;
        }

        public static void PerformClick(this IWebElement element)
        {
            Element(element).Click();
        }

        public static void PerformSendKeys(this IWebElement element, string text)
        {
            var existingElement = Element(element);
            existingElement.Clear();
            existingElement.SendKeys(text);
        }

        public static T NavigateToPage<T>(this IWebElement element) where T : class
        {
            element.PerformClick();
            var page = Activator.CreateInstance(typeof(T));
            return (T)page;
        }
    }
}
