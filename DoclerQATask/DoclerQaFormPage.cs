using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace DoclerQaTask
{

    public class DoclerQaFormPage : DoclerQaBasePage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"http://uitest.duodecadits.com/form.html";
        private readonly By DefaultPageLocator = By.TagName("img");


        public DoclerQaFormPage(IWebDriver browser) : base(browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "hello-input")]
        public IWebElement TextInput { get; set; }

        [FindsBy(How = How.Id, Using = "hello-submit")]
        public IWebElement SubmitButton { get; set; }

        public void Open()
        {
            this.driver.Navigate().GoToUrl(this.url);
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return Web.FindElement(DefaultPageLocator).Displayed;

            });
            wait.Until(waitForElement);
        }


        public void SetInputText(string inputText)
        {
            this.TextInput.SendKeys(inputText);
        }
        public void NavigateToHome()
        {
            this.pageMenu.HomeButton.Click();
        }

        public int elementsCount(string tagName, string type)
        {
            return this.driver.FindElements(By.CssSelector(tagName + "[type=" + type + "]")).Count;
        }

        public void SubmitForm()
        {
            this.SubmitButton.Click();
        }

    }
}