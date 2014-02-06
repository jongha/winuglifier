using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Compressor
{
    public static class CompressorFactory
    {
        public enum CompressorType
        {
            None = -1,
            CSS = 0,
            JS = 1,
        }

        public static CompressorType GetCompressorType(string path)
        {
            string ext = Path.GetExtension(path);
            ext = ext.Trim().ToLower();

            if (ext == ".js")
            {
                return CompressorType.JS;
            }
            else if (ext == ".css")
            {
                return CompressorType.CSS;
            }

            return CompressorType.None;
        }

        public static ICompressor GetCompressor(string name, CompressorType type)
        {
            if (type != CompressorType.None)
            {
                switch (name)
                {
                    case "YUI Compressor":
                        switch (type)
                        {
                            case CompressorType.CSS:
                                return (ICompressor)new Compressor(new Yahoo.Yui.Compressor.CssCompressor());
                            case CompressorType.JS:
                                return (ICompressor)new Compressor(new Yahoo.Yui.Compressor.JavaScriptCompressor());
                        }
                        break;
                }
            }
            return null;
        }
    }
}
