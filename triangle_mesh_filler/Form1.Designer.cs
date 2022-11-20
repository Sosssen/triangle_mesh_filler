
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.z_slider = new System.Windows.Forms.TrackBar();
            this.m_slider = new System.Windows.Forms.TrackBar();
            this.ks_slider = new System.Windows.Forms.TrackBar();
            this.kd_slider = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DrawShapeCheckBox = new System.Windows.Forms.CheckBox();
            this.AnimationCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ObjectColorButton = new System.Windows.Forms.Button();
            this.pictureBoxObjectColor = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.LightColorButton = new System.Windows.Forms.Button();
            this.pictureBoxLightColor = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.InterpolateVectors = new System.Windows.Forms.RadioButton();
            this.InterpolateColors = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.FillColor = new System.Windows.Forms.RadioButton();
            this.FillTexture = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
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
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(790, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(781, 923);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.z_slider, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.m_slider, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.ks_slider, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.kd_slider, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 455);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // z_slider
            // 
            this.z_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.z_slider.Location = new System.Drawing.Point(291, 3);
            this.z_slider.Maximum = 2000;
            this.z_slider.Minimum = 500;
            this.z_slider.Name = "z_slider";
            this.z_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.z_slider.Size = new System.Drawing.Size(90, 449);
            this.z_slider.SmallChange = 10;
            this.z_slider.TabIndex = 3;
            this.z_slider.Value = 500;
            this.z_slider.Scroll += new System.EventHandler(this.z_slider_ValueChanged);
            // 
            // m_slider
            // 
            this.m_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_slider.Location = new System.Drawing.Point(195, 3);
            this.m_slider.Maximum = 100;
            this.m_slider.Minimum = 1;
            this.m_slider.Name = "m_slider";
            this.m_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_slider.Size = new System.Drawing.Size(90, 449);
            this.m_slider.TabIndex = 2;
            this.m_slider.Value = 1;
            this.m_slider.Scroll += new System.EventHandler(this.m_slider_ValueChanged);
            // 
            // ks_slider
            // 
            this.ks_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ks_slider.Location = new System.Drawing.Point(99, 3);
            this.ks_slider.Maximum = 100;
            this.ks_slider.Name = "ks_slider";
            this.ks_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ks_slider.Size = new System.Drawing.Size(90, 449);
            this.ks_slider.TabIndex = 1;
            this.ks_slider.ValueChanged += new System.EventHandler(this.ks_slider_ValueChanged);
            // 
            // kd_slider
            // 
            this.kd_slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kd_slider.Location = new System.Drawing.Point(3, 3);
            this.kd_slider.Maximum = 100;
            this.kd_slider.Name = "kd_slider";
            this.kd_slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kd_slider.Size = new System.Drawing.Size(90, 449);
            this.kd_slider.TabIndex = 0;
            this.kd_slider.ValueChanged += new System.EventHandler(this.kd_slider_ValueChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.DrawShapeCheckBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.AnimationCheckBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(384, 456);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // DrawShapeCheckBox
            // 
            this.DrawShapeCheckBox.AutoSize = true;
            this.DrawShapeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawShapeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.DrawShapeCheckBox.Name = "DrawShapeCheckBox";
            this.DrawShapeCheckBox.Size = new System.Drawing.Size(378, 108);
            this.DrawShapeCheckBox.TabIndex = 0;
            this.DrawShapeCheckBox.Text = "draw shape";
            this.DrawShapeCheckBox.UseVisualStyleBackColor = true;
            this.DrawShapeCheckBox.CheckedChanged += new System.EventHandler(this.DrawShapeCheckBox_CheckedChanged);
            // 
            // AnimationCheckBox
            // 
            this.AnimationCheckBox.AutoSize = true;
            this.AnimationCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationCheckBox.Location = new System.Drawing.Point(3, 117);
            this.AnimationCheckBox.Name = "AnimationCheckBox";
            this.AnimationCheckBox.Size = new System.Drawing.Size(378, 108);
            this.AnimationCheckBox.TabIndex = 1;
            this.AnimationCheckBox.Text = "animate sun";
            this.AnimationCheckBox.UseVisualStyleBackColor = true;
            this.AnimationCheckBox.CheckedChanged += new System.EventHandler(this.AnimationCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.ObjectColorButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.pictureBoxObjectColor, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 231);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(378, 108);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // ObjectColorButton
            // 
            this.ObjectColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectColorButton.Location = new System.Drawing.Point(3, 3);
            this.ObjectColorButton.Name = "ObjectColorButton";
            this.ObjectColorButton.Size = new System.Drawing.Size(372, 48);
            this.ObjectColorButton.TabIndex = 2;
            this.ObjectColorButton.Text = "pick color of object";
            this.ObjectColorButton.UseVisualStyleBackColor = true;
            this.ObjectColorButton.Click += new System.EventHandler(this.ObjectColorButton_Click);
            // 
            // pictureBoxObjectColor
            // 
            this.pictureBoxObjectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxObjectColor.Location = new System.Drawing.Point(3, 57);
            this.pictureBoxObjectColor.Name = "pictureBoxObjectColor";
            this.pictureBoxObjectColor.Size = new System.Drawing.Size(372, 48);
            this.pictureBoxObjectColor.TabIndex = 3;
            this.pictureBoxObjectColor.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.LightColorButton, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.pictureBoxLightColor, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 345);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(378, 108);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // LightColorButton
            // 
            this.LightColorButton.Location = new System.Drawing.Point(3, 3);
            this.LightColorButton.Name = "LightColorButton";
            this.LightColorButton.Size = new System.Drawing.Size(372, 46);
            this.LightColorButton.TabIndex = 3;
            this.LightColorButton.Text = "pick color of light";
            this.LightColorButton.UseVisualStyleBackColor = true;
            this.LightColorButton.Click += new System.EventHandler(this.LightColorButton_Click);
            // 
            // pictureBoxLightColor
            // 
            this.pictureBoxLightColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLightColor.Location = new System.Drawing.Point(3, 57);
            this.pictureBoxLightColor.Name = "pictureBoxLightColor";
            this.pictureBoxLightColor.Size = new System.Drawing.Size(372, 48);
            this.pictureBoxLightColor.TabIndex = 4;
            this.pictureBoxLightColor.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.InterpolateVectors, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.InterpolateColors, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(393, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(385, 455);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // InterpolateVectors
            // 
            this.InterpolateVectors.AutoSize = true;
            this.InterpolateVectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterpolateVectors.Location = new System.Drawing.Point(3, 230);
            this.InterpolateVectors.Name = "InterpolateVectors";
            this.InterpolateVectors.Size = new System.Drawing.Size(379, 222);
            this.InterpolateVectors.TabIndex = 4;
            this.InterpolateVectors.Text = "interpolate vectors";
            this.InterpolateVectors.UseVisualStyleBackColor = true;
            this.InterpolateVectors.Click += new System.EventHandler(this.InterpolateVectors_Click);
            // 
            // InterpolateColors
            // 
            this.InterpolateColors.AutoSize = true;
            this.InterpolateColors.Checked = true;
            this.InterpolateColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterpolateColors.Location = new System.Drawing.Point(3, 3);
            this.InterpolateColors.Name = "InterpolateColors";
            this.InterpolateColors.Size = new System.Drawing.Size(379, 221);
            this.InterpolateColors.TabIndex = 3;
            this.InterpolateColors.TabStop = true;
            this.InterpolateColors.Text = "interpolate colors";
            this.InterpolateColors.UseVisualStyleBackColor = true;
            this.InterpolateColors.Click += new System.EventHandler(this.InterpolateColors_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.FillColor, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.FillTexture, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(393, 464);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(385, 456);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // FillColor
            // 
            this.FillColor.AutoSize = true;
            this.FillColor.Checked = true;
            this.FillColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillColor.Location = new System.Drawing.Point(3, 3);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(379, 222);
            this.FillColor.TabIndex = 0;
            this.FillColor.TabStop = true;
            this.FillColor.Text = "fill with color";
            this.FillColor.UseVisualStyleBackColor = true;
            this.FillColor.Click += new System.EventHandler(this.FillColor_Click);
            // 
            // FillTexture
            // 
            this.FillTexture.AutoSize = true;
            this.FillTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillTexture.Location = new System.Drawing.Point(3, 231);
            this.FillTexture.Name = "FillTexture";
            this.FillTexture.Size = new System.Drawing.Size(379, 222);
            this.FillTexture.TabIndex = 1;
            this.FillTexture.Text = "fill with texture";
            this.FillTexture.UseVisualStyleBackColor = true;
            this.FillTexture.Click += new System.EventHandler(this.FillTexture_Click);
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TrackBar z_slider;
        private System.Windows.Forms.TrackBar m_slider;
        private System.Windows.Forms.TrackBar ks_slider;
        private System.Windows.Forms.TrackBar kd_slider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox DrawShapeCheckBox;
        private System.Windows.Forms.CheckBox AnimationCheckBox;
        private System.Windows.Forms.Button ObjectColorButton;
        private System.Windows.Forms.Button LightColorButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pictureBoxObjectColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox pictureBoxLightColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RadioButton InterpolateVectors;
        private System.Windows.Forms.RadioButton InterpolateColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.RadioButton FillColor;
        private System.Windows.Forms.RadioButton FillTexture;
    }
}

