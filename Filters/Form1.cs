using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Selecione uma imagem.";
            dialogBox.Filter = "Png files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg";

            if (dialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dialogBox.FileName);
                Bitmap sourceImage = (Bitmap)Bitmap.FromStream(sr.BaseStream);
                sr.Close();

                panelSource.BackgroundImage = null;
                panelSource.BackgroundImage = new Bitmap(sourceImage);
                sourceImage.Dispose();

                OnCheckChangedEventHandler(sender, e);
            }
        }

        private void OnCheckChangedEventHandler(object sender, EventArgs e)
        {
            if (panelSource.BackgroundImage != null)
            {
                if (grayscaleRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeGrayScale(panelSource.BackgroundImage);   
                }
                if (sepiaRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeSepiaTone(panelSource.BackgroundImage);
                }
                if (negativeRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeNegative(panelSource.BackgroundImage);
                }
                if (blurRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeBlur(panelSource.BackgroundImage);
                }
                if (mediaRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeMedian(panelSource.BackgroundImage);
                }
                if (transparencyRadioButton.Checked == true)
                {
                    panelOutput.BackgroundImage = GetImage.makeTransparency(panelSource.BackgroundImage);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelOutput_Click(object sender, EventArgs e)
        {

        }
    }
}
