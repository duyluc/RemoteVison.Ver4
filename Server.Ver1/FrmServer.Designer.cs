namespace Server.Ver1
{
    partial class FrmServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageAuto = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pageTeaching = new System.Windows.Forms.TabPage();
            this.TeachingToolBlockControl = new VisionControl.ToolBlockSetting();
            this.pageSetting = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.lbIP = new System.Windows.Forms.Label();
            this.tbxIPAddress = new System.Windows.Forms.TextBox();
            this.IPAddressTable = new IpAddressTable.IpAddressTable();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.RecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.CogRecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tabControl1.SuspendLayout();
            this.pageAuto.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pageTeaching.SuspendLayout();
            this.pageSetting.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageAuto);
            this.tabControl1.Controls.Add(this.pageTeaching);
            this.tabControl1.Controls.Add(this.pageSetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 602);
            this.tabControl1.TabIndex = 0;
            // 
            // pageAuto
            // 
            this.pageAuto.Controls.Add(this.tableLayoutPanel1);
            this.pageAuto.Location = new System.Drawing.Point(4, 22);
            this.pageAuto.Name = "pageAuto";
            this.pageAuto.Padding = new System.Windows.Forms.Padding(3);
            this.pageAuto.Size = new System.Drawing.Size(1034, 576);
            this.pageAuto.TabIndex = 0;
            this.pageAuto.Text = "AUTO";
            this.pageAuto.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.070175F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.92982F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 570);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pageTeaching
            // 
            this.pageTeaching.Controls.Add(this.TeachingToolBlockControl);
            this.pageTeaching.Location = new System.Drawing.Point(4, 22);
            this.pageTeaching.Name = "pageTeaching";
            this.pageTeaching.Size = new System.Drawing.Size(1034, 576);
            this.pageTeaching.TabIndex = 2;
            this.pageTeaching.Text = "TEACHING";
            this.pageTeaching.UseVisualStyleBackColor = true;
            // 
            // TeachingToolBlockControl
            // 
            this.TeachingToolBlockControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TeachingToolBlockControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeachingToolBlockControl.Location = new System.Drawing.Point(0, 0);
            this.TeachingToolBlockControl.Name = "TeachingToolBlockControl";
            this.TeachingToolBlockControl.Size = new System.Drawing.Size(1034, 576);
            this.TeachingToolBlockControl.TabIndex = 0;
            this.TeachingToolBlockControl.ToolBlocks = null;
            // 
            // pageSetting
            // 
            this.pageSetting.Controls.Add(this.tableLayoutPanel2);
            this.pageSetting.Location = new System.Drawing.Point(4, 22);
            this.pageSetting.Name = "pageSetting";
            this.pageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.pageSetting.Size = new System.Drawing.Size(1034, 576);
            this.pageSetting.TabIndex = 1;
            this.pageSetting.Text = "SETTING";
            this.pageSetting.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IPAddressTable, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.35294F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.64706F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1028, 570);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenServer);
            this.panel1.Controls.Add(this.lbIP);
            this.panel1.Controls.Add(this.tbxIPAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 53);
            this.panel1.TabIndex = 1;
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenServer.BackgroundImage")));
            this.btnOpenServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenServer.FlatAppearance.BorderSize = 0;
            this.btnOpenServer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpenServer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpenServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenServer.Location = new System.Drawing.Point(227, 8);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(31, 23);
            this.btnOpenServer.TabIndex = 5;
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Location = new System.Drawing.Point(7, 10);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(24, 15);
            this.lbIP.TabIndex = 4;
            this.lbIP.Text = "IP:";
            // 
            // tbxIPAddress
            // 
            this.tbxIPAddress.Location = new System.Drawing.Point(37, 9);
            this.tbxIPAddress.Name = "tbxIPAddress";
            this.tbxIPAddress.Size = new System.Drawing.Size(184, 20);
            this.tbxIPAddress.TabIndex = 3;
            this.tbxIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIPAddress.Enter += new System.EventHandler(this.tbxIPAddress_Enter);
            this.tbxIPAddress.Leave += new System.EventHandler(this.tbxIPAddress_Leave);
            // 
            // IPAddressTable
            // 
            this.IPAddressTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IPAddressTable.DbProvider = null;
            this.IPAddressTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPAddressTable.Location = new System.Drawing.Point(3, 62);
            this.IPAddressTable.Name = "IPAddressTable";
            this.IPAddressTable.Size = new System.Drawing.Size(268, 505);
            this.IPAddressTable.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(339, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lbServerStatus
            // 
            this.lbServerStatus.Name = "lbServerStatus";
            this.lbServerStatus.Size = new System.Drawing.Size(55, 17);
            this.lbServerStatus.Text = "OFFLINE!";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 602);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.pageAuto.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pageTeaching.ResumeLayout(false);
            this.pageSetting.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.TextBox tbxIPAddress;
        private System.Windows.Forms.TabPage pageTeaching;
        private IpAddressTable.IpAddressTable IPAddressTable;
        private VisionControl.ToolBlockSetting TeachingToolBlockControl;
        private System.Windows.Forms.TabPage pageAuto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.CogRecordDisplay RecordDisplay;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbServerStatus;
        private Cognex.VisionPro.CogRecordDisplay CogRecordDisplay;
    }
}

