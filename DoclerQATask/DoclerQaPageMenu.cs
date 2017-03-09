using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DoclerQaTask
{

    public class DoclerQaPageMenu
    {
        private readonly IWebDriver driver;

        public DoclerQaPageMenu(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "site")]
        public IWebElement UITestingButton { get; set; }

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