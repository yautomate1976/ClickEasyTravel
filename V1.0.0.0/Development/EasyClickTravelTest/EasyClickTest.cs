using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.IO;
using System.Reflection;

namespace EasyClickTravelTest
{
    [TestClass]
    public class EasyClickTest
    {
        [TestMethod]
        public void OpenFireFoxTest()
        {       
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string solutionConfigurationType = Path.GetFileName(outputPath);
            string assemblyLocation = null;            
            if (File.Exists(@"..\\..\\..\\..\\Execution\\" + solutionConfigurationType + "\\geckodriver.exe"))
            {
                assemblyLocation = "Debug";
            }
                else
            {
                assemblyLocation = "Release";
            }
            string driverPath = "..\\..\\..\\..\\Execution\\" + assemblyLocation + "\\";
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverPath);
            FirefoxDriver driver = new FirefoxDriver(service);
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.easyclicktravel.com";
            Thread.Sleep(5000);
            driver.Dispose();   
        }
    }
}
