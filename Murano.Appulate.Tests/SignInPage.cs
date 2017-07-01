using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Murano.Appulate.Tests
{
    class SignInPage
    {
        private readonly IWebDriver _driver;

        private const string SelectorOfEmailTextbox = "#email";
        private const string SelectorOfPasswordTextbox = "#password";
        private const string SelectorOfSubmitButton = "form > button";

        [FindsBy(How = How.CssSelector, Using = SelectorOfEmailTextbox)]
        private IWebElement _email;

        [FindsBy(How = How.CssSelector, Using = SelectorOfPasswordTextbox)]
        private IWebElement _password;

        [FindsBy(How = How.CssSelector, Using = SelectorOfSubmitButton)]
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
