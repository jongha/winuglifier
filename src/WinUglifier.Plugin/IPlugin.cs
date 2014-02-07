using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Plugin
{
    public interface IPlugin : IDisposable
    {
        string Name { get; set; }
        object Execute(object input);
    }
}
