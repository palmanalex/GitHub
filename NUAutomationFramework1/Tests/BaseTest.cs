using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Xml.Linq;

namespace NUAutomationFramework1.Tests
{
    class BaseTest
    {
        public IWebDriver driver;
        private bool allureEnvWritten;

        [OneTimeSetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.mytinytodo.net/demo/ ";
            if (!allureEnvWritten)
            {
                new XElement("environment",
                new XElement("parameter",
                new XElement("key", "browser"),
                new XElement("value", ((ChromeDriver)driver).Capabilities.GetCapability("browserName"))),
                new XElement("parameter",
                new XElement("key", "browser.version"),
                new XElement("value", ((ChromeDriver)driver).Capabilities.GetCapability("browserVersion"))))
                .Save("..\\..\\..\\allure-results/environment.xml");
                allureEnvWritten = true;
            }
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                AllureLifecycle.Instance.AddAttachment("Full page screenshot", MediaTypeNames.Image.Jpeg, ((ITakesScreenshot)driver).GetScreenshot().AsByteArray);
            }
            driver.Quit();
        }
    }
}
