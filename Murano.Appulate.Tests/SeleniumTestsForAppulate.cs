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
        private MainSteps _mainSteps;
        private UploadImageSteps _uploadImageSteps;
        private FillingNameSteps _fillingNameSteps;
        private const string SiteUrl = "https://appulatebeta.com/";

        public SeleniumTestsForAppulate(DriverTypes type)
        {
            _driver = DriverInitHelper.CreateDriver(type);
        }

        [SetUp]
        public void Init()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = SiteUrl;

            _mainSteps = new MainSteps(_driver);
            _uploadImageSteps = new UploadImageSteps(_driver);
            _fillingNameSteps = new FillingNameSteps(_driver);
        }

        [Test]
        public void UploadImageInAdditionalInformation()
        {
            _mainSteps.LogInAccountOfInsurer();
            _mainSteps.ExpandListOfAppAndPolicies();
            Assert.AreEqual("krol appulate testing agency", _mainSteps.GetNameOfProviderCompany().ToLower());
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
            _mainSteps.ExpandListOfAppAndPolicies();
            Assert.AreEqual("krol appulate testing agency", _mainSteps.GetNameOfProviderCompany().ToLower());
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
