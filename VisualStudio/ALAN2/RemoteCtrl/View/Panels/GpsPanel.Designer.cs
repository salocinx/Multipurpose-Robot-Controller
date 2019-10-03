namespace RemoteCtrl {
    partial class GpsPanel {
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
            this.mapGps = new GMap.NET.WindowsForms.GMapControl();
            this.txtSatellites = new System.Windows.Forms.TextBox();
            this.lblSatellites = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.boxAutoZoom = new System.Windows.Forms.CheckBox();
            this.boxSatelliteView = new System.Windows.Forms.CheckBox();
            this.boxAutoPosition = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mapGps
            // 
            this.mapGps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapGps.Bearing = 0F;
            this.mapGps.CanDragMap = true;
            this.mapGps.EmptyTileColor = System.Drawing.Color.SteelBlue;
            this.mapGps.GrayScaleMode = false;
            this.mapGps.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapGps.LevelsKeepInMemmory = 5;
            this.mapGps.Location = new System.Drawing.Point(3, 3);
            this.mapGps.MarkersEnabled = true;
            this.mapGps.MaxZoom = 18;
            this.mapGps.MinZoom = 0;
            this.mapGps.MouseWheelZoomEnabled = true;
            this.mapGps.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapGps.Name = "mapGps";
            this.mapGps.NegativeMode = false;
            this.mapGps.PolygonsEnabled = false;
            this.mapGps.RetryLoadTile = 0;
            this.mapGps.RoutesEnabled = false;
            this.mapGps.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapGps.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapGps.ShowTileGridLines = false;
            this.mapGps.Size = new System.Drawing.Size(840, 443);
            this.mapGps.TabIndex = 0;
            this.mapGps.Zoom = 14D;
            // 
            // txtSatellites
            // 
            this.txtSatellites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSatellites.Enabled = false;
            this.txtSatellites.Location = new System.Drawing.Point(60, 452);
            this.txtSatellites.Name = "txtSatellites";
            this.txtSatellites.Size = new System.Drawing.Size(40, 20);
            this.txtSatellites.TabIndex = 44;
            this.txtSatellites.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSatellites
            // 
            this.lblSatellites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSatellites.AutoSize = true;
            this.lblSatellites.Location = new System.Drawing.Point(6, 455);
            this.lblSatellites.Name = "lblSatellites";
            this.lblSatellites.Size = new System.Drawing.Size(49, 13);
            this.lblSatellites.TabIndex = 43;
            this.lblSatellites.Text = "Satellites";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLatitude.Enabled = false;
            this.txtLatitude.Location = new System.Drawing.Point(183, 452);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 20);
            this.txtLatitude.TabIndex = 46;
            this.txtLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLatitude
            // 
            this.lblLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(122, 455);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(45, 13);
            this.lblLatitude.TabIndex = 45;
            this.lblLatitude.Text = "Latitude";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLongitude.Enabled = false;
            this.txtLongitude.Location = new System.Drawing.Point(183, 478);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 20);
            this.txtLongitude.TabIndex = 48;
            this.txtLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLongitude
            // 
            this.lblLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(122, 481);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(54, 13);
            this.lblLongitude.TabIndex = 47;
            this.lblLongitude.Text = "Longitude";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSpeed.Enabled = false;
            this.txtSpeed.Location = new System.Drawing.Point(364, 478);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(71, 20);
            this.txtSpeed.TabIndex = 52;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(316, 481);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 51;
            this.lblSpeed.Text = "Speed";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAltitude.Enabled = false;
            this.txtAltitude.Location = new System.Drawing.Point(364, 452);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Size = new System.Drawing.Size(71, 20);
            this.txtAltitude.TabIndex = 50;
            this.txtAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAltitude
            // 
            this.lblAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(316, 455);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(42, 13);
            this.lblAltitude.TabIndex = 49;
            this.lblAltitude.Text = "Altitude";
            // 
            // boxAutoZoom
            // 
            this.boxAutoZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxAutoZoom.AutoSize = true;
            this.boxAutoZoom.Checked = true;
            this.boxAutoZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoZoom.Location = new System.Drawing.Point(591, 454);
            this.boxAutoZoom.Name = "boxAutoZoom";
            this.boxAutoZoom.Size = new System.Drawing.Size(92, 17);
            this.boxAutoZoom.TabIndex = 53;
            this.boxAutoZoom.Text = "Auto Zooming";
            this.boxAutoZoom.UseVisualStyleBackColor = true;
            // 
            // boxSatelliteView
            // 
            this.boxSatelliteView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxSatelliteView.AutoSize = true;
            this.boxSatelliteView.Checked = true;
            this.boxSatelliteView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxSatelliteView.Location = new System.Drawing.Point(478, 454);
            this.boxSatelliteView.Name = "boxSatelliteView";
            this.boxSatelliteView.Size = new System.Drawing.Size(89, 17);
            this.boxSatelliteView.TabIndex = 54;
            this.boxSatelliteView.Text = "Satellite View";
            this.boxSatelliteView.UseVisualStyleBackColor = true;
            this.boxSatelliteView.CheckedChanged += new System.EventHandler(this.boxSatelliteView_CheckedChanged);
            // 
            // boxAutoPosition
            // 
            this.boxAutoPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxAutoPosition.AutoSize = true;
            this.boxAutoPosition.Checked = true;
            this.boxAutoPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoPosition.Location = new System.Drawing.Point(591, 480);
            this.boxAutoPosition.Name = "boxAutoPosition";
            this.boxAutoPosition.Size = new System.Drawing.Size(102, 17);
            this.boxAutoPosition.TabIndex = 55;
            this.boxAutoPosition.Text = "Auto Positioning";
            this.boxAutoPosition.UseVisualStyleBackColor = true;
            // 
            // GpsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxAutoPosition);
            this.Controls.Add(this.boxSatelliteView);
            this.Controls.Add(this.boxAutoZoom);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.txtAltitude);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.txtSatellites);
            this.Controls.Add(this.lblSatellites);
            this.Controls.Add(this.mapGps);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "GpsPanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapGps;
        private System.Windows.Forms.TextBox txtSatellites;
        private System.Windows.Forms.Label lblSatellites;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.CheckBox boxAutoZoom;
        private System.Windows.Forms.CheckBox boxSatelliteView;
        private System.Windows.Forms.CheckBox boxAutoPosition;
    }
}
