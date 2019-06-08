using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Fractal : Form
    {
        Bitmap bmp;
        Graphics graph;
        Pen pen = new Pen(Color.Black);

        int step = 10;
        int gx = 10;
        int gy = 10;

        static Random rnd;

        public Fractal()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            bmp = new Bitmap(Width, Height);
            graph = Graphics.FromImage(bmp);
            graph.Clear(Color.White);
            panel.BackgroundImage = bmp;
        }

        private void Fractal_Load(object sender, EventArgs e)
        {
            Init();
            Draw();
        }

        private void Draw()
        {
            //NextSpiro(10,10,400,400);
            //NextTriangle(0,panel.Height-1, panel.Width >> 1, 0, panel.Width, panel.Height-1);
            //NextTriangle2(0, panel.Height - 1, panel.Width >> 1, 0, panel.Width, panel.Height - 1);
            gx = 10;
            gy = panel.Height - step;
            gUp(5);
        }

        private void Fractal_Resize(object sender, EventArgs e)
        {
            Init();
            Draw();
            Debug.WriteLine(Width + "x" + Height);
        }
        void NextSpiro(int x, int y, int w, int h)
        {
            if (w <= 0 || h <= 0) return;
            int s = (int)(0.1 * (w+h));
            if (s == 0) s = 1;
            graph.DrawLine(pen, x, y, x+ (int)(w *0.95), y);
            graph.DrawLine(pen, x+ (int)(w * 0.95), y, x + (int)(w * 0.95), y+ (int)(h * 0.95));
            graph.DrawLine(pen, x + (int)(w * 0.95), y+ (int)(h * 0.95), x + s, y + (int)(h * 0.95));
            graph.DrawLine(pen, x + s, y + (int)(h * 0.95), x + s, y + s);
            NextSpiro(x+s+1/s,y+s-1/s,w-2*s, h-2*s);
        }

        void NextTriangle(int Ax, int Ay, int Bx, int By, int Cx, int Cy)
        {
            if((Math.Abs(Ax - Bx) <= 1) || Math.Abs(Cx - Bx) <= 1) 
                return;
            graph.DrawLine(pen, Ax, Ay, Bx, By);
            graph.DrawLine(pen, Bx, By, Cx, Cy);
            graph.DrawLine(pen, Cx, Cy, Ax, Ay);
            int Kx, Ky, Lx, Ly, Mx, My;
            Kx = (Ax + Bx) >> 1;
            Ky = (Ay + By) >> 1;
            Lx = (Bx + Cx) >> 1;
            Ly = (By + Cy) >> 1;
            Mx = (Cx + Ax) >> 1;
            My = (Cy + Ay) >> 1;
            NextTriangle(Ax, Ay, Kx, Ky, Mx, My);
            NextTriangle(Kx, Ky, Bx, By, Lx, Ly);
            NextTriangle(Mx, My, Lx, Ly, Cx, Cy);
        }

        void NextTriangle2(int Ax, int Ay, int Bx, int By, int Cx, int Cy)
        {
            if ((Math.Abs(Ax - Bx) <= 1) || Math.Abs(Cx - Bx) <= 1 || Math.Abs(Ax - Cx) <= 1)
                return;
            int Kx, Ky, Lx, Ly, Mx, My;
            Kx = (Ax + Bx) >> 1;
            Ky = (Ay + By) >> 1;
            Lx = (Bx + Cx) >> 1;
            Ly = (By + Cy) >> 1;
            Mx = (Cx + Ax) >> 1;
            My = (Cy + Ay) >> 1;
            graph.DrawLine(pen, Kx, Ky, Lx, Ly);
            graph.DrawLine(pen, Lx, Ly, Mx, My);
            graph.DrawLine(pen, Mx, My, Kx, Ky);
            NextTriangle2(Ax, Ay, Kx, Ky, Mx, My);
            NextTriangle2(Kx, Ky, Bx, By, Lx, Ly);
            NextTriangle2(Mx, My, Lx, Ly, Cx, Cy);
        }
        void DrawVector(int sx, int sy)
        {
            graph.DrawLine(pen, gx, gy, gx + sx, gy + sy);
            gx += sx;
            gy += sy;
        }
        void gRight(int d)
        {
            if (d <= -1) return;
            gUp(d - 1);
            DrawVector(step, 0);
            gRight(d - 1);
            DrawVector(0, -step);
            gRight(d - 1);
            DrawVector(-step, 0);
            gDown(d - 1);
        }
        void gLeft(int d)
        {
            if (d <= 0) return;
            gDown(d-1);
            DrawVector(-step, 0);
            gLeft(d - 1);
            DrawVector(0, step);
            gLeft(d - 1);
            DrawVector(step, 0);
            gUp(d - 1);
        }
        void gUp(int d)
        {
            if (d <= 0) return;
            gRight(d - 1);
            DrawVector(0, -step);
            gUp(d-1);
            DrawVector(step, 0);
            gUp(d - 1);
            DrawVector(0, step);
            gLeft(d-1);
        }
        void gDown(int d)
        {
            if (d <= 0) return;
            gLeft(d - 1);
            DrawVector(0, step);
            gDown(d - 1);
            DrawVector(-step, 0);
            gDown(d - 1);
            DrawVector(0, -step);
            gRight(d - 1);
        }
    }
}
