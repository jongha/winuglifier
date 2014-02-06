using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WinUglifier.Compressor;

namespace WinUglifier
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            rdoOverwrite.Checked = true;
            rdoRename.Enabled = false;

            comboAlgorithms.Items.Add("YUI Compressor");
            comboAlgorithms.SelectedIndex = 0;
        }

        private void btnUglify_Click(object sender, EventArgs e)
        {
            if (comboAlgorithms.SelectedIndex == 0)
            {
                Compression(treeItems.Nodes);
            }

        }

        private void Compression(TreeNodeCollection nodes)
        {
            for (int i = nodes.Count - 1; i >= 0; --i)
            {
                Compression(nodes[i].Nodes);

                if (nodes[i].Nodes.Count == 0)
                {
                    string result = string.Empty;
                    string fileName = ((WinUglifier.TreeView.TreeNode)nodes[i]).Value;
                    if (string.IsNullOrEmpty(fileName)) { continue; }

                    ICompressor compressor = Compressor.CompressorFactory.GetCompressor(
                        comboAlgorithms.SelectedItem.ToString(),
                        Compressor.CompressorFactory.GetCompressorType(fileName)
                        );

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        result = compressor.Compress(reader.ReadToEnd());
                    }

                    if (!string.IsNullOrEmpty(result))
                    {
                        using (StreamWriter writer = new StreamWriter(((WinUglifier.TreeView.TreeNode)nodes[i]).Value))
                        {
                            writer.Write(result);
                        }
                    }
                }

                nodes[i].Remove();
            }
        }

        private bool IsAddableType(string item)
        {
            string css = chkCSS.Checked ? "css" : string.Empty;
            string js = chkJavascript.Checked ? "js" : string.Empty;

            string pattern = ".*([^\\.][^m][^i][^n])\\.(" + string.Join("|", new string[] { css, js }) + ")$";
            return System.Text.RegularExpressions.Regex.IsMatch(item, pattern);
        }

        private void GetTreeNode(ref WinUglifier.TreeView.TreeNode root, string[] items)
        {
            foreach (string item in items)
            {
                if (Directory.Exists(item)) // is directory ?
                {
                    WinUglifier.TreeView.TreeNode node = new WinUglifier.TreeView.TreeNode(null, Path.GetFileName(item));

                    string[] files = Directory.GetFiles(item);
                    if (files.Length > 0) // has files?
                    {
                        GetTreeNode(ref node, files);
                    }

                    foreach (string dir in Directory.GetDirectories(item))
                    {
                        GetTreeNode(ref node, new string[] { dir });
                    }

                    if (node.Value != null || (node.Value == null && node.Nodes.Count > 0))
                    {
                        root.Nodes.Add(node);
                    }
                }
                else
                {
                    string name = Path.GetFileName(item);
                    if (IsAddableType(name))
                    {
                        WinUglifier.TreeView.TreeNode node = new WinUglifier.TreeView.TreeNode(item, name);

                        root.Nodes.Add(node);
                    }
                }
            }
        }

        private async void treeItems_DragDrop(object sender, DragEventArgs e)
        {
            string[] items = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            WinUglifier.TreeView.TreeNode root = new WinUglifier.TreeView.TreeNode();

            GetTreeNode(ref root, items);

            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode node in root.Nodes)
            {
                nodes.Add(node);
            }

            treeItems.Nodes.AddRange(nodes.ToArray());
            treeItems.ExpandAll();
        }

        private void treeItems_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (treeItems.SelectedNode != null)
                {
                    treeItems.SelectedNode.Remove();
                }
            }
        }
    }
}
