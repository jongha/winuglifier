using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.TreeView
{
    public class TreeNode : System.Windows.Forms.TreeNode
    {
        private string value;

        public TreeNode()
            : base()
        {
        }

        public TreeNode(string value, string text)
            : base(text)
        {
            this.value = value;
        }

        public string Value
        {
            set
            {
                this.value = value;
            }

            get
            {
                return this.value;
            }
        }
    }
}
