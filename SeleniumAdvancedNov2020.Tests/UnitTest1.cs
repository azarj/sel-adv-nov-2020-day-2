using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvancedNov2020.Framework.Pages;

namespace SeleniumAdvancedNov2020.Tests
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            var homePage = loginPage.LoginApp();
            var hotelManagementPage = homePage.menuItemControl.NavigateTo<HotelsManagementPage>("HOTELS","HOTELS");
        }
    }
}
