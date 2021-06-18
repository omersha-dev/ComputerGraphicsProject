using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices; 

namespace myOpenGL
{
    public partial class Form1 : Form
    {
        cOGL cGL;

        public Form1()
        {

            InitializeComponent();
            cGL = new cOGL(panel1);
            timerRUN.Enabled = true;
        }

        private void timerRepaint_Tick(object sender, EventArgs e)
        {
             cGL.Draw();
            timerRepaint.Enabled = false;
        }


        private void timerRUN_Tick(object sender, EventArgs e)
        {
            cGL.Draw(); 
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            timerRUN.Interval = hScrollBar1.Value;
            label1.Text = "timer delay = " + hScrollBar1.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cGL.Draw();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            cGL.OnResize();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cGL.intOptionA = 1 - cGL.intOptionA;
            cGL.Draw();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
	        cGL.isInside = !cGL.isInside;
            cGL.Draw();
        }

        //private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        //{
        //    cGL.viewAngle = hScrollBar2.Value;
        //    label2.Text = hScrollBar2.Value+"°";
        //    cGL.Draw();
        //}

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            cGL.isBounds = !cGL.isBounds;
            cGL.Draw();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            cGL.isAnimate = !cGL.isAnimate;
            label1.Text = "delay = " + hScrollBar1.Value;
            timerRUN.Enabled = !cGL.isAnimate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch(e.KeyChar)
            //{
            //    case 'x':
            //        cGL.Xangl -= 10;
            //        cGL.Draw();
            //        break;
            //    case 'X':
            //        cGL.Xangl += 10;
            //        cGL.Draw();
            //        break;
            //    case 'y':
            //        cGL.Yangl -= 10;
            //        cGL.Draw();
            //        break;
            //    case 'Y':
            //        cGL.Yangl += 10;
            //        cGL.Draw();
            //        break;
            //    case 'z':
            //        cGL.Zangl -= 10;
            //        cGL.Draw();
            //        break;
            //    case 'Z':
            //        cGL.Zangl += 10;
            //        cGL.Draw();
            //        break;
            //}
        }


    }
}