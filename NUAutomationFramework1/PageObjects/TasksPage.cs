using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUAutomationFramework1.PageObjects
{
    class TasksPage : BasePage
    {
        public TasksPage(IWebDriver driver) : base(driver){}
        public IWebElement NewTaskField => Driver.FindElement(By.CssSelector("#task"));
        public IWebElement NewTaskSubmitField => Driver.FindElement(By.CssSelector("#newtask_submit"));
        public IWebElement NewTaskAdvField => Driver.FindElement(By.CssSelector("#newtask_adv>span"));
        public IWebElement TextField => Driver.FindElement(By.CssSelector("#search"));
        public IWebElement GetTextField => Driver.FindElement(By.CssSelector("#total"));
        public IWebElement AddListField => Driver.FindElement(By.CssSelector(".mtt-tabs-add-button"));
        public IWebElement GetNameTask => Driver.FindElement(By.CssSelector(".task-title"));
        public IWebElement GetAdvTask => Driver.FindElement(By.CssSelector(".task-title"));
        public void AddSimpleTask(string task)
        {
            FillText((NewTaskField), task);
            Click(NewTaskSubmitField);
        }
        public void OpenAdvTask()
        {
            Click(NewTaskAdvField);
            Thread.Sleep(1500);
        }
        public void Search(string text)
        {
            FillText((TextField), text);
            Thread.Sleep(1500);
        }
        public int GetNumTasks()
        {
            string s = GetText(GetTextField);
            //Console.WriteLine(s);
            //string t = GetText(Driver.FindElement(By.CssSelector(".task-title")));
            int num = Int32.Parse(s);
            return num;
        }
        public string GetTask()
        {
            string tn = GetText(GetNameTask);
            return tn;
        }
        public void AddList(string name)
        {
            Click(AddListField);
            Thread.Sleep(1000);
            Driver.SwitchTo().Alert().SendKeys(name);
            Driver.SwitchTo().Alert().Accept();
        }
        public void ChooseList(string name)
        {
            IList<IWebElement> list = Driver.FindElements(By.CssSelector("li>a>span"));
            foreach (IWebElement el in list)
            {
                if (el.Text.Equals(name))
                {
                    Click(el);
                    break;
                }
            }
        }
    }
}
