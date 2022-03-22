using Allure.Commons;
using NUAutomationFramework1.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUAutomationFramework1.Tests
{
    [AllureNUnit]
    class AddSimpleTaskTest:BaseTest
    {
        [AllureSeverity(SeverityLevel.critical)]
        [Test, Description("add simple task to the tasks list")]
        public void TC01_Page1()
        {
            TasksPage tp = new TasksPage(driver);
            tp.AddSimpleTask("First Task");
            Thread.Sleep(3000);
            string taskName=tp.GetTask();
            Assert.That(taskName, Is.EqualTo("First Task"));
        }
    }
}
