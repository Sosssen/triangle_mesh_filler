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
        private bool isReady = false;

        private List<MyPoint> points = new List<MyPoint>();
        private List<double> normalVectorsX = new List<double>();
        private List<double> normalVectorsY = new List<double>();
        private List<double> normalVectorsZ = new List<double>();
        //private List<List<MyPoint>> polygons = new();
        //private List<List<Edge>> polygonsByEdges = new();
        private List<Polygon> polygons = new List<Polygon>();


        private DirectBitmap drawArea = null;
        private Pen pen = new Pen(Color.Black, 2);
        private SolidBrush sbBlack = new SolidBrush(Color.Black);
        private int radius = 3;
        private Pen penRed = new Pen(Color.Red, 1);
        private SolidBrush sbRed = new SolidBrush(Color.Red);
        private SolidBrush sbYellow = new SolidBrush(Color.Yellow);
        private Random rand = new Random();

        private double kd = 1;
        private double ks = 0.5;
        private int m = 10;
        private double zMax;

        private Sun sun = null;
        private bool clicked = false;
        private bool animating = false;

        private ColorDialog cdObject = new ColorDialog();
        private ColorDialog cdLight = new ColorDialog();
        private List<double> colorObject = new List<double>() { 1, 0, 0 };
        private List<double> colorLight = new List<double>() { 1, 1, 1 };
        private Bitmap bmColorObject = null;
        private Bitmap bmColorLight = null;

        private Bitmap image = null;
        private Color[,] textureColors = null;
        private Bitmap normalMap = null;
        private Color[,] normalMapColors = null;

        private int interpolationType = 0;
        private int fillingType = 0;
        public Form1()
        {
            InitializeComponent();

            Configuration();

            // TODO: move everything from the start of program to separate function



            // DrawCanvas();
            isReady = true;
            DrawCanvas();

        }

        public void Configuration()
        {
            // set title and icon
            this.Text = "Triangle Mesh Filler";
            this.Icon = Properties.Resources.tmf_icon;

            // can't change size of form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            // new size of form
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = (int)(screen.Width / 2.0);
            int h = (int)(screen.Height / 1.5);
            this.Size = new Size(w, h);

            // create canvas as square
            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel1.ColumnStyles[0].Width = tableLayoutPanel1.Height;
            Canvas.Width = tableLayoutPanel1.Height;
            Canvas.Height = Canvas.Width;
            this.Size = new Size(tableLayoutPanel1.Height + this.Width / 2, this.Height);

            // create new bitmap
            drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea.Bitmap;

            // load shape from *.obj file
            LoadShape(@".\obj_files\object.obj");

            // load texture from file
            LoadTexture(@".\texture_files\wood.jpg");

            // load normalmap from file
            LoadNormalMap(@".\nm_files\bricks.jpg");

            // Canvas.Image = normalMap;

            // set values of sliders
            kd_slider.Value = (int)(kd * 100);
            ks_slider.Value = (int)(ks * 100);
            m_slider.Value = m;

            Debug.WriteLine($"z_slider: {z_slider.Minimum}, {z_slider.Maximum}, {z_slider.Value}");


            Debug.WriteLine($"Canva size: {Canvas.Width}, {Canvas.Height}");

            // set values of colors
            cdObject.Color = Color.FromArgb((int)(colorObject[0] * 255.0), (int)(colorObject[1] * 255.0), (int)(colorObject[2] * 255.0));
            cdLight.Color = Color.FromArgb((int)(colorLight[0] * 255.0), (int)(colorLight[1] * 255.0), (int)(colorLight[2] * 255.0));

            bmColorObject = new Bitmap(pictureBoxObjectColor.Width, pictureBoxObjectColor.Height);
            pictureBoxObjectColor.Image = bmColorObject;
            bmColorLight = new Bitmap(pictureBoxLightColor.Width, pictureBoxLightColor.Height);
            pictureBoxLightColor.Image = bmColorLight;

            FillWithColor(pictureBoxObjectColor, bmColorObject, cdObject.Color);
            FillWithColor(pictureBoxLightColor, bmColorLight, cdLight.Color);

            Debug.WriteLine($"all: {polygons.Count}");
        }

        public void FillWithColor(PictureBox pb, Bitmap bitmap, Color color)
        {
            using Graphics g = Graphics.FromImage(bitmap);
            using SolidBrush sb = new SolidBrush(color);

            g.FillRectangle(sb, 0, 0, bitmap.Width, bitmap.Height);

            pb.Invalidate();
            pb.Update();
        }

        public void DrawCanvas()
        {
            //if (animating)
            //{
            //    if (drawArea != null) drawArea.Dispose();

            //    drawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            //    Canvas.Image = drawArea.Bitmap;
            //}

            if (!isReady) return;

            // return;

            Debug.WriteLine($"interpolation type {interpolationType}, filling type {fillingType}");

            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                g.Clear(Color.White);
            }

            Debug.WriteLine($"sun koords {sun.x}, {sun.y}");
            

            foreach (var polygon in polygons)
            {
                ScanlineFill(polygon);
            }
            if (DrawShapeCheckBox.Checked)
            {
                DrawShape();
            }
            if (DrawSunCheckBox.Checked)
            {
                DrawSun();
            }

            Canvas.Invalidate();
            if (this.IsHandleCreated)
            {
                try
                {
                    Canvas.Invoke((MethodInvoker)delegate
                    {
                    // Running on the UI thread
                    if (Canvas.IsDisposed) return;
                        Canvas.Update();
                    });
                }
                catch
                {
                    Debug.WriteLine("Error while closing with animation.");
                }
            }
            else
            {
                Canvas.Update();
            }
            
        }

        public void LoadShape(string str)
        {
            string[] lines = System.IO.File.ReadAllLines(str);

            points = new List<MyPoint>();
            normalVectorsX = new List<double>();
            normalVectorsY = new List<double>();
            normalVectorsZ = new List<double>();
            polygons = new List<Polygon>();

            foreach (string line in lines)
            {
                string[] words = line.Split();

                // Debug.WriteLine(words.Length);

                if (words[0] == "v")
                {
                    // Debug.WriteLine("enter v");
                    points.Add(new MyPoint(Convert.ToDouble(words[1]), Convert.ToDouble(words[2]), Convert.ToDouble(words[3]), 0, 0, 0));
                }
                else if (words[0] == "vn")
                {
                    // Debug.WriteLine("enter vn");
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
                    Polygon polygon = new Polygon();
                    List<MyPoint> pointsP = new List<MyPoint>();
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
                    List<Edge> edges = new List<Edge>();
                    for (int i = 0; i < polygon.size; i++)
                    {
                        edges.Add(new Edge(polygon.points[i], polygon.points[(i + 1) % polygon.size]));
                    }
                    polygon.edges = edges;
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

            zMax = double.MinValue;
            foreach (var point in points)
            {
                if (point.z > zMax) zMax = point.z;
            }
            Debug.WriteLine($"zMax: {zMax}");

            if (sun == null)
            {
                sun = new Sun(200.0, 400.0, zMax + 500.0, 100);
            }
            else
            {
                sun.z = zMax + 500.0;
            }

            z_slider.Minimum = (int)(1.1 * zMax);
            z_slider.Value = (int)sun.z;
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

        // TODO: move those tables to polygon - do not calculate it every frame

        private static EdgeTableTuple[] edgeTable;
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static EdgeTableTuple ActiveEdgeTuple = new EdgeTableTuple();

        public static EdgeTableTuple[] EdgeTable { get => edgeTable; set => edgeTable = value; }
#pragma warning restore CA2211 // Non-constant fields should not be visible

        public static void InitEdgeTable()
        {
            maxHt = maxY - minY + 1;
            EdgeTable = new EdgeTableTuple[maxHt];
            for (int i = 0; i < maxHt; i++)
            {
                EdgeTable[i] = new EdgeTableTuple();
                EdgeTable[i].countEdgeBucket = 0;
                for (int j = 0; j < maxVer; j++)
                {
                    EdgeTable[i].buckets[j] = new EdgeBucket();
                }
            }
            for (int i = 0; i < maxVer; i++)
            {
                ActiveEdgeTuple.buckets[i] = new EdgeBucket();
            }
            ActiveEdgeTuple.countEdgeBucket = 0;
        }

        static void InsertionSort(EdgeTableTuple ett)
        {
            int i, j;
            EdgeBucket temp = new EdgeBucket();

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

            // Debug.WriteLine($"interpolation type {interpolationType}, filling type {fillingType}");

            // List<Color> verticesColors = new List<Color>() { 0, 0, 0 };

            List<double> colorA = null;
            List<double> colorB = null;
            List<double> colorC = null;

            if (interpolationType == 0)
            {
                if (fillingType == 0)
                {
                    colorA = CountColorForPoint(polygon.points[0], null);
                    colorB = CountColorForPoint(polygon.points[1], null);
                    colorC = CountColorForPoint(polygon.points[2], null);
                }
                else
                {
                    Color color1 = textureColors[(int)polygon.points[0].x, (int)polygon.points[0].y];
                    Color color2 = textureColors[(int)polygon.points[1].x, (int)polygon.points[1].y];
                    Color color3 = textureColors[(int)polygon.points[2].x, (int)polygon.points[2].y];
                    colorA = new List<double>() { color1.R / 255.0, color1.G / 255.0, color1.B / 255.0 };
                    colorB = new List<double>() { color2.R / 255.0, color2.G / 255.0, color2.B / 255.0 };
                    colorC = new List<double>() { color3.R / 255.0, color3.G / 255.0, color3.B / 255.0 };
                }
                
            }
            // List<Color> verticesColors = FindColorsOfVertices(polygon);
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
                                Color color = Color.White;
                                if (area <= 0)
                                {
                                    color = Color.FromArgb(0, 0, 0);
                                }
                                else if (interpolationType == 0)
                                {

                                    color = FindColorOfPixel(polygon, colorA, colorB, colorC, new MyPoint(k, i + minY), area);

                                }
                                else if (interpolationType == 1)
                                {
                                    if (fillingType == 0)
                                    {
                                        MyPoint point = CountNormalVector(polygon, k, i + minY, area);
                                        var colorVector = CountColorForPoint(point, null);
                                        color = Color.FromArgb((int)(colorVector[0] * 255), (int)(colorVector[1] * 255), (int)(colorVector[2] * 255));
                                    }
                                    else if (fillingType == 1)
                                    {
                                        MyPoint point = CountNormalVector(polygon, k, i + minY, area);
                                        var colorVector = CountColorForPoint(point, textureColors[k, i+minY]);
                                        color = Color.FromArgb((int)(colorVector[0] * 255), (int)(colorVector[1] * 255), (int)(colorVector[2] * 255));
                                    }
                             
                                }
                                // TODO: if drawing using texture, use below
                                // Color color = textureColors[k, i + minY];
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

        public MyPoint CountNormalVector(Polygon polygon, int x, int y, double area)
        {
            MyPoint point = new MyPoint(x, y);
            if (x == (int)polygon.points[0].x && y == (int)polygon.points[0].y) return polygon.points[0];
            if (x == (int)polygon.points[1].x && y == (int)polygon.points[1].y) return polygon.points[1];
            if (x == (int)polygon.points[2].x && y == (int)polygon.points[2].y) return polygon.points[2];
            double alfa = getArea(polygon.points[1], polygon.points[2], point) / area;
            double beta = getArea(polygon.points[0], polygon.points[2], point) / area;
            double gamma = 1 - alfa - beta;

            List<double> normalVector = new List<double>() { 0, 0, 0 };

            point.z = alfa * polygon.points[0].z + beta * polygon.points[1].z + gamma * polygon.points[2].z;
            if (point.z < 0 || Double.IsNaN(point.z))
                point.z = 0.0;
            point.nx = alfa * polygon.points[0].nx + beta * polygon.points[1].nx + gamma * polygon.points[2].nx;
            if (Double.IsNaN(point.nx))
                point.nx = 0.0;
            point.ny = alfa * polygon.points[0].ny + beta * polygon.points[1].ny + gamma * polygon.points[2].ny;
            if (Double.IsNaN(point.ny)) 
                point.ny = 0.0;
            point.nz = alfa * polygon.points[0].nz + beta * polygon.points[1].nz + gamma * polygon.points[2].nz;
            if (Double.IsNaN(point.nz)) 
                point.nz = 0.0;
            if (NormalMapCheckbox.Checked)
            {
                var result = ModifyNormalVector(point);
                point.nx = result[0];
                point.ny = result[1];
                point.nz = result[2];
            }
            return point;
        }

        public Color FindColorOfPixel(Polygon polygon, List<double> colorA, List<double> colorB, List<double> colorC, MyPoint point, double area)
        {
            //if (point.x == (int)polygon.points[0].x && point.y == (int)polygon.points[0].y) return Color.FromArgb((int)colorA[0], (int)colorA[1], (int)colorA[2]);
            //if (point.x == (int)polygon.points[1].x && point.y == (int)polygon.points[1].y) return Color.FromArgb((int)colorB[0], (int)colorB[1], (int)colorB[2]);
            //if (point.x == (int)polygon.points[2].x && point.y == (int)polygon.points[2].y) return Color.FromArgb((int)colorC[0], (int)colorC[1], (int)colorC[2]);
            double alfa = getArea(polygon.points[1], polygon.points[2], point) / area;
            double beta = getArea(polygon.points[0], polygon.points[2], point) / area;
            // double gamma = getArea(polygon.points[0], polygon.points[1], point) / area;
            double gamma = 1 - alfa - beta;
            // if (gamma < 0) gamma = 0;

            // Debug.WriteLine($"{alfa + beta + gamma}");

            List<double> color = new List<double>() { 0, 0, 0 };
            color[0] = Math.Min(alfa * colorA[0] + beta * colorB[0] + gamma * colorC[0], 1.0) * 255.0;
            color[1] = Math.Min(alfa * colorA[1] + beta * colorB[1] + gamma * colorC[1], 1.0) * 255.0;
            color[2] = Math.Min(alfa * colorA[2] + beta * colorB[2] + gamma * colorC[2], 1.0) * 255.0;
            //color[0] = Math.Min((int)(alfa * colors[0].R + beta * colors[1].R + gamma * colors[2].R), 255);
            //color[1] = Math.Min((int)(alfa * colors[0].G + beta * colors[1].G + gamma * colors[2].G), 255);
            //color[2] = Math.Min((int)(alfa * colors[0].B + beta * colors[1].B + gamma * colors[2].B), 255);

            for (int i = 0; i < color.Count; i++)
            {
                if (color[i] < 0.0 || Double.IsNaN(color[i])) color[i] = 0.0;
            }
            return Color.FromArgb((int)color[0], (int)color[1], (int)color[2]);
            // return Color.FromArgb(0, 0, 0);
        }

        public List<double> CountColorForPoint(MyPoint point, Color? pixelColor)
        {
            if (fillingType == 1)
            {
                colorObject[0] = pixelColor.Value.R / 255.0;
                colorObject[1] = pixelColor.Value.G / 255.0;
                colorObject[2] = pixelColor.Value.B / 255.0;
            }
            List<double> L = new List<double>() { 0, 0, 0 };
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
            List<double> N = new List<double>() { point.nx, point.ny, point.nz };

            double lenN = Math.Sqrt(N[0] * N[0] + N[1] * N[1] + N[2] * N[2]);
            for (int i = 0; i < N.Count; i++)
            {
                N[i] /= lenN;
            }
            // Debug.WriteLine($"normal vector length: {Math.Sqrt(N[0] * N[0] + N[1] * N[1] + N[2] * N[2])}");
            double cosNL = L[0] * N[0] + L[1] * N[1] + L[2] * N[2];
            cosNL = cosNL < 0 ? 0 : cosNL;
            // Debug.WriteLine($"cosNL: {cosNL}");
            List<double> V = new List<double>() { 0, 0, 1 };
            List<double> R = new List<double>() { 0, 0, 0 };
            for (int i = 0; i < R.Count; i++)
            {
                R[i] = 2 * cosNL * N[i] - L[i];
            }
            double cosVR = V[0] * R[0] + V[1] * R[1] + V[2] * R[2];
            cosVR = cosVR < 0 ? 0 : cosVR;
            List<double> color = new List<double>() { 0, 0, 0 };
            for (int i = 0; i < color.Count; i++)
            {
                color[i] = kd * colorLight[i] * colorObject[i] * cosNL + ks * colorLight[i] * colorObject[i] * Math.Pow(cosVR, m);
                color[i] = Math.Min(color[i], 1.0);
                if (color[i] < 0) color[i] = 0.0;
            }
            return color;
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
            // TODO: same for every other object!!!
            if (AnimationError()) return;
            sun.x = e.X;
            sun.y = e.Y;
            clicked = true;
            DrawCanvas();
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

        private void kd_slider_ValueChanged(object sender, EventArgs e)
        {
            if (AnimationError())
            {
                kd_slider.Value = (int)(kd * 100);
                return;
            }
            kd = kd_slider.Value / 100.0;
            kd_label.Text = "kd = " + kd.ToString();
            kd_label.Invalidate();
            kd_label.Update();
            DrawCanvas();
        }

        private void ks_slider_ValueChanged(object sender, EventArgs e)
        {
            if (AnimationError())
            {
                ks_slider.Value = (int)(ks * 100);
                return;
            } 
            ks = ks_slider.Value / 100.0;
            ks_label.Text = "ks = " + ks.ToString();
            ks_label.Invalidate();
            ks_label.Update();
            DrawCanvas();
        }

        private void m_slider_ValueChanged(object sender, EventArgs e)
        {
            if (AnimationError())
            {
                m_slider.Value = m;
                return;
            }
            m = m_slider.Value;
            m_label.Text = "m = " + m.ToString();
            m_label.Invalidate();
            m_label.Update();
            DrawCanvas();
        }

        private void z_slider_ValueChanged(object sender, EventArgs e)
        {
            if (AnimationError())
            {
                z_slider.Value = (int)sun.z;
                return;
            }
            sun.z = z_slider.Value;
            z_label.Text = "z = " + sun.z.ToString();
            z_label.Invalidate();
            z_label.Update();
            DrawCanvas();
        }

        private void DrawShapeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawCanvas();
        }

        private void AnimationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnimationCheckBox.Checked)
            {
                AnimateSun();
            }
            else
            {
                animating = false;
            }
        }

        public void AnimateSun()
        {
            animating = true;

            var ts = new System.Threading.ThreadStart(animationFunction);
            var backgroundThread = new System.Threading.Thread(ts);
            backgroundThread.Start();
        }

        public void animationFunction()
        {
            double middleX = Canvas.Width / 2.0;
            double middleY = Canvas.Height / 2.0;
            double animationRadius = GetDistance(new MyPoint(middleX, middleY), new MyPoint(sun.x, sun.y));

            int sign = sun.x < middleX ? -1 : 1;

            while (true)
            {
                if (animating)
                {
                    sun.y += sign * 30.0;
                    if (sun.y - middleY >= animationRadius)
                    {
                        Debug.WriteLine("wchodze1");
                        sun.y = middleY + animationRadius;
                        sun.x = middleX;
                        sign = -sign;
                    }
                    else if (sun.y - middleY <= -animationRadius)
                    {
                        Debug.WriteLine("wchodze2");
                        sun.y = middleY - animationRadius;
                        sun.x = middleX;
                        sign = -sign;
                    }
                    else
                    {
                        double tempY = sun.y - middleY;
                        double tempX = sign * Math.Sqrt(animationRadius * animationRadius - tempY * tempY);
                        sun.x = tempX + middleX;
                    }
                    DrawCanvas();
                }
                else
                {
                    break;
                }
            }
        }


        public bool AnimationError()
        {
            if (animating)
            {
                MessageBox.Show("You can't do anything during animation.", "Animation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            animating = false;
        }

        private void ObjectColorButton_Click(object sender, EventArgs e)
        {
            cdObject.ShowDialog();
            colorObject[0] = cdObject.Color.R / 255.0;
            colorObject[1] = cdObject.Color.G / 255.0;
            colorObject[2] = cdObject.Color.B / 255.0;
            DrawCanvas();
            FillWithColor(pictureBoxObjectColor, bmColorObject, cdObject.Color);
        }

        private void LightColorButton_Click(object sender, EventArgs e)
        {
            cdLight.ShowDialog();
            colorLight[0] = cdLight.Color.R / 255.0;
            colorLight[1] = cdLight.Color.G / 255.0;
            colorLight[2] = cdLight.Color.B / 255.0;
            DrawCanvas();
            FillWithColor(pictureBoxLightColor, bmColorLight, cdLight.Color);
        }

        private void InterpolateColors_Click(object sender, EventArgs e)
        {
            interpolationType = 0;
            DrawCanvas();
        }

        private void InterpolateVectors_Click(object sender, EventArgs e)
        {
            interpolationType = 1;
            DrawCanvas();
        }

        private void FillColor_Click(object sender, EventArgs e)
        {
            fillingType = 0;
            ObjectColorButton.Enabled = true;
            LoadTextureButton.Enabled = false;
            colorObject[0] = cdObject.Color.R / 255.0;
            colorObject[1] = cdObject.Color.G / 255.0;
            colorObject[2] = cdObject.Color.B / 255.0;
            DrawCanvas();
        }

        private void FillTexture_Click(object sender, EventArgs e)
        {
            fillingType = 1;
            ObjectColorButton.Enabled = false;
            LoadTextureButton.Enabled = true;
            DrawCanvas();
        }

        private void LoadTexture(string filename)
        {
            Size s = new Size(Canvas.Width, Canvas.Height);
            image = new Bitmap(new Bitmap(filename), s);
            textureColors = new Color[Canvas.Width, Canvas.Height];
            for (int i = 0; i < Canvas.Width; i++)
            {
                for (int j = 0; j < Canvas.Height; j++)
                {
                    textureColors[i, j] = image.GetPixel(i, j);
                }
            }
            DrawCanvas();
        }

        private void LoadNormalMap(string filename)
        {
            Size s = new Size(Canvas.Width, Canvas.Height);
            normalMap = new Bitmap(new Bitmap(filename), s);
            normalMapColors = new Color[Canvas.Width, Canvas.Height];
            for (int i = 0; i < Canvas.Width; i++)
            {
                for (int j = 0; j < Canvas.Height; j++)
                {
                    normalMapColors[i, j] = normalMap.GetPixel(i, j);
                }
            }
        }

        private void LoadShapeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Debug.WriteLine(Environment.CurrentDirectory);
            ofd.InitialDirectory = Environment.CurrentDirectory + @".\obj_files";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = ofd.FileName;
                LoadShape(filename);
                DrawCanvas();
            }
        }

        private void LoadTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @".\texture_files";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = ofd.FileName;
                LoadTexture(filename);
            }
        }

        private void LoadShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void LightColorButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void ObjectColorButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void LoadTextureButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void InterpolateColors_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void InterpolateVectors_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void LoadNormalMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void kd_slider_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void ks_slider_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void m_slider_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void z_slider_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void FillColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void FillTexture_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void DrawShapeCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void NormalMapCheckbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void DrawSunCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawCanvas();
        }

        private void DrawSunCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimationError()) return;
        }

        private void LoadNormalMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @".\nm_files";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = ofd.FileName;
                LoadNormalMap(filename);
            }
        }

        private List<double> ModifyNormalVector(MyPoint point)
        {
            List<double> surfaceN = new List<double>() { point.nx, point.ny, point.nz };
            List<double> textureN = new List<double>() { 0, 0, 0 };
            Color test = Color.FromArgb(127, 127, 255);
            textureN[0] = (1.0 * normalMapColors[(int)point.x, (int)point.y].R - 127.5) / 127.5;
            textureN[1] = (1.0 * normalMapColors[(int)point.x, (int)point.y].G - 127.5) / 127.5;
            textureN[2] = (1.0 * normalMapColors[(int)point.x, (int)point.y].B) / 255.0;
            //textureN[0] = (1.0 * test.R - 127.5) / 127.5;
            //textureN[1] = (1.0 * test.G - 127.5) / 127.5;
            //textureN[2] = (1.0 * test.B) / 255.0;
            double textureNLength = Math.Sqrt(textureN[0] * textureN[0] + textureN[1] * textureN[1] + textureN[2] * textureN[2]);
            for (int i = 0; i < textureN.Count; i++)
            {
                textureN[i] /= textureNLength;
            }
            List<double> B = new List<double>() { 0, 0, 0 };
            if (point.nx == 0.0 && point.ny == 0.0 && point.nz == 1.0)
            {
                B[1] = 1.0;
            }
            else
            {
                B = CrossProduct(surfaceN, new List<double>() { 0, 0, 1 });
            }
            // TODO: add NSurface
            List<double> T = CrossProduct(B, surfaceN);
            double[,] M = new double[3, 3];
            M[0, 0] = T[0];
            M[0, 1] = B[0];
            M[0, 2] = surfaceN[0];
            M[1, 0] = T[1];
            M[1, 1] = B[1];
            M[1, 2] = surfaceN[1];
            M[2, 0] = T[2];
            M[2, 1] = B[2];
            M[2, 2] = surfaceN[2];
            var result = MatrixMultiplication(M, textureN);
            //for (int idx = 0; idx < result.Count; idx++)
            //{
            //    Debug.WriteLine(result[idx].ToString());
            //}
            return result;
        }

        private List<double> MatrixMultiplication(double[,] M, List<double> N)
        {
            return new List<double>() { M[0, 0] * N[0] + M[0, 1] * N[1] + M[0, 2] * N[2], M[1, 0] * N[0] + M[1, 1] * N[1] + M[1, 2] * N[2], M[2, 0] * N[0] + M[2, 1] * N[1] + M[2, 2] * N[2] };
        }

        private List<double> CrossProduct(List<double> a, List<double> b)
        {
            List<double> result = new List<double>() { 0, 0, 0 };
            List<double> i = new List<double>() { 1, 0, 0 };
            List<double> j = new List<double>() { 0, 1, 0 };
            List<double> k = new List<double>() { 0, 0, 1 };
            for (int idx = 0; idx < result.Count; idx++)
            {
                result[idx] = a[0] * b[1] * k[idx] + a[0] * b[2] * (-j[idx]) + a[1] * b[0] * (-k[idx]) + a[1] * b[2] * i[idx] + a[2] * b[0] * j[idx] + a[2] * b[1] * (-i[idx]);
            }
            return result;
        }

        private void NormalMapCheckbox_Click(object sender, EventArgs e)
        {
            if (NormalMapCheckbox.Checked)
            {
                foreach (var point in points)
                {
                    var result = ModifyNormalVector(point);
                    point.nx = result[0];
                    point.ny = result[1];
                    point.nz = result[2];
                }
                DrawCanvas();
            }
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
