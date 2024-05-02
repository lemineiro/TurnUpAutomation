using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpAutomation.Utilities;

namespace TurnUpAutomation.Pages
{
    public class HomePage
    {
        public void NavigateToCustomerPage(IWebDriver driver)
        {
            //Click on the Admin dropdown menu and navigate to Customer module
            IWebElement administrationDropdown = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
            administrationDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a", 2);

            IWebElement customerOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a"));
            customerOption.Click();
        }
    }
}
