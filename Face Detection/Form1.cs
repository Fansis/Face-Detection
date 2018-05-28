using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Face_Detection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Open_camera();
            face = new CascadeClassifier("haarcascade_frontalface_default.xml");

        }

        private void Open_camera()
        {
            try
            {
                capture = new VideoCapture(1);
            }
            catch (Exception e)
            {
                throw e;
            }
            Application.Idle += Process_frame;

        }

        private void Process_frame(object sender, EventArgs e)
        {
            Mat matFrame = capture.QueryFrame();
            Image<Bgr, byte> nextFrame = matFrame.ToImage<Bgr, byte>();
            Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
            currentFrame = matFrame.ToImage<Bgr, byte>();
            var faces = face.DetectMultiScale(matFrame, 1.2, 10,  Size.Empty, Size.Empty);
            foreach (var face in faces)
            {
                currentFrame.Draw(face,new Bgr(System.Drawing.Color.OrangeRed),2);
            }


            img_camera.Image = currentFrame;

        // currentFrame = capture.QuerySmallFrame().ToImage<Bgr, Byte>();
        // img_camera.Image = currentFrame;
        //  face.DetectMultiScale(fa)
    }

        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        VideoCapture capture;
        CascadeClassifier face;
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
