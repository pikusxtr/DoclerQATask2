using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DoclerQaTask
{
    [Binding]

    public sealed class DoclerQaSiteNavigationSteps
    {
        static IWebDriver _driver;
        static DoclerQaMainPage _mainPage;
        static DoclerQaPageMenu _pageMenu;
        static DoclerQaFormPage _formPage;
        static DoclerQaHelloPage _helloPage;
        static DoclerQaBasePage _basePage;

        string _homePageText = "Welcome to the Docler Holding QA Department";
        string _formPageText = "Simple Form Submission";
        string _errorPageUrl = "http://uitest.duodecadits.com/error";
        int _actualStatusCode;


        [BeforeFeature]
        public static void Before()
        {
            _driver = new ChromeDriver("C:\\bins");
            _mainPage = new DoclerQaMainPage(_driver);
            _pageMenu = new DoclerQaPageMenu(_driver);
            _formPage = new DoclerQaFormPage(_driver);
            _helloPage = new DoclerQaHelloPage(_driver);
            _basePage = new DoclerQaBasePage(_driver);
        }




        [Given(@"I open Main page")]
        [When(@"I open Main page")]
        public void WhenIOpenMainPage()
        {
            _mainPage.Open();
        }


        [Given(@"I open Form page")]
        [When(@"I open Form page")]
        public void WhenIOpenFormPage()
        {
            _formPage.Open();
        }

        [Then(@"Page title is equal to ""(.*)""")]
        public void ThenPageTitleIsEqualTo(string pageTitle)
        {
            Assert.AreEqual(pageTitle, _mainPage.PageTitle());
        }

        [When(@"I click Form button")]
        public void WhenIClickFormButton()
        {
            _pageMenu.FormButton.Click();
        }

        [When(@"I click Home button")]
        public void WhenIClickHomeButton()
        {
            _pageMenu.HomeButton.Click();
        }

        [When(@"I click UITesting button")]
        public void WhenIClickUiTestingButton()
        {
            _pageMenu.UiTestingButton.Click();
        }


        [When(@"I click Error button")]
        public void WhenIClickErrorButton()
        {
            _pageMenu.ErrorButton.Click();
        }

        [Then(@"Text in ""(.*)"" tag is equal to ""(.*)""")]
        public void ThenTextInTagIsEqualTo(string tagName, string tagText)
        {
            Assert.AreEqual(tagText, _mainPage.TagText(tagName));
        }

        [Then(@"Home Page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            Assert.AreEqual(_homePageText, _mainPage.TagText("h1"));
        }

        [Then(@"Form Page is displayed")]
        public void ThenFormPageIsDisplayed()
        {
            Assert.AreEqual(_formPageText, _formPage.TagText("h1"));
        }


        [Then(@"Hello Page is displayed")]
        public void ThenHelloPageIsDisplayed()
        {
            Assert.True(_helloPage.IsOnHelloPage());
        }

        [Then(@"(.*) ""(.*)"" of type ""(.*)"" element is displayed")]
        public void ThenOfTypeElementIsDisplayed(int elemCount, string tagName, string typeAttribute)
        {
            Assert.True(_formPage.ElementsCount(tagName, typeAttribute).Equals(elemCount));
        }

        [Then(@"Home button is active")]
        public void ThenHomeButtonIsActive()
        {
            Assert.True(_pageMenu.IsMenuButtonActive(_pageMenu.HomeButton));
        }

        [Then(@"Form button is active")]
        public void ThenFormButtonIsActive()
        {
            Assert.True(_pageMenu.IsMenuButtonActive(_pageMenu.FormButton));
        }

        [When(@"I submit (.*)")]
        public void WhenISubmit(string textToSubmit)
        {
            _formPage.SetInputText(textToSubmit);
            _formPage.SubmitForm();
        }

        [Then(@"(.*) text is displayed")]
        public void ThenTextIsDisplayed(string resultText)
        {
            Assert.AreEqual(resultText, _helloPage.TagText("h1"));
        }

        [Then(@"Logo image is displayed")]
        public void ThenLogoImageIsDisplayed()
        {
            Assert.True(_basePage.IsLogoVisible());
        }

        [When(@"I send GET request for Error Page")]
        public void WhenISendGetRequestForErrorPage()
        {
            var task = (HttpWebRequest)WebRequest.Create(_errorPageUrl);
            try
            {
               task.GetResponse();
                // var httpWebResponse = (HttpWebResponse)
            }
            catch (WebException e)
            {
                var response = e.Response as HttpWebResponse;
                if (response != null) _actualStatusCode = (int)response.StatusCode;
            }
        }

        [Then(@"HTTP Response status code is equal to (.*)")]
        public void ThenHttpResponseStatusCodeIsEqualTo(int statusCode)
        {
            Assert.AreEqual(statusCode, _actualStatusCode);
        }


        [AfterFeature]
        public static void After()
        {
            _driver.Quit();
        }

    }
}
