// ============================================================
// ServiceRequestStatusForm.cs - MODERN UI IMPLEMENTATION
// Matching Events & Announcements visual style - FIXED VERSION
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
    public partial class ServiceRequestStatusForm : Form
    {
        // Data structures for managing service requests
        private BinarySearchTree<ServiceRequest> bst = new BinarySearchTree<ServiceRequest>();
        private MinHeap<ServiceRequest> heap = new MinHeap<ServiceRequest>();
        private Graph serviceGraph = new Graph();
        private AVLTree<ServiceRequest> avlTree = new AVLTree<ServiceRequest>();

        // Link to actual issues from Part 1
        private IssueLinkedList issueList;
        private string currentUserId;

        // Store all requests for filtering
        private List<ServiceRequest> allRequests = new List<ServiceRequest>();

        // Random instance for status generation
        private Random rand = new Random();

        public ServiceRequestStatusForm(string userId = "Lungisani")
        {
            this.currentUserId = userId;
            InitializeComponent();
            SetupEventHandlers();
            LoadServiceRequests();
        }

        /// <summary>
        /// Wire up all event handlers for UI controls
        /// </summary>
        private void SetupEventHandlers()
        {
            // Back button
            btnBackToMenu.Click += (s, e) => this.Close();

            // Search button
            btnSearch.Click += (s, e) => PerformSearch();

            // Refresh button
            btnRefresh.Click += (s, e) =>
            {
                LoadServiceRequests();
                MessageBox.Show("Data refreshed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Show all button
            btnShowAll.Click += (s, e) => ShowAllRequestsDetails();

            // DataGridView double-click
            dgvRequests.CellDoubleClick += DgvRequests_CellDoubleClick;

            // Enter key in search box
            txtSearch.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    PerformSearch();
                    e.Handled = true;
                }
            };
        }

        /// <summary>
        /// Load REAL service requests from IssueStorage (Part 1 data)
        /// </summary>
        private void LoadServiceRequests()
        {
            try
            {
                // Load actual issues from Part 1
                issueList = IssueStorage.Load();

                // Clear existing data structures
                allRequests.Clear();
                bst = new BinarySearchTree<ServiceRequest>();
                heap = new MinHeap<ServiceRequest>();
                avlTree = new AVLTree<ServiceRequest>();
                serviceGraph = new Graph();

                if (issueList == null || issueList.Count() == 0)
                {
                    MessageBox.Show("No service requests found. Please submit issues first via 'Report Issues'.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateResultCount(0);
                    dgvRequests.DataSource = null;
                    return;
                }

                // Convert Issues to ServiceRequests and populate data structures
                int requestId = 1;
                var categoryMap = new Dictionary<string, List<int>>();

                // Convert linked list to array for iteration
                var issues = issueList.ToArray();

                foreach (var issue in issues)
                {
                    // Create ServiceRequest from Issue
                    var serviceRequest = new ServiceRequest(
                        requestId,
                        issue.UserId ?? "Unknown",
                        $"{issue.Category} - {issue.Description}",
                        DetermineStatus()
                    );

                    // Store in list
                    allRequests.Add(serviceRequest);

                    // Populate all data structures
                    bst.Insert(serviceRequest);           // BST for sorted access O(log n)
                    heap.Insert(serviceRequest);          // Heap for priority queue O(log n)
                    avlTree.Insert(serviceRequest);       // AVL for balanced tree O(log n)
                    serviceGraph.AddVertex(requestId.ToString());

                    // Track categories for graph relationships
                    string category = issue.Category ?? "Other";
                    if (!categoryMap.ContainsKey(category))
                        categoryMap[category] = new List<int>();
                    categoryMap[category].Add(requestId);

                    requestId++;
                }

                // Create graph relationships based on categories
                foreach (var categoryGroup in categoryMap.Values)
                {
                    if (categoryGroup.Count > 1)
                    {
                        // Connect first request to next 2-3 requests (hub pattern)
                        int hub = categoryGroup[0];
                        for (int i = 1; i < Math.Min(categoryGroup.Count, 4); i++)
                        {
                            serviceGraph.AddEdge(hub.ToString(), categoryGroup[i].ToString());
                        }

                        // Connect some middle requests to create clusters
                        for (int i = 1; i < categoryGroup.Count - 1; i += 2)
                        {
                            if (i + 1 < categoryGroup.Count)
                            {
                                serviceGraph.AddEdge(
                                    categoryGroup[i].ToString(),
                                    categoryGroup[i + 1].ToString()
                                );
                            }
                        }
                    }
                }

                // Display in UI
                DisplayRequests(allRequests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading service requests: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Determine request status based on random distribution
        /// </summary>
        private string DetermineStatus()
        {
            int statusValue = rand.Next(100);

            if (statusValue < 30)
                return "Pending";
            else if (statusValue < 70)
                return "In Progress";
            else
                return "Completed";
        }

        /// <summary>
        /// Display requests in the DataGridView
        /// </summary>
        private void DisplayRequests(IEnumerable<ServiceRequest> requests)
        {
            var requestList = requests.OrderBy(r => r.Id).Select(r => new
            {
                ID = r.Id,
                Resident = r.ResidentName,
                Description = r.Description,
                Status = r.Status,
                Priority = r.Status == "Pending" ? "High" : r.Status == "In Progress" ? "Medium" : "Low"
            }).ToList();

            dgvRequests.DataSource = requestList;

            // Customize column widths
            if (dgvRequests.Columns.Count > 0 && dgvRequests.Columns.Contains("ID"))
            {
                dgvRequests.Columns["ID"].Width = 80;
                dgvRequests.Columns["Resident"].Width = 200;
                dgvRequests.Columns["Description"].Width = 550;
                dgvRequests.Columns["Status"].Width = 150;
                dgvRequests.Columns["Priority"].Width = 120;
            }

            // Apply row colors based on status
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();

                    if (status == "Completed")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
                    }
                    else if (status == "In Progress")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 178);
                    }
                    else if (status == "Pending")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 205, 210);
                    }
                }
            }

            UpdateResultCount(requestList.Count);
        }

        /// <summary>
        /// Update result count label
        /// </summary>
        private void UpdateResultCount(int count)
        {
            lblResultCount.Text = $"{count} request{(count != 1 ? "s" : "")} found";
        }

        /// <summary>
        /// Perform search based on filters
        /// </summary>
        private void PerformSearch()
        {
            var filteredRequests = allRequests.AsEnumerable();

            // Text search
            string searchText = txtSearch.Text;
            if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search by ID or description...")
            {
                filteredRequests = filteredRequests.Where(r =>
                    r.Id.ToString().Contains(searchText) ||
                    (r.ResidentName != null && r.ResidentName.ToLower().Contains(searchText.ToLower())) ||
                    (r.Description != null && r.Description.ToLower().Contains(searchText.ToLower())));
            }

            // Status filter
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                string selectedStatus = cmbStatusFilter.SelectedItem.ToString();
                filteredRequests = filteredRequests.Where(r => r.Status == selectedStatus);
            }

            DisplayRequests(filteredRequests.ToList());
        }

        /// <summary>
        /// Handle double-click on DataGridView to show details
        /// </summary>
        private void DgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRequests.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                var row = dgvRequests.Rows[e.RowIndex];
                int requestId = Convert.ToInt32(row.Cells["ID"].Value);
                ShowRequestDetails(requestId);
            }
        }

        /// <summary>
        /// Show detailed information about a specific request with BFS traversal
        /// </summary>
        private void ShowRequestDetails(int requestId)
        {
            // Search for request in BST
            ServiceRequest found = allRequests.FirstOrDefault(r => r.Id == requestId);

            if (found == null)
            {
                MessageBox.Show($"Request ID {requestId} not found in the system.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Perform BFS traversal from this request
            var traversal = GraphTraversal.BFS(serviceGraph, requestId.ToString());

            // Handle null or empty traversal
            if (traversal == null || traversal.Count == 0)
            {
                traversal = new List<string> { requestId.ToString() };
            }

            // Create detail form
            Form detailForm = new Form
            {
                Text = "Request Details",
                Size = new Size(700, 650),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(250, 250, 250),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Header panel
            Color headerColor = found.Status == "Completed" ? ServiceRequestColors.StatusGreen :
                               found.Status == "In Progress" ? ServiceRequestColors.StatusOrange : ServiceRequestColors.StatusRed;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = headerColor
            };

            Label lblDetailTitle = new Label
            {
                Text = $"REQUEST #{found.Id}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(640, 40),
                Location = new Point(30, 15),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDetailSubtitle = new Label
            {
                Text = found.Status.ToUpper(),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 255, 230),
                BackColor = Color.Transparent,
                Location = new Point(30, 50),
                AutoSize = true
            };

            headerPanel.Controls.Add(lblDetailTitle);
            headerPanel.Controls.Add(lblDetailSubtitle);

            // Content panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 20),
                AutoScroll = true,
                BackColor = Color.White
            };

            int yPos = 15;
            void AddDetailRow(string label, string value, Color color)
            {
                Panel row = new Panel
                {
                    Location = new Point(10, yPos),
                    Size = new Size(600, 60),
                    BackColor = Color.FromArgb(227, 242, 253)
                };

                Label lblLabel = new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = color,
                    BackColor = Color.Transparent,
                    Location = new Point(15, 10),
                    AutoSize = true
                };

                Label lblValue = new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = ServiceRequestColors.TextDark,
                    BackColor = Color.Transparent,
                    Location = new Point(15, 32),
                    Size = new Size(570, 22)
                };

                row.Controls.Add(lblLabel);
                row.Controls.Add(lblValue);
                contentPanel.Controls.Add(row);
                yPos += 70;
            }

            AddDetailRow("RESIDENT", found.ResidentName ?? "Unknown", ServiceRequestColors.PrimaryBlue);
            AddDetailRow("ISSUE DESCRIPTION", found.Description ?? "No description", ServiceRequestColors.SecondaryBlue);
            AddDetailRow("CURRENT STATUS", found.Status, headerColor);

            // BFS Graph section
            Panel graphPanel = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(600, 140),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            Label lblGraphTitle = new Label
            {
                Text = "RELATED REQUESTS (BFS Graph Traversal)",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = ServiceRequestColors.SecondaryBlue,
                BackColor = Color.Transparent,
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblGraphDesc = new Label
            {
                Text = "Requests in the same category share municipal resources:",
                Font = new Font("Segoe UI", 9),
                ForeColor = ServiceRequestColors.TextMedium,
                BackColor = Color.Transparent,
                Location = new Point(15, 38),
                AutoSize = true
            };

            Label lblGraphPath = new Label
            {
                Text = string.Join(" → ", traversal),
                Font = new Font("Consolas", 11, FontStyle.Bold),
                ForeColor = ServiceRequestColors.PrimaryBlue,
                BackColor = Color.Transparent,
                Location = new Point(15, 62),
                Size = new Size(570, 25)
            };

            Label lblGraphStats = new Label
            {
                Text = $"✓ Found {traversal.Count - 1} related request(s) | Time Complexity: O(V + E)",
                Font = new Font("Segoe UI", 8F),
                ForeColor = ServiceRequestColors.TextMedium,
                BackColor = Color.Transparent,
                Location = new Point(15, 95),
                Size = new Size(570, 35)
            };

            graphPanel.Controls.Add(lblGraphTitle);
            graphPanel.Controls.Add(lblGraphDesc);
            graphPanel.Controls.Add(lblGraphPath);
            graphPanel.Controls.Add(lblGraphStats);
            contentPanel.Controls.Add(graphPanel);

            // Close button
            Button btnClose = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = ServiceRequestColors.TextMedium,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(240, yPos + 160),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();
            contentPanel.Controls.Add(btnClose);

            detailForm.Controls.Add(contentPanel);
            detailForm.Controls.Add(headerPanel);
            detailForm.ShowDialog();
        }

        /// <summary>
        /// Show summary of all requests
        /// </summary>
        private void ShowAllRequestsDetails()
        {
            if (allRequests.Count == 0)
            {
                MessageBox.Show("No service requests found.\n\nSubmit issues via the 'Report Issues' menu to see them here.",
                    "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form summaryForm = new Form
            {
                Text = "All Requests Summary",
                Size = new Size(900, 700),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(250, 250, 250),
                FormBorderStyle = FormBorderStyle.Sizable
            };

            // Header
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = ServiceRequestColors.PrimaryBlue
            };

            Label lblSummaryTitle = new Label
            {
                Text = "ALL REQUESTS SUMMARY",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblSummarySubtitle = new Label
            {
                Text = $"Total: {allRequests.Count} request(s) | Displayed using BST in-order traversal",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(200, 220, 240),
                BackColor = Color.Transparent,
                Location = new Point(20, 45),
                AutoSize = true
            };

            headerPanel.Controls.Add(lblSummaryTitle);
            headerPanel.Controls.Add(lblSummarySubtitle);

            // Content
            RichTextBox rtbSummary = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            foreach (var req in bst.InOrder())
            {
                rtbSummary.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
                rtbSummary.SelectionColor = ServiceRequestColors.TextDark;
                rtbSummary.AppendText($"[{req.Id}] {req.ResidentName ?? "Unknown"}\n");

                rtbSummary.SelectionFont = new Font("Segoe UI", 9.5F);
                rtbSummary.SelectionColor = ServiceRequestColors.TextMedium;
                rtbSummary.AppendText($"    {req.Description ?? "No description"}\n");

                rtbSummary.SelectionFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                rtbSummary.SelectionColor = req.Status == "Completed" ? ServiceRequestColors.StatusGreen :
                                            req.Status == "In Progress" ? ServiceRequestColors.StatusOrange : ServiceRequestColors.StatusRed;
                rtbSummary.AppendText($"    Status: {req.Status}\n\n");
                rtbSummary.SelectionColor = Color.Black;
            }

            // Footer
            Panel footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White
            };

            Button btnCloseSummary = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10),
                BackColor = ServiceRequestColors.TextMedium,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 35),
                Location = new Point(385, 12),
                Cursor = Cursors.Hand
            };
            btnCloseSummary.FlatAppearance.BorderSize = 0;
            btnCloseSummary.Click += (s, e) => summaryForm.Close();

            footerPanel.Controls.Add(btnCloseSummary);

            summaryForm.Controls.Add(rtbSummary);
            summaryForm.Controls.Add(footerPanel);
            summaryForm.Controls.Add(headerPanel);
            summaryForm.ShowDialog();
        }
    }
}