﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpAutomation.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver, string username, string password)
        {
            //Open Chrome browser

            driver.Manage().Window.Maximize();

            //Launch TurnUp Portal and navigate to website login page

            string baseURL = "http://horse.industryconnect.io/";
            driver.Navigate().GoToUrl(baseURL);

            try
            {
                //Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                //Identify password textbox and enter password
                IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
                passwordTextbox.SendKeys("123123");

                //Identify login button and click on Login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            }
            catch (Exception)
            {
                Assert.Fail("TurnUp Portal login page did not launch");
                throw;
            }
        }
    }
}

