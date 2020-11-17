using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumAdvancedNov2020.Framework.Pages
{
    public class LoginPage : FactoryBase<LoginPage>
    {

        [FindsBy(How =How.Name, Using = "email")]
        public IWebElement TxtUsername { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement BtnLogin { get; set; }

        public HomePage LoginApp()
        {
            TxtUsername.PerformSendKeys("admin@phptravels.com");
            TxtPassword.PerformSendKeys("demoadmin");
            return BtnLogin.NavigateToPage<HomePage>();
        }
    }
}
