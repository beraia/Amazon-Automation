using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Automation
{
    internal class Program
    {
        //Create a reference for chrome browser
        IWebDriver driver = new ChromeDriver();
        
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            //Go to Amazon page
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        [Test]
        public void ExecuteTest()
        {
            //Make the browser full screen
            driver.Manage().Window.Maximize();

            IWebElement SignIn = driver.FindElement(By.Id("nav-link-accountList"));
            SignIn.Click();

            IWebElement EmailField = driver.FindElement(By.Id("ap_email"));
            EmailField.SendKeys("pewpew@gmile.com");

            IWebElement ContinueButton = driver.FindElement(By.Id("continue"));
            ContinueButton.Click();

            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "There was a problem";
            Assert.AreEqual(ActualErrorMessageText, ExpectedErrorMessageText);
        }

        [TearDown]
        public void CloseTest()
        {
            //Close the browser
            driver.Quit();
        }
    }
}
