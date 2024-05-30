using Mars.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions
    {

        IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObject = new LoginPage();
        HomePage homePageObject = new HomePage();
        LanguagePage langPageObject = new LanguagePage();
        SkillPage skillPageObject = new SkillPage();

        [Given(@"I log into Mars portal")]
        public void GivenILogIntoMarsPortal()
        {
           loginPageObject.LoginSteps(driver);
            Thread.Sleep(2000);
        }

       
        [When(@"I navigate to Language page")]
        public void WhenINavigateToLanguagePage()
        {
            homePageObject.GoToLanguagePage(driver);
            Thread.Sleep(2000);
        }


        [When(@"I create a new Language record '([^']*)'")]
        public void WhenICreateANewLanguageRecord(string language)
        {
            langPageObject.AddLanguage(driver, language);
            Thread.Sleep(2000);
        }

        [Then(@"the record should be saved '([^']*)'")]
        public void ThenTheRecordShouldBeSaved(string language)
        {
            langPageObject.AssertAddLanguage(driver, language);
            driver.Quit();
        }


        [When(@"I edit an existing Language record '([^']*)' '([^']*)'")]
        public void WhenIEditAnExistingLanguageRecord(string language, string editedlanguage)
        {
            langPageObject.EditLanguageRecord(driver, language, editedlanguage);
        }

        [Then(@"the record should be updated '([^']*)'")]
        public void ThenTheRecordShouldBeUpdated(string editedlanguage)
        {
            langPageObject.AssertEditLanguage(driver, editedlanguage);
            driver.Quit();
        }

        [When(@"I delete an existing Language record '([^']*)'")]
        public void WhenIDeleteAnExistingLanguageRecord(string language)
        {
           langPageObject.DeleteLanguageRecord(driver, language);
        }

        [Then(@"the record should be deleted '([^']*)'")]
        public void ThenTheRecordShouldBeDeleted(string language)
        {
            langPageObject.AssertDeleteLanguageRecord(driver, language);
            driver.Quit();
        }

        [When(@"I navigate to Skills page")]
        public void WhenINavigateToSkillsPage()
        {
            homePageObject.GoToSkillsPage(driver);
            Thread.Sleep(1000);
        }

        [When(@"I create a new Skills record '([^']*)'")]
        public void WhenICreateANewSkillsRecord(string skills)
        {
            skillPageObject.AddSkills(driver, skills);
        }
        [Then(@"the skill should be saved '([^']*)'")]
        public void ThenTheSkillShouldBeSaved(string skills)
        {
            skillPageObject.AssertAddSkills(driver, skills);
            driver.Quit();
        }


        [When(@"I edit an existing Skills record '([^']*)' '([^']*)'")]
        public void WhenIEditAnExistingSkillsRecord(string skills, string newSkills)
        {
            skillPageObject.EditSkillsRecord(driver, skills, newSkills);
        }

        [Then(@"the old skills record should be updated '([^']*)'")]
        public void ThenTheOldSkillsRecordShouldBeUpdated(string newSkills)
        {
            skillPageObject.AssertEditSkills(driver, newSkills);
            driver.Quit();
        }

        [When(@"I delete an existing Skills record '([^']*)'")]
        public void WhenIDeleteAnExistingSkillsRecord(string skills)
        {
            skillPageObject.DeleteSkillsRecord(driver, skills);
        }

        [Then(@"the skill record should be deleted '([^']*)'")]
        public void ThenTheSkillRecordShouldBeDeleted(string skills)
        {
            skillPageObject.AssertDeleteSkillsRecord(driver, skills);
            driver.Quit();
        }






    }
}
