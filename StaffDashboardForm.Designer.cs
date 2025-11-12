// ============================================================
// StaffDashboardForm.Designer.cs - Designer File
// With consistent color scheme matching other forms
// ============================================================
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class StaffDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form controls
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel statCard4;
        private System.Windows.Forms.Label lblCompletedCount;
        private System.Windows.Forms.Label lblCompletedLabel;
        private System.Windows.Forms.Panel colorBar4;
        private System.Windows.Forms.Panel statCard3;
        private System.Windows.Forms.Label lblInProgressCount;
        private System.Windows.Forms.Label lblInProgressLabel;
        private System.Windows.Forms.Panel colorBar3;
        private System.Windows.Forms.Panel statCard2;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.Label lblPendingLabel;
        private System.Windows.Forms.Panel colorBar2;
        private System.Windows.Forms.Panel statCard1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Panel colorBar1;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.RichTextBox rtbDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Button btnBackToMenu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statCard4 = new System.Windows.Forms.Panel();
            this.lblCompletedCount = new System.Windows.Forms.Label();
            this.lblCompletedLabel = new System.Windows.Forms.Label();
            this.colorBar4 = new System.Windows.Forms.Panel();
            this.statCard3 = new System.Windows.Forms.Panel();
            this.lblInProgressCount = new System.Windows.Forms.Label();
            this.lblInProgressLabel = new System.Windows.Forms.Label();
            this.colorBar3 = new System.Windows.Forms.Panel();
            this.statCard2 = new System.Windows.Forms.Panel();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblPendingLabel = new System.Windows.Forms.Label();
            this.colorBar2 = new System.Windows.Forms.Panel();
            this.statCard1 = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.colorBar1 = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.lvIssues = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.rtbDetails = new System.Windows.Forms.RichTextBox();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.statCard4.SuspendLayout();
            this.statCard3.SuspendLayout();
            this.statCard2.SuspendLayout();
            this.statCard1.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = StaffDashboardColors.PrimaryBlue;
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1200, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = StaffDashboardColors.LightText;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 47);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(278, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Process and manage citizen service requests";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏢 Staff Dashboard";
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.White;
            this.statsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statsPanel.Controls.Add(this.statCard4);
            this.statsPanel.Controls.Add(this.statCard3);
            this.statsPanel.Controls.Add(this.statCard2);
            this.statsPanel.Controls.Add(this.statCard1);
            this.statsPanel.Location = new System.Drawing.Point(20, 100);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(1160, 80);
            this.statsPanel.TabIndex = 1;
            // 
            // statCard4
            // 
            this.statCard4.BackColor = StaffDashboardColors.CardBackground;
            this.statCard4.Controls.Add(this.lblCompletedCount);
            this.statCard4.Controls.Add(this.lblCompletedLabel);
            this.statCard4.Controls.Add(this.colorBar4);
            this.statCard4.Location = new System.Drawing.Point(880, 10);
            this.statCard4.Name = "statCard4";
            this.statCard4.Size = new System.Drawing.Size(270, 60);
            this.statCard4.TabIndex = 3;
            // 
            // lblCompletedCount
            // 
            this.lblCompletedCount.AutoSize = true;
            this.lblCompletedCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCompletedCount.ForeColor = StaffDashboardColors.SuccessGreen;
            this.lblCompletedCount.Location = new System.Drawing.Point(15, 28);
            this.lblCompletedCount.Name = "lblCompletedCount";
            this.lblCompletedCount.Size = new System.Drawing.Size(28, 32);
            this.lblCompletedCount.TabIndex = 2;
            this.lblCompletedCount.Text = "0";
            // 
            // lblCompletedLabel
            // 
            this.lblCompletedLabel.AutoSize = true;
            this.lblCompletedLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompletedLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblCompletedLabel.Location = new System.Drawing.Point(15, 10);
            this.lblCompletedLabel.Name = "lblCompletedLabel";
            this.lblCompletedLabel.Size = new System.Drawing.Size(66, 15);
            this.lblCompletedLabel.TabIndex = 1;
            this.lblCompletedLabel.Text = "Completed";
            // 
            // colorBar4
            // 
            this.colorBar4.BackColor = StaffDashboardColors.SuccessGreen;
            this.colorBar4.Location = new System.Drawing.Point(0, 0);
            this.colorBar4.Name = "colorBar4";
            this.colorBar4.Size = new System.Drawing.Size(5, 60);
            this.colorBar4.TabIndex = 0;
            // 
            // statCard3
            // 
            this.statCard3.BackColor = StaffDashboardColors.CardBackground;
            this.statCard3.Controls.Add(this.lblInProgressCount);
            this.statCard3.Controls.Add(this.lblInProgressLabel);
            this.statCard3.Controls.Add(this.colorBar3);
            this.statCard3.Location = new System.Drawing.Point(590, 10);
            this.statCard3.Name = "statCard3";
            this.statCard3.Size = new System.Drawing.Size(270, 60);
            this.statCard3.TabIndex = 2;
            // 
            // lblInProgressCount
            // 
            this.lblInProgressCount.AutoSize = true;
            this.lblInProgressCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblInProgressCount.ForeColor = StaffDashboardColors.PrimaryBlue;
            this.lblInProgressCount.Location = new System.Drawing.Point(15, 28);
            this.lblInProgressCount.Name = "lblInProgressCount";
            this.lblInProgressCount.Size = new System.Drawing.Size(28, 32);
            this.lblInProgressCount.TabIndex = 2;
            this.lblInProgressCount.Text = "0";
            // 
            // lblInProgressLabel
            // 
            this.lblInProgressLabel.AutoSize = true;
            this.lblInProgressLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInProgressLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblInProgressLabel.Location = new System.Drawing.Point(15, 10);
            this.lblInProgressLabel.Name = "lblInProgressLabel";
            this.lblInProgressLabel.Size = new System.Drawing.Size(65, 15);
            this.lblInProgressLabel.TabIndex = 1;
            this.lblInProgressLabel.Text = "In Progress";
            // 
            // colorBar3
            // 
            this.colorBar3.BackColor = StaffDashboardColors.PrimaryBlue;
            this.colorBar3.Location = new System.Drawing.Point(0, 0);
            this.colorBar3.Name = "colorBar3";
            this.colorBar3.Size = new System.Drawing.Size(5, 60);
            this.colorBar3.TabIndex = 0;
            // 
            // statCard2
            // 
            this.statCard2.BackColor = StaffDashboardColors.CardBackground;
            this.statCard2.Controls.Add(this.lblPendingCount);
            this.statCard2.Controls.Add(this.lblPendingLabel);
            this.statCard2.Controls.Add(this.colorBar2);
            this.statCard2.Location = new System.Drawing.Point(300, 10);
            this.statCard2.Name = "statCard2";
            this.statCard2.Size = new System.Drawing.Size(270, 60);
            this.statCard2.TabIndex = 1;
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPendingCount.ForeColor = StaffDashboardColors.WarningOrange;
            this.lblPendingCount.Location = new System.Drawing.Point(15, 28);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(28, 32);
            this.lblPendingCount.TabIndex = 2;
            this.lblPendingCount.Text = "0";
            // 
            // lblPendingLabel
            // 
            this.lblPendingLabel.AutoSize = true;
            this.lblPendingLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendingLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingLabel.Location = new System.Drawing.Point(15, 10);
            this.lblPendingLabel.Name = "lblPendingLabel";
            this.lblPendingLabel.Size = new System.Drawing.Size(51, 15);
            this.lblPendingLabel.TabIndex = 1;
            this.lblPendingLabel.Text = "Pending";
            // 
            // colorBar2
            // 
            this.colorBar2.BackColor = StaffDashboardColors.WarningOrange;
            this.colorBar2.Location = new System.Drawing.Point(0, 0);
            this.colorBar2.Name = "colorBar2";
            this.colorBar2.Size = new System.Drawing.Size(5, 60);
            this.colorBar2.TabIndex = 0;
            // 
            // statCard1
            // 
            this.statCard1.BackColor = StaffDashboardColors.CardBackground;
            this.statCard1.Controls.Add(this.lblTotalCount);
            this.statCard1.Controls.Add(this.lblTotalLabel);
            this.statCard1.Controls.Add(this.colorBar1);
            this.statCard1.Location = new System.Drawing.Point(10, 10);
            this.statCard1.Name = "statCard1";
            this.statCard1.Size = new System.Drawing.Size(270, 60);
            this.statCard1.TabIndex = 0;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = StaffDashboardColors.ErrorRed;
            this.lblTotalCount.Location = new System.Drawing.Point(15, 28);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(28, 32);
            this.lblTotalCount.TabIndex = 2;
            this.lblTotalCount.Text = "0";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalLabel.Location = new System.Drawing.Point(15, 10);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(67, 15);
            this.lblTotalLabel.TabIndex = 1;
            this.lblTotalLabel.Text = "Total Issues";
            // 
            // colorBar1
            // 
            this.colorBar1.BackColor = StaffDashboardColors.ErrorRed;
            this.colorBar1.Location = new System.Drawing.Point(0, 0);
            this.colorBar1.Name = "colorBar1";
            this.colorBar1.Size = new System.Drawing.Size(5, 60);
            this.colorBar1.TabIndex = 0;
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.btnClearAll);
            this.filterPanel.Controls.Add(this.btnExport);
            this.filterPanel.Controls.Add(this.btnRefresh);
            this.filterPanel.Controls.Add(this.cmbCategoryFilter);
            this.filterPanel.Controls.Add(this.lblFilterCategory);
            this.filterPanel.Controls.Add(this.cmbStatusFilter);
            this.filterPanel.Controls.Add(this.lblFilterStatus);
            this.filterPanel.Location = new System.Drawing.Point(20, 200);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1160, 60);
            this.filterPanel.TabIndex = 2;
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = StaffDashboardColors.ErrorRed;
            this.btnClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Location = new System.Drawing.Point(910, 15);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(140, 30);
            this.btnClearAll.TabIndex = 6;
            this.btnClearAll.Text = "🗑️ Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = StaffDashboardColors.SuccessGreen;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(750, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 30);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "📊 Export Report";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = StaffDashboardColors.PrimaryBlue;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(610, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(400, 17);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(180, 25);
            this.cmbCategoryFilter.TabIndex = 3;
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterCategory.Location = new System.Drawing.Point(310, 20);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(76, 19);
            this.lblFilterCategory.TabIndex = 2;
            this.lblFilterCategory.Text = "Category:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Pending",
            "In Progress",
            "Completed"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(130, 17);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbStatusFilter.TabIndex = 1;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterStatus.Location = new System.Drawing.Point(15, 20);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(112, 19);
            this.lblFilterStatus.TabIndex = 0;
            this.lblFilterStatus.Text = "Filter by Status:";
            // 
            // lvIssues
            // 
            this.lvIssues.BackColor = System.Drawing.Color.White;
            this.lvIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colDate,
            this.colCategory,
            this.colLocation,
            this.colStatus,
            this.colPriority});
            this.lvIssues.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.HideSelection = false;
            this.lvIssues.Location = new System.Drawing.Point(20, 280);
            this.lvIssues.Name = "lvIssues";
            this.lvIssues.Size = new System.Drawing.Size(700, 380);
            this.lvIssues.TabIndex = 3;
            this.lvIssues.UseCompatibleStateImageBehavior = false;
            this.lvIssues.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 80;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 180;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 80;
            // 
            // detailsPanel
            // 
            this.detailsPanel.AutoScroll = true;
            this.detailsPanel.BackColor = System.Drawing.Color.White;
            this.detailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsPanel.Controls.Add(this.btnUpdateStatus);
            this.detailsPanel.Controls.Add(this.cmbNewStatus);
            this.detailsPanel.Controls.Add(this.lblUpdateStatus);
            this.detailsPanel.Controls.Add(this.rtbDetails);
            this.detailsPanel.Controls.Add(this.lblDetailsTitle);
            this.detailsPanel.Location = new System.Drawing.Point(740, 280);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(440, 380);
            this.detailsPanel.TabIndex = 4;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = StaffDashboardColors.SuccessGreen;
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.Enabled = false;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(230, 318);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(190, 30);
            this.btnUpdateStatus.TabIndex = 4;
            this.btnUpdateStatus.Text = "✓ Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            // 
            // cmbNewStatus
            // 
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNewStatus.FormattingEnabled = true;
            this.cmbNewStatus.Items.AddRange(new object[] {
            "Pending",
            "In Progress",
            "Completed"});
            this.cmbNewStatus.Location = new System.Drawing.Point(15, 320);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(200, 25);
            this.cmbNewStatus.TabIndex = 3;
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpdateStatus.Location = new System.Drawing.Point(15, 295);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(106, 19);
            this.lblUpdateStatus.TabIndex = 2;
            this.lblUpdateStatus.Text = "Update Status:";
            // 
            // rtbDetails
            // 
            this.rtbDetails.BackColor = System.Drawing.Color.White;
            this.rtbDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtbDetails.Location = new System.Drawing.Point(15, 50);
            this.rtbDetails.Name = "rtbDetails";
            this.rtbDetails.ReadOnly = true;
            this.rtbDetails.Size = new System.Drawing.Size(405, 230);
            this.rtbDetails.TabIndex = 1;
            this.rtbDetails.Text = "";
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = StaffDashboardColors.PrimaryBlue;
            this.lblDetailsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(132, 21);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "📋 Issue Details";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.Gray;
            this.btnBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMenu.Location = new System.Drawing.Point(20, 670);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(150, 35);
            this.btnBackToMenu.TabIndex = 5;
            this.btnBackToMenu.Text = "← Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = false;
            // 
            // StaffDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = StaffDashboardColors.Background;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.lvIssues);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StaffDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Dashboard - Municipal Services";
            this.Load += new System.EventHandler(this.StaffDashboardForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statCard4.ResumeLayout(false);
            this.statCard4.PerformLayout();
            this.statCard3.ResumeLayout(false);
            this.statCard3.PerformLayout();
            this.statCard2.ResumeLayout(false);
            this.statCard2.PerformLayout();
            this.statCard1.ResumeLayout(false);
            this.statCard1.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }

    // Static color class to match other forms
    internal static class StaffDashboardColors
    {
        public static readonly Color PrimaryBlue = Color.FromArgb(21, 101, 192);
        public static readonly Color SecondaryBlue = Color.FromArgb(25, 118, 210);
        public static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        public static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        public static readonly Color ErrorRed = Color.FromArgb(244, 67, 54);
        public static readonly Color Background = Color.FromArgb(245, 245, 245);
        public static readonly Color CardBackground = Color.FromArgb(250, 250, 250);
        public static readonly Color LightText = Color.FromArgb(200, 200, 255);
    }
}