namespace RemoteCtrl {
    partial class SystemPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grpNetwork = new System.Windows.Forms.GroupBox();
            this.txtWifiRxRate = new System.Windows.Forms.Label();
            this.txtWifiTxRate = new System.Windows.Forms.Label();
            this.txtWifiSsid = new System.Windows.Forms.Label();
            this.grpComponents = new System.Windows.Forms.GroupBox();
            this.treComponents = new System.Windows.Forms.TreeView();
            this.grpResources = new System.Windows.Forms.GroupBox();
            this.treResources = new System.Windows.Forms.TreeView();
            this.grpBattery = new System.Windows.Forms.GroupBox();
            this.pgsBatteryState = new System.Windows.Forms.ProgressBar();
            this.txtBatteryState = new System.Windows.Forms.Label();
            this.ctxComponents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogbook = new System.Windows.Forms.ToolStripMenuItem();
            this.imgBatteryState = new System.Windows.Forms.PictureBox();
            this.imgWiFi = new System.Windows.Forms.PictureBox();
            this.grpNetwork.SuspendLayout();
            this.grpComponents.SuspendLayout();
            this.grpResources.SuspendLayout();
            this.grpBattery.SuspendLayout();
            this.ctxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWiFi)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNetwork
            // 
            this.grpNetwork.Controls.Add(this.imgWiFi);
            this.grpNetwork.Controls.Add(this.txtWifiRxRate);
            this.grpNetwork.Controls.Add(this.txtWifiTxRate);
            this.grpNetwork.Controls.Add(this.txtWifiSsid);
            this.grpNetwork.Location = new System.Drawing.Point(10, 8);
            this.grpNetwork.Name = "grpNetwork";
            this.grpNetwork.Size = new System.Drawing.Size(200, 85);
            this.grpNetwork.TabIndex = 1;
            this.grpNetwork.TabStop = false;
            this.grpNetwork.Text = "Network";
            // 
            // txtWifiRxRate
            // 
            this.txtWifiRxRate.AutoSize = true;
            this.txtWifiRxRate.Location = new System.Drawing.Point(6, 60);
            this.txtWifiRxRate.Name = "txtWifiRxRate";
            this.txtWifiRxRate.Size = new System.Drawing.Size(88, 13);
            this.txtWifiRxRate.TabIndex = 2;
            this.txtWifiRxRate.Text = "RX-Rate: 0 mbps";
            // 
            // txtWifiTxRate
            // 
            this.txtWifiTxRate.AutoSize = true;
            this.txtWifiTxRate.Location = new System.Drawing.Point(6, 45);
            this.txtWifiTxRate.Name = "txtWifiTxRate";
            this.txtWifiTxRate.Size = new System.Drawing.Size(87, 13);
            this.txtWifiTxRate.TabIndex = 1;
            this.txtWifiTxRate.Text = "TX-Rate: 0 mbps";
            // 
            // txtWifiSsid
            // 
            this.txtWifiSsid.AutoSize = true;
            this.txtWifiSsid.Location = new System.Drawing.Point(6, 21);
            this.txtWifiSsid.Name = "txtWifiSsid";
            this.txtWifiSsid.Size = new System.Drawing.Size(55, 13);
            this.txtWifiSsid.TabIndex = 0;
            this.txtWifiSsid.Text = "SSID: n/a";
            // 
            // grpComponents
            // 
            this.grpComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComponents.Controls.Add(this.treComponents);
            this.grpComponents.Location = new System.Drawing.Point(432, 8);
            this.grpComponents.Name = "grpComponents";
            this.grpComponents.Size = new System.Drawing.Size(406, 486);
            this.grpComponents.TabIndex = 2;
            this.grpComponents.TabStop = false;
            this.grpComponents.Text = "Components";
            // 
            // treComponents
            // 
            this.treComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treComponents.Location = new System.Drawing.Point(9, 19);
            this.treComponents.Name = "treComponents";
            this.treComponents.Size = new System.Drawing.Size(387, 461);
            this.treComponents.TabIndex = 1;
            this.treComponents.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treComponents_NodeMouseDoubleClick);
            this.treComponents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treComponents_MouseClick);
            // 
            // grpResources
            // 
            this.grpResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpResources.Controls.Add(this.treResources);
            this.grpResources.Location = new System.Drawing.Point(10, 99);
            this.grpResources.Name = "grpResources";
            this.grpResources.Size = new System.Drawing.Size(406, 395);
            this.grpResources.TabIndex = 3;
            this.grpResources.TabStop = false;
            this.grpResources.Text = "Resources";
            // 
            // treResources
            // 
            this.treResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treResources.Location = new System.Drawing.Point(7, 20);
            this.treResources.Name = "treResources";
            this.treResources.Size = new System.Drawing.Size(393, 369);
            this.treResources.TabIndex = 0;
            // 
            // grpBattery
            // 
            this.grpBattery.Controls.Add(this.imgBatteryState);
            this.grpBattery.Controls.Add(this.pgsBatteryState);
            this.grpBattery.Controls.Add(this.txtBatteryState);
            this.grpBattery.Location = new System.Drawing.Point(216, 8);
            this.grpBattery.Name = "grpBattery";
            this.grpBattery.Size = new System.Drawing.Size(200, 85);
            this.grpBattery.TabIndex = 4;
            this.grpBattery.TabStop = false;
            this.grpBattery.Text = "Battery";
            // 
            // pgsBatteryState
            // 
            this.pgsBatteryState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsBatteryState.Location = new System.Drawing.Point(6, 50);
            this.pgsBatteryState.Name = "pgsBatteryState";
            this.pgsBatteryState.Size = new System.Drawing.Size(126, 23);
            this.pgsBatteryState.TabIndex = 1;
            // 
            // txtBatteryState
            // 
            this.txtBatteryState.AutoSize = true;
            this.txtBatteryState.Location = new System.Drawing.Point(6, 25);
            this.txtBatteryState.Name = "txtBatteryState";
            this.txtBatteryState.Size = new System.Drawing.Size(123, 13);
            this.txtBatteryState.TabIndex = 0;
            this.txtBatteryState.Text = "Current Voltage: 12.5 [V]";
            // 
            // ctxComponents
            // 
            this.ctxComponents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmConfigure,
            this.itmLogbook});
            this.ctxComponents.Name = "contextMenuStrip1";
            this.ctxComponents.Size = new System.Drawing.Size(128, 48);
            // 
            // itmConfigure
            // 
            this.itmConfigure.Enabled = false;
            this.itmConfigure.Image = global::RemoteCtrl.Properties.Resources.configure_18;
            this.itmConfigure.Name = "itmConfigure";
            this.itmConfigure.Size = new System.Drawing.Size(152, 22);
            this.itmConfigure.Text = "Configure";
            this.itmConfigure.Click += new System.EventHandler(this.itmConfigure_Click);
            // 
            // itmLogbook
            // 
            this.itmLogbook.Enabled = false;
            this.itmLogbook.Image = global::RemoteCtrl.Properties.Resources.chart_18;
            this.itmLogbook.Name = "itmLogbook";
            this.itmLogbook.Size = new System.Drawing.Size(152, 22);
            this.itmLogbook.Text = "Logbook";
            this.itmLogbook.Click += new System.EventHandler(this.itmLogbook_Click);
            // 
            // imgBatteryState
            // 
            this.imgBatteryState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBatteryState.ErrorImage = global::RemoteCtrl.Properties.Resources.battery_0;
            this.imgBatteryState.Image = global::RemoteCtrl.Properties.Resources.battery_3;
            this.imgBatteryState.InitialImage = global::RemoteCtrl.Properties.Resources.battery_3;
            this.imgBatteryState.Location = new System.Drawing.Point(146, 49);
            this.imgBatteryState.Name = "imgBatteryState";
            this.imgBatteryState.Size = new System.Drawing.Size(44, 24);
            this.imgBatteryState.TabIndex = 2;
            this.imgBatteryState.TabStop = false;
            // 
            // imgWiFi
            // 
            this.imgWiFi.ErrorImage = global::RemoteCtrl.Properties.Resources.WiFi_0;
            this.imgWiFi.Image = global::RemoteCtrl.Properties.Resources.WiFi_0;
            this.imgWiFi.InitialImage = global::RemoteCtrl.Properties.Resources.WiFi_0;
            this.imgWiFi.Location = new System.Drawing.Point(142, 49);
            this.imgWiFi.Name = "imgWiFi";
            this.imgWiFi.Size = new System.Drawing.Size(43, 24);
            this.imgWiFi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgWiFi.TabIndex = 1;
            this.imgWiFi.TabStop = false;
            // 
            // SystemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBattery);
            this.Controls.Add(this.grpResources);
            this.Controls.Add(this.grpComponents);
            this.Controls.Add(this.grpNetwork);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "SystemPanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.grpNetwork.ResumeLayout(false);
            this.grpNetwork.PerformLayout();
            this.grpComponents.ResumeLayout(false);
            this.grpResources.ResumeLayout(false);
            this.grpBattery.ResumeLayout(false);
            this.grpBattery.PerformLayout();
            this.ctxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBatteryState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWiFi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNetwork;
        private System.Windows.Forms.PictureBox imgWiFi;
        private System.Windows.Forms.Label txtWifiRxRate;
        private System.Windows.Forms.Label txtWifiTxRate;
        private System.Windows.Forms.Label txtWifiSsid;
        private System.Windows.Forms.GroupBox grpComponents;
        private System.Windows.Forms.GroupBox grpResources;
        private System.Windows.Forms.TreeView treResources;
        private System.Windows.Forms.GroupBox grpBattery;
        private System.Windows.Forms.ProgressBar pgsBatteryState;
        private System.Windows.Forms.Label txtBatteryState;
        private System.Windows.Forms.PictureBox imgBatteryState;
        private System.Windows.Forms.TreeView treComponents;
        private System.Windows.Forms.ContextMenuStrip ctxComponents;
        private System.Windows.Forms.ToolStripMenuItem itmConfigure;
        private System.Windows.Forms.ToolStripMenuItem itmLogbook;
    }
}
