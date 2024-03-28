using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Handlers
{
    class CustomShellHandler : ShellRenderer
    {

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            return new CustomShellItemRenderer(this);
        }
    }

}
