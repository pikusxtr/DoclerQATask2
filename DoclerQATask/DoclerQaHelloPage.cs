using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DoclerQaTask
{

    public class DoclerQaHelloPage : DoclerQaBasePage
    {
        private readonly IWebDriver _driver;

        public DoclerQaHelloPage(IWebDriver browser) : base(browser)
        {
            _driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public bool IsOnHelloPage()
        {
            return _driver.Url.Contains("/hello.html");
        }
    }
}