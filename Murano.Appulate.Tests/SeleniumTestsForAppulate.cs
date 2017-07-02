using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Murano.Appulate.HelpersForTests;

namespace Murano.Appulate.Tests
{
    [TestFixture(DriverTypes.Chrome)]
  //[TestFixture(DriverTypes.Edge)]
    [TestFixture(DriverTypes.Explorer)]
    public class SeleniumTestsForAppulate
    {
        private readonly IWebDriver _driver;
        private readonly MainSteps _mainSteps;
        private readonly UploadImageSteps _uploadImageSteps;
        private readonly FillingNameSteps _fillingNameSteps;
        private const string SiteUrl = "https://appulatebeta.com/";

        public SeleniumTestsForAppulate(DriverTypes type)
        {
            _driver = DriverInitHelper.CreateDriver(type);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _mainSteps = new MainSteps(_driver);
            _uploadImageSteps = new UploadImageSteps(_driver);
            _fillingNameSteps = new FillingNameSteps(_driver);
        }

        [SetUp]
        public void Init()
        {
            _driver.Url = SiteUrl;
        }

        [Test]
        public void UploadImageInAdditionalInformation()
        {
            _mainSteps.LogInAccountOfInsurer();
            Assert.AreEqual("krol appulate testing agency", _mainSteps.GetNameOfProviderCompany().ToLower());
            _mainSteps.ExpandListOfAppAndPolicies();
            Assert.IsTrue(_mainSteps.GetTitleOfNeededApp().ToLower().Contains("workers' compensation"));
            _mainSteps.ClickOnLinkToOpenWorkersCompensationApp();
            _uploadImageSteps.OpenAdditionalInformationOfApp();
            _uploadImageSteps.UploadImageInAdditionalInfotmation();
            Assert.IsTrue(_uploadImageSteps.CheckUploadedFile());
        }

        [Test]
        public void FillingInsureNameInApp()
        {
            _mainSteps.LogInAccountOfInsurer();
            Assert.AreEqual("krol appulate testing agency", _mainSteps.GetNameOfProviderCompany().ToLower());
            _mainSteps.ExpandListOfAppAndPolicies();
            Assert.IsTrue(_mainSteps.GetTitleOfNeededApp().ToLower().Contains("workers' compensation"));
            _mainSteps.ClickOnLinkToOpenWorkersCompensationApp();
            _fillingNameSteps.FillNameTextbox();
            Assert.IsTrue(_fillingNameSteps.CheckChangesNameOnAppPage());
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
