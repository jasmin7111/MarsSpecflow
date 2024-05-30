using NUnit.Framework;
using OpenQA.Selenium;
using TurnupPortalSpecFlow.Utilities;

namespace Mars.Pages
{
    public class LanguagePage
    {
        public void AddLanguage(IWebDriver driver, string language)
        {
            // Click on Add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            // enter language
            IWebElement languageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            languageTextbox.SendKeys(language);

            // Select  dropdown list
            IWebElement levelDropdownList = driver.FindElement(By.XPath("//select[@name='level']"));
            levelDropdownList.Click();

            // Select level from dropdown list
            IWebElement chooselevelDropdownList = driver.FindElement(By.XPath("//option[@value='Conversational']"));
            chooselevelDropdownList.Click();

            //click on Add button
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            saveButton.Click();


        }

        public void AssertAddLanguage(IWebDriver driver, String language)
        {
            

            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(newLanguage.Text == language, "New language record has not been created. Test failed!");
        }

        public void EditLanguageRecord(IWebDriver driver, String language, String editedlanguage)
        {
            

            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (recordToBeEdited.Text == language)
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found.");
            }


            try
            {
                //Edit the language details
                IWebElement languageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                languageTextbox.Clear();
                languageTextbox.SendKeys(editedlanguage);
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit button isn't working", ex.Message);
            }


            //Click save
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(2000);


        }

        public void AssertEditLanguage(IWebDriver driver, String editedlanguage)
        {
            // Check if new language record has been created successfully

            

            IWebElement language = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(language.Text == editedlanguage, "New language field has not been created. Test failed!");
        }
        public void DeleteLanguageRecord(IWebDriver driver, String language)
        {


            Thread.Sleep(2000); 
           

            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (recordToBeDeleted.Text == language)
            {
                //Click on delete button on a selected record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to deleted has not been found.");
            }

            Thread.Sleep(1000);

           

            driver.Navigate().Refresh();

            Thread.Sleep(3000);

        }

        public void AssertDeleteLanguageRecord(IWebDriver driver, String language)
        {
            //Check if the language record is deleted
           

            IWebElement deletedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));

            Assert.That(deletedLanguage.Text != language, "Record hasn't been deleted successfully. Test Failed");
        }
    }
}
