using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace DoclerQaTask
{

    public class DoclerQaHelloPage : DoclerQaBasePage
    {
        private readonly IWebDriver driver;

        public DoclerQaHelloPage(IWebDriver browser) : base(browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public bool IsOnHelloPage()
        {
            return driver.Url.Contains("/hello.html");
        }
    }
}