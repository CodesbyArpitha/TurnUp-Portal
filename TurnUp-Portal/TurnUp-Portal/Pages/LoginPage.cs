using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_Portal.Pages
{
    public class LoginPage
    {
        //Functions that allow users to login to TurnUp Portal

        public void LoginActions(IWebDriver driver) 
        {
          

            //Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();

            //Identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");
            Thread.Sleep(1000);

            //Identify password textbox and enter valid username
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //Identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            //Thread.Sleep(3000);


            // check if user has logged in successfully
            //This is explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a")));
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            


            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User succesfully logged in. Test Passed :)");
            }
            else
            {
                Console.WriteLine("User login failed. Test Failed :(");
            }
        }
    }
}
