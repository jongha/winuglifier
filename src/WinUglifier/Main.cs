using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yahoo.Yui.Compressor;

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
            
        }

        private void btnUglify_Click(object sender, EventArgs e)
        {
            //JavaScriptCompressor javascript = new JavaScriptCompressor();

            foreach (ListViewItem item in listFiles.CheckedItems)
            {
                System.Console.Out.WriteLine(item.SubItems[1]);
            }
        }

        private ListViewItem GetItem(string item)
        {
            ListViewItem lv = new ListViewItem();
            lv.SubItems.Add(Path.GetDirectoryName(item));
            lv.SubItems.Add(Path.GetFileName(item));

            return lv;
        }

        private void GetFiles(string[] items)
        {
            string pattern = ".*\\.(css|js)$";
            foreach (string path in items)
            {
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(file, pattern))
                        {
                            listFiles.Items.Add(GetItem(file));
                        }
                    }
                    
                    GetFiles(Directory.GetDirectories(path));
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(path, pattern))
                    {
                        listFiles.Items.Add(GetItem(path));
                    }
                }
            }
        }

        private void listFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] items = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            GetFiles(items);
        }

        private void listFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < listFiles.Items.Count; ++i)
                {
                    //listFiles.SetSelected(i, true);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                for (int i = listFiles.SelectedItems.Count - 1; i >= 0; --i)
                {
                    listFiles.Items.Remove(listFiles.SelectedItems[i]);
                }
            }
        }
    }
}
