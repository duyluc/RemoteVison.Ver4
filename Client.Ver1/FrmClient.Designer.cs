namespace Client.Ver1
{
    partial class FrmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabcontrol1 = new System.Windows.Forms.TabControl();
            this.pageHome = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.InputTerminalTable = new InOutTerminalCollectionTable.InOutTerminalCollectionTableV1();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCapture = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbIP = new System.Windows.Forms.Label();
            this.tbxIPAddress = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TaktTable = new TaktTimeTable.TaktTimeTableV1();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CameraDisplay = new System.Windows.Forms.PictureBox();
            this.pageCamera = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sliderExposure = new PylonControl.FloatSliderUserControl();
            this.sliderHeight = new PylonControl.IntSliderUserControl();
            this.sliderWidth = new PylonControl.IntSliderUserControl();
            this.cbPixelFormat = new PylonControl.EnumerationComboBoxUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dvCameraList = new System.Windows.Forms.DataGridView();
            this.dvCameraList_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvCameraList_SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageTeaching = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ModelTable = new ModelTable.ModelTableV1();
            this.tabcontrol1.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDisplay)).BeginInit();
            this.pageCamera.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvCameraList)).BeginInit();
            this.pageTeaching.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcontrol1
            // 
            this.tabcontrol1.Controls.Add(this.pageHome);
            this.tabcontrol1.Controls.Add(this.pageTeaching);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.3247F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.6753F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1081, 630);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.InputTerminalTable, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(311, 624);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // InputTerminalTable
            // 
            this.InputTerminalTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTerminalTable.Location = new System.Drawing.Point(2, 55);
            this.InputTerminalTable.Margin = new System.Windows.Forms.Padding(2);
            this.InputTerminalTable.Name = "InputTerminalTable";
            this.InputTerminalTable.Size = new System.Drawing.Size(307, 212);
            this.InputTerminalTable.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnCapture);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.lbIP);
            this.panel4.Controls.Add(this.tbxIPAddress);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 47);
            this.panel4.TabIndex = 3;
            // 
            // btnCapture
            // 
            this.btnCapture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCapture.BackgroundImage")));
            this.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.btnCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Location = new System.Drawing.Point(257, 8);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(41, 28);
            this.btnCapture.TabIndex = 7;
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Location = new System.Drawing.Point(3, 14);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(24, 15);
            this.lbIP.TabIndex = 1;
            this.lbIP.Text = "IP:";
            // 
            // tbxIPAddress
            // 
            this.tbxIPAddress.Location = new System.Drawing.Point(33, 13);
            this.tbxIPAddress.Name = "tbxIPAddress";
            this.tbxIPAddress.Size = new System.Drawing.Size(184, 20);
            this.tbxIPAddress.TabIndex = 0;
            this.tbxIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIPAddress.Enter += new System.EventHandler(this.tbxIPAddress_Enter);
            this.tbxIPAddress.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbCameraStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(311, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbCameraStatus
            // 
            this.lbCameraStatus.Name = "lbCameraStatus";
            this.lbCameraStatus.Size = new System.Drawing.Size(52, 17);
            this.lbCameraStatus.Text = "OFFLINE";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.TaktTable);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 272);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(305, 325);
            this.panel6.TabIndex = 6;
            // 
            // TaktTable
            // 
            this.TaktTable.Location = new System.Drawing.Point(3, 3);
            this.TaktTable.Name = "TaktTable";
            this.TaktTable.Size = new System.Drawing.Size(295, 315);
            this.TaktTable.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.CameraDisplay);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(320, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(758, 624);
            this.panel5.TabIndex = 3;
            // 
            // CameraDisplay
            // 
            this.CameraDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CameraDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CameraDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraDisplay.Location = new System.Drawing.Point(0, 0);
            this.CameraDisplay.Name = "CameraDisplay";
            this.CameraDisplay.Size = new System.Drawing.Size(754, 620);
            this.CameraDisplay.TabIndex = 1;
            this.CameraDisplay.TabStop = false;
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.34921F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.65079F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1081, 630);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sliderExposure);
            this.panel1.Controls.Add(this.sliderHeight);
            this.panel1.Controls.Add(this.sliderWidth);
            this.panel1.Controls.Add(this.cbPixelFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 269);
            this.panel1.TabIndex = 1;
            // 
            // sliderExposure
            // 
            this.sliderExposure.DefaultName = "N/A";
            this.sliderExposure.Location = new System.Drawing.Point(20, 78);
            this.sliderExposure.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderExposure.Name = "sliderExposure";
            this.sliderExposure.Size = new System.Drawing.Size(245, 50);
            this.sliderExposure.TabIndex = 3;
            // 
            // sliderHeight
            // 
            this.sliderHeight.DefaultName = "N/A";
            this.sliderHeight.Location = new System.Drawing.Point(20, 210);
            this.sliderHeight.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderHeight.Name = "sliderHeight";
            this.sliderHeight.Size = new System.Drawing.Size(245, 50);
            this.sliderHeight.TabIndex = 2;
            // 
            // sliderWidth
            // 
            this.sliderWidth.DefaultName = "N/A";
            this.sliderWidth.Location = new System.Drawing.Point(20, 145);
            this.sliderWidth.MinimumSize = new System.Drawing.Size(245, 50);
            this.sliderWidth.Name = "sliderWidth";
            this.sliderWidth.Size = new System.Drawing.Size(245, 50);
            this.sliderWidth.TabIndex = 1;
            // 
            // cbPixelFormat
            // 
            this.cbPixelFormat.DefaultName = "N/A";
            this.cbPixelFormat.Location = new System.Drawing.Point(20, 1);
            this.cbPixelFormat.Name = "cbPixelFormat";
            this.cbPixelFormat.Size = new System.Drawing.Size(227, 57);
            this.cbPixelFormat.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(276, 3);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel2.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(802, 624);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dvCameraList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 349);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvCameraList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvCameraList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvCameraList.Location = new System.Drawing.Point(0, 0);
            this.dvCameraList.Name = "dvCameraList";
            this.dvCameraList.ReadOnly = true;
            this.dvCameraList.RowHeadersWidth = 20;
            this.dvCameraList.Size = new System.Drawing.Size(267, 349);
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
            // pageTeaching
            // 
            this.pageTeaching.Controls.Add(this.tableLayoutPanel4);
            this.pageTeaching.Location = new System.Drawing.Point(4, 22);
            this.pageTeaching.Name = "pageTeaching";
            this.pageTeaching.Padding = new System.Windows.Forms.Padding(3);
            this.pageTeaching.Size = new System.Drawing.Size(1087, 636);
            this.pageTeaching.TabIndex = 3;
            this.pageTeaching.Text = "TEACHING";
            this.pageTeaching.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.ModelTable, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1081, 630);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // ModelTable
            // 
            this.ModelTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModelTable.Location = new System.Drawing.Point(3, 3);
            this.ModelTable.Name = "ModelTable";
            this.tableLayoutPanel4.SetRowSpan(this.ModelTable, 2);
            this.ModelTable.Size = new System.Drawing.Size(293, 624);
            this.ModelTable.TabIndex = 0;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 662);
            this.Controls.Add(this.tabcontrol1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabcontrol1.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraDisplay)).EndInit();
            this.pageCamera.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvCameraList)).EndInit();
            this.pageTeaching.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dvCameraList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvCameraList_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvCameraList_SerialNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbCameraStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.TextBox tbxIPAddress;
        private System.Windows.Forms.Button button1;
        private InOutTerminalCollectionTable.InOutTerminalCollectionTableV1 InputTerminalTable;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox CameraDisplay;
        private TaktTimeTable.TaktTimeTableV1 TaktTable;
        private System.Windows.Forms.TabPage pageTeaching;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ModelTable.ModelTableV1 ModelTable;
    }
}

