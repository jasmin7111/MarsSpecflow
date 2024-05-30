using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class HomePage
    {
        public void GoToLanguagePage(IWebDriver driver)
        {
            // Navigate to language page
            IWebElement languageTab = driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
            languageTab.Click();

            
        }

        public void GoToSkillsPage(IWebDriver driver)
        {
            // navigate to skills page
            IWebElement skillsTab = driver.FindElement(By.XPath(" //a[contains(text(),'Skills')]"));
            skillsTab.Click();

        }
    }
}
