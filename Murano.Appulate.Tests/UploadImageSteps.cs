using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Murano.Appulate.Tests
{
    class UploadImageSteps
    {
        private readonly IWebDriver _driver;

        public UploadImageSteps(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
