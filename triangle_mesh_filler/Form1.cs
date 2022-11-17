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
        //private List<List<MyPoint>> polygons = new();
        //private List<List<Edge>> polygonsByEdges = new();
        private List<Polygon> polygons = new();


        private DirectBitmap drawArea = null;
        private Pen pen = new(Color.Black, 2);
        private SolidBrush sbBlack = new(Color.Black);
        private int radius = 3;
        private Pen penRed = new(Color.Red, 1);
        private SolidBrush sbRed = new(Color.Red);
        private SolidBrush sbYellow = new(Color.Yellow);
        private Random rand = new();

        double kd = 0.5;
        double ks = 0.3;
        int m = 100;
        
        Sun sun;
        bool clicked = false;
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

            

            LoadShape();

            double zMax = double.MinValue;
            foreach (var point in points)
            {
                if (point.z > zMax) zMax = point.z;
            }
            Debug.WriteLine($"zMax: {zMax}");

            sun = new Sun(0, 0, 700.0, 20);

            Debug.WriteLine($"all: {polygons.Count}");

            DrawCanvas();
        }

        public void DrawCanvas()
        {
            //if (drawArea != null) drawArea.Dispose();

            //drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            //Canvas.Image = drawArea.Bitmap;

            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(Color.White);
            }

            Debug.WriteLine($"sun koords {sun.x}, {sun.y}");
            

            foreach (var polygon in polygons)
            {
                ScanlineFill(polygon);
            }
            DrawShape();
            DrawSun();
            Canvas.Invalidate();
            Canvas.Update();
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
                    Polygon polygon = new();
                    List<MyPoint> pointsP = new();
                    foreach (var word in words)
                    {
                        if (word == "f") continue;
                        var numbers = word.Split("//");
                        var point = points[Convert.ToInt32(numbers[0]) - 1];
                        point.nx = normalVectorsX[Convert.ToInt32(numbers[1]) - 1];
                        point.ny = normalVectorsY[Convert.ToInt32(numbers[1]) - 1];
                        point.nz = normalVectorsZ[Convert.ToInt32(numbers[1]) - 1];
                        pointsP.Add(point);
                    }
                    polygon.points = pointsP;
                    polygon.size = pointsP.Count;
                    List<Edge> edges = new();
                    for (int i = 0; i < polygon.size; i++)
                    {
                        edges.Add(new Edge(polygon.points[i], polygon.points[(i + 1) % polygon.size]));
                    }
                    polygon.edges = edges;
                    polygons.Add(polygon);
                }
            }

            //foreach (var polygon in polygons)
            //{
            //    List<Edge> edges = new();
            //    for (int i = 0; i < polygon.Count; i++)
            //    {
            //        if (polygon[i].y <= polygon[(i + 1) % polygon.Count].y)
            //        {
            //            edges.Add(new Edge(polygon[i], polygon[(i + 1) % polygon.Count]));
            //        }
            //        else
            //        {
            //            edges.Add(new Edge(polygon[(i + 1) % polygon.Count], polygon[i]));
            //        }
            //    }
            //    polygonsByEdges.Add(edges);
            //}



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

            foreach (var point in points)
            {

                g.DrawEllipse(pen, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
                g.FillEllipse(sbBlack, (int)point.x - radius, (int)point.y - radius, 2 * radius, 2 * radius);
            }

            foreach (var polygon in polygons)
            {
                for (int i = 0; i < polygon.size; i++)
                {
                    g.DrawLine(pen, (int)polygon.points[i].x, (int)polygon.points[i].y, (int)polygon.points[(i + 1) % (int)polygon.size].x, (int)polygon.points[(i + 1) % polygon.size].y);
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

        public void ScanlineFill(Polygon polygon)
        {
            minY = int.MaxValue;
            maxY = int.MinValue;

            List<Color> verticesColors = FindColorsOfVertices(polygon);
            double area = getArea(polygon.points[0], polygon.points[1], polygon.points[2]);

            foreach (var edge in polygon.edges)
            {
                if (edge.src.y < minY) minY = (int)edge.src.y;
                if (edge.src.y > maxY) maxY = (int)edge.src.y;
                if (edge.dst.y < minY) minY = (int)edge.dst.y;
                if (edge.dst.y > maxY) maxY = (int)edge.dst.y;
            }

            InitEdgeTable();

            foreach (var edge in polygon.edges)
            {
                StoreEdgeInTable((int)edge.src.x, (int)edge.src.y, (int)edge.dst.x, (int)edge.dst.y);
            }

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
                                Color color = FindColorOfPixel(polygon, verticesColors, new MyPoint(k, i + minY), area);
                                drawArea.SetPixel(k, i + minY, color);
                            }
                        }
                    }
                    j++;
                }
                Updatexbyslopeinv(ActiveEdgeTuple);
            }

            //for (int a = 0; a < polygon.size; a++)
            //{
            //    using SolidBrush sb = new SolidBrush(verticesColors[a]);
            //    using Graphics g = Graphics.FromImage(drawArea.Bitmap);
            //    g.FillEllipse(sb, (int)polygon.points[a].x - sun.radius, (int)polygon.points[a].y - sun.radius, 2 * sun.radius, 2 * sun.radius);
            //}
        }

        public double getArea(MyPoint A, MyPoint B, MyPoint C)
        {
            int Ax = Convert.ToInt32(A.x);
            int Ay = Convert.ToInt32(A.y);
            int Bx = Convert.ToInt32(B.x);
            int By = Convert.ToInt32(B.y);
            int Cx = Convert.ToInt32(C.x);
            int Cy = Convert.ToInt32(C.y);
            return Math.Abs(Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By)) / 2.0;
            //return Math.Abs(Math.Round(A.x) * (Math.Round(B.y) - Math.Round(C.y)) + Math.Round(B.x) * (Math.Round(C.y) - Math.Round(A.y)) + Math.Round(C.x) * (Math.Round(A.y) - Math.Round(B.y))) / 2.0;
            //double a = GetDistance(B, C);
            //double b = GetDistance(A, C);
            //double c = GetDistance(A, B);
            //double s = (a + b + c) / 2.0;
            //double tmp = s * (s - a) * (s - b) * (s - c);
            //if (tmp <= 0) return 0;
            //else return Math.Sqrt(tmp);
        }

        public double GetDistance(MyPoint A, MyPoint B)
        {
            double ret  = Math.Sqrt((Math.Round(A.x) - Math.Round(B.x)) * (Math.Round(A.x) - Math.Round(B.x)) + (Math.Round(A.y) - Math.Round(B.y)) * (Math.Round(A.y) - Math.Round(B.y)));
            return ret;
        }

        public Color FindColorOfPixel(Polygon polygon, List<Color> colors, MyPoint point, double area)
        {
            double alfa = getArea(polygon.points[1], polygon.points[2], point) / area;
            double beta = getArea(polygon.points[0], polygon.points[2], point) / area;
            // double gamma = getArea(polygon.points[0], polygon.points[1], point) / area;
            double gamma = 1 - alfa - beta;
            // if (gamma < 0) gamma = 0;

            // Debug.WriteLine($"{alfa + beta + gamma}");

            List<int> color = new() { 0, 0, 0 };
            color[0] = Math.Min((int)(alfa * colors[0].R + beta * colors[1].R + gamma * colors[2].R), 255);
            color[1] = Math.Min((int)(alfa * colors[0].G + beta * colors[1].G + gamma * colors[2].G), 255);
            color[2] = Math.Min((int)(alfa * colors[0].B + beta * colors[1].B + gamma * colors[2].B), 255);

            for (int i = 0; i < color.Count; i++)
            {
                if (color[i] < 0) color[i] = 0;
            }
            return Color.FromArgb(color[0], color[1], color[2]);
            // return Color.FromArgb(0, 0, 0);
        }

        public List<Color> FindColorsOfVertices(Polygon polygon)
        {
            List<Color> colors = new();
            List<double> colorOfLight = new() { 1, 1, 1 };
            List<double> colorOfObject = new() { 1, 0, 0 };
            

            foreach (var point in polygon.points)
            {
                List<double> L = new() { 0, 0, 0 };
                L[0] = (sun.x - point.x);
                L[1] = (sun.y - point.y);
                L[2] = (sun.z - point.z);
                // Debug.WriteLine($"L: {L[0]}, {L[1]}, {L[2]}");
                double lenL = Math.Sqrt(L[0] * L[0] + L[1] * L[1] + L[2] * L[2]);
                for (int i = 0; i < L.Count; i++)
                {
                    L[i] /= lenL;
                }
                // Debug.WriteLine($"new length: {Math.Sqrt(L[0] * L[0] + L[1] * L[1] + L[2] * L[2])}");
                List<double> N = new() { point.nx, point.ny, point.nz };
                
                double lenN = Math.Sqrt(N[0] * N[0] + N[1] * N[1] + N[2] * N[2]);
                for (int i = 0; i < N.Count; i++)
                {
                    N[i] /= lenN;
                }
                // Debug.WriteLine($"normal vector length: {Math.Sqrt(N[0] * N[0] + N[1] * N[1] + N[2] * N[2])}");
                double cosNL = L[0] * N[0] + L[1] * N[1] + L[2] * N[2];
                cosNL = cosNL < 0 ? 0 : cosNL;
                // Debug.WriteLine($"cosNL: {cosNL}");
                List<double> V = new() { 0, 0, 1 };
                List<double> R = new() { 0, 0, 0 };
                for (int i = 0; i < R.Count; i++)
                {
                    R[i] = 2 * cosNL * N[i] - L[i];
                }
                double cosVR = V[0] * R[0] + V[1] * R[1] + V[2] * R[2];
                cosVR = cosVR < 0 ? 0 : cosVR;
                List<double> color = new(){ 0, 0, 0 };
                for (int i = 0; i < color.Count; i++)
                {
                    color[i] = kd * colorOfLight[i] * colorOfObject[i] * cosNL + ks * colorOfLight[i] * colorOfObject[i] * Math.Pow(cosVR, 1);
                }
                // Debug.WriteLine($"color: {color[0]}, {color[1]}, {color[2]}");
                colors.Add(Color.FromArgb(Math.Min((int)(color[0] * 255), 255), Math.Min((int)(color[1] * 255), 255), Math.Min((int)(color[2] * 255), 255)));
            }
            return colors;
        }
        
        public void DrawSun()
        {
            int x = (int)sun.x;
            int y = (int)sun.y;

            using Graphics g = Graphics.FromImage(drawArea.Bitmap);

            Bitmap sunImage = new Bitmap(@"C:\Users\Sosna\Desktop\sun.png");
            g.DrawImage(sunImage, x - sun.radius, y - sun.radius, 2 * sun.radius, 2 * sun.radius);

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("mousedown");
            sun.x = e.X;
            sun.y = e.Y;
            clicked = true;
            DrawCanvas();
            //for (int i = 0; i < 1000; i+= 10)
            //{
            //    sun.x = i;
            //    sun.y = i;
            //    DrawCanvas();
            //}
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                sun.x = e.X;
                sun.y = e.Y;
                DrawCanvas();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
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

        public MyPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.nz = 0;
            this.ny = 0;
            this.nz = 0;
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

    public class Polygon
    {
        public List<MyPoint> points;
        public List<Edge> edges;
        public int size;
        static int index = 0;
        int polygonIndex;


        public Polygon()
        {
            this.points = null;
            this.edges = null;
            this.size = 0;
            this.polygonIndex = index;
            Polygon.index++;
        }

        public Polygon(List<MyPoint> points, List<Edge> edges, int size)
        {
            this.points = points;
            this.edges = edges;
            this.size = size;
            this.polygonIndex = index;
            Polygon.index++;
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

    public class Sun
    {
        public double x;
        public double y;
        public double z;
        public int radius;

        public Sun(double x, double y, double z, int radius)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
        }
    }
}
