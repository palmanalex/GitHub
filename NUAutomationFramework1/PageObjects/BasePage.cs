using NUnit.Allure.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUAutomationFramework1.PageObjects
{
    [AllureNUnit]
    class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }
        public void FillText(IWebElement el, string text)
        {
            el.Clear();
            el.SendKeys(text);
        }
        public void Click(IWebElement el)
        {
            Thread.Sleep(1000);
            el.Click();
        }
        public string GetText(IWebElement el)
        {
            return el.Text;
        }
        /*
        * Call this method with your element and a color like (red,green,orange etc...)
        */
        private void HighlightElement(IWebElement element, String color)
        {
            //keep the old style to change it back
            String originalStyle = element.GetAttribute("style");
            String newStyle = "background-color:yellow;border: 1px solid " + color + ";" + originalStyle;
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            // Change the style 
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '" + newStyle + "');},0);",
                    element);

            // Change the style back after few miliseconds
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '"
                    + originalStyle + "');},400);", element);

        }
    }
}
