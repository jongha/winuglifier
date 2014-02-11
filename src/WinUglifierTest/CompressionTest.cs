using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinUglifier.Plugin;
using System.IO;

namespace WinUglifierTest
{
    [TestClass]
    public class CompressionTest
    {
        [TestMethod]
        public void YuiJSCompressionTest()
        {
            IPlugin plugin = new WinUglifier.Plugin.YUI.js.Main();
            string dir = Directory.GetCurrentDirectory() + "\\testcase\\input\\js";

            if (Directory.Exists(dir))
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string input = reader.ReadToEnd();
                        string output = (string)plugin.Execute(input);

                        Assert.IsTrue(output.Length < input.Length);
                    }
                }
            }
        }

        [TestMethod]
        public void YuiCSSCompressionTest()
        {
            IPlugin plugin = new WinUglifier.Plugin.YUI.css.Main();
            string dir = Directory.GetCurrentDirectory() + "\\testcase\\input\\css";

            if (Directory.Exists(dir))
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string input = reader.ReadToEnd();
                        string output = (string)plugin.Execute(input);

                        Assert.IsTrue(output.Length < input.Length);
                    }
                }
            }
        }
    }
}
