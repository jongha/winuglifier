using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Compressor
{
    public interface ICompressor
    {
        string Compress(string source);
    }
}
