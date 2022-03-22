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
    class AdvancedTasksTest:BaseTest
    {
        [AllureSeverity(SeverityLevel.critical)]
        [Test, Description("add simple task to the tasks list")]
        public void TC02_Page2()
        {
            TasksPage tp = new TasksPage(driver);
            tp.OpenAdvTask();
            Thread.Sleep(1500);
            AdvTaskPage atp = new AdvTaskPage(driver);
            atp.FillForm("1", "24/02/22", "myAdvancedTask", "myNote", "myTag");
            Thread.Sleep(1500);
            string taskAdvName = atp.GetAdvName();
            Assert.That(taskAdvName, Is.EqualTo("myAdvancedTask"));
        }
    }
}
