// ========================================
// FILE 1: MainForm.cs
// ========================================
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        // Simple color palette
        private static readonly Color PrimaryNavy = Color.FromArgb(0, 30, 60);
        private static readonly Color AccentGold = Color.FromArgb(255, 215, 0);
        private static readonly Color LightText = Color.WhiteSmoke;
        private static readonly Color ButtonBlue = Color.FromArgb(0, 50, 100);
        private static readonly Color StaffPurple = Color.FromArgb(156, 39, 176);

        // STAFF CREDENTIALS
        private const string STAFF_USERNAME = "admin";
        private const string STAFF_PASSWORD = "staff123";

        public MainForm()
        {
            InitializeComponent();
            InitializeLogo();
        }

        private void InitializeLogo()
        {
            try
            {
                string logoPath = @"C:\Users\davyc\source\repos\MunicipalServicesApp\MunicipalityLogo.png";
                if (System.IO.File.Exists(logoPath))
                {
                    if (this.pbLogo != null)
                    {
                        this.pbLogo.Image = Image.FromFile(logoPath);
                    }
                    var logoImage = Image.FromFile(logoPath);
                    this.Icon = Icon.FromHandle(((System.Drawing.Bitmap)logoImage).GetHicon());
                }
            }
            catch { }
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            Form loginForm = new Form
            {
                Text = "Staff Login",
                Size = new Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            Label lblTitle = new Label
            {
                Text = "🔐 Staff Authentication",
                Location = new Point(20, 20),
                Size = new Size(360, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = StaffPurple
            };

            Label lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(30, 70),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10)
            };

            TextBox txtUsername = new TextBox
            {
                Location = new Point(140, 68),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10)
            };

            Label lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(30, 110),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10)
            };

            TextBox txtPassword = new TextBox
            {
                Location = new Point(140, 108),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10),
                UseSystemPasswordChar = true
            };

            Button btnLogin = new Button
            {
                Text = "Login",
                Location = new Point(140, 155),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(250, 155),
                Size = new Size(90, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            btnLogin.Click += (s, ev) =>
            {
                if (txtUsername.Text == STAFF_USERNAME && txtPassword.Text == STAFF_PASSWORD)
                {
                    loginForm.DialogResult = DialogResult.OK;
                    loginForm.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            };

            txtPassword.KeyPress += (s, ev) =>
            {
                if (ev.KeyChar == (char)Keys.Enter)
                {
                    btnLogin.PerformClick();
                    ev.Handled = true;
                }
            };

            loginForm.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, txtUsername, lblPassword, txtPassword, btnLogin, btnCancel
            });
            loginForm.AcceptButton = btnLogin;
            loginForm.CancelButton = btnCancel;

            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                this.Hide();
                Forms.StaffDashboardForm staffDashboard = new Forms.StaffDashboardForm();
                staffDashboard.FormClosed += (s, args) => this.Show();
                staffDashboard.Show();
            }
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.FormClosed += (s, args) => this.Show();
            reportForm.Show();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsAndAnnouncementsForm eventsForm = new EventsAndAnnouncementsForm();
            eventsForm.FormClosed += (s, args) => this.Show();
            eventsForm.Show();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.ServiceRequestStatusForm statusForm = new Forms.ServiceRequestStatusForm();
            statusForm.FormClosed += (s, args) => this.Show();
            statusForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}