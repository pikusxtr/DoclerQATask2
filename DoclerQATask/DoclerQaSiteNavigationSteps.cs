using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using TechTalk.SpecFlow;

namespace DoclerQaTask
{
    [Binding]

    public sealed class DoclerQaSiteNavigationSteps
    {
        static IWebDriver driver;
        static DoclerQaMainPage mainPage;
        static DoclerQaPageMenu pageMenu;
        static DoclerQaFormPage formPage;
        static DoclerQaHelloPage helloPage;
        static DoclerQaBasePage basePage;

        string homePageText = "Welcome to the Docler Holding QA Department";
        string formPageText = "Simple Form Submission";
        string errorPageUrl = "http://uitest.duodecadits.com/error";
        int actualStatusCode;


        [BeforeFeature]
        public static void Before()
        {
            driver = new ChromeDriver("C:\\bins");
            mainPage = new DoclerQaMainPage(driver);
            pageMenu = new DoclerQaPageMenu(driver);
            formPage = new DoclerQaFormPage(driver);
            helloPage = new DoclerQaHelloPage(driver);
            basePage = new DoclerQaBasePage(driver);
        }




        [Given(@"I open Main page")]
        [When(@"I open Main page")]
        public void WhenIOpenMainPage()
        {
            mainPage.Open();
        }


        [Given(@"I open Form page")]
        [When(@"I open Form page")]
        public void WhenIOpenFormPage()
        {
            formPage.Open();
        }

        [Then(@"Page title is equal to ""(.*)""")]
        public void ThenPageTitleIsEqualTo(string pageTitle)
        {
            Assert.AreEqual(pageTitle, mainPage.PageTitle());
        }

        [When(@"I click Form button")]
        public void WhenIClickFormButton()
        {
            pageMenu.FormButton.Click();
        }

        [When(@"I click Home button")]
        public void WhenIClickHomeButton()
        {
            pageMenu.HomeButton.Click();
        }

        [When(@"I click UITesting button")]
        public void WhenIClickUITestingButton()
        {
            pageMenu.UITestingButton.Click();
        }


        [When(@"I click Error button")]
        public void WhenIClickErrorButton()
        {
            pageMenu.ErrorButton.Click();
        }

        [Then(@"Text in ""(.*)"" tag is equal to ""(.*)""")]
        public void ThenTextInTagIsEqualTo(string tagName, string tagText)
        {
            Assert.AreEqual(tagText, mainPage.TagText(tagName));
        }

        [Then(@"Home Page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            Assert.AreEqual(homePageText, mainPage.TagText("h1"));
        }

        [Then(@"Form Page is displayed")]
        public void ThenFormPageIsDisplayed()
        {
            Assert.AreEqual(formPageText, formPage.TagText("h1"));
        }


        [Then(@"Hello Page is displayed")]
        public void ThenHelloPageIsDisplayed()
        {
            Assert.True(helloPage.IsOnHelloPage());
        }

        [Then(@"(.*) ""(.*)"" of type ""(.*)"" element is displayed")]
        public void ThenOfTypeElementIsDisplayed(int elemCount, string tagName, string typeAttribute)
        {
            Assert.True(formPage.elementsCount(tagName, typeAttribute).Equals(elemCount));
        }

        [Then(@"Home button is active")]
        public void ThenHomeButtonIsActive()
        {
            Assert.True(pageMenu.IsMenuButtonActive(pageMenu.HomeButton));
        }

        [Then(@"Form button is active")]
        public void ThenFormButtonIsActive()
        {
            Assert.True(pageMenu.IsMenuButtonActive(pageMenu.FormButton));
        }

        [When(@"I submit (.*)")]
        public void WhenISubmit(string textToSubmit)
        {
            formPage.SetInputText(textToSubmit);
            formPage.SubmitForm();
        }

        [Then(@"(.*) text is displayed")]
        public void ThenTextIsDisplayed(string resultText)
        {
            Assert.AreEqual(resultText, helloPage.TagText("h1"));
        }

        [Then(@"Logo image is displayed")]
        public void ThenLogoImageIsDisplayed()
        {
            Assert.True(basePage.IsLogoVisible());
        }

        [When(@"I send GET request for Error Page")]
        public void WhenISendGETRequestForErrorPage()
        {
            HttpWebResponse taskresponse = null;
            var task = (HttpWebRequest)WebRequest.Create(errorPageUrl);
            try
            {
                taskresponse = (HttpWebResponse)task.GetResponse();
            }
            catch (WebException e)
            {
                var response = e.Response as HttpWebResponse;
                actualStatusCode = (int)response.StatusCode;
            }
        }

        [Then(@"HTTP Response status code is equal to (.*)")]
        public void ThenHTTPResponseStatusCodeIsEqualTo(int statusCode)
        {
            Assert.AreEqual(statusCode, actualStatusCode);
        }


        [AfterFeature]
        public static void After()
        {
            driver.Quit();
        }

    }
}
