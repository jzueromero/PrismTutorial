using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTuto.Services
{
    public interface IMyTabbedPageSelectedTab
    {
        int SelectedTab { get; set; }
        void SetSelectedTab(int tabIndex);
    }
}
