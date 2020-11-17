using SeleniumExtras.PageObjects;

namespace SeleniumAdvancedNov2020.Framework.Pages
{
    public class FactoryBase<T> where T : class
    {
        public FactoryBase()
        {
            PageFactory.InitElements(BrowserInstance.Browser.Instance, this);
        }
    }
}
