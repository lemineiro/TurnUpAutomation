using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnUpAutomation.Pages;
using TurnUpAutomation.Utilities;

namespace TurnUpAutomation.StepDefinitions
{
    [Binding]
    public class CustomerStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        CustomerPage customerPageObj = new CustomerPage();

        [BeforeScenario]

        public void LoginFunction()
        {
            driver = new ChromeDriver();
        }

        [AfterScenario]

        public void QuitTestRun()
        {
            driver.Quit();
        }

        [Given(@"user logs into turnup portal")]
        public void GivenUserLogsIntoTurnupPortal()
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");
        }

        [Given(@"user navigates to the Customer page")]
        public void GivenUserNavigatesToTheCustomerPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToCustomerPage(driver);
        }

        [When(@"user creates a new Customer record")]
        public void WhenUserCreatesANewCustomerRecord()
        {
            CustomerPage customerPageObj = new CustomerPage();
            customerPageObj.CreateCustomerRecord(driver);
        }

        [Then(@"system should save the new Customer record")]
        public void ThenSystemShouldSaveTheNewCustomerRecord()
        {
            customerPageObj.CreateCustomerRecordAssertion(driver);
        }
        [When(@"user edits an existing Customer record")]
        public void WhenUserEditsAnExistingCustomerRecord()
        {
            customerPageObj.EditCustomerRecord(driver);
        }

        [Then(@"system should save the edited Customer record")]
        public void ThenSystemShouldSaveTheEditedCustomerRecord()
        {
            customerPageObj.EditCustomerRecordAssertion(driver);
        }

        [When(@"user deletes an existing Customer record")]
        public void WhenUserDeletesAnExistingCustomerRecord()
        {
            customerPageObj.DeleteCustomerRecord(driver);
        }

        [Then(@"system should delete the Customer record")]
        public void ThenSystemShouldDeleteTheCustomerRecord()
        {
            customerPageObj.DeleteCustomerRecordAssertion(driver);
        }

    }
}
