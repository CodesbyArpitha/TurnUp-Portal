using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

public class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

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
        Thread.Sleep(3000);

        //check if user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User succesfully logged in. Test Passed :)");
        }
        else
        {
            Console.WriteLine("User login failed. Test Failed :(");
        }

        //Create Time and Material Record
        // Navigate to Time and Material Page
        IWebElement administrationButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationButton.Click();
        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();
        Thread.Sleep(3000);

        //Click on Create New Button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        //Select Time from dropdown
        IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropDown.Click();
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();
        

        //Type code into Code Textbox
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("Practice Time Record");

        //Type description  in description textbox
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("Demo");

        //Type the price in price textbox
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();
        //Thread.Sleep(1000);
        //priceTagOverlap.SendKeys("120");
        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("120");

        //Click on save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(2000);

        //Check if time record has been created successfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newCode.Text == "Practice Time Record")
        {
            Console.WriteLine("Time Record Created Successfully!");


        }
        
        else
        {
            Console.WriteLine("Time Record has not been Created");
        }



        //Editing the last record from the table

        //Click on Edit Option

        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();
        Thread.Sleep(2000);

        //Change the Type code of the record

        IWebElement typeCodeInEdit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeInEdit.Click();
        Thread.Sleep(2000);
        IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
        materialOption.Click();

        //Change the text in Code Text Box

        IWebElement editCodeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
        editCodeTextbox.Clear();
        editCodeTextbox.SendKeys("Edited Code");

        IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
        editSaveButton.Click();
        Thread.Sleep(2000);

        //Deleting the last record from the table

        IWebElement goToLastPageButtonToDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButtonToDelete.Click();
        Thread.Sleep(1000);
        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteButton.Click();
        Thread.Sleep(2000);
        driver.SwitchTo().Alert().Accept();

        IWebElement verifyDeletion = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (verifyDeletion.Text != "Edited Code")
        {
            Console.WriteLine("Record deleted successfully!");

        }

        else
        {
            Console.WriteLine("Record has not been deleted");
        }











    }

    

}