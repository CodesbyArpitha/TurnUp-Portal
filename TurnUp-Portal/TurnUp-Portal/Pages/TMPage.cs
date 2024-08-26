using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TurnUp_Portal.Utilities;

namespace TurnUp_Portal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create New Button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select Time from dropdown
            IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropDown.Click();
            //This is Fluent wait
            Wait.WaitToBeVisible(driver, "Xpath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 1);
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

            Assert.That(newCode.Text == "Practice Time Record", "Time Record has not been Created");
            //if (newCode.Text == "Practice Time Record")
            //{
            //    Console.WriteLine("Time Record Created Successfully!");


            //}

            //else
            //{
            //    Console.WriteLine("Time Record has not been Created");
            //}
        }

        public void EditTimeRecord(IWebDriver driver)
        
            {
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

            }

            public void DeleteTimeRecord(IWebDriver driver)
            {
                IWebElement goToLastPageButtonToDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPageButtonToDelete.Click();
                Thread.Sleep(1000);
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(1000);

                IWebElement verifyDeletion = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

                if (verifyDeletion.Text != "Edited Code" || verifyDeletion == null) 
                {
                    Console.WriteLine("Record deleted successfully!");

                }

                else
                {
                    Console.WriteLine("Record has not been deleted");
                }

                
            }
        }
    }

