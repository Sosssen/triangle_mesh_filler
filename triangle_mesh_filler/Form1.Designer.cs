
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
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).BeginInit();
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
            this.z_slider.Scroll += new System.EventHandler(this.z_slider_Scroll);
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
            this.m_slider.Scroll += new System.EventHandler(this.m_slider_Scroll);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 929);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_slider)).EndInit();
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
    }
}

