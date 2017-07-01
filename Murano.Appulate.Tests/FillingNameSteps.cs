using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murano.Appulate.HelpersForTests;
using OpenQA.Selenium;

namespace Murano.Appulate.Tests
{
    class FillingNameSteps
    {
        private readonly IWebDriver _driver;

        private const string NewInsuredsName = "Murano Software";

        private const string SelectorOfInsuredsNameTextbox = "table[class=\"section-table\"] table[class=\"section-table\"] " +
                                                             "tr:nth-child(2) input[type=\"text\"]";
        private const string SelectorOfReturnOnAppPageLink = "div[class=\"content\"] > a";
        private const string SelectorOfExpandListLink = "div[class=\"customer\"]>a";

        public FillingNameSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillNameTextbox()
        {
            var nameTextbox = _driver.FindElement(By.CssSelector(SelectorOfInsuredsNameTextbox));
            nameTextbox.Clear();
            nameTextbox.SendKeys(NewInsuredsName);
        }

        public bool CheckChangesNameOnAppPage()
        {
            _driver.FindElement(By.CssSelector(SelectorOfReturnOnAppPageLink)).Click();
            return _driver.FindElement(By.CssSelector(SelectorOfExpandListLink)).Text == NewInsuredsName;
        }
    }
}
