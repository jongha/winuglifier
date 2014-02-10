using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinUglifier.Plugin;
using WinUglifier.TreeView;

namespace WinUglifier
{
    public partial class Main : Form
    {
        private Dictionary<string, PluginInfo> pluginInfo;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pluginInfo = new Dictionary<string, PluginInfo>();
            Collection<PluginInfo> plugins = PluginInfo.LoadAll();
            if (plugins.Count == 0)
            {
                OpenFileDialog file = new OpenFileDialog();
                DialogResult result = file.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PluginInfo info = new PluginInfo(file.FileName);
                    info.Save();
                }

                plugins = PluginInfo.LoadAll();
            }

            foreach (PluginInfo plugin in plugins)
            {
                pluginInfo.Add(plugin.Name, plugin);
                comboAlgorithms.Items.Add(plugin.Name);
            }

            treeItems.ImageList = new ImageList();

            comboAlgorithms.SelectedIndex = 0;
            
            rdoOverwrite.Checked = true;
            rdoRename.Enabled = false;

            chkCSS.Checked = false;
            chkCSS.Enabled = false;
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

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        PluginInfo plugin = (PluginInfo)pluginInfo[comboAlgorithms.SelectedItem.ToString()];
                        result = (string)plugin.CreateInstance().Execute(reader.ReadToEnd());
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

        private void SetNodeImage(string item, ref WinUglifier.TreeView.TreeNode node)
        {
            treeItems.ImageList.Images.Add(ShellIcon.GetSmallIcon(item).ToBitmap(), Color.Empty);
            node.ImageIndex = treeItems.ImageList.Images.Count - 1;
            node.SelectedImageIndex = treeItems.ImageList.Images.Count - 1;
        }

        private void GetTreeNode(ref WinUglifier.TreeView.TreeNode root, string[] items)
        {
            foreach (string item in items)
            {
                if (Directory.Exists(item)) // is directory ?
                {
                    WinUglifier.TreeView.TreeNode node = new WinUglifier.TreeView.TreeNode(null, Path.GetFileName(item));

                    SetNodeImage(item, ref node);

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

                        SetNodeImage(item, ref node);

                        root.Nodes.Add(node);
                    }
                }
            }
        }

        private void treeItems_DragDrop(object sender, DragEventArgs e)
        {
            string[] items = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            WinUglifier.TreeView.TreeNode root = new WinUglifier.TreeView.TreeNode();

            GetTreeNode(ref root, items);

            List<WinUglifier.TreeView.TreeNode> nodes = new List<WinUglifier.TreeView.TreeNode>();
            foreach (WinUglifier.TreeView.TreeNode node in root.Nodes)
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
