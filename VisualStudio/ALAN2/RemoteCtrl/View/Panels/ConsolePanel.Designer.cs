namespace RemoteCtrl {
    partial class ConsolePanel {
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
            this.layConsoles = new System.Windows.Forms.TableLayoutPanel();
            this.txtAtmelConsole = new System.Windows.Forms.TextBox();
            this.txtAgentConsole = new System.Windows.Forms.TextBox();
            this.lblAgentConsole = new System.Windows.Forms.Label();
            this.lblAtmelConsole = new System.Windows.Forms.Label();
            this.cmdAtmelClear = new System.Windows.Forms.Button();
            this.cmdAgentClear = new System.Windows.Forms.Button();
            this.layControls = new System.Windows.Forms.TableLayoutPanel();
            this.layConsoles.SuspendLayout();
            this.layControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // layConsoles
            // 
            this.layConsoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layConsoles.ColumnCount = 2;
            this.layConsoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layConsoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layConsoles.Controls.Add(this.txtAtmelConsole, 1, 0);
            this.layConsoles.Controls.Add(this.txtAgentConsole, 0, 0);
            this.layConsoles.Location = new System.Drawing.Point(3, 39);
            this.layConsoles.Name = "layConsoles";
            this.layConsoles.RowCount = 1;
            this.layConsoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layConsoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 462F));
            this.layConsoles.Size = new System.Drawing.Size(840, 462);
            this.layConsoles.TabIndex = 0;
            // 
            // txtAtmelConsole
            // 
            this.txtAtmelConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAtmelConsole.BackColor = System.Drawing.Color.White;
            this.txtAtmelConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAtmelConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtmelConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAtmelConsole.Location = new System.Drawing.Point(423, 3);
            this.txtAtmelConsole.MaxLength = 250000;
            this.txtAtmelConsole.Multiline = true;
            this.txtAtmelConsole.Name = "txtAtmelConsole";
            this.txtAtmelConsole.ReadOnly = true;
            this.txtAtmelConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAtmelConsole.Size = new System.Drawing.Size(414, 456);
            this.txtAtmelConsole.TabIndex = 1;
            this.txtAtmelConsole.Text = "<default>";
            this.txtAtmelConsole.WordWrap = false;
            // 
            // txtAgentConsole
            // 
            this.txtAgentConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgentConsole.BackColor = System.Drawing.Color.White;
            this.txtAgentConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAgentConsole.Location = new System.Drawing.Point(3, 3);
            this.txtAgentConsole.MaxLength = 250000;
            this.txtAgentConsole.Multiline = true;
            this.txtAgentConsole.Name = "txtAgentConsole";
            this.txtAgentConsole.ReadOnly = true;
            this.txtAgentConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAgentConsole.Size = new System.Drawing.Size(414, 456);
            this.txtAgentConsole.TabIndex = 0;
            this.txtAgentConsole.Text = "<default>";
            this.txtAgentConsole.WordWrap = false;
            // 
            // lblAgentConsole
            // 
            this.lblAgentConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentConsole.Location = new System.Drawing.Point(3, 0);
            this.lblAgentConsole.Name = "lblAgentConsole";
            this.lblAgentConsole.Size = new System.Drawing.Size(204, 30);
            this.lblAgentConsole.TabIndex = 1;
            this.lblAgentConsole.Text = "Remote Agent Console";
            this.lblAgentConsole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAtmelConsole
            // 
            this.lblAtmelConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtmelConsole.Location = new System.Drawing.Point(423, 0);
            this.lblAtmelConsole.Name = "lblAtmelConsole";
            this.lblAtmelConsole.Size = new System.Drawing.Size(204, 30);
            this.lblAtmelConsole.TabIndex = 2;
            this.lblAtmelConsole.Text = "Atmel Microprocessor Console";
            this.lblAtmelConsole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdAtmelClear
            // 
            this.cmdAtmelClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAtmelClear.Location = new System.Drawing.Point(762, 3);
            this.cmdAtmelClear.Name = "cmdAtmelClear";
            this.cmdAtmelClear.Size = new System.Drawing.Size(75, 23);
            this.cmdAtmelClear.TabIndex = 4;
            this.cmdAtmelClear.Text = "Clear";
            this.cmdAtmelClear.UseVisualStyleBackColor = true;
            this.cmdAtmelClear.Click += new System.EventHandler(this.cmdAtmelClear_Click);
            // 
            // cmdAgentClear
            // 
            this.cmdAgentClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgentClear.Location = new System.Drawing.Point(342, 3);
            this.cmdAgentClear.Name = "cmdAgentClear";
            this.cmdAgentClear.Size = new System.Drawing.Size(75, 23);
            this.cmdAgentClear.TabIndex = 5;
            this.cmdAgentClear.Text = "Clear";
            this.cmdAgentClear.UseVisualStyleBackColor = true;
            this.cmdAgentClear.Click += new System.EventHandler(this.cmdAgentClear_Click);
            // 
            // layControls
            // 
            this.layControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layControls.ColumnCount = 4;
            this.layControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layControls.Controls.Add(this.lblAgentConsole, 0, 0);
            this.layControls.Controls.Add(this.cmdAtmelClear, 3, 0);
            this.layControls.Controls.Add(this.cmdAgentClear, 1, 0);
            this.layControls.Controls.Add(this.lblAtmelConsole, 2, 0);
            this.layControls.Location = new System.Drawing.Point(3, 3);
            this.layControls.Name = "layControls";
            this.layControls.RowCount = 1;
            this.layControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layControls.Size = new System.Drawing.Size(840, 30);
            this.layControls.TabIndex = 6;
            // 
            // ConsolePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layControls);
            this.Controls.Add(this.layConsoles);
            this.MinimumSize = new System.Drawing.Size(846, 504);
            this.Name = "ConsolePanel";
            this.Size = new System.Drawing.Size(846, 504);
            this.layConsoles.ResumeLayout(false);
            this.layConsoles.PerformLayout();
            this.layControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layConsoles;
        private System.Windows.Forms.TextBox txtAgentConsole;
        private System.Windows.Forms.TextBox txtAtmelConsole;
        private System.Windows.Forms.Label lblAgentConsole;
        private System.Windows.Forms.Label lblAtmelConsole;
        private System.Windows.Forms.Button cmdAtmelClear;
        private System.Windows.Forms.Button cmdAgentClear;
        private System.Windows.Forms.TableLayoutPanel layControls;
    }
}
