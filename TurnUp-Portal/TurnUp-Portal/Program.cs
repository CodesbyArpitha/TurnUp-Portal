using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TurnUp_Portal.Pages;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Support.UI;

public class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        //Implicit Wait 
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        //Login Page Object Initialization and Definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home Page Object Initialization and Definition

        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //TM Page Object Initialization and Definition

        TMPage tmPageObj = new TMPage();
        tmPageObj.CreateTimeRecord(driver);
        tmPageObj.EditTimeRecord(driver);
        tmPageObj.DeleteTimeRecord(driver);


    }

}