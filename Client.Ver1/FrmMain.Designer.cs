namespace Client.Ver1
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabcontrol1 = new System.Windows.Forms.TabControl();
            this.pageHome = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pageCamera = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCapture = new System.Windows.Forms.Button();
            this.sliderExposure = new PylonControl.FloatSliderUserControl();
            this.sliderHeight = new PylonControl.IntSliderUserControl();
            this.sliderWidth = new PylonControl.IntSliderUserControl();
            this.cbPixelFormat = new PylonControl.EnumerationComboBoxUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CameraDisplay = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dvCameraList = new System.Windows.Forms.DataGridView();
            this.dvCameraList_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvCameraList_SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabcontrol1.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pageCamera.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDisplay)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvCameraList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontrol1
            // 
            this.tabcontrol1.Controls.Add(this.pageHome);
            this.tabcontrol1.Controls.Add(this.pageCamera);
            this.tabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrol1.Location = new System.Drawing.Point(0, 0);
            this.tabcontrol1.Name = "tabcontrol1";
            this.tabcontrol1.SelectedIndex = 0;
            this.tabcontrol1.Size = new System.Drawing.Size(1095, 662);
            this.tabcontrol1.TabIndex = 0;
            // 
            // pageHome
            // 
            this.pageHome.Controls.Add(this.tableLayoutPanel1);
            this.pageHome.Location = new System.Drawing.Point(4, 22);
            this.pageHome.Name = "pageHome";
            this.pageHome.Padding = new System.Windows.Forms.Padding(3);
            this.pageHome.Size = new System.Drawing.Size(1087, 636);
            this.pageHome.TabIndex = 1;
            this.pageHome.Text = "HOME";
            this.pageHome.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1081, 630);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbCameraStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 608);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(540, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbCameraStatus
            // 
            this.lbCameraStatus.Name = "lbCameraStatus";
            this.lbCameraStatus.Size = new System.Drawing.Size(52, 17);
            this.lbCameraStatus.Text = "OFFLINE";
            // 
            // pageCamera
            // 
            this.pageCamera.Controls.Add(this.tableLayoutPanel2);
            this.pageCamera.Location = new System.Drawing.Point(4, 22);
            this.pageCamera.Name = "pageCamera";
            this.pageCamera.Padding = new System.Windows.Forms.Padding(3);
            this.pageCamera.Size = new System.Drawing.Size(1087, 636);
            this.pageCamera.TabIndex = 2;
            this.pageCamera.Text = "CAMERA";
            this.pageCamera.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 273F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1081, 630);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCapture);
            this.panel1.Controls.Add(this.sliderExposure);
            this.panel1.Controls.Add(this.sliderHeight);
            this.panel1.Controls.Add(this.sliderWidth);
            this.panel1.Controls.Add(this.cbPixelFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 309);
            this.panel1.TabIndex = 1;
            // 
            // btnCapture
            // 
            this.btnCapture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCapture.BackgroundImage")));
            this.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.btnCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Location = new System.Drawing.Point(3, 9);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(41, 28);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // sliderExposure
            // 
            this.sliderExposure.DefaultName = "N/A";
            this.sliderExposure.Location = new System.Drawing.Point(19, 120);
            this.sliderExposure.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderExposure.Name = "sliderExposure";
            this.sliderExposure.Size = new System.Drawing.Size(245, 50);
            this.sliderExposure.TabIndex = 3;
            // 
            // sliderHeight
            // 
            this.sliderHeight.DefaultName = "N/A";
            this.sliderHeight.Location = new System.Drawing.Point(19, 252);
            this.sliderHeight.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderHeight.Name = "sliderHeight";
            this.sliderHeight.Size = new System.Drawing.Size(245, 50);
            this.sliderHeight.TabIndex = 2;
            // 
            // sliderWidth
            // 
            this.sliderWidth.DefaultName = "N/A";
            this.sliderWidth.Location = new System.Drawing.Point(19, 187);
            this.sliderWidth.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderWidth.Name = "sliderWidth";
            this.sliderWidth.Size = new System.Drawing.Size(245, 50);
            this.sliderWidth.TabIndex = 1;
            // 
            // cbPixelFormat
            // 
            this.cbPixelFormat.DefaultName = "N/A";
            this.cbPixelFormat.Location = new System.Drawing.Point(19, 43);
            this.cbPixelFormat.Name = "cbPixelFormat";
            this.cbPixelFormat.Size = new System.Drawing.Size(227, 57);
            this.cbPixelFormat.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CameraDisplay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(276, 3);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel2.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(802, 624);
            this.panel2.TabIndex = 2;
            // 
            // CameraDisplay
            // 
            this.CameraDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CameraDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CameraDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraDisplay.Location = new System.Drawing.Point(0, 0);
            this.CameraDisplay.Name = "CameraDisplay";
            this.CameraDisplay.Size = new System.Drawing.Size(802, 624);
            this.CameraDisplay.TabIndex = 0;
            this.CameraDisplay.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dvCameraList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 309);
            this.panel3.TabIndex = 3;
            // 
            // dvCameraList
            // 
            this.dvCameraList.AllowUserToAddRows = false;
            this.dvCameraList.AllowUserToDeleteRows = false;
            this.dvCameraList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvCameraList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCameraList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvCameraList_Name,
            this.dvCameraList_SerialNumber});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvCameraList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dvCameraList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvCameraList.Location = new System.Drawing.Point(0, 0);
            this.dvCameraList.Name = "dvCameraList";
            this.dvCameraList.ReadOnly = true;
            this.dvCameraList.RowHeadersWidth = 20;
            this.dvCameraList.Size = new System.Drawing.Size(267, 309);
            this.dvCameraList.TabIndex = 0;
            this.dvCameraList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvCameraList_CellClick);
            // 
            // dvCameraList_Name
            // 
            this.dvCameraList_Name.HeaderText = "Name";
            this.dvCameraList_Name.MinimumWidth = 100;
            this.dvCameraList_Name.Name = "dvCameraList_Name";
            this.dvCameraList_Name.ReadOnly = true;
            // 
            // dvCameraList_SerialNumber
            // 
            this.dvCameraList_SerialNumber.HeaderText = "Serial Number";
            this.dvCameraList_SerialNumber.Name = "dvCameraList_SerialNumber";
            this.dvCameraList_SerialNumber.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 662);
            this.Controls.Add(this.tabcontrol1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabcontrol1.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pageCamera.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraDisplay)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvCameraList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrol1;
        private System.Windows.Forms.TabPage pageHome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage pageCamera;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private PylonControl.FloatSliderUserControl sliderExposure;
        private PylonControl.IntSliderUserControl sliderHeight;
        private PylonControl.IntSliderUserControl sliderWidth;
        private PylonControl.EnumerationComboBoxUserControl cbPixelFormat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dvCameraList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvCameraList_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvCameraList_SerialNumber;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbCameraStatus;
        private System.Windows.Forms.PictureBox CameraDisplay;
    }
}

