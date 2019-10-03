namespace RemoteCtrl {
    partial class CameraPanel {
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
            this.grpStreamPerformance = new System.Windows.Forms.GroupBox();
            this.pgsNetworkTraffic = new System.Windows.Forms.ProgressBar();
            this.txtNetworkTraffic = new System.Windows.Forms.Label();
            this.pgsCompressionRate = new System.Windows.Forms.ProgressBar();
            this.pgsFramerate = new System.Windows.Forms.ProgressBar();
            this.txtFramerate = new System.Windows.Forms.Label();
            this.txtCompressionTime = new System.Windows.Forms.Label();
            this.txtCompressionRate = new System.Windows.Forms.Label();
            this.pgsCompressionTime = new System.Windows.Forms.ProgressBar();
            this.grpStreamProperties = new System.Windows.Forms.GroupBox();
            this.txtResolution = new System.Windows.Forms.Label();
            this.txtColorDepth = new System.Windows.Forms.Label();
            this.txtImageSize = new System.Windows.Forms.Label();
            this.grpVideoControlPanel = new System.Windows.Forms.GroupBox();
            this.trkQuality = new System.Windows.Forms.TrackBar();
            this.boxCapturing = new System.Windows.Forms.CheckBox();
            this.boxSwapped = new System.Windows.Forms.CheckBox();
            this.boxStreaming = new System.Windows.Forms.CheckBox();
            this.boxColoured = new System.Windows.Forms.CheckBox();
            this.txtQuality = new System.Windows.Forms.Label();
            this.cbxResolutions = new System.Windows.Forms.ComboBox();
            this.grpNetworkImageStream = new System.Windows.Forms.GroupBox();
            this.imgNetworkStreamImage = new Emgu.CV.UI.ImageBox();
            this.grpStreamPerformance.SuspendLayout();
            this.grpStreamProperties.SuspendLayout();
            this.grpVideoControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).BeginInit();
            this.grpNetworkImageStream.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNetworkStreamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStreamPerformance
            // 
            this.grpStreamPerformance.Controls.Add(this.pgsNetworkTraffic);
            this.grpStreamPerformance.Controls.Add(this.txtNetworkTraffic);
            this.grpStreamPerformance.Controls.Add(this.pgsCompressionRate);
            this.grpStreamPerformance.Controls.Add(this.pgsFramerate);
            this.grpStreamPerformance.Controls.Add(this.txtFramerate);
            this.grpStreamPerformance.Controls.Add(this.txtCompressionTime);
            this.grpStreamPerformance.Controls.Add(this.txtCompressionRate);
            this.grpStreamPerformance.Controls.Add(this.pgsCompressionTime);
            this.grpStreamPerformance.Location = new System.Drawing.Point(8, 287);
            this.grpStreamPerformance.Name = "grpStreamPerformance";
            this.grpStreamPerformance.Size = new System.Drawing.Size(181, 210);
            this.grpStreamPerformance.TabIndex = 22;
            this.grpStreamPerformance.TabStop = false;
            this.grpStreamPerformance.Text = "Video Streaming Performance";
            // 
            // pgsNetworkTraffic
            // 
            this.pgsNetworkTraffic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsNetworkTraffic.Location = new System.Drawing.Point(9, 177);
            this.pgsNetworkTraffic.Name = "pgsNetworkTraffic";
            this.pgsNetworkTraffic.Size = new System.Drawing.Size(160, 20);
            this.pgsNetworkTraffic.TabIndex = 13;
            // 
            // txtNetworkTraffic
            // 
            this.txtNetworkTraffic.AutoSize = true;
            this.txtNetworkTraffic.Location = new System.Drawing.Point(6, 161);
            this.txtNetworkTraffic.Name = "txtNetworkTraffic";
            this.txtNetworkTraffic.Size = new System.Drawing.Size(120, 13);
            this.txtNetworkTraffic.TabIndex = 14;
            this.txtNetworkTraffic.Text = "Network Traffic: 0 mbps";
            // 
            // pgsCompressionRate
            // 
            this.pgsCompressionRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsCompressionRate.Location = new System.Drawing.Point(9, 130);
            this.pgsCompressionRate.Name = "pgsCompressionRate";
            this.pgsCompressionRate.Size = new System.Drawing.Size(160, 20);
            this.pgsCompressionRate.TabIndex = 7;
            // 
            // pgsFramerate
            // 
            this.pgsFramerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsFramerate.Location = new System.Drawing.Point(9, 40);
            this.pgsFramerate.Maximum = 60;
            this.pgsFramerate.Name = "pgsFramerate";
            this.pgsFramerate.Size = new System.Drawing.Size(160, 20);
            this.pgsFramerate.TabIndex = 8;
            // 
            // txtFramerate
            // 
            this.txtFramerate.AutoSize = true;
            this.txtFramerate.Location = new System.Drawing.Point(6, 24);
            this.txtFramerate.Name = "txtFramerate";
            this.txtFramerate.Size = new System.Drawing.Size(83, 13);
            this.txtFramerate.TabIndex = 9;
            this.txtFramerate.Text = "Framerate: 0 fps";
            // 
            // txtCompressionTime
            // 
            this.txtCompressionTime.AutoSize = true;
            this.txtCompressionTime.Location = new System.Drawing.Point(6, 68);
            this.txtCompressionTime.Name = "txtCompressionTime";
            this.txtCompressionTime.Size = new System.Drawing.Size(121, 13);
            this.txtCompressionTime.TabIndex = 12;
            this.txtCompressionTime.Text = "Compression Time: 0 ms";
            // 
            // txtCompressionRate
            // 
            this.txtCompressionRate.AutoSize = true;
            this.txtCompressionRate.Location = new System.Drawing.Point(6, 114);
            this.txtCompressionRate.Name = "txtCompressionRate";
            this.txtCompressionRate.Size = new System.Drawing.Size(118, 13);
            this.txtCompressionRate.TabIndex = 10;
            this.txtCompressionRate.Text = "Compression Ratio: 0 %";
            // 
            // pgsCompressionTime
            // 
            this.pgsCompressionTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsCompressionTime.Location = new System.Drawing.Point(9, 84);
            this.pgsCompressionTime.Maximum = 50;
            this.pgsCompressionTime.Name = "pgsCompressionTime";
            this.pgsCompressionTime.Size = new System.Drawing.Size(160, 20);
            this.pgsCompressionTime.TabIndex = 11;
            // 
            // grpStreamProperties
            // 
            this.grpStreamProperties.Controls.Add(this.txtResolution);
            this.grpStreamProperties.Controls.Add(this.txtColorDepth);
            this.grpStreamProperties.Controls.Add(this.txtImageSize);
            this.grpStreamProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStreamProperties.Location = new System.Drawing.Point(8, 8);
            this.grpStreamProperties.Name = "grpStreamProperties";
            this.grpStreamProperties.Size = new System.Drawing.Size(182, 79);
            this.grpStreamProperties.TabIndex = 21;
            this.grpStreamProperties.TabStop = false;
            this.grpStreamProperties.Text = "Video Streaming Properties";
            // 
            // txtResolution
            // 
            this.txtResolution.AutoSize = true;
            this.txtResolution.Location = new System.Drawing.Point(10, 22);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(80, 13);
            this.txtResolution.TabIndex = 13;
            this.txtResolution.Text = "Resolution: n/a";
            // 
            // txtColorDepth
            // 
            this.txtColorDepth.AutoSize = true;
            this.txtColorDepth.Location = new System.Drawing.Point(10, 38);
            this.txtColorDepth.Name = "txtColorDepth";
            this.txtColorDepth.Size = new System.Drawing.Size(86, 13);
            this.txtColorDepth.TabIndex = 14;
            this.txtColorDepth.Text = "Color Depth: n/a";
            // 
            // txtImageSize
            // 
            this.txtImageSize.AutoSize = true;
            this.txtImageSize.Location = new System.Drawing.Point(10, 54);
            this.txtImageSize.Name = "txtImageSize";
            this.txtImageSize.Size = new System.Drawing.Size(87, 13);
            this.txtImageSize.TabIndex = 16;
            this.txtImageSize.Text = "Image Size: 0 kB";
            // 
            // grpVideoControlPanel
            // 
            this.grpVideoControlPanel.Controls.Add(this.trkQuality);
            this.grpVideoControlPanel.Controls.Add(this.boxCapturing);
            this.grpVideoControlPanel.Controls.Add(this.boxSwapped);
            this.grpVideoControlPanel.Controls.Add(this.boxStreaming);
            this.grpVideoControlPanel.Controls.Add(this.boxColoured);
            this.grpVideoControlPanel.Controls.Add(this.txtQuality);
            this.grpVideoControlPanel.Controls.Add(this.cbxResolutions);
            this.grpVideoControlPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVideoControlPanel.Location = new System.Drawing.Point(8, 93);
            this.grpVideoControlPanel.Name = "grpVideoControlPanel";
            this.grpVideoControlPanel.Size = new System.Drawing.Size(181, 188);
            this.grpVideoControlPanel.TabIndex = 20;
            this.grpVideoControlPanel.TabStop = false;
            this.grpVideoControlPanel.Text = "Video Control Panel";
            // 
            // trkQuality
            // 
            this.trkQuality.Location = new System.Drawing.Point(9, 138);
            this.trkQuality.Maximum = 100;
            this.trkQuality.Name = "trkQuality";
            this.trkQuality.Size = new System.Drawing.Size(160, 45);
            this.trkQuality.TabIndex = 20;
            this.trkQuality.TickFrequency = 5;
            this.trkQuality.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkQuality.Value = 85;
            this.trkQuality.Scroll += new System.EventHandler(this.trkQuality_Scroll);
            this.trkQuality.ValueChanged += new System.EventHandler(this.trkQuality_ValueChanged);
            this.trkQuality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkQuality_KeyDown);
            this.trkQuality.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trkQuality_KeyUp);
            this.trkQuality.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkQuality_MouseDown);
            this.trkQuality.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkQuality_MouseUp);
            // 
            // boxCapturing
            // 
            this.boxCapturing.AutoSize = true;
            this.boxCapturing.Location = new System.Drawing.Point(9, 70);
            this.boxCapturing.Name = "boxCapturing";
            this.boxCapturing.Size = new System.Drawing.Size(71, 17);
            this.boxCapturing.TabIndex = 19;
            this.boxCapturing.Text = "Capturing";
            this.boxCapturing.UseVisualStyleBackColor = true;
            this.boxCapturing.CheckedChanged += new System.EventHandler(this.boxCapturing_CheckedChanged);
            // 
            // boxSwapped
            // 
            this.boxSwapped.AutoSize = true;
            this.boxSwapped.Location = new System.Drawing.Point(83, 92);
            this.boxSwapped.Name = "boxSwapped";
            this.boxSwapped.Size = new System.Drawing.Size(71, 17);
            this.boxSwapped.TabIndex = 18;
            this.boxSwapped.Text = "Swapped";
            this.boxSwapped.UseVisualStyleBackColor = true;
            this.boxSwapped.CheckedChanged += new System.EventHandler(this.boxChannelsSwapped_CheckedChanged);
            // 
            // boxStreaming
            // 
            this.boxStreaming.AutoSize = true;
            this.boxStreaming.Location = new System.Drawing.Point(83, 70);
            this.boxStreaming.Name = "boxStreaming";
            this.boxStreaming.Size = new System.Drawing.Size(73, 17);
            this.boxStreaming.TabIndex = 17;
            this.boxStreaming.Text = "Streaming";
            this.boxStreaming.UseVisualStyleBackColor = true;
            this.boxStreaming.CheckedChanged += new System.EventHandler(this.boxStreaming_CheckedChanged);
            // 
            // boxColoured
            // 
            this.boxColoured.AutoSize = true;
            this.boxColoured.Location = new System.Drawing.Point(9, 92);
            this.boxColoured.Name = "boxColoured";
            this.boxColoured.Size = new System.Drawing.Size(68, 17);
            this.boxColoured.TabIndex = 16;
            this.boxColoured.Text = "Coloured";
            this.boxColoured.UseVisualStyleBackColor = true;
            this.boxColoured.CheckedChanged += new System.EventHandler(this.boxColoured_CheckedChanged);
            // 
            // txtQuality
            // 
            this.txtQuality.AutoSize = true;
            this.txtQuality.Location = new System.Drawing.Point(6, 121);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(113, 13);
            this.txtQuality.TabIndex = 1;
            this.txtQuality.Text = "Encoding Quality: 85%";
            // 
            // cbxResolutions
            // 
            this.cbxResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolutions.FormattingEnabled = true;
            this.cbxResolutions.Items.AddRange(new object[] {
            "640 x 480"});
            this.cbxResolutions.Location = new System.Drawing.Point(9, 29);
            this.cbxResolutions.Name = "cbxResolutions";
            this.cbxResolutions.Size = new System.Drawing.Size(160, 21);
            this.cbxResolutions.TabIndex = 0;
            this.cbxResolutions.SelectedValueChanged += new System.EventHandler(this.cbxResolutions_SelectedValueChanged);
            // 
            // grpNetworkImageStream
            // 
            this.grpNetworkImageStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNetworkImageStream.Controls.Add(this.imgNetworkStreamImage);
            this.grpNetworkImageStream.Location = new System.Drawing.Point(196, 8);
            this.grpNetworkImageStream.Name = "grpNetworkImageStream";
            this.grpNetworkImageStream.Size = new System.Drawing.Size(642, 489);
            this.grpNetworkImageStream.TabIndex = 23;
            this.grpNetworkImageStream.TabStop = false;
            // 
            // imgNetworkStreamImage
            // 
            this.imgNetworkStreamImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgNetworkStreamImage.ErrorImage = global::RemoteCtrl.Properties.Resources.no_cam_connected;
            this.imgNetworkStreamImage.InitialImage = global::RemoteCtrl.Properties.Resources.no_cam_connected;
            this.imgNetworkStreamImage.Location = new System.Drawing.Point(1, 7);
            this.imgNetworkStreamImage.Name = "imgNetworkStreamImage";
            this.imgNetworkStreamImage.Size = new System.Drawing.Size(640, 480);
            this.imgNetworkStreamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgNetworkStreamImage.TabIndex = 2;
            this.imgNetworkStreamImage.TabStop = false;
            // 
            // CameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpNetworkImageStream);
            this.Controls.Add(this.grpStreamPerformance);
            this.Controls.Add(this.grpStreamProperties);
            this.Controls.Add(this.grpVideoControlPanel);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "CameraPanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.grpStreamPerformance.ResumeLayout(false);
            this.grpStreamPerformance.PerformLayout();
            this.grpStreamProperties.ResumeLayout(false);
            this.grpStreamProperties.PerformLayout();
            this.grpVideoControlPanel.ResumeLayout(false);
            this.grpVideoControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).EndInit();
            this.grpNetworkImageStream.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgNetworkStreamImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStreamPerformance;
        private System.Windows.Forms.ProgressBar pgsNetworkTraffic;
        private System.Windows.Forms.Label txtNetworkTraffic;
        private System.Windows.Forms.ProgressBar pgsCompressionRate;
        private System.Windows.Forms.ProgressBar pgsFramerate;
        private System.Windows.Forms.Label txtFramerate;
        private System.Windows.Forms.Label txtCompressionTime;
        private System.Windows.Forms.Label txtCompressionRate;
        private System.Windows.Forms.ProgressBar pgsCompressionTime;
        private System.Windows.Forms.GroupBox grpStreamProperties;
        private System.Windows.Forms.Label txtResolution;
        private System.Windows.Forms.Label txtColorDepth;
        private System.Windows.Forms.Label txtImageSize;
        private System.Windows.Forms.GroupBox grpVideoControlPanel;
        private Emgu.CV.UI.ImageBox imgNetworkStreamImage;
        private System.Windows.Forms.GroupBox grpNetworkImageStream;
        private System.Windows.Forms.Label txtQuality;
        private System.Windows.Forms.ComboBox cbxResolutions;
        private System.Windows.Forms.CheckBox boxSwapped;
        private System.Windows.Forms.CheckBox boxStreaming;
        private System.Windows.Forms.CheckBox boxColoured;
        private System.Windows.Forms.TrackBar trkQuality;
        private System.Windows.Forms.CheckBox boxCapturing;
    }
}
