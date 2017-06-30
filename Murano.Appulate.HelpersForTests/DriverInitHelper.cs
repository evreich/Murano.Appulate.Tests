using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace Murano.Appulate.HelpersForTests
{
    public enum DriverTypes { Chrome, Explorer, Edge }

    public static class DriverInitHelper
    {
        public static IWebDriver CreateDriver(DriverTypes type)
        {
            string pathToDrivers = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\");
            switch (type)
            {
                case (DriverTypes.Chrome):
                    return new ChromeDriver(pathToDrivers);
                case (DriverTypes.Edge):
                    return new EdgeDriver(pathToDrivers);
                case (DriverTypes.Explorer):
                    return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(pathToDrivers));
                default:
                    throw new ArgumentException("Incorrect type.");
            }
        }
    }
}
