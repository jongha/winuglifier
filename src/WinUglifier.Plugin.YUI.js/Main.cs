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
        private static string name = "YUI Compression JS";

        public Main() : base(name)
        {
        }

        public override object Execute(object input)
        {
            Yahoo.Yui.Compressor.JavaScriptCompressor compressor = new Yahoo.Yui.Compressor.JavaScriptCompressor();
            return compressor.Compress((string)input);
        }
    }
}
