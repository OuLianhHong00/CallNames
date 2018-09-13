namespace MvcThreeModel
{
    partial class Count
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.c_course = new System.Windows.Forms.ComboBox();
            this.l_course = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_course = new System.Windows.Forms.Button();
            this.b_return = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_chuqin = new System.Windows.Forms.Label();
            this.label_chidao = new System.Windows.Forms.Label();
            this.label_kuangke = new System.Windows.Forms.Label();
            this.label_qingjia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_course
            // 
            this.c_course.FormattingEnabled = true;
            this.c_course.Location = new System.Drawing.Point(80, 25);
            this.c_course.Margin = new System.Windows.Forms.Padding(2);
            this.c_course.Name = "c_course";
            this.c_course.Size = new System.Drawing.Size(143, 20);
            this.c_course.TabIndex = 21;
            // 
            // l_course
            // 
            this.l_course.AutoSize = true;
            this.l_course.BackColor = System.Drawing.Color.Transparent;
            this.l_course.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_course.Location = new System.Drawing.Point(26, 28);
            this.l_course.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_course.Name = "l_course";
            this.l_course.Size = new System.Drawing.Size(41, 12);
            this.l_course.TabIndex = 20;
            this.l_course.Text = "课程：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(527, 181);
            this.dataGridView1.TabIndex = 19;
            // 
            // button_course
            // 
            this.button_course.Location = new System.Drawing.Point(244, 23);
            this.button_course.Name = "button_course";
            this.button_course.Size = new System.Drawing.Size(75, 23);
            this.button_course.TabIndex = 24;
            this.button_course.Text = "查询";
            this.button_course.UseVisualStyleBackColor = true;
            this.button_course.Click += new System.EventHandler(this.button_course_Click);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(479, 22);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(75, 23);
            this.b_return.TabIndex = 22;
            this.b_return.Text = "返回";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(28, 262);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "出勤情况";
            dataPoint1.AxisLabel = "出勤";
            dataPoint1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            dataPoint1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.None;
            dataPoint1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopLeft;
            dataPoint1.BackSecondaryColor = System.Drawing.Color.Lime;
            dataPoint1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataPoint1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataPoint1.MarkerSize = 10;
            dataPoint2.AxisLabel = "旷课";
            dataPoint2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            dataPoint2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.None;
            dataPoint2.BackSecondaryColor = System.Drawing.Color.Red;
            dataPoint2.BorderColor = System.Drawing.Color.Red;
            dataPoint2.Color = System.Drawing.Color.Red;
            dataPoint3.AxisLabel = "迟到";
            dataPoint3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            dataPoint3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.None;
            dataPoint3.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataPoint3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataPoint3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataPoint4.AxisLabel = "请假";
            dataPoint4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            dataPoint4.BackSecondaryColor = System.Drawing.Color.Black;
            dataPoint4.Color = System.Drawing.Color.Black;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(527, 254);
            this.chart1.TabIndex = 26;
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // label_chuqin
            // 
            this.label_chuqin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_chuqin.AutoSize = true;
            this.label_chuqin.BackColor = System.Drawing.Color.Transparent;
            this.label_chuqin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_chuqin.Location = new System.Drawing.Point(27, 57);
            this.label_chuqin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_chuqin.Name = "label_chuqin";
            this.label_chuqin.Size = new System.Drawing.Size(71, 12);
            this.label_chuqin.TabIndex = 27;
            this.label_chuqin.Text = "出勤：0人次";
            // 
            // label_chidao
            // 
            this.label_chidao.AutoSize = true;
            this.label_chidao.BackColor = System.Drawing.Color.Transparent;
            this.label_chidao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_chidao.Location = new System.Drawing.Point(179, 57);
            this.label_chidao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_chidao.Name = "label_chidao";
            this.label_chidao.Size = new System.Drawing.Size(71, 12);
            this.label_chidao.TabIndex = 28;
            this.label_chidao.Text = "迟到：0人次";
            // 
            // label_kuangke
            // 
            this.label_kuangke.AutoSize = true;
            this.label_kuangke.BackColor = System.Drawing.Color.Transparent;
            this.label_kuangke.Location = new System.Drawing.Point(331, 57);
            this.label_kuangke.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_kuangke.Name = "label_kuangke";
            this.label_kuangke.Size = new System.Drawing.Size(71, 12);
            this.label_kuangke.TabIndex = 29;
            this.label_kuangke.Text = "旷课：0人次";
            // 
            // label_qingjia
            // 
            this.label_qingjia.AutoSize = true;
            this.label_qingjia.BackColor = System.Drawing.Color.Transparent;
            this.label_qingjia.Location = new System.Drawing.Point(483, 57);
            this.label_qingjia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_qingjia.Name = "label_qingjia";
            this.label_qingjia.Size = new System.Drawing.Size(71, 12);
            this.label_qingjia.TabIndex = 7;
            this.label_qingjia.Text = "请假：0人次";
            // 
            // Count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MvcThreeModel.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(597, 528);
            this.Controls.Add(this.label_qingjia);
            this.Controls.Add(this.label_kuangke);
            this.Controls.Add(this.label_chidao);
            this.Controls.Add(this.label_chuqin);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.b_return);
            this.Controls.Add(this.c_course);
            this.Controls.Add(this.l_course);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_course);
            this.Name = "Count";
            this.Text = "统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox c_course;
        private System.Windows.Forms.Label l_course;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_course;
        private System.Windows.Forms.Button b_return;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label_chuqin;
        private System.Windows.Forms.Label label_chidao;
        private System.Windows.Forms.Label label_kuangke;
        private System.Windows.Forms.Label label_qingjia;
    }
}