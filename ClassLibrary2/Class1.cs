using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TestClassLibrary
{
    public class TestClass
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            var SignUpPage = driver.FindElement(By.ClassName("login"));
            SignUpPage.Click();

            var EmailInput = driver.FindElement(By.Id("email"));
            EmailInput.SendKeys("pasichnikmaks@gmail.com");

            var PasswordInput = driver.FindElement(By.Id("passwd"));
            PasswordInput.SendKeys("new123");

            var SubmitLoginButton = driver.FindElement(By.Id("SubmitLogin"));
            SubmitLoginButton.Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    
        [Test]
        public void CheckContactUsPage()
        {
            var CatalogLink = driver.FindElement(By.Id("contact-link"));
            CatalogLink.Click();
        }
        [Test]
        public void ChangeProfile()
        {
            var PersonalInfo = driver.FindElement(By.ClassName("icon-user"));
            PersonalInfo.Click();

            var FirstNameInput = driver.FindElement(By.Id("firstname"));
            FirstNameInput.Clear();
            FirstNameInput.SendKeys("Hi");

            var LastNameInput = driver.FindElement(By.Id("lastname"));
            LastNameInput.Clear();
            LastNameInput.SendKeys("Max");

            var OldPasswordInput = driver.FindElement(By.Id("old_passwd"));
            OldPasswordInput.SendKeys("new123");

            var SubmitInfoButton = driver.FindElement(By.Name("submitIdentity"));
            SubmitInfoButton.Click();
        }
    }
}
