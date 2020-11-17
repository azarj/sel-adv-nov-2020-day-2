using OpenQA.Selenium;
using SeleniumAdvancedNov2020.Framework.Pages;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAdvancedNov2020.Framework.Shared
{
    public class MenuItemControl : FactoryBase<MenuItemControl>
    {
        [FindsBy(How = How.XPath, Using = "//ul[@id='social-sidebar-menu']/li")]
        public IList<IWebElement> MenuItemList { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='social-sidebar-menu']/li//ul[@aria-expanded='true']/li")]
        public IList<IWebElement> SubMenuItemList { get; set; }

        public T NavigateTo<T>(params string[] menuItems) where T : class
        {
            if (menuItems[0] == null)
            {
                Console.WriteLine("Menu items should have at least one element!");
            }
            MenuItemList.FirstOrDefault(el => el.Text.Equals(menuItems[0])).PerformClick();
            if (menuItems[1] != null)
            {
                SubMenuItemList.FirstOrDefault(el => el.Text.Equals(menuItems[1])).PerformClick();
            }

            var page = Activator.CreateInstance(typeof(T));
            return (T)page;
        }
    }
}