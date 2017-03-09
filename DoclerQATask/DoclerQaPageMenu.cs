using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DoclerQaTask
{

    public class DoclerQaPageMenu
    {
        public DoclerQaPageMenu(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "site")]
        public IWebElement UiTestingButton { get; set; }

        [FindsBy(How = How.Id, Using = "home")]
        public IWebElement HomeButton { get; set; }

        [FindsBy(How = How.Id, Using = "form")]
        public IWebElement FormButton { get; set; }

        [FindsBy(How = How.Id, Using = "error")]
        public IWebElement ErrorButton { get; set; }


        public bool IsMenuButtonActive(IWebElement button)
        {
            return button.FindElement(By.XPath("..")).GetAttribute("class").Equals("active");
        }


    }
}