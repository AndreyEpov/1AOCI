﻿namespace _1Laba
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.button5 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.RGBList = new System.Windows.Forms.CheckedListBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.LR_1 = new System.Windows.Forms.ListBox();
            this.LR_2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbForScale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LR_3 = new System.Windows.Forms.ListBox();
            this.Accept_but = new System.Windows.Forms.Button();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbForComma = new System.Windows.Forms.TextBox();
            this.labelComma = new System.Windows.Forms.Label();
            this.labelComma1 = new System.Windows.Forms.Label();
            this.tbYcomma = new System.Windows.Forms.TextBox();
            this.but_quarter1 = new System.Windows.Forms.Button();
            this.but_quarter2 = new System.Windows.Forms.Button();
            this.but_quarter3 = new System.Windows.Forms.Button();
            this.but_quarter4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.LR_4 = new System.Windows.Forms.ListBox();
            this.LR_5 = new System.Windows.Forms.ListBox();
            this.LR_6 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.LR_7 = new System.Windows.Forms.ListBox();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.butTri = new System.Windows.Forms.Button();
            this.butRectangle = new System.Windows.Forms.Button();
            this.butCirkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(640, 480);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "LoadPic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(707, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(640, 480);
            this.imageBox2.TabIndex = 4;
            this.imageBox2.TabStop = false;
            this.imageBox2.Click += new System.EventHandler(this.imageBox2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(658, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 43);
            this.button3.TabIndex = 6;
            this.button3.Text = "Video";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(707, 495);
            this.hScrollBar1.Maximum = 250;
            this.hScrollBar1.Minimum = -250;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(640, 17);
            this.hScrollBar1.TabIndex = 8;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1350, 12);
            this.vScrollBar1.Maximum = 255;
            this.vScrollBar1.Minimum = -255;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 480);
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(658, 106);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 44);
            this.button5.TabIndex = 10;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(707, 515);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(159, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(872, 515);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Minimum = 50;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(148, 45);
            this.trackBar2.TabIndex = 12;
            this.trackBar2.Value = 50;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(1201, 515);
            this.trackBar3.Maximum = 150;
            this.trackBar3.Minimum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(146, 45);
            this.trackBar3.TabIndex = 13;
            this.trackBar3.Value = 150;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(1037, 515);
            this.trackBar4.Maximum = 200;
            this.trackBar4.Minimum = 150;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(158, 45);
            this.trackBar4.TabIndex = 14;
            this.trackBar4.Value = 200;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // RGBList
            // 
            this.RGBList.FormattingEnabled = true;
            this.RGBList.Items.AddRange(new object[] {
            "Blue",
            "Green",
            "Red"});
            this.RGBList.Location = new System.Drawing.Point(656, 156);
            this.RGBList.Name = "RGBList";
            this.RGBList.Size = new System.Drawing.Size(52, 49);
            this.RGBList.TabIndex = 15;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(597, 515);
            this.trackBar5.Maximum = 20;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(104, 45);
            this.trackBar5.TabIndex = 21;
            this.trackBar5.Value = 10;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(707, 543);
            this.trackBar6.Maximum = 255;
            this.trackBar6.Minimum = -255;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(640, 45);
            this.trackBar6.SmallChange = 5;
            this.trackBar6.TabIndex = 22;
            this.trackBar6.TickFrequency = 10;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(487, 511);
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(104, 45);
            this.trackBar7.TabIndex = 23;
            this.trackBar7.Value = 5;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(416, 511);
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(104, 45);
            this.trackBar8.TabIndex = 24;
            this.trackBar8.Value = 5;
            this.trackBar8.Scroll += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // trackBar9
            // 
            this.trackBar9.Location = new System.Drawing.Point(1011, 677);
            this.trackBar9.Maximum = 255;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(336, 45);
            this.trackBar9.TabIndex = 36;
            this.trackBar9.Value = 126;
            this.trackBar9.Scroll += new System.EventHandler(this.trackBar9_Scroll);
            // 
            // trackBar10
            // 
            this.trackBar10.Location = new System.Drawing.Point(365, 611);
            this.trackBar10.Maximum = 100;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(336, 45);
            this.trackBar10.TabIndex = 37;
            this.trackBar10.Value = 100;
            this.trackBar10.Scroll += new System.EventHandler(this.trackBar10_Scroll);
            // 
            // trackBar11
            // 
            this.trackBar11.LargeChange = 1;
            this.trackBar11.Location = new System.Drawing.Point(448, 543);
            this.trackBar11.Maximum = 2;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(143, 45);
            this.trackBar11.TabIndex = 39;
            this.trackBar11.Scroll += new System.EventHandler(this.trackBar11_Scroll);
            // 
            // trackBar12
            // 
            this.trackBar12.Location = new System.Drawing.Point(707, 632);
            this.trackBar12.Maximum = 255;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(640, 45);
            this.trackBar12.SmallChange = 5;
            this.trackBar12.TabIndex = 40;
            this.trackBar12.TickFrequency = 10;
            this.trackBar12.Scroll += new System.EventHandler(this.trackBar12_Scroll);
            // 
            // LR_1
            // 
            this.LR_1.FormattingEnabled = true;
            this.LR_1.Items.AddRange(new object[] {
            "Canny",
            "Cell_Shading",
            "Video"});
            this.LR_1.Location = new System.Drawing.Point(15, 511);
            this.LR_1.Name = "LR_1";
            this.LR_1.Size = new System.Drawing.Size(86, 186);
            this.LR_1.TabIndex = 43;
            this.LR_1.SelectedIndexChanged += new System.EventHandler(this.LR_1_SelectedIndexChanged);
            // 
            // LR_2
            // 
            this.LR_2.DisplayMember = "1";
            this.LR_2.FormattingEnabled = true;
            this.LR_2.Items.AddRange(new object[] {
            "RGB",
            "Make_Gray",
            "Sepia",
            "Brightness||Contrast",
            "Logical_Addition",
            "Logical_Expect",
            "Logical_Intersect",
            "HSV",
            "Median_Blur",
            "Matrix_Sharp",
            "Matrix_Embos",
            "Matrix_Edges",
            "Water_Filter",
            "Cartoon_Filter"});
            this.LR_2.Location = new System.Drawing.Point(116, 511);
            this.LR_2.Name = "LR_2";
            this.LR_2.Size = new System.Drawing.Size(120, 186);
            this.LR_2.TabIndex = 44;
            this.LR_2.ValueMember = "1";
            this.LR_2.SelectedIndexChanged += new System.EventHandler(this.LR_2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Лабораторная 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Лабораторная 2";
            // 
            // tbForScale
            // 
            this.tbForScale.Location = new System.Drawing.Point(637, 645);
            this.tbForScale.Name = "tbForScale";
            this.tbForScale.Size = new System.Drawing.Size(36, 20);
            this.tbForScale.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Лабораторная 3";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // LR_3
            // 
            this.LR_3.FormattingEnabled = true;
            this.LR_3.Items.AddRange(new object[] {
            "Scale",
            "BiScale",
            "Shift",
            "Rotate",
            "Homography",
            "Flip"});
            this.LR_3.Location = new System.Drawing.Point(256, 511);
            this.LR_3.Name = "LR_3";
            this.LR_3.Size = new System.Drawing.Size(86, 186);
            this.LR_3.TabIndex = 49;
            this.LR_3.SelectedIndexChanged += new System.EventHandler(this.LR_3_SelectedIndexChanged);
            // 
            // Accept_but
            // 
            this.Accept_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.Accept_but.Location = new System.Drawing.Point(570, 495);
            this.Accept_but.Name = "Accept_but";
            this.Accept_but.Size = new System.Drawing.Size(200, 150);
            this.Accept_but.TabIndex = 50;
            this.Accept_but.Text = "Accept";
            this.Accept_but.UseVisualStyleBackColor = true;
            this.Accept_but.Visible = false;
            this.Accept_but.Click += new System.EventHandler(this.Accept_but_Click);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(637, 677);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(36, 20);
            this.tbY.TabIndex = 51;
            // 
            // tbForComma
            // 
            this.tbForComma.Location = new System.Drawing.Point(694, 643);
            this.tbForComma.Name = "tbForComma";
            this.tbForComma.Size = new System.Drawing.Size(36, 20);
            this.tbForComma.TabIndex = 52;
            this.tbForComma.Text = "0";
            // 
            // labelComma
            // 
            this.labelComma.AutoSize = true;
            this.labelComma.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComma.Location = new System.Drawing.Point(679, 643);
            this.labelComma.Name = "labelComma";
            this.labelComma.Size = new System.Drawing.Size(13, 20);
            this.labelComma.TabIndex = 53;
            this.labelComma.Text = ",";
            // 
            // labelComma1
            // 
            this.labelComma1.AutoSize = true;
            this.labelComma1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComma1.Location = new System.Drawing.Point(679, 677);
            this.labelComma1.Name = "labelComma1";
            this.labelComma1.Size = new System.Drawing.Size(13, 20);
            this.labelComma1.TabIndex = 54;
            this.labelComma1.Text = ",";
            // 
            // tbYcomma
            // 
            this.tbYcomma.Location = new System.Drawing.Point(694, 677);
            this.tbYcomma.Name = "tbYcomma";
            this.tbYcomma.Size = new System.Drawing.Size(36, 20);
            this.tbYcomma.TabIndex = 55;
            this.tbYcomma.Text = "0";
            // 
            // but_quarter1
            // 
            this.but_quarter1.Location = new System.Drawing.Point(811, 595);
            this.but_quarter1.Name = "but_quarter1";
            this.but_quarter1.Size = new System.Drawing.Size(34, 31);
            this.but_quarter1.TabIndex = 56;
            this.but_quarter1.Text = "1";
            this.but_quarter1.UseVisualStyleBackColor = true;
            this.but_quarter1.Click += new System.EventHandler(this.but_quarter1_Click);
            // 
            // but_quarter2
            // 
            this.but_quarter2.Location = new System.Drawing.Point(851, 594);
            this.but_quarter2.Name = "but_quarter2";
            this.but_quarter2.Size = new System.Drawing.Size(34, 31);
            this.but_quarter2.TabIndex = 57;
            this.but_quarter2.Text = "2";
            this.but_quarter2.UseVisualStyleBackColor = true;
            this.but_quarter2.Click += new System.EventHandler(this.but_quarter2_Click);
            // 
            // but_quarter3
            // 
            this.but_quarter3.Location = new System.Drawing.Point(891, 594);
            this.but_quarter3.Name = "but_quarter3";
            this.but_quarter3.Size = new System.Drawing.Size(34, 31);
            this.but_quarter3.TabIndex = 58;
            this.but_quarter3.Text = "3";
            this.but_quarter3.UseVisualStyleBackColor = true;
            this.but_quarter3.Click += new System.EventHandler(this.but_quarter3_Click);
            // 
            // but_quarter4
            // 
            this.but_quarter4.Location = new System.Drawing.Point(931, 594);
            this.but_quarter4.Name = "but_quarter4";
            this.but_quarter4.Size = new System.Drawing.Size(34, 31);
            this.but_quarter4.TabIndex = 59;
            this.but_quarter4.Text = "4";
            this.but_quarter4.UseVisualStyleBackColor = true;
            this.but_quarter4.Click += new System.EventHandler(this.but_quarter4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 594);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Лабораторная 4";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 607);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Лабораторная 5";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(348, 515);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 17);
            this.radioButton1.TabIndex = 62;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1-3 ЛР";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(348, 538);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 63;
            this.radioButton2.Text = "4-6 ЛР";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 620);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Лабораторная 6";
            // 
            // LR_4
            // 
            this.LR_4.FormattingEnabled = true;
            this.LR_4.Items.AddRange(new object[] {
            "Pre-processing ",
            "Search approximated contours",
            "Search for primitives"});
            this.LR_4.Location = new System.Drawing.Point(15, 528);
            this.LR_4.Name = "LR_4";
            this.LR_4.Size = new System.Drawing.Size(86, 186);
            this.LR_4.TabIndex = 65;
            this.LR_4.SelectedIndexChanged += new System.EventHandler(this.LR_4_SelectedIndexChanged);
            // 
            // LR_5
            // 
            this.LR_5.FormattingEnabled = true;
            this.LR_5.Items.AddRange(new object[] {
            "Canny",
            "Cell_Shading",
            "Video"});
            this.LR_5.Location = new System.Drawing.Point(116, 528);
            this.LR_5.Name = "LR_5";
            this.LR_5.Size = new System.Drawing.Size(120, 186);
            this.LR_5.TabIndex = 66;
            // 
            // LR_6
            // 
            this.LR_6.FormattingEnabled = true;
            this.LR_6.Items.AddRange(new object[] {
            "Canny",
            "Cell_Shading",
            "Video"});
            this.LR_6.Location = new System.Drawing.Point(256, 528);
            this.LR_6.Name = "LR_6";
            this.LR_6.Size = new System.Drawing.Size(86, 186);
            this.LR_6.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 632);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Лабораторная 7";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(348, 562);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 69;
            this.radioButton3.Text = "7 ЛР";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // LR_7
            // 
            this.LR_7.FormattingEnabled = true;
            this.LR_7.Items.AddRange(new object[] {
            "Canny",
            "Cell_Shading",
            "Video"});
            this.LR_7.Location = new System.Drawing.Point(15, 543);
            this.LR_7.Name = "LR_7";
            this.LR_7.Size = new System.Drawing.Size(327, 186);
            this.LR_7.TabIndex = 70;
            // 
            // trackBar13
            // 
            this.trackBar13.Location = new System.Drawing.Point(801, 669);
            this.trackBar13.Minimum = 1;
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(104, 45);
            this.trackBar13.TabIndex = 71;
            this.trackBar13.Value = 5;
            this.trackBar13.Scroll += new System.EventHandler(this.trackBar13_Scroll);
            // 
            // butTri
            // 
            this.butTri.Location = new System.Drawing.Point(570, 641);
            this.butTri.Name = "butTri";
            this.butTri.Size = new System.Drawing.Size(75, 23);
            this.butTri.TabIndex = 72;
            this.butTri.Text = "Triangle";
            this.butTri.UseVisualStyleBackColor = true;
            this.butTri.Click += new System.EventHandler(this.butTri_Click);
            // 
            // butRectangle
            // 
            this.butRectangle.Location = new System.Drawing.Point(570, 669);
            this.butRectangle.Name = "butRectangle";
            this.butRectangle.Size = new System.Drawing.Size(75, 23);
            this.butRectangle.TabIndex = 73;
            this.butRectangle.Text = "Rectangle";
            this.butRectangle.UseVisualStyleBackColor = true;
            this.butRectangle.Click += new System.EventHandler(this.butRectangle_Click);
            // 
            // butCirkle
            // 
            this.butCirkle.Location = new System.Drawing.Point(570, 698);
            this.butCirkle.Name = "butCirkle";
            this.butCirkle.Size = new System.Drawing.Size(75, 23);
            this.butCirkle.TabIndex = 74;
            this.butCirkle.Text = "Cirkle";
            this.butCirkle.UseVisualStyleBackColor = true;
            this.butCirkle.Click += new System.EventHandler(this.butCirkle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 726);
            this.Controls.Add(this.butCirkle);
            this.Controls.Add(this.butRectangle);
            this.Controls.Add(this.butTri);
            this.Controls.Add(this.trackBar13);
            this.Controls.Add(this.LR_7);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LR_6);
            this.Controls.Add(this.LR_5);
            this.Controls.Add(this.LR_4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.but_quarter4);
            this.Controls.Add(this.but_quarter3);
            this.Controls.Add(this.but_quarter2);
            this.Controls.Add(this.but_quarter1);
            this.Controls.Add(this.tbYcomma);
            this.Controls.Add(this.labelComma1);
            this.Controls.Add(this.labelComma);
            this.Controls.Add(this.tbForComma);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.Accept_but);
            this.Controls.Add(this.LR_3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbForScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LR_2);
            this.Controls.Add(this.LR_1);
            this.Controls.Add(this.trackBar12);
            this.Controls.Add(this.trackBar11);
            this.Controls.Add(this.trackBar10);
            this.Controls.Add(this.trackBar9);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.RGBList);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.CheckedListBox RGBList;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.ListBox LR_1;
        private System.Windows.Forms.ListBox LR_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbForScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LR_3;
        private System.Windows.Forms.Button Accept_but;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbForComma;
        private System.Windows.Forms.Label labelComma;
        private System.Windows.Forms.Label labelComma1;
        private System.Windows.Forms.TextBox tbYcomma;
        private System.Windows.Forms.Button but_quarter1;
        private System.Windows.Forms.Button but_quarter2;
        private System.Windows.Forms.Button but_quarter3;
        private System.Windows.Forms.Button but_quarter4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox LR_4;
        private System.Windows.Forms.ListBox LR_5;
        private System.Windows.Forms.ListBox LR_6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ListBox LR_7;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.Button butTri;
        private System.Windows.Forms.Button butRectangle;
        private System.Windows.Forms.Button butCirkle;
    }
}

