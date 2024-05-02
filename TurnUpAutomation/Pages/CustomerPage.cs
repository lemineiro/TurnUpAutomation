using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpAutomation.Utilities;

namespace TurnUpAutomation.Pages
{
    public class CustomerPage
    {
        public void CreateCustomerRecord(IWebDriver driver)
        {
            //Click on the Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Enter Name
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Chuck");

            //Click on the Edit Contact button
            IWebElement editContactButton = driver.FindElement(By.Id("EditContactButton"));
            editContactButton.Click();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id=\"contactDetailWindow\"]/iframe")));

            Wait.WaitToBeVisible(driver, "Id", "FirstName", 10);

            //Enter first name
            IWebElement firstNameTextbox = driver.FindElement(By.XPath("//*[@id=\"FirstName\"]"));
            firstNameTextbox.SendKeys("Chuck");

            //Enter last name
            IWebElement lastNameTextbox = driver.FindElement(By.XPath("//*[@id=\"LastName\"]"));
            lastNameTextbox.SendKeys("Norris");

            //Click on Phone
            //Enter phone
            IWebElement phoneTextbox = driver.FindElement(By.Id("Phone"));
            phoneTextbox.SendKeys("123123");

            //Enter email
            IWebElement emailTextbox = driver.FindElement(By.Id("email"));
            emailTextbox.SendKeys("norris@domain.com");

            //Click on Save Contact
            IWebElement saveContactButton = driver.FindElement(By.Id("submitButton"));
            saveContactButton.Click();

            driver.SwitchTo().DefaultContent();

            Wait.WaitToBeVisible(driver, "Id", "IsSameContact", 5);

            //Click on Same as above box
            IWebElement checkboxButton = driver.FindElement(By.Id("IsSameContact"));
            checkboxButton.Click();

            //Click on Save
            IWebElement saveButton = driver.FindElement(By.Id("submitButton"));
            saveButton.Click();

            IWebElement administrationDropdown = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
            administrationDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a", 2);

            IWebElement customerOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a"));
            customerOption.Click();

        }

        public void CreateCustomerRecordAssertion(IWebDriver driver) 
        {
            Thread.Sleep(5000);

            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//a[@title='Go to the last page']"));
            goToTheLastPageButton.Click();

            IWebElement newName = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));

            Assert.That(newName.Text == "Chuck", "New name and expected code do not match");
        }

        public void EditCustomerRecord(IWebDriver driver)
        {
            //Go to the last page
            Thread.Sleep(5000);

            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//a[@title='Go to the last page']"));
            goToTheLastPageButton.Click();

            Thread.Sleep(5000);

            //Find record created
            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
            Console.WriteLine(findRecordCreated.Text);

            if (findRecordCreated.Text == "Chuck")
            {
                //Click on Edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[4]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited.");
            }

            //Switch to edit frame
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id=\"detailWindow\"]/iframe")));

            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.Clear();
            nameTextbox.SendKeys("Jack");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("submitButton"));
            saveButton.Click();

            //Swith to default content
            driver.SwitchTo().DefaultContent();

            driver.Navigate().Refresh();
        }

        public void EditCustomerRecordAssertion(IWebDriver driver)
        {
            //Go to the last page
            Thread.Sleep(5000);

            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//a[@title='Go to the last page']"));
            goToTheLastPageButton.Click();

            Thread.Sleep(5000);

            //Find edited record on contact textbox
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
            Console.WriteLine(createdCode.Text);

            Assert.That(createdCode.Text == "Jack", "New record code and expected code do not match");
        }

        public void DeleteCustomerRecord(IWebDriver driver)
        {

        }

        public void DeleteCustomerRecordAssertion(IWebDriver driver)
        {

        }
    }
}
