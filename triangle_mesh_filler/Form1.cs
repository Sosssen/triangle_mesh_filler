﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace triangle_mesh_filler
{
    public partial class Form1 : Form
    {

        private List<MyPoint> points = new();
        private int radius = 2;
        private List<List<MyPoint>> polygons = new();
        

        private DirectBitmap drawArea;
        private Pen pen = new(Color.Black, 1);
        private SolidBrush sbBlack = new(Color.Black);
        public Form1()
        {
            InitializeComponent();

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            // int w = (int)(screen.Width / 1.5);
            int w = (int)(screen.Height / 1.5);
            int h = (int)(screen.Height / 1.5);
            this.Size = new Size(w, h);

            drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea.Bitmap;

            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(Color.White);
            }

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Sosna\Desktop\obj_files\hemisphere.obj");

            int vn_counter = 0;

            foreach (string line in lines)
            {
                // Debug.WriteLine(line);
                string[] words = line.Split();
                //foreach (string word in words)
                //{
                //    Debug.WriteLine(word);
                //}
                if (words[0] == "v")
                {
                    points.Add(new MyPoint(Convert.ToDouble(words[1]), Convert.ToDouble(words[2]), Convert.ToDouble(words[3]), 0, 0, 0));
                }
                // TODO: how to add normal vectors to points?
                //if (words[0] == "vn")
                //{
                //    points[vn_counter].nx = Convert.ToDouble(words[1]);
                //    points[vn_counter].ny = Convert.ToDouble(words[2]);
                //    points[vn_counter].nz = Convert.ToDouble(words[3]);
                //    vn_counter++;
                //    Debug.WriteLine($"vncounter: {vn_counter}");
                //}
                
            }
            Debug.WriteLine(points.Count);
            foreach (string line in lines)
            {

                string[] words = line.Split();

                if (words[0] == "f")
                {
                    List<MyPoint> polygon = new();
                    foreach (var word in words)
                    {
                        if (word == "f") continue;         
                        var numbers = word.Split("//");
                        polygon.Add(points[Convert.ToInt32(numbers[0]) - 1]);
                    }
                    polygons.Add(polygon);
                    
                }
            }



            double minX = double.MaxValue;
            double minY = double.MaxValue;

            foreach (var point in points)
            {
                if (point.x < minX) minX = point.x;
                if (point.y < minY) minY = point.y;
            }

            double maxX = double.MinValue;
            double maxY = double.MinValue;

            foreach (var point in points)
            {
                if (point.x > maxX) maxX = point.x;
                if (point.y > maxY) maxY = point.y;
            }

            // Debug.WriteLine($"minx {minX}, miny {minY}");

            foreach (var point in points)
            {
                point.x -= minX;
                point.y -= minY;
            }

            foreach (var point in points)
            {
                if (point.x > maxX) maxX = point.x;
                if (point.y > maxY) maxY = point.y;
            }

            //Debug.WriteLine($"max: {maxX}, {maxY}");

            double max = maxX >= maxY ? maxX : maxY;
            double minDim = Canvas.Width <= Canvas.Height ? Canvas.Width : Canvas.Height;

            double scale = (minDim / max) * 0.8;

            foreach (var point in points)
            {
                point.x *= scale;
                point.y *= scale;
                point.z *= scale;

                point.x += minDim * 0.1;
                point.y += minDim * 0.1;
            }


            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                foreach (var point in points)
                {

                    // drawArea.SetPixel((int)point.x, (int)point.y, Color.Black);
                    g.DrawEllipse(pen, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
                    g.FillEllipse(sbBlack, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
                }

                foreach (var polygon in polygons)
                {
                    for (int i = 0; i < polygon.Count; i++)
                    {
                        g.DrawLine(pen, (int)polygon[i].x, (int)polygon[i].y, (int)polygon[(i + 1) % (int)polygon.Count].x, (int)polygon[(i + 1) % polygon.Count].y);
                    }
                }
            }


            for (int i = 0; i < Canvas.Height; i++)
            {
                drawArea.SetPixel(100, i, Color.Red);
            }

            //foreach (var point in points)
            //{
            //    Debug.WriteLine($"point: {point.x}, {point.y}, {point.z}");
            //}


        }

    }

    public class MyPoint
    {
        public double x;
        public double y;
        public double z;
        public double nx;
        public double ny;
        public double nz;

        public MyPoint(double x, double y, double z, double nx, double ny, double nz)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.nx = nx;
            this.ny = ny;
            this.nz = nz;
        }
    }

    public class Edge
    {
        public MyPoint src;
        public MyPoint dst;

        public Edge(MyPoint src, MyPoint dst)
        {
            this.src = src;
            this.dst = dst;
        }
    }

    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected System.Runtime.InteropServices.GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = System.Runtime.InteropServices.GCHandle.Alloc(Bits, System.Runtime.InteropServices.GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
