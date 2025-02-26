namespace heidischwartz_c969.Forms
{
    partial class Report
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
            lblReportTitle = new System.Windows.Forms.Label();
            tbReportInfo = new System.Windows.Forms.TextBox();
            btnClose = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblReportTitle
            // 
            lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblReportTitle.Location = new System.Drawing.Point(12, 9);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new System.Drawing.Size(805, 60);
            lblReportTitle.TabIndex = 0;
            lblReportTitle.Text = "label1";
            // 
            // tbReportInfo
            // 
            tbReportInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            tbReportInfo.Location = new System.Drawing.Point(0, 72);
            tbReportInfo.Multiline = true;
            tbReportInfo.Name = "tbReportInfo";
            tbReportInfo.Size = new System.Drawing.Size(958, 386);
            tbReportInfo.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            btnClose.Location = new System.Drawing.Point(823, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(122, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "CLOSE REPORT";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Report
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(958, 458);
            Controls.Add(btnClose);
            Controls.Add(tbReportInfo);
            Controls.Add(lblReportTitle);
            Text = "Report";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.TextBox tbReportInfo;

        private System.Windows.Forms.Label lblReportTitle;

        #endregion
    }
}