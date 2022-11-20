
namespace triangle_mesh_filler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.InterpolateVectors = new System.Windows.Forms.RadioButton();
            this.pictureBoxObjectColor = new System.Windows.Forms.PictureBox();
            this.InterpolateColors = new System.Windows.Forms.RadioButton();
            this.ObjectColorButton = new System.Windows.Forms.Button();
            this.LoadTextureButton = new System.Windows.Forms.Button();
            this.LoadNormalMapButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kd_slider = new System.Windows.Forms.TrackBar();
            this.ks_slider = new System.Windows.Forms.TrackBar();
            this.m_slider = new System.Windows.Forms.TrackBar();
            this.z_slider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLightColor = new System.Windows.Forms.PictureBox();
            this.LightColorButton = new System.Windows.Forms.Button();
            this.z_label = new System.Windows.Forms.Label();
            this.m_label = new System.Windows.Forms.Label();
            this.ks_label = new System.Windows.Forms.Label();
            this.LoadShapeButton = new System.Windows.Forms.Button();
            this.kd_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.DrawShapeCheckBox = new System.Windows.Forms.CheckBox();
            this.FillTexture = new System.Windows.Forms.RadioButton();
            this.FillColor = new System.Windows.Forms.RadioButton();
            this.NormalMapCheckbox = new System.Windows.Forms.CheckBox();
            this.AnimationCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawSunCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(3, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(781, 923);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Canvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 929);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(790, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(781, 923);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.InterpolateVectors, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxObjectColor, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.InterpolateColors, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.ObjectColorButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.LoadTextureButton, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.LoadNormalMapButton, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(384, 456);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // InterpolateVectors
            // 
            this.InterpolateVectors.AutoSize = true;
            this.InterpolateVectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterpolateVectors.Location = new System.Drawing.Point(3, 307);
            this.InterpolateVectors.Name = "InterpolateVectors";
            this.InterpolateVectors.Size = new System.Drawing.Size(378, 70);
            this.InterpolateVectors.TabIndex = 4;
            this.InterpolateVectors.Text = "interpolate vectors";
            this.InterpolateVectors.UseVisualStyleBackColor = true;
            this.InterpolateVectors.Click += new System.EventHandler(this.InterpolateVectors_Click);
            this.InterpolateVectors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterpolateVectors_MouseDown);
            // 
            // pictureBoxObjectColor
            // 
            this.pictureBoxObjectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxObjectColor.Location = new System.Drawing.Point(3, 79);
            this.pictureBoxObjectColor.Name = "pictureBoxObjectColor";
            this.pictureBoxObjectColor.Size = new System.Drawing.Size(378, 70);
            this.pictureBoxObjectColor.TabIndex = 3;
            this.pictureBoxObjectColor.TabStop = false;
            // 
            // InterpolateColors
            // 
            this.InterpolateColors.AutoSize = true;
            this.InterpolateColors.Checked = true;
            this.InterpolateColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterpolateColors.Location = new System.Drawing.Point(3, 231);
            this.InterpolateColors.Name = "InterpolateColors";
            this.InterpolateColors.Size = new System.Drawing.Size(378, 70);
            this.InterpolateColors.TabIndex = 3;
            this.InterpolateColors.TabStop = true;
            this.InterpolateColors.Text = "interpolate colors";
            this.InterpolateColors.UseVisualStyleBackColor = true;
            this.InterpolateColors.Click += new System.EventHandler(this.InterpolateColors_Click);
            this.InterpolateColors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterpolateColors_MouseDown);
            // 
            // ObjectColorButton
            // 
            this.ObjectColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectColorButton.Location = new System.Drawing.Point(3, 3);
            this.ObjectColorButton.Name = "ObjectColorButton";
            this.ObjectColorButton.Size = new System.Drawing.Size(378, 70);
            this.ObjectColorButton.TabIndex = 2;
            this.ObjectColorButton.Text = "pick color of object";
            this.ObjectColorButton.UseVisualStyleBackColor = true;
            this.ObjectColorButton.Click += new System.EventHandler(this.ObjectColorButton_Click);
            this.ObjectColorButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ObjectColorButton_MouseDown);
            // 
            // LoadTextureButton
            // 
            this.LoadTextureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadTextureButton.Enabled = false;
            this.LoadTextureButton.Location = new System.Drawing.Point(3, 155);
            this.LoadTextureButton.Name = "LoadTextureButton";
            this.LoadTextureButton.Size = new System.Drawing.Size(378, 70);
            this.LoadTextureButton.TabIndex = 4;
            this.LoadTextureButton.Text = "load texture";
            this.LoadTextureButton.UseVisualStyleBackColor = true;
            this.LoadTextureButton.Click += new System.EventHandler(this.LoadTexture_Click);
            this.LoadTextureButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoadTextureButton_MouseDown);
            // 
            // LoadNormalMapButton
            // 
            this.LoadNormalMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadNormalMapButton.Location = new System.Drawing.Point(3, 383);
            this.LoadNormalMapButton.Name = "LoadNormalMapButton";
            this.LoadNormalMapButton.Size = new System.Drawing.Size(378, 70);
            this.LoadNormalMapButton.TabIndex = 5;
            this.LoadNormalMapButton.Text = "load normal map";
            this.LoadNormalMapButton.UseVisualStyleBackColor = true;
            this.LoadNormalMapButton.Click += new System.EventHandler(this.LoadNormalMapButton_Click);
            this.LoadNormalMapButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoadNormalMap_MouseDown);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.kd_slider, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.ks_slider, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.m_slider, 2, 1);
            this.tableLayoutPanel9.Controls.Add(this.z_slider, 3, 1);
            this.tableLayoutPanel9.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(393, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(385, 455);
            this.tableLayoutPanel9.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(291, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "z";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(195, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "m";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(99, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "ks";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kd_slider
            // 
            this.kd_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kd_slider.Location = new System.Drawing.Point(3, 48);
            this.kd_slider.Maximum = 100;
            this.kd_slider.Name = "kd_slider";
            this.kd_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kd_slider.Size = new System.Drawing.Size(90, 404);
            this.kd_slider.TabIndex = 0;
            this.kd_slider.ValueChanged += new System.EventHandler(this.kd_slider_ValueChanged);
            this.kd_slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kd_slider_MouseDown);
            // 
            // ks_slider
            // 
            this.ks_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ks_slider.Location = new System.Drawing.Point(99, 48);
            this.ks_slider.Maximum = 100;
            this.ks_slider.Name = "ks_slider";
            this.ks_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ks_slider.Size = new System.Drawing.Size(90, 404);
            this.ks_slider.TabIndex = 1;
            this.ks_slider.ValueChanged += new System.EventHandler(this.ks_slider_ValueChanged);
            this.ks_slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ks_slider_MouseDown);
            // 
            // m_slider
            // 
            this.m_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_slider.Location = new System.Drawing.Point(195, 48);
            this.m_slider.Maximum = 100;
            this.m_slider.Minimum = 1;
            this.m_slider.Name = "m_slider";
            this.m_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_slider.Size = new System.Drawing.Size(90, 404);
            this.m_slider.TabIndex = 2;
            this.m_slider.Value = 1;
            this.m_slider.ValueChanged += new System.EventHandler(this.m_slider_ValueChanged);
            this.m_slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_slider_MouseDown);
            // 
            // z_slider
            // 
            this.z_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.z_slider.Location = new System.Drawing.Point(291, 48);
            this.z_slider.Maximum = 2000;
            this.z_slider.Minimum = 500;
            this.z_slider.Name = "z_slider";
            this.z_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.z_slider.Size = new System.Drawing.Size(91, 404);
            this.z_slider.SmallChange = 10;
            this.z_slider.TabIndex = 3;
            this.z_slider.Value = 500;
            this.z_slider.ValueChanged += new System.EventHandler(this.z_slider_ValueChanged);
            this.z_slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.z_slider_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "kd";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBoxLightColor, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.LightColorButton, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.z_label, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.m_label, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.ks_label, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.LoadShapeButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kd_label, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 455);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // pictureBoxLightColor
            // 
            this.pictureBoxLightColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLightColor.Location = new System.Drawing.Point(3, 387);
            this.pictureBoxLightColor.Name = "pictureBoxLightColor";
            this.pictureBoxLightColor.Size = new System.Drawing.Size(378, 65);
            this.pictureBoxLightColor.TabIndex = 4;
            this.pictureBoxLightColor.TabStop = false;
            // 
            // LightColorButton
            // 
            this.LightColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightColorButton.Location = new System.Drawing.Point(3, 323);
            this.LightColorButton.Name = "LightColorButton";
            this.LightColorButton.Size = new System.Drawing.Size(378, 58);
            this.LightColorButton.TabIndex = 3;
            this.LightColorButton.Text = "pick color of light";
            this.LightColorButton.UseVisualStyleBackColor = true;
            this.LightColorButton.Click += new System.EventHandler(this.LightColorButton_Click);
            this.LightColorButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LightColorButton_MouseDown);
            // 
            // z_label
            // 
            this.z_label.AutoSize = true;
            this.z_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.z_label.Location = new System.Drawing.Point(3, 256);
            this.z_label.Name = "z_label";
            this.z_label.Size = new System.Drawing.Size(378, 64);
            this.z_label.TabIndex = 3;
            this.z_label.Text = "label4";
            this.z_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_label
            // 
            this.m_label.AutoSize = true;
            this.m_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_label.Location = new System.Drawing.Point(3, 192);
            this.m_label.Name = "m_label";
            this.m_label.Size = new System.Drawing.Size(378, 64);
            this.m_label.TabIndex = 2;
            this.m_label.Text = "label3";
            this.m_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ks_label
            // 
            this.ks_label.AutoSize = true;
            this.ks_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ks_label.Location = new System.Drawing.Point(3, 128);
            this.ks_label.Name = "ks_label";
            this.ks_label.Size = new System.Drawing.Size(378, 64);
            this.ks_label.TabIndex = 1;
            this.ks_label.Text = "label2";
            this.ks_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadShapeButton
            // 
            this.LoadShapeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadShapeButton.Location = new System.Drawing.Point(3, 3);
            this.LoadShapeButton.Name = "LoadShapeButton";
            this.LoadShapeButton.Size = new System.Drawing.Size(378, 58);
            this.LoadShapeButton.TabIndex = 0;
            this.LoadShapeButton.Text = "load shape";
            this.LoadShapeButton.UseVisualStyleBackColor = true;
            this.LoadShapeButton.Click += new System.EventHandler(this.LoadShapeButton_Click);
            this.LoadShapeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoadShapeButton_MouseDown);
            // 
            // kd_label
            // 
            this.kd_label.AutoSize = true;
            this.kd_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kd_label.Location = new System.Drawing.Point(3, 64);
            this.kd_label.Name = "kd_label";
            this.kd_label.Size = new System.Drawing.Size(378, 64);
            this.kd_label.TabIndex = 0;
            this.kd_label.Text = "label1";
            this.kd_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.DrawShapeCheckBox, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.FillTexture, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.FillColor, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.NormalMapCheckbox, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.AnimationCheckBox, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.DrawSunCheckBox, 0, 3);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(393, 464);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 6;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(385, 456);
            this.tableLayoutPanel10.TabIndex = 8;
            // 
            // DrawShapeCheckBox
            // 
            this.DrawShapeCheckBox.AutoSize = true;
            this.DrawShapeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawShapeCheckBox.Location = new System.Drawing.Point(3, 155);
            this.DrawShapeCheckBox.Name = "DrawShapeCheckBox";
            this.DrawShapeCheckBox.Size = new System.Drawing.Size(379, 70);
            this.DrawShapeCheckBox.TabIndex = 0;
            this.DrawShapeCheckBox.Text = "draw shape";
            this.DrawShapeCheckBox.UseVisualStyleBackColor = true;
            this.DrawShapeCheckBox.CheckedChanged += new System.EventHandler(this.DrawShapeCheckBox_CheckedChanged);
            this.DrawShapeCheckBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawShapeCheckBox_MouseDown);
            // 
            // FillTexture
            // 
            this.FillTexture.AutoSize = true;
            this.FillTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillTexture.Location = new System.Drawing.Point(3, 79);
            this.FillTexture.Name = "FillTexture";
            this.FillTexture.Size = new System.Drawing.Size(379, 70);
            this.FillTexture.TabIndex = 1;
            this.FillTexture.Text = "fill with texture";
            this.FillTexture.UseVisualStyleBackColor = true;
            this.FillTexture.Click += new System.EventHandler(this.FillTexture_Click);
            this.FillTexture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FillTexture_MouseDown);
            // 
            // FillColor
            // 
            this.FillColor.AutoSize = true;
            this.FillColor.Checked = true;
            this.FillColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillColor.Location = new System.Drawing.Point(3, 3);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(379, 70);
            this.FillColor.TabIndex = 0;
            this.FillColor.TabStop = true;
            this.FillColor.Text = "fill with color";
            this.FillColor.UseVisualStyleBackColor = true;
            this.FillColor.Click += new System.EventHandler(this.FillColor_Click);
            this.FillColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FillColor_MouseDown);
            // 
            // NormalMapCheckbox
            // 
            this.NormalMapCheckbox.AutoSize = true;
            this.NormalMapCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalMapCheckbox.Location = new System.Drawing.Point(3, 383);
            this.NormalMapCheckbox.Name = "NormalMapCheckbox";
            this.NormalMapCheckbox.Size = new System.Drawing.Size(379, 70);
            this.NormalMapCheckbox.TabIndex = 2;
            this.NormalMapCheckbox.Text = "use normal map";
            this.NormalMapCheckbox.UseVisualStyleBackColor = true;
            this.NormalMapCheckbox.Click += new System.EventHandler(this.NormalMapCheckbox_Click);
            this.NormalMapCheckbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NormalMapCheckbox_MouseDown);
            // 
            // AnimationCheckBox
            // 
            this.AnimationCheckBox.AutoSize = true;
            this.AnimationCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationCheckBox.Location = new System.Drawing.Point(3, 307);
            this.AnimationCheckBox.Name = "AnimationCheckBox";
            this.AnimationCheckBox.Size = new System.Drawing.Size(379, 70);
            this.AnimationCheckBox.TabIndex = 1;
            this.AnimationCheckBox.Text = "animate sun";
            this.AnimationCheckBox.UseVisualStyleBackColor = true;
            this.AnimationCheckBox.CheckedChanged += new System.EventHandler(this.AnimationCheckBox_CheckedChanged);
            // 
            // DrawSunCheckBox
            // 
            this.DrawSunCheckBox.AutoSize = true;
            this.DrawSunCheckBox.Checked = true;
            this.DrawSunCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawSunCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawSunCheckBox.Location = new System.Drawing.Point(3, 231);
            this.DrawSunCheckBox.Name = "DrawSunCheckBox";
            this.DrawSunCheckBox.Size = new System.Drawing.Size(379, 70);
            this.DrawSunCheckBox.TabIndex = 3;
            this.DrawSunCheckBox.Text = "draw sun";
            this.DrawSunCheckBox.UseVisualStyleBackColor = true;
            this.DrawSunCheckBox.CheckedChanged += new System.EventHandler(this.DrawSunCheckBox_CheckedChanged);
            this.DrawSunCheckBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawSunCheckBox_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 929);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TrackBar z_slider;
        private System.Windows.Forms.TrackBar m_slider;
        private System.Windows.Forms.TrackBar ks_slider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox DrawShapeCheckBox;
        private System.Windows.Forms.CheckBox AnimationCheckBox;
        private System.Windows.Forms.Button ObjectColorButton;
        private System.Windows.Forms.Button LightColorButton;
        private System.Windows.Forms.PictureBox pictureBoxObjectColor;
        private System.Windows.Forms.PictureBox pictureBoxLightColor;
        private System.Windows.Forms.RadioButton InterpolateVectors;
        private System.Windows.Forms.RadioButton InterpolateColors;
        private System.Windows.Forms.RadioButton FillColor;
        private System.Windows.Forms.RadioButton FillTexture;
        private System.Windows.Forms.TrackBar kd_slider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button LoadShapeButton;
        private System.Windows.Forms.Label kd_label;
        private System.Windows.Forms.Label ks_label;
        private System.Windows.Forms.Label m_label;
        private System.Windows.Forms.Label z_label;
        private System.Windows.Forms.Button LoadTextureButton;
        private System.Windows.Forms.Button LoadNormalMapButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.CheckBox NormalMapCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox DrawSunCheckBox;
    }
}

