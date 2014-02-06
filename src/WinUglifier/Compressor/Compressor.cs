using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Compressor
{
    public class Compressor : ICompressor
    {
        private Yahoo.Yui.Compressor.ICompressor compressor;
        public Compressor(Yahoo.Yui.Compressor.CssCompressor compressor)
        {
            this.compressor = compressor;
        }

        public Compressor(Yahoo.Yui.Compressor.JavaScriptCompressor compressor)
        {
            this.compressor = compressor;
        }

        public string Compress(string source)
        {
            return this.compressor.Compress(source);
        }
    }
}
