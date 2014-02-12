using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUglifier.Plugin;

namespace WinUglifier.Plugin.YUI.js
{
    public class Main : Plugin
    {
        private static PluginType type = PluginType.JS;
        private static string name = "YUI Compression JS";

        public Main()
            : base(type, name)
        {
        }

        public override object Execute(object input)
        {
            return new Yahoo.Yui.Compressor.JavaScriptCompressor().Compress((string)input);
        }
    }
}
