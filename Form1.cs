using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Simple_Drawing_Application
{
    public partial class Form1 : Form
    {
        public Point end = new Point();
        public Point start = new Point();
        public Pen p;
        bool draw = false;
        string color;
        Graphics graphics;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            GenerateVaribles();
        }



        void GenerateVaribles()
        {
            graphics = pb_canvas.CreateGraphics();
            comboBox1.Text = "8";
            color = "#000000";
            txt_color.Text = color;
            CreateCanvas();
        }

        void CreateCanvas() {
            bmp = new Bitmap(pb_canvas.Width, pb_canvas.Height);
            graphics = Graphics.FromImage(bmp);
            pb_canvas.BackgroundImage = bmp;
            pb_canvas.BackgroundImageLayout = ImageLayout.None;
        }

        private void pb_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;

            start = e.Location;

            int size;

            if (comboBox1.Text == "")
            {
                size = 8;
            }
            else
            {
                size = Convert.ToInt32(comboBox1.Text);
            }

            Color newColor = ColorTranslator.FromHtml(color);
            p = new Pen(newColor, size);
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }

        private void pb_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {


                if (e.Button == MouseButtons.Left)
                {
                    end = e.Location;
                    graphics.DrawLine(p, start, end);
                    start = end;
                    pb_canvas.Invalidate();
                }

            }
        }

        private void pb_canvas_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CreateCanvas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                color = "#" + (cd.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                txt_color.Text = color;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files| *.png|jpeg files| *.jpg|bitmaps | *.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
