using System;
using System.IO;
using System.Threading;
using Murano.Appulate.HelpersForTests;
using OpenQA.Selenium;

namespace Murano.Appulate.Tests
{
    class MainSteps
    {
        private readonly IWebDriver _driver;
        private SignInPage _signinPage;

        private const string SelectorOfSignInLink = "div[class=\"hero-header__top\"]>a:last-child";
        private const string SelectorOfExpandListLink = "div[class=\"customer\"]>a";
        private const string SelectorOfProviderCompanyLink = "#ui-id-1";
        private const string SelectorOfNeededAppLink = "a[data-policy-id=\"666739\"]";

        private readonly string _pathToCredentials = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\credentials.txt");

        public MainSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        private void RedirectOnSighInPage()
        {
            //Browsers remember sign in page after first enter on start page and avoiding start page later.
            if (_driver.Title.ToLower() != "sign in to appulate")
                _driver.FindElement(By.CssSelector(SelectorOfSignInLink)).Click();
        }

        public void LogInAccountOfInsurer()
        {
            RedirectOnSighInPage();
            var credentials = DataHelper.GetAuthData(_pathToCredentials);
            _signinPage = new SignInPage(_driver);
            _signinPage.LogInAccount(credentials[0], credentials[1]);
        }

        public void ExpandListOfAppAndPolicies()
        {
            _driver.FindElement(By.CssSelector(SelectorOfExpandListLink)).Click();
            Thread.Sleep(2000);
        }

        public void ClickOnLinkToOpenWorkersCompensationApp()
        {
            _driver.FindElement(By.CssSelector(SelectorOfNeededAppLink)).Click();
        }

        public string GetNameOfProviderCompany()
        {
            return _driver.FindElement(By.CssSelector(SelectorOfProviderCompanyLink)).Text;
        }

        public string GetTitleOfNeededApp()
        {
            return _driver.FindElement(By.CssSelector(SelectorOfNeededAppLink)).Text;
        }
    }
}
