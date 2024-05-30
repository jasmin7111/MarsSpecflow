using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            // launch Mars site
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            Thread.Sleep(1500);
            try
            {
                // identify the SignIn page
                IWebElement signinButton = driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
                signinButton.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("Mars site hasn't launched", ex.Message);
            }

            // identify emailid textbox and enter valid emailid
            IWebElement emailidTextbox = driver.FindElement(By.XPath("//input[contains(@name,'email')]"));
            emailidTextbox.SendKeys("mathewjasmin48@gmail.com");


            // identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[contains(@name,'password')]"));
            passwordTextbox.SendKeys("Mars123");

            // click on login button
            IWebElement loginButton = driver.FindElement(By.XPath(" //button[contains(text(),'Login')]"));
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }
}
