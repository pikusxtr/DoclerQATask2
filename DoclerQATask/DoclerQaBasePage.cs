using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DoclerQaTask
{

    public class DoclerQaBasePage
    {
        private readonly IWebDriver _driver;
        public DoclerQaPageMenu PageMenu { get; }

        public DoclerQaBasePage(IWebDriver browser)
        {
            _driver = browser;
            PageFactory.InitElements(browser, this);
            PageMenu = new DoclerQaPageMenu(browser);

        }

        [FindsBy(How = How.Id, Using = "dh_logo")]
        public IWebElement Logo { get; set; }

        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement H1Tag { get; set; }

        [FindsBy(How = How.TagName, Using = "p")]
        public IWebElement PTag { get; set; }

        public bool IsLogoVisible()
        {
            return Logo.Displayed;
        }

        public String PageTitle()
        {
            return _driver.Title;
        }

        public String TagText(string tagName)
        {
            return _driver.FindElement(By.TagName(tagName)).Text;
        }

    }
}