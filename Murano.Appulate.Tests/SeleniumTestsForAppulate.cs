using System;
using System.IO;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using Murano.Appulate.HelpersForTests;

namespace Murano.Appulate.Tests
{
    [TestFixture(DriverTypes.Chrome)]
    [TestFixture(DriverTypes.Edge)]
    [TestFixture(DriverTypes.Explorer)]
    public class SeleniumTestsForAppulate
    {
        private readonly IWebDriver _driver;
        private MainSteps _mainSteps;
        private UploadImageSteps _uploadImageSteps;
        private const string SiteUrl = "https://appulatebeta.com/";

        public SeleniumTestsForAppulate(DriverTypes type)
        {
            _driver = DriverInitHelper.CreateDriver(type);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = SiteUrl;
        }

        [OneTimeSetUp]
        public void Init()
        {
            _mainSteps = new MainSteps(_driver);
            _uploadImageSteps = new UploadImageSteps(_driver);
        }

        [Test]
        public void UploadImageInAdditionalInformation()
        {
            _mainSteps.LogInAccountOfInsurer();
            _mainSteps.ExpandListOfAppAndPolicies();
            Assert.AreEqual("Krol Appulate Testing Agency", _mainSteps.GetNameOfProviderCompany());

        }
       
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
