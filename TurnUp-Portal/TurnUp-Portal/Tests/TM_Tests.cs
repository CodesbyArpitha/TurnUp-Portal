using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp_Portal.Pages;
using TurnUp_Portal.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace TurnUp_Portal.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver 
    {
        [SetUp]
        public void SetUpSteps()

        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            //Login Page Object Initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home Page Object Initialization and Definition

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test(TMPage tmPageObj)
        {
           
            tmPageObj.CreateTimeRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTimeRecord(driver);
        }
        [Test]
        public void DeleteTime_Test()
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTimeRecord(driver);
        }
        [TearDown]
        public void CloseTestRun()
        { 
            driver.Quit();
        }

    }
}
