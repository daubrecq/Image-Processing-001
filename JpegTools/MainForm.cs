using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JpegTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult res = openFile.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                DisplayAndAddToList(openFile.FileName);
            }
        }

        private void DisplayAndAddToList(string fileName)
        {
            DisplayImageForm display = DisplayImageFromFile(fileName);
            AddDisplayToList(display);

        }
        private ListViewItem AddDisplayToList(DisplayImageForm display)
        {
            ListViewItem item = displayList.Items.Add(display.Text);
            item.Tag = display;
            return item;
        }



        private DisplayImageForm DisplayImageFromFile(String fileName)
        {
            Image image = Image.FromFile(fileName);

            DisplayImageForm display = new DisplayImageForm();
            display.Text = fileName;
            display.Left = this.Left + 100;
            display.SetImage(image);
            display.Show();
            display.ShowFlicker(100);
            return display;
        }

   
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void displayList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var s = sender as ListView;
            ListViewItem item = s.SelectedItems[0];
            String fileName = item.Text;
            if (item.Tag !=  null)
                DisplayImageFromFile(fileName);
        }
    }
}
