using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murano.Appulate.HelpersForTests;
using OpenQA.Selenium;

namespace Murano.Appulate.Tests
{
    class MainSteps
    {
        private readonly IWebDriver _driver;
        private SignInPage _signinPage;

        private const string SelectorForSignInLink = "div[class=\"hero-header__top\"]>a:last-child";
        private const string SelectorForExpandListLink = "div[class=\"customer\"]>a";
        private const string SelectorForProviderCompanyLink = "#ui-id-1";

        private readonly string _pathToCredentials = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\credentials.txt");

        public MainSteps(IWebDriver driver)
        {
            _driver = driver;
            _signinPage = new SignInPage(_driver);
        }

        public void LogInAccountOfInsurer()
        {
            try
            {
                _driver.FindElement(By.CssSelector(SelectorForSignInLink)).Click();
                var credentials = DataHelper.GetAuthData(_pathToCredentials);
                _signinPage = new SignInPage(_driver);
                _signinPage.LogInAccount(credentials[0], credentials[1]);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void ExpandListOfAppAndPolicies()
        {
            try
            {
                _driver.FindElement(By.CssSelector(SelectorForExpandListLink)).Click();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public string GetNameOfProviderCompany()
        {
            string res = string.Empty;
            try
            {
                res = _driver.FindElement(By.CssSelector(SelectorForProviderCompanyLink)).Text;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return res;
        }
    }
}
