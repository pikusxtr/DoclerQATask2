using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DoclerQaTask
{

    public class DoclerQaFormPage : DoclerQaBasePage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"http://uitest.duodecadits.com/form.html";
        private readonly By _defaultPageLocator = By.TagName("img");


        public DoclerQaFormPage(IWebDriver browser) : base(browser)
        {
            _driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "hello-input")]
        public IWebElement TextInput { get; set; }

        [FindsBy(How = How.Id, Using = "hello-submit")]
        public IWebElement SubmitButton { get; set; }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, bool> waitForElement = web => web.FindElement(_defaultPageLocator).Displayed;
            wait.Until(waitForElement);
        }


        public void SetInputText(string inputText)
        {
            TextInput.SendKeys(inputText);
        }
        public void NavigateToHome()
        {
            PageMenu.HomeButton.Click();
        }

        public int ElementsCount(string tagName, string type)
        {
            return _driver.FindElements(By.CssSelector(tagName + "[type=" + type + "]")).Count;
        }

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

    }
}