using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Murano.Appulate.Tests
{
    class SignInPage
    {
        private readonly IWebDriver _driver;

        private const string SelectorForEmailTextbox = "#email";
        private const string SelectorForPasswordTextbox = "#password";
        private const string SelectorForSubmitButton = "form > button";

        [FindsBy(How = How.CssSelector, Using = SelectorForEmailTextbox)]
        private IWebElement _email;

        [FindsBy(How = How.CssSelector, Using = SelectorForPasswordTextbox)]
        private IWebElement _password;

        [FindsBy(How = How.CssSelector, Using = SelectorForSubmitButton)]
        private IWebElement _button;

        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void LogInAccount(string userEmail, string userPassword)
        {
            _email.Clear();
            _email.SendKeys(userEmail);
            _password.SendKeys(userPassword);
            _button.Submit();
        }

    }
}
