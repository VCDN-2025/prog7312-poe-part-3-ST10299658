using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private string CurrentUserId = "Okuhle";
        private IssueLinkedList issueList;
        private string attachedFilePath = "";

        public ReportIssueForm()
        {
            InitializeComponent();
            this.Load += ReportIssueForm_Load;
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            // Load issues from storage
            issueList = IssueStorage.Load();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.mov;*.mp4|All files (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = dialog.FileName;
                lblStatus.Text = "File Attached: " + Path.GetFileName(attachedFilePath);
                lblStatus.ForeColor = System.Drawing.Color.SkyBlue;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblStatus.Text = "Location is a required field.";
                lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                MessageBox.Show(lblStatus.Text, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                lblStatus.Text = "Category is a required field.";
                lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                MessageBox.Show(lblStatus.Text, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                lblStatus.Text = "Description is a required field.";
                lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                MessageBox.Show(lblStatus.Text, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Create new issue
            var issue = new Issue
            {
                Province = "Not Specified",
                City = "Not Specified",
                Area = txtLocation.Text,
                Category = cmbCategory.SelectedItem?.ToString() ?? string.Empty,
                Description = rtbDescription.Text.Trim(),
                UserId = CurrentUserId
            };

            // Handle attachment if provided
            if (!string.IsNullOrEmpty(attachedFilePath))
            {
                string copiedFile = IssueStorage.CopyMediaFile(attachedFilePath);
                issue.AttachedFiles = new string[] { copiedFile };
            }

            // Add to linked list and save
            issueList.Add(issue);
            IssueStorage.Save(issueList);

            string successMessage = $"Issue reported successfully! Report Number: {issue.Id}";
            lblStatus.Text = successMessage;
            lblStatus.ForeColor = System.Drawing.Color.LightGreen;
            MessageBox.Show(successMessage, "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form for the next report
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "";
            rtbDescription.Clear();
            attachedFilePath = "";
            lblStatus.Text = "";
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}