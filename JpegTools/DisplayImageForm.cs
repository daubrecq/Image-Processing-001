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

        delegate void SetImageCallback(Image im);
        public void SetImage(Image image)
        {
            if (this.imageBox.InvokeRequired)
            {
                SetImageCallback f = new SetImageCallback(SetImage);
                this.Invoke(f, new object[] { image });
            }
            else
            {
                _image = image;
                this.imageBox.Image = _image;
                Refresh();
            }
        }

        public Image LoadImage(String fileName)
        {
            Image image = Utils.GetMultipleImage(Bitmap.FromFile(fileName));
            SetImage(image);
            return _image;
        }

        private Image _image;

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
            
            Image i1 = _image;
            Image i2 = Utils.GetInverse(_image);
            //Image i2 = _image;
            //Image im = Utils.Add(i1, i2);

            Image im;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                    im = i1;
                else
                    im = i2;

                SetImage(im);
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
