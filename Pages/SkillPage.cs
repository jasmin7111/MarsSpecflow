using NUnit.Framework;
using OpenQA.Selenium;
using TurnupPortalSpecFlow.Utilities;

namespace Mars.Pages
{
    public class SkillPage
    {
        public void AddSkills(IWebDriver driver, string skills)
        {
            // Click on Add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            // enter skill
            IWebElement skillTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            skillTextbox.SendKeys(skills);

            // Select  dropdown list
            IWebElement levelDropdownList = driver.FindElement(By.XPath("//select[@name='level']"));
            levelDropdownList.Click();

            // Select level from dropdown list
            IWebElement chooselevelDropdownList = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
            chooselevelDropdownList.Click();

            //click on Add button
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            saveButton.Click();


        }

        public void AssertAddSkills(IWebDriver driver, String skills)
        {

            Thread.Sleep(2000);
            IWebElement newSkills = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(newSkills.Text == skills, "New skills record has not been created. Test failed!");
        }

        public void EditSkillsRecord(IWebDriver driver, String skills, String newSkills)
        {


            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (recordToBeEdited.Text == skills)
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found.");
            }


            try
            {
                //Edit the skills details
                IWebElement skillsTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                skillsTextbox.Clear();
                skillsTextbox.SendKeys(newSkills);
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

        public void AssertEditSkills(IWebDriver driver, String newSkills)
        {
            // Check if new skills record has been created successfully



            IWebElement skills = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(skills.Text == newSkills, "New skills field has not been created. Test failed!");
        }
        public void DeleteSkillsRecord(IWebDriver driver, String skills)
        {


            Thread.Sleep(2000);


            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (recordToBeDeleted.Text == skills)
            {
                //Click on delete button on a selected record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i\r\n"));
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

        public void AssertDeleteSkillsRecord(IWebDriver driver, String skills)
        {
            //Check if the skills record is deleted


            IWebElement deletedSkills = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(deletedSkills.Text != skills, "Record hasn't been deleted successfully. Test Failed");
        }
    }
}
