using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Windows.Forms;

namespace SPDz_10
{
    public partial class Form1 : Form
    {
        string  path = @"Software\Microsoft\Windows\CurrentVersion\Run";
        public Form1()
        {
            RegistryKey current = Registry.CurrentUser;
            RegistryKey run = current.OpenSubKey(path, true);
            InitializeComponent();
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Value");
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            foreach (var KeyName in run.GetValueNames())
            {
                ListViewItem lvi = new ListViewItem(KeyName);
                lvi.SubItems.Add(run.GetValue(KeyName).ToString());
                listView1.Items.Add(lvi);

            }
            current.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
                RegistryKey current = Registry.CurrentUser;
                RegistryKey run = current.OpenSubKey(path, true);
                run.SetValue(textBoxKey.Text, textBoxValue.Text);
                listView1.Items.Add(textBoxKey.Text + "  " + textBoxValue.Text);
                current.Close();          
           
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RegistryKey current = Registry.CurrentUser;
            RegistryKey run = current.OpenSubKey(path, true);
            if (listView1.SelectedItems.Count == 1)
            {
                string tmp = listView1.SelectedItems[0].Text.ToString();
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                run.DeleteValue(tmp);
            }
            current.Close();
        }
       

       
    }
}
