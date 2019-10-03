namespace RemoteCtrl {
    partial class ServoLayerControl {
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
            this.txtName = new System.Windows.Forms.Label();
            this.boxVisible = new System.Windows.Forms.CheckBox();
            this.boxLocked = new System.Windows.Forms.CheckBox();
            this.tipVisible = new System.Windows.Forms.ToolTip(this.components);
            this.tipLocked = new System.Windows.Forms.ToolTip(this.components);
            this.imgIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(36, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(101, 13);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "<ServoLayerName>";
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServoLayerControl_MouseClick);
            // 
            // boxVisible
            // 
            this.boxVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxVisible.Appearance = System.Windows.Forms.Appearance.Button;
            this.boxVisible.Checked = true;
            this.boxVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxVisible.Image = global::RemoteCtrl.Properties.Resources.visible_16;
            this.boxVisible.Location = new System.Drawing.Point(184, 3);
            this.boxVisible.Name = "boxVisible";
            this.boxVisible.Size = new System.Drawing.Size(28, 24);
            this.boxVisible.TabIndex = 2;
            this.tipVisible.SetToolTip(this.boxVisible, "Visible");
            this.boxVisible.UseVisualStyleBackColor = true;
            this.boxVisible.CheckedChanged += new System.EventHandler(this.boxVisible_CheckedChanged);
            // 
            // boxLocked
            // 
            this.boxLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxLocked.Appearance = System.Windows.Forms.Appearance.Button;
            this.boxLocked.Image = global::RemoteCtrl.Properties.Resources.locked_16;
            this.boxLocked.Location = new System.Drawing.Point(214, 3);
            this.boxLocked.Name = "boxLocked";
            this.boxLocked.Size = new System.Drawing.Size(28, 24);
            this.boxLocked.TabIndex = 3;
            this.tipLocked.SetToolTip(this.boxLocked, "Locked");
            this.boxLocked.UseVisualStyleBackColor = true;
            this.boxLocked.CheckedChanged += new System.EventHandler(this.boxLocked_CheckedChanged);
            // 
            // tipVisible
            // 
            this.tipVisible.AutomaticDelay = 250;
            this.tipVisible.AutoPopDelay = 10000;
            this.tipVisible.InitialDelay = 250;
            this.tipVisible.ReshowDelay = 50;
            // 
            // tipLocked
            // 
            this.tipLocked.AutomaticDelay = 250;
            this.tipLocked.AutoPopDelay = 10000;
            this.tipLocked.InitialDelay = 250;
            this.tipLocked.ReshowDelay = 50;
            // 
            // imgIcon
            // 
            this.imgIcon.ErrorImage = global::RemoteCtrl.Properties.Resources.layer_24;
            this.imgIcon.Image = global::RemoteCtrl.Properties.Resources.layer_24;
            this.imgIcon.InitialImage = global::RemoteCtrl.Properties.Resources.layer_24;
            this.imgIcon.Location = new System.Drawing.Point(3, 3);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(24, 24);
            this.imgIcon.TabIndex = 0;
            this.imgIcon.TabStop = false;
            this.imgIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServoLayerControl_MouseClick);
            // 
            // ServoLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxLocked);
            this.Controls.Add(this.boxVisible);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imgIcon);
            this.Name = "ServoLayerControl";
            this.Size = new System.Drawing.Size(247, 30);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServoLayerControl_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgIcon;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.CheckBox boxVisible;
        private System.Windows.Forms.CheckBox boxLocked;
        private System.Windows.Forms.ToolTip tipVisible;
        private System.Windows.Forms.ToolTip tipLocked;
    }
}
