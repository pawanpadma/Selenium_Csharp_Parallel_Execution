using NUnit.Framework;
using nunit_datadriven.pageobjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nunit_datadriven.commons
{
    //[TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class SetupClass : InitBrowser
    {
        public IWebDriver _driver;
        public HomePage home;
        public LoginPage login;
        public Read_ini read;

        [OneTimeSetUp]
        public void initApplication()
        {
        }

        [SetUp]
        public void loginToApp()
        {
            _driver = Getbrowser();
            _driver.Navigate().GoToUrl(ReadEnv.ReadData("base", "appUrl"));
            _driver.Manage().Window.Maximize();
            read = new Read_ini();
            home = new HomePage(_driver);
            login = new LoginPage(_driver);

            home.TapLoginLink();
            login.AssertLogin();
            login.loginToApplication(ReadEnv.ReadData("base", "username"), ReadEnv.ReadData("base", "password"));
        }

        [TearDown]
        public void logout()
        {
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
        }
    }
}