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
        private List<double> normalVectorsX = new();
        private List<double> normalVectorsY = new();
        private List<double> normalVectorsZ = new();
        private List<List<MyPoint>> polygons = new();
        private List<List<Edge>> polygonsByEdges = new();
        

        private DirectBitmap drawArea;
        private Pen pen = new(Color.Black, 1);
        private SolidBrush sbBlack = new(Color.Black);
        private Pen penRed = new(Color.Red, 1);
        private SolidBrush sbRed = new(Color.Red);
        private int radius = 2;

        private Random rand = new();

        double kd = 0.5;
        double ks = 0.5;
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = (int)(screen.Width / 2.0);
            // int w = (int)(screen.Height / 1.5);
            int h = (int)(screen.Height / 1.5);
            this.Size = new Size(w, h);

            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel1.ColumnStyles[0].Width = tableLayoutPanel1.Height;
            Canvas.Width = tableLayoutPanel1.Height;
            Canvas.Height = Canvas.Width;

            Debug.WriteLine($"Canva size: {Canvas.Width}, {Canvas.Height}");

            drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea.Bitmap;

            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(Color.White);
            }

            loadShape();

            foreach (var edge in polygonsByEdges[0])
            {
                Debug.WriteLine($"src: {edge.src.x}, {edge.src.y} dst: {edge.dst.x}, {edge.dst.y}");
            }

            //foreach (var polygon in polygonsByEdges)
            //{
            //    fillPolygon(polygon);
            //}
            for (int i = 0; i < polygons.Count; i++)
            {
                fillPolygon(polygonsByEdges[i], polygons[i]);
            }
            // fillPolygon(polygonsByEdges[0]);

            // drawShape();
        }

        public void loadShape()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Sosna\Desktop\obj_files\hemisphere.obj");

            foreach (string line in lines)
            {
                string[] words = line.Split();

                if (words[0] == "v")
                {
                    points.Add(new MyPoint(Convert.ToDouble(words[1]), Convert.ToDouble(words[2]), Convert.ToDouble(words[3]), 0, 0, 0));
                }
                else if (words[0] == "vn")
                {
                    normalVectorsX.Add(Convert.ToDouble(words[1]));
                    normalVectorsY.Add(Convert.ToDouble(words[2]));
                    normalVectorsZ.Add(Convert.ToDouble(words[3]));
                }

            }
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
                        var point = points[Convert.ToInt32(numbers[0]) - 1];
                        point.nx = normalVectorsX[Convert.ToInt32(numbers[1]) - 1];
                        point.ny = normalVectorsY[Convert.ToInt32(numbers[1]) - 1];
                        point.nz = normalVectorsZ[Convert.ToInt32(numbers[1]) - 1];
                        polygon.Add(point);
                    }
                    polygons.Add(polygon);

                }
            }

            foreach (var polygon in polygons)
            {
                List<Edge> edges = new();
                for (int i = 0; i < polygon.Count; i++)
                {
                    if (polygon[i].y <= polygon[(i + 1) % polygon.Count].y)
                    {
                        edges.Add(new Edge(polygon[i], polygon[(i + 1) % polygon.Count]));
                    }
                    else
                    {
                        edges.Add(new Edge(polygon[(i + 1) % polygon.Count], polygon[i]));
                    }
                }
                polygonsByEdges.Add(edges);
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

           
        }

        public void drawShape()
        {

            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                // g.Clear(Color.White);

                foreach (var point in points)
                {

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

                // HIGHLIGHT FIRST TRIANGLE
                //for (int i = 0; i < polygons[0].Count; i++)
                //{
                //    var point = polygons[0][i];
                //    g.DrawEllipse(penRed, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
                //    g.FillEllipse(sbRed, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
                //}
                //for (int i = 0; i < polygonsByEdges[0].Count; i++)
                //{
                //    g.DrawLine(penRed, (int)polygonsByEdges[0][i].src.x, (int)polygonsByEdges[0][i].src.y, (int)polygonsByEdges[0][i].dst.x, (int)polygonsByEdges[0][i].dst.y);
                //}
            }
        }

        public void fillPolygon(List<Edge> edges, List<MyPoint> points)
        {
            // Color color = Color.FromArgb(rand.Next() % 255, rand.Next() % 255, rand.Next() % 255);
            Color color = Color.Red;
            // Find min and max of starting y
            int minY = int.MaxValue;
            int maxY = int.MinValue;

            foreach (var edge in edges)
            {
                if ((int)edge.src.y < minY) minY = (int)edge.src.y;
                if ((int)edge.src.y > maxY) maxY = (int)edge.src.y;
            }

            Debug.WriteLine($"minY = {minY}, maxY = {maxY}");

            // Create EAT and ET
            List<StructForFillingPolygon> EAT = new();
            List<StructForFillingPolygon>[] ET = new List<StructForFillingPolygon>[maxY - minY + 1];

            for (int i = 0; i < ET.Length; i++)
            {
                ET[i] = new();
            }

            // Add all edges to ET
            foreach (var edge in edges)
            {

                ET[(int)edge.src.y - minY].Add(new StructForFillingPolygon((int)edge.dst.y, (int)edge.src.x, (edge.src.x - edge.dst.x) / (edge.src.y - edge.dst.y)));
            }

            //for (int i = 0; i < ET.Length; i++)
            //{
            //    foreach (var s in ET[i])
            //    {
            //        Debug.WriteLine($"{i}. ymax: {s.ymax}, x: {s.x}, 1/m: {s.mInverse}");
            //    }
            //}

            // Count how many "buckets" are in ET
            int y = minY;
            int counter = 0;

            for (int i = 0; i < ET.Length; i++)
            {
                if (ET[i].Count != 0)
                {
                    counter++;
                }
            }

            double area = getArea(points[0], points[1], points[2]);
            points[0].color = Color.Red;
            points[1].color = Color.Green;
            points[2].color = Color.Blue;

            // do this while ET and EAT are not empy
            while (counter > 0 || EAT.Count > 0)
            {
                // move lists from ET to EAT
                if (y - minY < ET.Length && ET[y - minY].Count > 0)
                {
                    counter--;
                    foreach (var s in ET[y - minY])
                    {
                        EAT.Add(s);
                    }
                    ET[y - minY] = new();
                }
                // Sort EAT by x
                EAT.Sort((el1, el2) => el1.x.CompareTo(el2.x));
                //foreach (var s in EAT)
                //{
                //    Debug.WriteLine($"{s.x}");
                //}
                // TODO: it's a work aroung!! how to make this work properly?
                // Set pixels between edges
                for (int i = (int)EAT[0].x; i <= (int)EAT[^1].x; i++)
                // for (int i = (int)EAT[0].x; i <= (int)EAT[1].x; i++)
                {
                    Color newColor = getColor(points, area, new MyPoint(i, y, 0, 0, 0, 0));
                    drawArea.SetPixel(i, y, newColor);
                }

                // Delete elements from EAT where ymax = y
                EAT.RemoveAll(el => el.ymax <= y);

                // Increase y by one
                y++;

                // Change x for every edge
                foreach (var s in EAT)
                {
                    s.x += s.mInverse;
                }
            }
            
        }

        public double getArea(MyPoint A, MyPoint B, MyPoint C)
        {
            return Math.Abs(A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y)) / 2.0;
        }

        public Color getColor(List<MyPoint> points, double area, MyPoint p)
        {
            double alfa = getArea(p, points[1], points[2]) / area;
            double beta = getArea(p, points[0], points[2]) / area;
            double gamma = getArea(p, points[0], points[1]) / area;

            return Color.FromArgb((int)(alfa * points[0].color.R + beta * points[1].color.R + gamma * points[2].color.R) % 255,
                (int)(alfa * points[0].color.G + beta * points[1].color.G + gamma * points[2].color.G) % 255,
                (int)(alfa * points[0].color.B + beta * points[1].color.B + gamma * points[2].color.B) % 255);
        }

    }

    public class StructForFillingPolygon
    {
        public int ymax;
        public double x;
        public double mInverse;

        public StructForFillingPolygon(int ymax, double x, double mInverse)
        {
            this.ymax = ymax;
            this.x = x;
            this.mInverse = mInverse;
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
        public Color color;

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
