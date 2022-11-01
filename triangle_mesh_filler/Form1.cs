using System;
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
        private Pen pen = new(Color.Black, 2);
        private SolidBrush sbBlack = new(Color.Black);
        private Pen penRed = new(Color.Red, 1);
        private SolidBrush sbRed = new(Color.Red);
        private int radius = 3;

        private Random rand = new();

        double kd = 0.5;
        double ks = 0.5;
        public Form1()
        {
            InitializeComponent();

            this.Text = "Triangle Mesh Filler";
            this.Icon = Properties.Resources.tmf_icon;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = (int)(screen.Width / 2.0);
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

            LoadShape();

            Debug.WriteLine($"all: {polygonsByEdges.Count}");

            int counter = 0;

            foreach (var polygon in polygonsByEdges)
            {
                minY = int.MaxValue;
                maxY = int.MinValue;

                foreach (var edge in polygon)
                {
                    if (edge.src.y < minY) minY = (int)edge.src.y;
                    if (edge.src.y > maxY) maxY = (int)edge.src.y;
                    if (edge.dst.y < minY) minY = (int)edge.dst.y;
                    if (edge.dst.y > maxY) maxY = (int)edge.dst.y;
                }

                InitEdgeTable();
                // Debug.WriteLine($"counter: {counter}");
                foreach (var edge in polygon)
                {
                    StoreEdgeInTable((int)edge.src.x, (int)edge.src.y, (int)edge.dst.x, (int)edge.dst.y);
                }
                counter++;
                ScanlineFill();
            }

            DrawShape();
        }

        public void LoadShape()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Sosna\Desktop\obj_files\hemisphereAVG.obj");

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

        public void DrawShape()
        {

            using Graphics g = Graphics.FromImage(drawArea.Bitmap);
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
        }

        private static readonly int maxVer = 4;
        private static int maxHt = 1000;
        private static int minY;
        private static int maxY;

        public class EdgeBucket
        {
            public int ymax;
            public double xofymin;
            public double slopeinverse;
        }

        public class EdgeTableTuple
        {
            public int countEdgeBucket;
            public EdgeBucket[] buckets = new EdgeBucket[maxVer];
        }

        private static EdgeTableTuple[] edgeTable;
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static EdgeTableTuple ActiveEdgeTuple = new();

        public static EdgeTableTuple[] EdgeTable { get => edgeTable; set => edgeTable = value; }
#pragma warning restore CA2211 // Non-constant fields should not be visible

        public static void InitEdgeTable()
        {
            maxHt = maxY - minY + 1;
            EdgeTable = new EdgeTableTuple[maxHt];
            for (int i = 0; i < maxHt; i++)
            {
                EdgeTable[i] = new();
                EdgeTable[i].countEdgeBucket = 0;
                for (int j = 0; j < maxVer; j++)
                {
                    EdgeTable[i].buckets[j] = new();
                }
            }
            for (int i = 0; i < maxVer; i++)
            {
                ActiveEdgeTuple.buckets[i] = new();
            }
            ActiveEdgeTuple.countEdgeBucket = 0;
        }

        static void InsertionSort(EdgeTableTuple ett)
        {
            int i, j;
            EdgeBucket temp = new();

            for (i = 1; i < ett.countEdgeBucket; i++)
            {
                temp.ymax = ett.buckets[i].ymax;
                temp.xofymin = ett.buckets[i].xofymin;
                temp.slopeinverse = ett.buckets[i].slopeinverse;
                j = i - 1;
                while ((j >= 0) &&  (temp.xofymin < ett.buckets[j].xofymin))
                {
                    ett.buckets[j + 1].ymax = ett.buckets[j].ymax;
                    ett.buckets[j + 1].xofymin = ett.buckets[j].xofymin;
                    ett.buckets[j + 1].slopeinverse = ett.buckets[j].slopeinverse;
                    j--;
                }
                ett.buckets[j + 1].ymax = temp.ymax;
                ett.buckets[j + 1].xofymin = temp.xofymin;
                ett.buckets[j + 1].slopeinverse = temp.slopeinverse;
            }
        }

        public static void StoreEdgeInTuple(EdgeTableTuple receiver, int ym, int xm, double slopInv)
        {
            receiver.buckets[receiver.countEdgeBucket].ymax = ym;
            receiver.buckets[receiver.countEdgeBucket].xofymin = (double)xm;
            receiver.buckets[receiver.countEdgeBucket].slopeinverse = slopInv;

            InsertionSort(receiver);

            receiver.countEdgeBucket++;

        }

        public static void StoreEdgeInTable(int x1, int y1, int x2, int y2)
        {
            double m, minv;
            int ymaxTS, xwithyminTS, scanline;

            if (x2 == x1)
            {
                minv = 0.0;
            }
            else
            {
                m = ((double)(y2 - y1)) / ((double)(x2 - x1));
                if (y2 == y1) return;

                minv = (double)(1.0 / m);
            }

            if (y1 > y2)
            {
                scanline = y2;
                ymaxTS = y1;
                xwithyminTS = x2;
            }
            else
            {
                scanline = y1;
                ymaxTS = y2;
                xwithyminTS = x1;
            }

            StoreEdgeInTuple(EdgeTable[scanline - minY], ymaxTS, xwithyminTS, minv);
        }

        public static void RemoveEdgeByYmax(EdgeTableTuple Tup, int yy)
        {
            int i, j;
            for (i = 0; i < Tup.countEdgeBucket; i++)
            {
                if (Tup.buckets[i].ymax == yy)
                {
                    for (j = i; j < Tup.countEdgeBucket - 1; j++)
                    {
                        Tup.buckets[j].ymax = Tup.buckets[j + 1].ymax;
                        Tup.buckets[j].xofymin = Tup.buckets[j + 1].xofymin;
                        Tup.buckets[j].slopeinverse = Tup.buckets[j + 1].slopeinverse;
                    }
                    Tup.countEdgeBucket--;
                    i--;
                }
            }
        }

        public static void Updatexbyslopeinv(EdgeTableTuple Tup)
        {
            int i;

            for (i = 0; i < Tup.countEdgeBucket; i++)
            {
                Tup.buckets[i].xofymin = Tup.buckets[i].xofymin + Tup.buckets[i].slopeinverse;
            }
        }

        public void ScanlineFill()
        {
            int i, j, x1, ymax1, x2, ymax2, coordCount;
            for (i = 0; i < maxHt; i++)
            {
                for (j = 0; j < EdgeTable[i].countEdgeBucket; j++)
                {
                    StoreEdgeInTuple(ActiveEdgeTuple, EdgeTable[i].buckets[j].ymax, (int)EdgeTable[i].buckets[j].xofymin, EdgeTable[i].buckets[j].slopeinverse);
                }

                RemoveEdgeByYmax(ActiveEdgeTuple, i + minY);

                InsertionSort(ActiveEdgeTuple);

                j = 0;
                coordCount = 0;
                x1 = 0;
                x2 = 0;
                ymax1 = 0;
                ymax2 = 0;
                while (j < ActiveEdgeTuple.countEdgeBucket)
                {
                    if (coordCount % 2 == 0)
                    {
                        x1 = (int)(ActiveEdgeTuple.buckets[j].xofymin);
                        ymax1 = ActiveEdgeTuple.buckets[j].ymax;
                        if (x1 == x2)
                        {
                            if (((x1 == ymax1) && (x2 != ymax2)) ||((x1 != ymax1) && (x2 == ymax2)))
                            {
                                x2 = x1;
                                ymax2 = ymax1;
                            }
                            else
                            {
                                coordCount++;
                            }
                        }
                        else
                        {
                            coordCount++;
                        }
                    }
                    else
                    {
                        x2 = (int)ActiveEdgeTuple.buckets[j].xofymin;
                        ymax2 = ActiveEdgeTuple.buckets[j].ymax;

                        int FillFlag = 0;

                        if (x1 == x2)
                        {
                            if (((x1 == ymax1) && (x2 != ymax2)) || ((x1 != ymax1) && (x2 == ymax2)))
                            {
                                x1 = x2;
                                ymax1 = ymax2;
                            }
                            else
                            {
                                coordCount++;
                                FillFlag = 1;
                            }
                        }
                        else
                        {
                            coordCount++;
                            FillFlag = 1;
                        }

                        if(FillFlag == 1)
                        {
                            for (int k = x1; k <= x2; k++)
                            {
                                drawArea.SetPixel(k, i + minY, Color.Red);
                            }
                        }
                    }
                    j++;
                }
                Updatexbyslopeinv(ActiveEdgeTuple);
            }
        }

        public static double GetArea(MyPoint A, MyPoint B, MyPoint C)
        {
            return Math.Abs(A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y)) / 2.0;
        }

        public static Color GetColor(List<MyPoint> points, double area, MyPoint p)
        {
            double alfa = GetArea(p, points[1], points[2]) / area;
            double beta = GetArea(p, points[0], points[2]) / area;
            double gamma = GetArea(p, points[0], points[1]) / area;

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

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
