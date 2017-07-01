using Murano.Appulate.HelpersForTests;
using Murano.Appulate.Tests;

namespace Murano.Appulate.ConsoleAppForBugTrack
{
    class Program
    {
        static void Main()
        {
            SeleniumTestsForAppulate test = new SeleniumTestsForAppulate(DriverTypes.Chrome);
            test.UploadImageInAdditionalInformation();
        }
    }
}
