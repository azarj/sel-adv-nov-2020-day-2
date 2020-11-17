using SeleniumAdvancedNov2020.Framework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvancedNov2020.Framework.Pages
{
    public class BaseWebPage : FactoryBase<BaseWebPage>
    {
        public MenuItemControl menuItemControl => new MenuItemControl();
    }
}
