// ============================================================
// ServiceRequestStatusForm.Designer.cs - MODERN UI REDESIGN
// Matching Events & Announcements visual style - FIXED VERSION
// ============================================================
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        // Designer controls
        private Panel pnlHeader;
        private Panel pnlSearch;
        private DataGridView dgvRequests;
        private TextBox txtSearch;
        private Button btnBackToMenu;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnShowAll;
        private ComboBox cmbStatusFilter;
        private Label lblHeaderTitle;
        private Label lblSearchTitle;
        private Label lblResultCount;

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
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            this.ClientSize = new Size(1400, 850);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "Service Request Status";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ServiceRequestColors.WhiteSmoke;
            this.Font = new Font("Segoe UI", 9.75F);

            // Build UI components
            InitializeHeaderPanel();
            InitializeSearchPanel();
            InitializeDataGridView();

            this.ResumeLayout(false);
        }

        private void InitializeHeaderPanel()
        {
            this.pnlHeader = new Panel();
            this.lblHeaderTitle = new Label();
            this.btnBackToMenu = new Button();

            // Header panel with gradient
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(
                        this.pnlHeader.ClientRectangle,
                        ServiceRequestColors.PrimaryBlue,
                        ServiceRequestColors.DarkNavy,
                        LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, this.pnlHeader.ClientRectangle);
                }
            };

            // Header title - centered
            this.lblHeaderTitle.Text = "SERVICE REQUEST STATUS TRACKER";
            this.lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.White;
            this.lblHeaderTitle.BackColor = Color.Transparent;
            this.lblHeaderTitle.AutoSize = false;
            this.lblHeaderTitle.Size = new Size(1400, 40);
            this.lblHeaderTitle.Location = new Point(0, 20);
            this.lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Back button
            this.btnBackToMenu.Text = "← Back";
            this.btnBackToMenu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnBackToMenu.BackColor = Color.FromArgb(180, 255, 255, 255);
            this.btnBackToMenu.ForeColor = ServiceRequestColors.DarkNavy;
            this.btnBackToMenu.FlatStyle = FlatStyle.Flat;
            this.btnBackToMenu.Size = new Size(100, 32);
            this.btnBackToMenu.Location = new Point(20, 24);
            this.btnBackToMenu.Cursor = Cursors.Hand;
            this.btnBackToMenu.FlatAppearance.BorderSize = 0;
            this.btnBackToMenu.MouseEnter += (s, e) => btnBackToMenu.BackColor = Color.White;
            this.btnBackToMenu.MouseLeave += (s, e) => btnBackToMenu.BackColor = Color.FromArgb(180, 255, 255, 255);

            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.pnlHeader);
        }

        private void InitializeSearchPanel()
        {
            this.pnlSearch = new Panel();
            this.lblSearchTitle = new Label();
            this.txtSearch = new TextBox();
            this.cmbStatusFilter = new ComboBox();
            this.btnSearch = new Button();
            this.btnRefresh = new Button();
            this.btnShowAll = new Button();
            this.lblResultCount = new Label();

            // Search panel
            this.pnlSearch.Location = new Point(0, 80);
            this.pnlSearch.Size = new Size(1400, 120);
            this.pnlSearch.BackColor = Color.White;
            this.pnlSearch.Padding = new Padding(20, 12, 20, 12);

            // Add bottom border
            this.pnlSearch.Paint += (s, pe) =>
            {
                using (Pen borderPen = new Pen(ServiceRequestColors.BorderLight, 1))
                {
                    pe.Graphics.DrawLine(borderPen, 0, pnlSearch.Height - 1, pnlSearch.Width, pnlSearch.Height - 1);
                }
            };

            // Search title
            this.lblSearchTitle.Text = "Search & Filter";
            this.lblSearchTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSearchTitle.ForeColor = ServiceRequestColors.TextDark;
            this.lblSearchTitle.Location = new Point(20, 12);
            this.lblSearchTitle.AutoSize = true;

            // Search textbox
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(20, 40);
            this.txtSearch.Size = new Size(250, 30);
            this.txtSearch.Text = "Search by ID or description...";
            this.txtSearch.ForeColor = Color.Gray;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;

            this.txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Search by ID or description...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = ServiceRequestColors.TextDark;
                }
            };

            this.txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search by ID or description...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            // Status filter combo
            this.cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            this.cmbStatusFilter.Location = new Point(285, 40);
            this.cmbStatusFilter.Size = new Size(180, 30);
            this.cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FlatStyle = FlatStyle.Standard;
            this.cmbStatusFilter.Items.AddRange(new string[] { "All Statuses", "Pending", "In Progress", "Completed" });
            this.cmbStatusFilter.SelectedIndex = 0;

            // Search button
            this.btnSearch.Text = "Search";
            this.btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnSearch.BackColor = ServiceRequestColors.SecondaryBlue;
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Size = new Size(110, 34);
            this.btnSearch.Location = new Point(20, 78);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ServiceRequestColors.LightBlue;
            this.btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ServiceRequestColors.SecondaryBlue;

            // Refresh button
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnRefresh.BackColor = ServiceRequestColors.StatusGreen;
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Size = new Size(110, 34);
            this.btnRefresh.Location = new Point(140, 78);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.FromArgb(87, 180, 91);
            this.btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = ServiceRequestColors.StatusGreen;

            // Show All button
            this.btnShowAll.Text = "Show All Details";
            this.btnShowAll.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnShowAll.BackColor = ServiceRequestColors.TextMedium;
            this.btnShowAll.ForeColor = Color.White;
            this.btnShowAll.FlatStyle = FlatStyle.Flat;
            this.btnShowAll.Size = new Size(130, 34);
            this.btnShowAll.Location = new Point(260, 78);
            this.btnShowAll.Cursor = Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.MouseEnter += (s, e) => btnShowAll.BackColor = Color.FromArgb(104, 130, 142);
            this.btnShowAll.MouseLeave += (s, e) => btnShowAll.BackColor = ServiceRequestColors.TextMedium;

            // Result count label
            this.lblResultCount.Text = "0 requests found";
            this.lblResultCount.Font = new Font("Segoe UI", 9.5F);
            this.lblResultCount.ForeColor = ServiceRequestColors.TextMedium;
            this.lblResultCount.Location = new Point(850, 85);
            this.lblResultCount.AutoSize = true;

            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.cmbStatusFilter);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.pnlSearch);
        }

        private void InitializeDataGridView()
        {
            this.dgvRequests = new DataGridView();

            // DataGridView configuration
            this.dgvRequests.Location = new Point(25, 215);
            this.dgvRequests.Size = new Size(1350, 600);
            this.dgvRequests.BackgroundColor = Color.White;
            this.dgvRequests.BorderStyle = BorderStyle.None;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.AutoGenerateColumns = true;
            this.dgvRequests.EnableHeadersVisualStyles = false;
            this.dgvRequests.GridColor = ServiceRequestColors.BorderLight;
            this.dgvRequests.RowTemplate.Height = 45;

            // Header style
            this.dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = ServiceRequestColors.PrimaryBlue;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = ServiceRequestColors.PrimaryBlue;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.dgvRequests.ColumnHeadersHeight = 45;

            // Row style
            this.dgvRequests.DefaultCellStyle.BackColor = Color.White;
            this.dgvRequests.DefaultCellStyle.ForeColor = ServiceRequestColors.TextDark;
            this.dgvRequests.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            this.dgvRequests.DefaultCellStyle.SelectionBackColor = ServiceRequestColors.SoftBlue;
            this.dgvRequests.DefaultCellStyle.SelectionForeColor = ServiceRequestColors.TextDark;
            this.dgvRequests.DefaultCellStyle.Padding = new Padding(5);

            // Alternating rows
            this.dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            this.Controls.Add(this.dgvRequests);
        }
    }

    // Static color class to avoid duplication
    internal static class ServiceRequestColors
    {
        public static readonly Color PrimaryBlue = Color.FromArgb(13, 71, 161);
        public static readonly Color SecondaryBlue = Color.FromArgb(25, 118, 210);
        public static readonly Color LightBlue = Color.FromArgb(66, 165, 245);
        public static readonly Color DarkNavy = Color.FromArgb(21, 56, 105);
        public static readonly Color WhiteSmoke = Color.FromArgb(250, 250, 250);
        public static readonly Color TextDark = Color.FromArgb(38, 50, 56);
        public static readonly Color TextMedium = Color.FromArgb(84, 110, 122);
        public static readonly Color BorderLight = Color.FromArgb(207, 216, 220);
        public static readonly Color StatusGreen = Color.FromArgb(67, 160, 71);
        public static readonly Color StatusOrange = Color.FromArgb(251, 140, 0);
        public static readonly Color StatusRed = Color.FromArgb(229, 57, 53);
        public static readonly Color SoftBlue = Color.FromArgb(227, 242, 253);
    }
}