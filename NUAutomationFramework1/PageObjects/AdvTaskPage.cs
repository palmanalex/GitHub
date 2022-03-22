using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUAutomationFramework1.PageObjects
{
	class AdvTaskPage : BasePage
	{
		public AdvTaskPage(IWebDriver driver) : base(driver){}
		public IWebElement SelectField => Driver.FindElement(By.CssSelector("[name='prio']"));
		public IWebElement DateField => Driver.FindElement(By.CssSelector("#duedate"));
		public IWebElement TaskField => Driver.FindElement(By.CssSelector("[name='task'].in500"));
		public IWebElement NoteField => Driver.FindElement(By.CssSelector("[name='note'].in500"));
		public IWebElement TagsField => Driver.FindElement(By.CssSelector("#edittags"));
		public IWebElement SaveBtn => Driver.FindElement(By.CssSelector("[value='Save']"));
		public IWebElement GetAdvTask => Driver.FindElement(By.CssSelector(".task-title"));
		public void FillForm(string priority, string date, string task, string note, string tags)
		{
			SelectElement select = new SelectElement(SelectField);
			select.SelectByValue(priority);
			FillText((DateField), date);
			FillText((TaskField), task);
			FillText((NoteField), note);
			FillText((TagsField), tags);
			Click(SaveBtn);
			Thread.Sleep(1500);
		}
		public string GetAdvName()
		{
			string at = GetText(GetAdvTask);
			return at;
		}
	}
}
