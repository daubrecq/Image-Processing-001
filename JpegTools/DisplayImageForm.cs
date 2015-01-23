using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ImageProcessing;

namespace JpegTools
{


    public partial class DisplayImageForm : Form
    {
        public DisplayImageForm()
        {
            InitializeComponent();
        }

        delegate void SetBitmapCallback(Bitmap bm);
        public void SetBitmap(Bitmap bitmap)
        {
            if (this.imageBox.InvokeRequired)
            {
                SetBitmapCallback f = new SetBitmapCallback(SetBitmap);
                this.Invoke(f, new object[] { bitmap });
            }
            else
            {
                _bitmap = bitmap;
                this.imageBox.Image = _bitmap;
                Refresh();
            }
        }

        public Bitmap LoadImage(String fileName)
        {
            Bitmap image = Utils.GetMultipleImage(new Bitmap(Image.FromFile(fileName)));
            SetBitmap(image);
            return _bitmap;
        }

        private Bitmap _bitmap;

        private void DisplayImageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }


 

        private void Flick()
        {
            DoFlicker(100);
        }

        private void DoFlicker(int mils)
        {
            
            Bitmap i1 = new Bitmap(_bitmap);
            Bitmap i2 = Utils.GetInverse(i1);
            //Image i2 = _image;
            //Image im = Utils.Add(i1, i2);

            Bitmap bm;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                    bm = i1;
                else
                    bm = i2;

                SetBitmap(bm);
                System.Threading.Thread.Sleep(100);
            }
        }
        
        public void ShowFlicker(int mils)
        {
            Thread t = new Thread(new ThreadStart(Flick));
            t.Start();
        }

    }
}
