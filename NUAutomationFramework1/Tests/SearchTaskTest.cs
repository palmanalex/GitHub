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
    class SearchTaskTest:BaseTest
    {
        [AllureSeverity(SeverityLevel.critical)]
        [Test, Description("add simple task to the tasks list")]
        public void TC04_Page4()
        {
            TasksPage tp = new TasksPage(driver);
            tp.AddSimpleTask("myTask");
            Thread.Sleep(1500);
            tp.Search("myTask");
            Thread.Sleep(1500);
            int num = tp.GetNumTasks();
            Assert.That(num.Equals(1));

        }
    }
}
