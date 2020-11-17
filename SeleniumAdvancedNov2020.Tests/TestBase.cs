using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvancedNov2020.Framework.BrowserInstance;
using SeleniumAdvancedNov2020.Framework.Pages;

namespace SeleniumAdvancedNov2020.Tests
{
    public class TestBase
    {
        public LoginPage loginPage { get; set; }

        [TestInitialize]
        public void TestSetup()
        {
            Browser.StartBrowser();
            Browser.Instance.Navigate().GoToUrl("http://www.phptravels.net/admin");

            loginPage = new LoginPage();
           
        }

        [TestCleanup]
        public void CleanUp()
        {

            Browser.Instance.Quit();
        }
    }
}