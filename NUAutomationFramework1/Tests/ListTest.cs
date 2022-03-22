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
    class ListTest:BaseTest
    {
        [AllureSeverity(SeverityLevel.critical)]
        [Test, Description("add simple task to the tasks list")]
        public void TC03_Page3()
        {
            TasksPage tp = new TasksPage(driver);

            tp.AddList("MyPage");
            Thread.Sleep(1000);
            tp.ChooseList("MyPage");
            tp.AddSimpleTask("MyTask1");
            Thread.Sleep(1000);
            tp.AddSimpleTask("MyTask2");
            Thread.Sleep(1000);
            int num = tp.GetNumTasks();
            Thread.Sleep(1500);
            Assert.That(num.Equals(2));           
        }
    }
}
