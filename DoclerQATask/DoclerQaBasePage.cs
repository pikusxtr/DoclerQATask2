using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace DoclerQaTask
{

    public class DoclerQaBasePage
    {
        private readonly IWebDriver driver;
        private readonly By DefaultPageLocator = By.TagName("img");
        public DoclerQaPageMenu pageMenu { get; }

        public DoclerQaBasePage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            pageMenu = new DoclerQaPageMenu(browser);

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
            return driver.Title;
        }

        public String TagText(string tagName)
        {
            return driver.FindElement(By.TagName(tagName)).Text;

        }

    }
}