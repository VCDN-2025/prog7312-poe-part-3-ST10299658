// ========================================
// FILE 2: MainForm.Designer.cs
// ========================================
namespace MunicipalServicesApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Theme Colors
            var primaryBlue = System.Drawing.Color.FromArgb(0, 30, 60);
            var accentGold = System.Drawing.Color.FromArgb(255, 215, 0);
            var lightTextColor = System.Drawing.Color.WhiteSmoke;
            var controlBackColor = System.Drawing.Color.FromArgb(0, 50, 100);
            var staffPurple = System.Drawing.Color.FromArgb(156, 39, 176);
            var titleFont = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            var buttonFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // Control Declarations
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReportIssue = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceStatus = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnStaffLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // Form
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = primaryBlue;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Text = "Municipality Services Portal";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Logo
            this.pbLogo.Location = new System.Drawing.Point(225, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 75);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;

            // Title
            this.lblTitle.Text = "Services Portal";
            this.lblTitle.Font = titleFont;
            this.lblTitle.ForeColor = accentGold;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(175, 95);
            this.lblTitle.TabIndex = 1;

            // Staff Login Button
            this.btnStaffLogin.Text = "🔐 Staff";
            this.btnStaffLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStaffLogin.Size = new System.Drawing.Size(120, 40);
            this.btnStaffLogin.Location = new System.Drawing.Point(460, 10);
            this.btnStaffLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffLogin.BackColor = staffPurple;
            this.btnStaffLogin.ForeColor = System.Drawing.Color.White;
            this.btnStaffLogin.FlatAppearance.BorderSize = 0;
            this.btnStaffLogin.Name = "btnStaffLogin";
            this.btnStaffLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaffLogin.TabIndex = 2;
            this.btnStaffLogin.Click += new System.EventHandler(this.btnStaffLogin_Click);

            // Report Issue Button
            this.btnReportIssue.Text = "Report a New Issue";
            this.btnReportIssue.Font = buttonFont;
            this.btnReportIssue.Size = new System.Drawing.Size(250, 60);
            this.btnReportIssue.Location = new System.Drawing.Point(175, 150);
            this.btnReportIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssue.BackColor = accentGold;
            this.btnReportIssue.ForeColor = primaryBlue;
            this.btnReportIssue.FlatAppearance.BorderSize = 0;
            this.btnReportIssue.Name = "btnReportIssue";
            this.btnReportIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportIssue.TabIndex = 3;
            this.btnReportIssue.Click += new System.EventHandler(this.btnReportIssue_Click);

            // Local Events Button
            this.btnLocalEvents.Text = "Local Events";
            this.btnLocalEvents.Font = buttonFont;
            this.btnLocalEvents.Size = new System.Drawing.Size(250, 60);
            this.btnLocalEvents.Location = new System.Drawing.Point(175, 220);
            this.btnLocalEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalEvents.BackColor = controlBackColor;
            this.btnLocalEvents.ForeColor = lightTextColor;
            this.btnLocalEvents.FlatAppearance.BorderColor = accentGold;
            this.btnLocalEvents.FlatAppearance.BorderSize = 1;
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalEvents.TabIndex = 4;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);

            // Service Status Button
            this.btnServiceStatus.Text = "Service Request Status";
            this.btnServiceStatus.Font = buttonFont;
            this.btnServiceStatus.Size = new System.Drawing.Size(250, 60);
            this.btnServiceStatus.Location = new System.Drawing.Point(175, 290);
            this.btnServiceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStatus.BackColor = controlBackColor;
            this.btnServiceStatus.ForeColor = lightTextColor;
            this.btnServiceStatus.FlatAppearance.BorderColor = accentGold;
            this.btnServiceStatus.FlatAppearance.BorderSize = 1;
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServiceStatus.TabIndex = 5;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);

            // Exit Button
            this.btnExit.Text = "Exit";
            this.btnExit.Font = buttonFont;
            this.btnExit.Size = new System.Drawing.Size(250, 60);
            this.btnExit.Location = new System.Drawing.Point(175, 360);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.BackColor = controlBackColor;
            this.btnExit.ForeColor = lightTextColor;
            this.btnExit.FlatAppearance.BorderColor = accentGold;
            this.btnExit.FlatAppearance.BorderSize = 1;
            this.btnExit.Name = "btnExit";
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.TabIndex = 6;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReportIssue);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnStaffLogin);

            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReportIssue;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnStaffLogin;
    }
}