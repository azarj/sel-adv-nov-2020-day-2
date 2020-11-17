using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumAdvancedNov2020.Framework.Pages
{
    public class HotelsManagementPage : BaseWebPage
    {
        [FindsBy(How = How.CssSelector, Using = "[type].btn-success")]
        public IWebElement BtnAdd { get; set; }

        public AddHotelPage NavigateToAddHotelPage()
        {
            return BtnAdd.NavigateToPage<AddHotelPage>();
        }
    }
}