using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Plugin
{
    public enum PluginType : int
    {
        None = 0,
        JS = 1,
        CSS = 2
    };

    public interface IPlugin : IDisposable
    {
        string Name { get; set; }
        PluginType Type { get; set; }
        object Execute(object input);
    }
}
