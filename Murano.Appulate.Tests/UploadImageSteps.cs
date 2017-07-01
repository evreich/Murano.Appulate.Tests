using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Murano.Appulate.Tests
{
    class UploadImageSteps
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;
        private readonly WebDriverWait _waitDriver;

        private const string PictureName = "beach.jpg";
        private readonly string _pathToPicture = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"+ PictureName));
        private const string SelectorOfSectionElement = "div[class=\"section-item\"]";
        private const string SelectorOfAdditionalInformationLink = "div[class=\"rc-tooltip-inner\"] li:last-child > a";
        private const string SelectorOfUploadFileInput = "div[class=\"upload-container\"] input";
        private const string SelectorOfSuccessMessage = "div[class=\"ui-message-contents\"]";
        private const string SelectorOfAddedImage = "div[class=\"uploaded-files\"] > div:first-child > a";

        public UploadImageSteps(IWebDriver driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
            _waitDriver = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public void OpenAdditionalInformationOfApp()
        {
            var sectionElem = _driver.FindElement(By.CssSelector(SelectorOfSectionElement));
            _actions.MoveToElement(sectionElem).Build().Perform();
            _driver.FindElement(By.CssSelector(SelectorOfAdditionalInformationLink)).Click();
        }

        public void UploadImageInAdditionalInfotmation()
        {
            var uploadInput = _driver.FindElement(By.CssSelector(SelectorOfUploadFileInput));
            uploadInput.SendKeys(_pathToPicture);
        }

        public bool CheckUploadedFile()
        {
            try
            {
                _waitDriver.Until(ExpectedConditions.ElementExists(By.CssSelector(SelectorOfSuccessMessage)));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return _driver.FindElement(By.CssSelector(SelectorOfAddedImage)).Text== PictureName;
        }
    }
}
