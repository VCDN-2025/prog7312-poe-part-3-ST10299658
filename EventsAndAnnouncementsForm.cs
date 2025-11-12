using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp
{
    public partial class EventsAndAnnouncementsForm : Form
    {
        // Data structures
        private CustomSortedDictionary<string, Event> eventsByDate;
        private CustomDictionary<string, Event> eventsById;
        private CustomDictionary<string, Announcement> announcementsById;
        private CustomSet<string> categories;
        private CustomSet<string> uniqueDates;
        private CustomQueue<Event> recentlyViewedEvents;
        private CustomQueue<Announcement> recentlyViewedAnnouncements;
        private CustomPriorityQueue<Event> upcomingEvents;

        private RecommendationEngine recommendationEngine;

        // UI Components
        private Panel mainPanel;
        private TabControl tabControl;
        private Button btnBack;
        private DataGridView dgvEvents;
        private DataGridView dgvAnnouncements;

        // Refined Blue Color Palette
        private static readonly Color PrimaryBlue = Color.FromArgb(13, 71, 161);
        private static readonly Color SecondaryBlue = Color.FromArgb(25, 118, 210);
        private static readonly Color LightBlue = Color.FromArgb(66, 165, 245);
        private static readonly Color AccentBlue = Color.FromArgb(41, 182, 246);
        private static readonly Color DarkNavy = Color.FromArgb(21, 56, 105);
        private static readonly Color SoftBlue = Color.FromArgb(227, 242, 253);
        private static readonly Color WhiteSmoke = Color.FromArgb(250, 250, 250);
        private static readonly Color TextDark = Color.FromArgb(38, 50, 56);
        private static readonly Color TextMedium = Color.FromArgb(84, 110, 122);
        private static readonly Color BorderLight = Color.FromArgb(207, 216, 220);
        private static readonly Color SuccessGreen = Color.FromArgb(67, 160, 71);
        private static readonly Color WarningAmber = Color.FromArgb(251, 140, 0);
        private static readonly Color ErrorRed = Color.FromArgb(229, 57, 53);

        public EventsAndAnnouncementsForm()
        {
            InitializeComponent();
            InitializeDataStructures();
            LoadSampleData();
            BuildUI();
        }

        private void InitializeDataStructures()
        {
            eventsByDate = new CustomSortedDictionary<string, Event>();
            eventsById = new CustomDictionary<string, Event>();
            announcementsById = new CustomDictionary<string, Announcement>();
            categories = new CustomSet<string>();
            uniqueDates = new CustomSet<string>();
            recentlyViewedEvents = new CustomQueue<Event>();
            recentlyViewedAnnouncements = new CustomQueue<Announcement>();
            upcomingEvents = new CustomPriorityQueue<Event>();
            recommendationEngine = new RecommendationEngine();
        }

        private void LoadSampleData()
        {
            var events = new[]
            {
                new Event("E001", "Community Clean-Up Day", "Community", new DateTime(2025, 11, 20), "City Park", "Join us for a day of community service and environmental care", "", 2),
                new Event("E002", "Municipal Budget Meeting", "Government", new DateTime(2025, 11, 25), "City Hall", "Annual budget review and public input session", "", 3),
                new Event("E003", "Free Health Screening", "Health", new DateTime(2025, 11, 22), "Community Center", "Free health checks for all residents", "", 2),
                new Event("E004", "Youth Sports Tournament", "Sports", new DateTime(2025, 12, 5), "Sports Complex", "Annual youth soccer tournament", "", 1),
                new Event("E005", "Arts & Culture Festival", "Culture", new DateTime(2025, 12, 12), "Town Square", "Celebrate local artists and performers", "", 3),
                new Event("E006", "Job Fair", "Employment", new DateTime(2025, 11, 28), "Convention Center", "Meet local employers and explore opportunities", "", 2),
                new Event("E007", "Public Safety Workshop", "Safety", new DateTime(2025, 12, 3), "Police Station", "Community safety and crime prevention tips", "", 2)
            };

            foreach (var evt in events)
            {
                string dateKey = evt.Date.ToString("yyyy-MM-dd");
                eventsByDate.Add(dateKey, evt);
                eventsById.Add(evt.EventId, evt);
                categories.Add(evt.Category);
                uniqueDates.Add(dateKey);

                if (evt.Date >= DateTime.Now)
                {
                    upcomingEvents.Enqueue(evt);
                }
            }

            var announcements = new[]
            {
                new Announcement("A001", "Emergency Power Outage Scheduled", "Scheduled maintenance in Zone 5 will cause power interruption from 2AM to 6AM on November 15th. Please prepare accordingly.", new DateTime(2025, 11, 15), 3),
                new Announcement("A002", "Water Quality Notice", "Recent tests show water quality is excellent. Annual water quality report available at City Hall.", new DateTime(2025, 11, 10), 1),
                new Announcement("A003", "New Recycling Program Launch", "Starting December 1st, we're introducing expanded recycling. Blue bins will be distributed to all households.", new DateTime(2025, 12, 1), 2),
                new Announcement("A004", "Road Closure - Main Street", "Main Street will be closed for resurfacing November 18-22. Please use alternate routes. Expect delays.", new DateTime(2025, 11, 18), 3),
                new Announcement("A005", "Library Extended Hours", "Public library now open until 9PM on weekdays and 6PM on weekends. More time for community learning!", new DateTime(2025, 11, 5), 1),
                new Announcement("A006", "Property Tax Deadline Approaching", "Property tax payments are due by November 30th. Pay online or at City Hall. Late fees apply after deadline.", new DateTime(2025, 11, 30), 3),
                new Announcement("A007", "New Bus Route Added", "Route 47 now services the Industrial Park area. Weekday service from 6AM to 8PM. Full schedule at transit center.", new DateTime(2025, 11, 8), 2)
            };

            foreach (var ann in announcements)
            {
                announcementsById.Add(ann.Id, ann);
            }
        }

        private void BuildUI()
        {
            this.Text = "Local Events & Announcements";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = WhiteSmoke;
            this.Font = new Font("Segoe UI", 9.75F);

            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(0)
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            Panel header = CreateHeader();
            mainLayout.Controls.Add(header, 0, 0);

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                Padding = new Point(15, 6)
            };
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;

            TabPage eventsTab = new TabPage("  Events  ");
            eventsTab.BackColor = WhiteSmoke;
            eventsTab.Controls.Add(CreateEventsTab());

            TabPage announcementsTab = new TabPage("  Announcements  ");
            announcementsTab.BackColor = WhiteSmoke;
            announcementsTab.Controls.Add(CreateAnnouncementsTab());

            tabControl.TabPages.Add(eventsTab);
            tabControl.TabPages.Add(announcementsTab);

            mainLayout.Controls.Add(tabControl, 0, 1);

            Panel footer = CreateFooter();
            mainLayout.Controls.Add(footer, 0, 2);

            this.Controls.Add(mainLayout);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabCtrl = (TabControl)sender;
            TabPage page = tabCtrl.TabPages[e.Index];
            Rectangle bounds = e.Bounds;

            bool isSelected = (e.Index == tabCtrl.SelectedIndex);

            using (SolidBrush bgBrush = new SolidBrush(isSelected ? PrimaryBlue : Color.FromArgb(230, 230, 230)))
            {
                e.Graphics.FillRectangle(bgBrush, bounds);
            }

            using (SolidBrush textBrush = new SolidBrush(isSelected ? Color.White : TextMedium))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(page.Text, tabCtrl.Font, textBrush, bounds, sf);
            }

            if (isSelected)
            {
                using (Pen underline = new Pen(AccentBlue, 3))
                {
                    e.Graphics.DrawLine(underline, bounds.Left, bounds.Bottom - 2, bounds.Right, bounds.Bottom - 2);
                }
            }
        }

        private Panel CreateHeader()
        {
            Panel header = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0) };
            header.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    header.ClientRectangle, PrimaryBlue, DarkNavy, LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, header.ClientRectangle);
                }
            };

            btnBack = new Button
            {
                Text = "← Back",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                BackColor = Color.FromArgb(180, 255, 255, 255),
                ForeColor = DarkNavy,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 32),
                Location = new Point(20, 24),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => this.Close();

            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.White;
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(180, 255, 255, 255);

            Label lblTitle = new Label
            {
                Text = "LOCAL EVENTS & ANNOUNCEMENTS",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1400, 40),
                Location = new Point(0, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            header.Controls.Add(btnBack);
            header.Controls.Add(lblTitle);

            return header;
        }

        private Panel CreateEventsTab()
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = WhiteSmoke };

            Panel searchPanel = CreateSearchPanel();
            panel.Controls.Add(searchPanel);

            // Create DataGridView for events
            dgvEvents = new DataGridView
            {
                Location = new Point(20, 130),
                Size = new Size(1340, 590),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                GridColor = BorderLight,
                RowTemplate = { Height = 40 }
            };

            // Style the headers
            dgvEvents.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            dgvEvents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEvents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEvents.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryBlue;
            dgvEvents.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvEvents.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvEvents.ColumnHeadersHeight = 45;

            // Style the rows
            dgvEvents.DefaultCellStyle.BackColor = Color.White;
            dgvEvents.DefaultCellStyle.ForeColor = TextDark;
            dgvEvents.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvEvents.DefaultCellStyle.SelectionBackColor = SoftBlue;
            dgvEvents.DefaultCellStyle.SelectionForeColor = TextDark;
            dgvEvents.DefaultCellStyle.Padding = new Padding(5);

            dgvEvents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            dgvEvents.CellDoubleClick += DgvEvents_CellDoubleClick;

            panel.Controls.Add(dgvEvents);

            // Load initial data
            DisplayEvents(eventsById.GetAllValues());

            return panel;
        }

        private void DisplayEvents(System.Collections.Generic.IEnumerable<Event> events)
        {
            var eventList = events.OrderBy(e => e.Date).Select(e => new
            {
                Title = e.Title,
                Category = e.Category,
                Date = e.Date.ToString("MMM dd, yyyy"),
                Location = e.Location,
                Description = e.Description,
                Priority = e.Priority == 1 ? "Low" : e.Priority == 2 ? "Medium" : "High"
            }).ToList();

            dgvEvents.DataSource = eventList;

            // Customize column widths
            if (dgvEvents.Columns.Count > 0)
            {
                dgvEvents.Columns["Title"].Width = 280;
                dgvEvents.Columns["Category"].Width = 140;
                dgvEvents.Columns["Date"].Width = 140;
                dgvEvents.Columns["Location"].Width = 200;
                dgvEvents.Columns["Description"].Width = 420;
                dgvEvents.Columns["Priority"].Width = 100;
            }
        }

        private void DgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvEvents.Rows[e.RowIndex];
                string title = row.Cells["Title"].Value.ToString();

                var evt = eventsById.GetAllValues().FirstOrDefault(ev => ev.Title == title);
                if (evt != null)
                {
                    ShowEventDetails(evt);
                }
            }
        }

        private Panel CreateSearchPanel()
        {
            Panel panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1380, 120),
                BackColor = Color.White,
                Padding = new Padding(20, 12, 20, 12)
            };

            panel.Paint += (s, pe) =>
            {
                using (Pen borderPen = new Pen(BorderLight, 1))
                {
                    pe.Graphics.DrawLine(borderPen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
                }
            };

            Label lblSearchTitle = new Label
            {
                Text = "Search & Filter",
             //   Font = new Font("Segoe UI", 11, FontStyle.Semibold),
                ForeColor = TextDark,
                Location = new Point(20, 12),
                AutoSize = true
            };

            TextBox txtSearch = CreateStyledTextBox("Search events...", new Point(20, 40), 250);

            ComboBox cmbCategory = CreateStyledComboBox(new Point(285, 40), 180);
            cmbCategory.Items.Add("All Categories");
            foreach (var cat in categories.ToList().OrderBy(c => c))
            {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;

            DateTimePicker dtpDate = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10),
                Width = 180,
                Location = new Point(480, 40),
                Format = DateTimePickerFormat.Short
            };

            ComboBox cmbSort = CreateStyledComboBox(new Point(675, 40), 160);
            cmbSort.Items.AddRange(new string[] { "Sort by Date", "Sort by Category", "Sort by Title" });
            cmbSort.SelectedIndex = 0;

            Button btnSearch = CreateActionButton("Search", SecondaryBlue, new Point(20, 78), 110);
            Button btnClearFilters = CreateActionButton("Clear", TextMedium, new Point(140, 78), 110);
            Button btnShowRecommendations = CreateActionButton("Recommendations", SuccessGreen, new Point(260, 78), 160);

            Label lblResultCount = new Label
            {
                Text = $"{eventsById.GetAllValues().Count} events found",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = TextMedium,
                Location = new Point(850, 85),
                AutoSize = true
            };

            // Search button click handler
            btnSearch.Click += (s, e) =>
            {
                var allEvents = eventsById.GetAllValues();
                var filteredEvents = allEvents.AsEnumerable();

                string searchText = txtSearch.Text;
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search events...")
                {
                    filteredEvents = filteredEvents.Where(ev =>
                        ev.Title.ToLower().Contains(searchText.ToLower()) ||
                        ev.Description.ToLower().Contains(searchText.ToLower()));

                    recommendationEngine.RecordSearch(searchText);
                }

                if (cmbCategory.SelectedIndex > 0)
                {
                    string selectedCategory = cmbCategory.SelectedItem.ToString();
                    filteredEvents = filteredEvents.Where(ev => ev.Category == selectedCategory);
                }

                filteredEvents = filteredEvents.Where(ev => ev.Date.Date >= dtpDate.Value.Date);

                switch (cmbSort.SelectedIndex)
                {
                    case 0:
                        filteredEvents = filteredEvents.OrderBy(ev => ev.Date);
                        break;
                    case 1:
                        filteredEvents = filteredEvents.OrderBy(ev => ev.Category).ThenBy(ev => ev.Date);
                        break;
                    case 2:
                        filteredEvents = filteredEvents.OrderBy(ev => ev.Title);
                        break;
                }

                var resultList = filteredEvents.ToList();
                lblResultCount.Text = $"{resultList.Count} events found";
                DisplayEvents(resultList);
            };

            btnClearFilters.Click += (s, e) =>
            {
                txtSearch.Text = "Search events...";
                txtSearch.ForeColor = Color.Gray;
                cmbCategory.SelectedIndex = 0;
                dtpDate.Value = DateTime.Now;
                cmbSort.SelectedIndex = 0;

                var allEvents = eventsById.GetAllValues();
                lblResultCount.Text = $"{allEvents.Count} events found";
                DisplayEvents(allEvents);
            };

            btnShowRecommendations.Click += BtnShowRecommendations_Click;

            panel.Controls.AddRange(new Control[] {
                lblSearchTitle, txtSearch, cmbCategory, dtpDate, cmbSort,
                btnSearch, btnClearFilters, btnShowRecommendations, lblResultCount
            });

            return panel;
        }

        private Panel CreateAnnouncementsTab()
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = WhiteSmoke };

            Label title = new Label
            {
                Text = "OFFICIAL ANNOUNCEMENTS",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = PrimaryBlue,
                Location = new Point(25, 15),
                AutoSize = true
            };
            panel.Controls.Add(title);

            Label subtitle = new Label
            {
                Text = "Important updates from your municipal services",
                Font = new Font("Segoe UI", 10),
                ForeColor = TextMedium,
                Location = new Point(25, 45),
                AutoSize = true
            };
            panel.Controls.Add(subtitle);

            // Create DataGridView for announcements
            dgvAnnouncements = new DataGridView
            {
                Location = new Point(25, 85),
                Size = new Size(1330, 630),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                GridColor = BorderLight,
                RowTemplate = { Height = 50 }
            };

            dgvAnnouncements.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryBlue;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvAnnouncements.ColumnHeadersHeight = 45;

            dgvAnnouncements.DefaultCellStyle.BackColor = Color.White;
            dgvAnnouncements.DefaultCellStyle.ForeColor = TextDark;
            dgvAnnouncements.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvAnnouncements.DefaultCellStyle.SelectionBackColor = SoftBlue;
            dgvAnnouncements.DefaultCellStyle.SelectionForeColor = TextDark;
            dgvAnnouncements.DefaultCellStyle.Padding = new Padding(5);
            dgvAnnouncements.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvAnnouncements.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            dgvAnnouncements.CellDoubleClick += DgvAnnouncements_CellDoubleClick;

            var allAnnouncements = announcementsById.GetAllValues()
                .OrderByDescending(a => a.Priority)
                .ThenByDescending(a => a.Date)
                .Select(a => new
                {
                    Title = a.Title,
                    Description = a.Description,
                    Date = a.Date.ToString("MMM dd, yyyy"),
                    Priority = a.Priority >= 3 ? "URGENT" : a.Priority == 2 ? "IMPORTANT" : "INFO"
                }).ToList();

            dgvAnnouncements.DataSource = allAnnouncements;

            if (dgvAnnouncements.Columns.Count > 0)
            {
                dgvAnnouncements.Columns["Title"].Width = 350;
                dgvAnnouncements.Columns["Description"].Width = 700;
                dgvAnnouncements.Columns["Date"].Width = 150;
                dgvAnnouncements.Columns["Priority"].Width = 120;
            }

            panel.Controls.Add(dgvAnnouncements);

            return panel;
        }

        private void DgvAnnouncements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAnnouncements.Rows[e.RowIndex];
                string title = row.Cells["Title"].Value.ToString();

                var ann = announcementsById.GetAllValues().FirstOrDefault(a => a.Title == title);
                if (ann != null)
                {
                    ShowAnnouncementDetails(ann);
                }
            }
        }

        private void ShowAnnouncementDetails(Announcement ann)
        {
            if (recentlyViewedAnnouncements.Count >= 5)
            {
                recentlyViewedAnnouncements.Dequeue();
            }
            recentlyViewedAnnouncements.Enqueue(ann);

            Form detailForm = new Form
            {
                Text = "Announcement Details",
                Size = new Size(650, 480),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = WhiteSmoke,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Color headerColor = ann.Priority >= 3 ? ErrorRed : ann.Priority == 2 ? WarningAmber : SuccessGreen;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = headerColor
            };

            Label lblDetailTitle = new Label
            {
                Text = ann.Title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(590, 60),
                Location = new Point(30, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblDetailTitle);

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 20),
                AutoScroll = true,
                BackColor = Color.White
            };

            Label lblDateHeader = new Label
            {
                Text = "EFFECTIVE DATE",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = headerColor,
                Location = new Point(10, 15),
                AutoSize = true
            };

            Label lblDateValue = new Label
            {
                Text = ann.Date.ToString("dddd, MMMM dd, yyyy"),
                Font = new Font("Segoe UI", 11),
                ForeColor = TextDark,
                Location = new Point(10, 38),
                AutoSize = true
            };

            Label lblPriorityHeader = new Label
            {
                Text = "PRIORITY LEVEL",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = headerColor,
                Location = new Point(10, 75),
                AutoSize = true
            };

            Label lblPriorityValue = new Label
            {
                Text = ann.Priority >= 3 ? "URGENT - Immediate Attention Required" :
                       ann.Priority == 2 ? "IMPORTANT - Please Review" : "INFORMATIONAL",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = TextDark,
                Location = new Point(10, 98),
                Size = new Size(550, 30)
            };

            Panel descPanel = new Panel
            {
                Location = new Point(10, 140),
                Size = new Size(550, 140),
                BackColor = SoftBlue
            };

            Label lblDescTitle = new Label
            {
                Text = "DETAILS",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = PrimaryBlue,
                BackColor = Color.Transparent,
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblDesc = new Label
            {
                Text = ann.Description,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
                Location = new Point(15, 38),
                Size = new Size(520, 90)
            };

            descPanel.Controls.Add(lblDescTitle);
            descPanel.Controls.Add(lblDesc);

            Button btnClose = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = headerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(220, 300),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();

            contentPanel.Controls.Add(lblDateHeader);
            contentPanel.Controls.Add(lblDateValue);
            contentPanel.Controls.Add(lblPriorityHeader);
            contentPanel.Controls.Add(lblPriorityValue);
            contentPanel.Controls.Add(descPanel);
            contentPanel.Controls.Add(btnClose);

            detailForm.Controls.Add(contentPanel);
            detailForm.Controls.Add(headerPanel);
            detailForm.ShowDialog();
        }

        private Color GetCategoryColor(string category)
        {
            switch (category)
            {
                case "Community": return Color.FromArgb(102, 187, 106);
                case "Government": return Color.FromArgb(66, 165, 245);
                case "Infrastructure": return Color.FromArgb(251, 140, 0);
                case "Health": return Color.FromArgb(236, 64, 122);
                case "Sports": return Color.FromArgb(171, 71, 188);
                case "Culture": return Color.FromArgb(255, 112, 67);
                case "Environment": return Color.FromArgb(102, 187, 106);
                case "Employment": return Color.FromArgb(92, 107, 192);
                case "Safety": return Color.FromArgb(239, 83, 80);
                case "Education": return Color.FromArgb(41, 182, 246);
                default: return SecondaryBlue;
            }
        }

        private TextBox CreateStyledTextBox(string placeholder, Point location, int width)
        {
            TextBox txt = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Width = width,
                Location = location,
                Text = placeholder,
                ForeColor = Color.Gray,
                BorderStyle = BorderStyle.FixedSingle
            };
            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = TextDark;
                }
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
            return txt;
        }

        private ComboBox CreateStyledComboBox(Point location, int width)
        {
            return new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Width = width,
                Location = location,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Standard
            };
        }

        private Button CreateActionButton(string text, Color color, Point location, int width)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = width,
                Height = 34,
                Location = location,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            Color hoverColor = ControlPaint.Light(color, 0.1f);
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = color;

            return btn;
        }

        private Panel CreateFooter()
        {
            Panel footer = new Panel { Dock = DockStyle.Fill, BackColor = DarkNavy };

            Label lblFooter = new Label
            {
                Text = "📞 0800-123-456  |  ✉️ events@municipality.gov.za  |  © 2025 Municipal Services",
                ForeColor = Color.FromArgb(200, 220, 240),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };
            footer.Controls.Add(lblFooter);

            return footer;
        }

        private void BtnShowRecommendations_Click(object sender, EventArgs e)
        {
            var allEvents = eventsById.GetAllValues();
            var recommendations = recommendationEngine.GetRecommendedEvents(allEvents, 6);
            bool hasSearchHistory = recommendationEngine.GetTotalSearchCount() > 0;

            Form recForm = new Form
            {
                Text = "Event Recommendations",
                Size = new Size(900, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = WhiteSmoke,
                FormBorderStyle = FormBorderStyle.Sizable,
                MaximizeBox = true
            };

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = SuccessGreen
            };

            Label lblRecTitle = new Label
            {
                Text = "RECOMMENDED FOR YOU",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblRecSubtitle = new Label
            {
                Text = hasSearchHistory ? "Based on your search history and interests" : "Popular upcoming events",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(230, 255, 230),
                BackColor = Color.Transparent,
                Location = new Point(20, 45),
                AutoSize = true
            };

            headerPanel.Controls.Add(lblRecTitle);
            headerPanel.Controls.Add(lblRecSubtitle);

            DataGridView dgvRecommendations = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                GridColor = BorderLight,
                RowTemplate = { Height = 45 }
            };

            dgvRecommendations.ColumnHeadersDefaultCellStyle.BackColor = SecondaryBlue;
            dgvRecommendations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecommendations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRecommendations.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvRecommendations.ColumnHeadersHeight = 40;

            dgvRecommendations.DefaultCellStyle.BackColor = Color.White;
            dgvRecommendations.DefaultCellStyle.ForeColor = TextDark;
            dgvRecommendations.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRecommendations.DefaultCellStyle.SelectionBackColor = SoftBlue;
            dgvRecommendations.DefaultCellStyle.SelectionForeColor = TextDark;
            dgvRecommendations.DefaultCellStyle.Padding = new Padding(5);

            dgvRecommendations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            var recList = recommendations.Select(ey => new
            {
                Title = ey.Title,
                Category = ey.Category,
                Date = ey.Date.ToString("MMM dd, yyyy"),
                Location = ey.Location
            }).ToList();

            dgvRecommendations.DataSource = recList;

            if (dgvRecommendations.Columns.Count > 0)
            {
                dgvRecommendations.Columns["Title"].Width = 280;
                dgvRecommendations.Columns["Category"].Width = 120;
                dgvRecommendations.Columns["Date"].Width = 130;
                dgvRecommendations.Columns["Location"].Width = 200;
            }

            dgvRecommendations.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    var row = dgvRecommendations.Rows[ev.RowIndex];
                    string title = row.Cells["Title"].Value.ToString();
                    var evt = recommendations.FirstOrDefault(ey => ey.Title == title);
                    if (evt != null)
                    {
                        ShowEventDetails(evt);
                    }
                }
            };

            Panel footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Label lblStats = new Label
            {
                Text = recommendationEngine.GetSearchStatistics(),
                Font = new Font("Segoe UI", 9F),
                ForeColor = TextMedium,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Button btnCloseRec = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10),
                BackColor = TextMedium,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point(770, 12),
                Cursor = Cursors.Hand
            };
            btnCloseRec.FlatAppearance.BorderSize = 0;
            btnCloseRec.Click += (s, ev) => recForm.Close();

            footerPanel.Controls.Add(lblStats);
            footerPanel.Controls.Add(btnCloseRec);

            recForm.Controls.Add(dgvRecommendations);
            recForm.Controls.Add(footerPanel);
            recForm.Controls.Add(headerPanel);
            recForm.ShowDialog();
        }

        private void ShowEventDetails(Event evt)
        {
            if (recentlyViewedEvents.Count >= 5)
            {
                recentlyViewedEvents.Dequeue();
            }
            recentlyViewedEvents.Enqueue(evt);

            Form detailForm = new Form
            {
                Text = "Event Details",
                Size = new Size(650, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = WhiteSmoke,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = GetCategoryColor(evt.Category)
            };

            Label lblDetailTitle = new Label
            {
                Text = evt.Title,
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(590, 70),
                Location = new Point(30, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(lblDetailTitle);

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
                    Size = new Size(550, 55),
                    BackColor = SoftBlue
                };

                Label lblLabel = new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = color,
                    BackColor = Color.Transparent,
                    Location = new Point(15, 10),
                    Size = new Size(520, 18)
                };

                Label lblValue = new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = TextDark,
                    BackColor = Color.Transparent,
                    Location = new Point(15, 30),
                    Size = new Size(520, 20)
                };

                row.Controls.Add(lblLabel);
                row.Controls.Add(lblValue);
                contentPanel.Controls.Add(row);
                yPos += 65;
            }

            AddDetailRow("CATEGORY", evt.Category, GetCategoryColor(evt.Category));
            AddDetailRow("DATE & TIME", evt.Date.ToString("dddd, MMMM dd, yyyy"), SecondaryBlue);
            AddDetailRow("LOCATION", evt.Location, WarningAmber);

            Panel descPanel = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(550, 120),
                BackColor = SoftBlue
            };

            Label lblDescTitle = new Label
            {
                Text = "DESCRIPTION",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = SuccessGreen,
                BackColor = Color.Transparent,
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblDesc = new Label
            {
                Text = evt.Description,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
                Location = new Point(15, 35),
                Size = new Size(520, 75)
            };

            descPanel.Controls.Add(lblDescTitle);
            descPanel.Controls.Add(lblDesc);
            contentPanel.Controls.Add(descPanel);

            Button btnClose = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = TextMedium,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(220, yPos + 140),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();
            contentPanel.Controls.Add(btnClose);

            detailForm.Controls.Add(contentPanel);
            detailForm.Controls.Add(headerPanel);
            detailForm.ShowDialog();
        }

        private void EventsAndAnnouncementsForm_Load(object sender, EventArgs e)
        {
        }
    }
}