namespace MunicipalServicesApp
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // --- Theme Colors and Fonts ---
            var primaryBlue = System.Drawing.Color.FromArgb(0, 30, 60); // Deep Navy Blue
            var accentGold = System.Drawing.Color.FromArgb(255, 215, 0); // Gold
            var lightTextColor = System.Drawing.Color.White;
            var controlBackColor = System.Drawing.Color.FromArgb(0, 50, 100); // Slightly Lighter Blue

            var labelFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            var inputFont = new System.Drawing.Font("Segoe UI", 9.5F);
            var buttonFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // --- Control Declarations ---
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // --- Form Styling ---
            this.Text = "Report an Issue";
            this.Width = 550;
            this.Height = 600;
            this.BackColor = primaryBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "ReportIssueForm";

            // --- lblLocation ---
            this.lblLocation.Text = "Location:";
            this.lblLocation.Top = 40;
            this.lblLocation.Left = 30;
            this.lblLocation.ForeColor = accentGold;
            this.lblLocation.Font = labelFont;
            this.lblLocation.AutoSize = true;

            // --- txtLocation ---
            this.txtLocation.Top = 40;
            this.txtLocation.Left = 150;
            this.txtLocation.Width = 350;
            this.txtLocation.BackColor = controlBackColor;
            this.txtLocation.ForeColor = lightTextColor;
            this.txtLocation.Font = inputFont;
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // --- lblCategory ---
            this.lblCategory.Text = "Category:";
            this.lblCategory.Top = 80;
            this.lblCategory.Left = 30;
            this.lblCategory.ForeColor = accentGold;
            this.lblCategory.Font = labelFont;
            this.lblCategory.AutoSize = true;

            // --- cmbCategory ---
            this.cmbCategory.Top = 80;
            this.cmbCategory.Left = 150;
            this.cmbCategory.Width = 350;
            this.cmbCategory.BackColor = controlBackColor;
            this.cmbCategory.ForeColor = lightTextColor;
            this.cmbCategory.Font = inputFont;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Items.AddRange(new string[] { "Road Damage", "Waste Management", "Water Supply", "Electricity", "Other" });

            // --- lblDescription ---
            this.lblDescription.Text = "Description:";
            this.lblDescription.Top = 120;
            this.lblDescription.Left = 30;
            this.lblDescription.ForeColor = accentGold;
            this.lblDescription.Font = labelFont;
            this.lblDescription.AutoSize = true;

            // --- rtbDescription ---
            this.rtbDescription.Top = 150;
            this.rtbDescription.Left = 150;
            this.rtbDescription.Width = 350;
            this.rtbDescription.Height = 150;
            this.rtbDescription.BackColor = controlBackColor;
            this.rtbDescription.ForeColor = lightTextColor;
            this.rtbDescription.Font = inputFont;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // --- btnAttach ---
            this.btnAttach.Text = "Attach Media";
            this.btnAttach.Top = 320;
            this.btnAttach.Left = 150;
            this.btnAttach.Width = 165;
            this.btnAttach.Height = 40;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.BackColor = controlBackColor;
            this.btnAttach.ForeColor = lightTextColor;
            this.btnAttach.Font = buttonFont;
            this.btnAttach.FlatAppearance.BorderColor = accentGold;
            this.btnAttach.FlatAppearance.BorderSize = 1;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);

            // --- btnSubmit ---
            this.btnSubmit.Text = "Submit Issue";
            this.btnSubmit.Top = 380;
            this.btnSubmit.Left = 150;
            this.btnSubmit.Width = 165;
            this.btnSubmit.Height = 40;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.BackColor = accentGold;
            this.btnSubmit.ForeColor = primaryBlue;
            this.btnSubmit.Font = buttonFont;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // --- btnBack ---
            this.btnBack.Text = "Back";
            this.btnBack.Top = 380;
            this.btnBack.Left = 335;
            this.btnBack.Width = 165;
            this.btnBack.Height = 40;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.BackColor = controlBackColor;
            this.btnBack.ForeColor = lightTextColor;
            this.btnBack.Font = buttonFont;
            this.btnBack.FlatAppearance.BorderColor = accentGold;
            this.btnBack.FlatAppearance.BorderSize = 1;
            this.btnBack.Click += new System.EventHandler(this.btnBackToMenu_Click);

            // --- lblStatus ---
            this.lblStatus.Text = "";
            this.lblStatus.Top = 450;
            this.lblStatus.Left = 150;
            this.lblStatus.Width = 350;
            this.lblStatus.ForeColor = lightTextColor;
            this.lblStatus.Font = inputFont;

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblLocation, this.txtLocation,
                this.lblCategory, this.cmbCategory,
                this.lblDescription, this.rtbDescription,
                this.btnAttach, this.btnSubmit, this.btnBack,
                this.lblStatus
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}