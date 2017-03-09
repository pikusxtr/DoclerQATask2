using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DoclerQaTask
{

    public class DoclerQaMainPage : DoclerQaBasePage
    {
        private readonly IWebDriver _driver;
        private readonly By _defaultPageLocator = By.TagName("img");


        private readonly string _url = @"http://uitest.duodecadits.com/";
        public DoclerQaMainPage(IWebDriver browser) : base(browser)
        {
            _driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, bool> waitForElement = web => web.FindElement(_defaultPageLocator).Displayed;
            wait.Until(waitForElement);
        }

        public DoclerQaFormPage NavigateToForm()
        {
            PageMenu.FormButton.Click();
            return new DoclerQaFormPage(_driver);
        }

        public String PTagText()
        {
            return PTag.Text;
        }

    }
}