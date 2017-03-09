using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace DoclerQaTask
{

    public class DoclerQaMainPage : DoclerQaBasePage
    {
        private readonly IWebDriver driver;
        private readonly By DefaultPageLocator = By.TagName("img");


        private readonly string url = @"http://uitest.duodecadits.com/";
        public DoclerQaMainPage(IWebDriver browser) : base(browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return Web.FindElement(DefaultPageLocator).Displayed;

            });
            wait.Until(waitForElement);
        }

        public DoclerQaFormPage NavigateToForm()
        {
            pageMenu.FormButton.Click();
            return new DoclerQaFormPage(driver);
        }

        public String PTagText()
        {
            return PTag.Text;
        }

    }
}