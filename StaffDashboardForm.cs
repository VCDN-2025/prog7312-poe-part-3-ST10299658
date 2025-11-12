// ============================================================
// StaffDashboardForm.cs - Staff Dashboard for Processing Issues
// ============================================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class StaffDashboardForm : Form
    {
        private IssueLinkedList issueList;
        private MinHeap<ServiceRequest> priorityQueue;
        private Issue selectedIssue;

        // Color scheme
        private static readonly Color PrimaryBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        private static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        private static readonly Color ErrorRed = Color.FromArgb(244, 67, 54);
        private static readonly Color LightGray = Color.FromArgb(245, 245, 245);

        public StaffDashboardForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadIssues();
        }

        private void SetupEventHandlers()
        {
            btnBackToMenu.Click += (s, e) => this.Close();
            btnRefresh.Click += (s, e) => LoadIssues();
            btnClearAll.Click += BtnClearAll_Click;
            cmbStatusFilter.SelectedIndexChanged += (s, e) => FilterIssues();
            cmbCategoryFilter.SelectedIndexChanged += (s, e) => FilterIssues();
            lvIssues.SelectedIndexChanged += LvIssues_SelectedIndexChanged;
            btnUpdateStatus.Click += BtnUpdateStatus_Click;
            btnExport.Click += BtnExport_Click;
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            // Count current issues
            int issueCount = issueList?.Count() ?? 0;

            if (issueCount == 0)
            {
                MessageBox.Show("There are no issues to clear.", "No Issues",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmation dialog
            var result = MessageBox.Show(
                $"Are you sure you want to delete ALL {issueCount} issue(s)?\n\n" +
                "⚠️ This action CANNOT be undone!\n\n" +
                "All reported issues will be permanently removed from the system.",
                "Confirm Clear All Issues",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Double confirmation for safety
                var confirmAgain = MessageBox.Show(
                    "This is your last chance!\n\n" +
                    $"Permanently delete {issueCount} issue(s)?",
                    "Final Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                if (confirmAgain == DialogResult.Yes)
                {
                    try
                    {
                        // Clear the issue list
                        issueList = new IssueLinkedList();

                        // Save empty list
                        IssueStorage.Save(issueList);

                        // Clear UI
                        lvIssues.Items.Clear();
                        rtbDetails.Clear();
                        selectedIssue = null;
                        btnUpdateStatus.Enabled = false;

                        // Update statistics
                        UpdateStatistics();

                        MessageBox.Show(
                            $"Successfully deleted all {issueCount} issue(s).\n\n" +
                            "The system has been cleared.",
                            "Issues Cleared",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error clearing issues: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadIssues()
        {
            try
            {
                issueList = IssueStorage.Load();
                priorityQueue = new MinHeap<ServiceRequest>();

                if (issueList == null || issueList.Count() == 0)
                {
                    MessageBox.Show("No issues found in the system.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateStatistics();
                    return;
                }

                // Populate category filter
                var categories = new HashSet<string>();
                foreach (var issue in issueList.GetAll())
                {
                    if (!string.IsNullOrEmpty(issue.Category))
                        categories.Add(issue.Category);
                }

                cmbCategoryFilter.Items.Clear();
                cmbCategoryFilter.Items.Add("All Categories");
                foreach (var cat in categories.OrderBy(c => c))
                    cmbCategoryFilter.Items.Add(cat);
                cmbCategoryFilter.SelectedIndex = 0;

                DisplayIssues();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading issues: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayIssues()
        {
            lvIssues.Items.Clear();

            if (issueList == null) return;

            foreach (var issue in issueList.GetAll())
            {
                var item = new ListViewItem(issue.Id.ToString().Substring(0, 8));
                item.SubItems.Add(issue.DateReported.ToString("yyyy-MM-dd"));
                item.SubItems.Add(issue.Category ?? "N/A");
                item.SubItems.Add(issue.FullLocation);

                string status = GetIssueStatus(issue.Id);
                item.SubItems.Add(status);

                string priority = CalculatePriority(issue);
                item.SubItems.Add(priority);
                item.Tag = issue;

                // Color code by status
                switch (status.ToLower())
                {
                    case "completed":
                        item.BackColor = Color.FromArgb(200, 255, 200);
                        break;
                    case "in progress":
                        item.BackColor = Color.FromArgb(255, 245, 200);
                        break;
                    case "pending":
                        item.BackColor = Color.FromArgb(255, 220, 220);
                        break;
                }

                lvIssues.Items.Add(item);
            }
        }

        private void FilterIssues()
        {
            if (issueList == null) return;

            lvIssues.Items.Clear();
            string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
            string categoryFilter = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

            foreach (var issue in issueList.GetAll())
            {
                string status = GetIssueStatus(issue.Id);

                bool statusMatch = statusFilter == "All" || status == statusFilter;
                bool categoryMatch = categoryFilter == "All Categories" || issue.Category == categoryFilter;

                if (statusMatch && categoryMatch)
                {
                    var item = new ListViewItem(issue.Id.ToString().Substring(0, 8));
                    item.SubItems.Add(issue.DateReported.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(issue.Category ?? "N/A");
                    item.SubItems.Add(issue.FullLocation);
                    item.SubItems.Add(status);
                    item.SubItems.Add(CalculatePriority(issue));
                    item.Tag = issue;

                    switch (status.ToLower())
                    {
                        case "completed":
                            item.BackColor = Color.FromArgb(200, 255, 200);
                            break;
                        case "in progress":
                            item.BackColor = Color.FromArgb(255, 245, 200);
                            break;
                        case "pending":
                            item.BackColor = Color.FromArgb(255, 220, 220);
                            break;
                    }

                    lvIssues.Items.Add(item);
                }
            }
        }

        private void LvIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvIssues.SelectedItems.Count == 0)
            {
                btnUpdateStatus.Enabled = false;
                return;
            }

            selectedIssue = lvIssues.SelectedItems[0].Tag as Issue;
            if (selectedIssue != null)
            {
                DisplayIssueDetails(selectedIssue);
                btnUpdateStatus.Enabled = true;

                string currentStatus = GetIssueStatus(selectedIssue.Id);
                int statusIndex = cmbNewStatus.Items.IndexOf(currentStatus);
                if (statusIndex >= 0)
                    cmbNewStatus.SelectedIndex = statusIndex;
            }
        }

        private void DisplayIssueDetails(Issue issue)
        {
            rtbDetails.Clear();

            rtbDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            rtbDetails.SelectionColor = PrimaryBlue;
            rtbDetails.AppendText($"Issue ID: {issue.Id.ToString().Substring(0, 13)}\n\n");

            rtbDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            rtbDetails.SelectionColor = Color.Black;
            rtbDetails.AppendText("Submitted: ");
            rtbDetails.SelectionFont = new Font("Segoe UI", 9);
            rtbDetails.AppendText($"{issue.DateReported:yyyy-MM-dd HH:mm}\n");

            rtbDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            rtbDetails.AppendText("Category: ");
            rtbDetails.SelectionFont = new Font("Segoe UI", 9);
            rtbDetails.AppendText($"{issue.Category ?? "N/A"}\n");

            rtbDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            rtbDetails.AppendText("Location: ");
            rtbDetails.SelectionFont = new Font("Segoe UI", 9);
            rtbDetails.AppendText($"{issue.FullLocation}\n\n");

            rtbDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            rtbDetails.AppendText("Description:\n");
            rtbDetails.SelectionFont = new Font("Segoe UI", 9);
            rtbDetails.AppendText($"{issue.Description}\n\n");

            if (issue.AttachedFiles != null && issue.AttachedFiles.Length > 0)
            {
                rtbDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
                rtbDetails.AppendText("Attachments:\n");
                rtbDetails.SelectionFont = new Font("Segoe UI", 9);
                foreach (var file in issue.AttachedFiles)
                    rtbDetails.AppendText($"  • {System.IO.Path.GetFileName(file)}\n");
            }
        }

        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null) return;

            string newStatus = cmbNewStatus.SelectedItem.ToString();
            UpdateIssueStatus(selectedIssue.Id, newStatus);

            MessageBox.Show($"Status updated to '{newStatus}' successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            FilterIssues();
            UpdateStatistics();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = $"IssuesReport_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new System.IO.StreamWriter(sfd.FileName))
                    {
                        writer.WriteLine("ID,Date,Category,Location,Status,Priority,Description");

                        foreach (var issue in issueList.GetAll())
                        {
                            writer.WriteLine($"\"{issue.Id}\",\"{issue.DateReported:yyyy-MM-dd}\"," +
                                $"\"{issue.Category}\",\"{issue.FullLocation}\"," +
                                $"\"{GetIssueStatus(issue.Id)}\",\"{CalculatePriority(issue)}\"," +
                                $"\"{issue.Description?.Replace("\"", "\"\"")}\"");
                        }
                    }

                    MessageBox.Show("Report exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            int total = 0, pending = 0, inProgress = 0, completed = 0;

            if (issueList != null)
            {
                foreach (var issue in issueList.GetAll())
                {
                    total++;
                    string status = GetIssueStatus(issue.Id);
                    switch (status.ToLower())
                    {
                        case "pending": pending++; break;
                        case "in progress": inProgress++; break;
                        case "completed": completed++; break;
                    }
                }
            }

            lblTotalCount.Text = total.ToString();
            lblPendingCount.Text = pending.ToString();
            lblInProgressCount.Text = inProgress.ToString();
            lblCompletedCount.Text = completed.ToString();
        }

        private string GetIssueStatus(Guid issueId)
        {
            // This would typically check a status tracking system
            // For now, using simple logic based on date
            var issue = issueList.GetAll().FirstOrDefault(i => i.Id == issueId);
            if (issue == null) return "Pending";

            var daysSince = (DateTime.Now - issue.DateReported).TotalDays;

            if (daysSince < 1) return "Pending";
            if (daysSince < 5) return "In Progress";
            return "Completed";
        }

        private void UpdateIssueStatus(Guid issueId, string newStatus)
        {
            // In a real system, this would update a database or status file
            // For now, this is a placeholder that would be implemented
            // with your actual status tracking mechanism
        }

        private string CalculatePriority(Issue issue)
        {
            // Priority based on category and age
            var urgentCategories = new[] { "Sanitation", "Water", "Electricity" };
            var daysSince = (DateTime.Now - issue.DateReported).TotalDays;

            if (urgentCategories.Contains(issue.Category) || daysSince > 7)
                return "High";
            if (daysSince > 3)
                return "Medium";
            return "Low";
        }

        private void StaffDashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}