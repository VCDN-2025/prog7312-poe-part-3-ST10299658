<div align="center">
  <h1> Municipal Services App - Part 3</h1>
  <h3>Community Engagement & Events Made Simple</h3>
  
  <p>Empowering South African citizens through seamless access to local events, announcements, and personalized recommendations within a comprehensive Municipal Services platform.</p>
  
  ![C#](https://img.shields.io/badge/C%23-11.0-purple?style=for-the-badge&logo=csharp)
  ![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue?style=for-the-badge&logo=dotnet)
  ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-green?style=for-the-badge&logo=windows)
  ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-blueviolet?style=for-the-badge&logo=visualstudio)
  
  <a href="https://youtu.be/2ZMX1A2UMSY">
    <img src="https://img.shields.io/badge/Watch_Demo-YouTube-red?style=for-the-badge&logo=youtube" alt="Watch Demo on YouTube">
  </a>
</div>

---

## 📋 Table of Contents
- [Overview](#-overview)
- [Key Features](#-key-features)
- [Screenshots](#-screenshots)
- [Technology Stack](#-technology-stack)
- [Data Structures Implementation](#-data-structures-implementation)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage Guide](#-usage-guide)
- [Project Structure](#-project-structure)
- [Code Attributions](#-code-attributions)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

---
# MunicipalityApp

**Student Name:** Okuhle Nyawo  
**Student Number:** ST10299658  
**Course:** PROG7312 – Practical Assessment (Part 3)  
**Module:** Advanced Application Development  

A comprehensive Windows Forms application built with **.NET 8.0** and **SQLite** for efficient municipal issue reporting, tracking, and management. This project demonstrates the practical application of advanced data structures and algorithms to solve real-world municipal service delivery challenges.

This **Part 3** version represents the culmination of a year-long development process, incorporating sophisticated data structures, real-time status tracking, and enhanced user experience based on iterative feedback.

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [What's New in Part 3](#whats-new-in-part-3)
- [Technologies Used](#technologies-used)
- [Data Structures Implemented](#data-structures-implemented)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Architecture](#architecture)
- [Database Schema](#database-schema)
- [Screenshots](#screenshots)
- [Changelog](#changelog)
- [Future Improvements](#future-improvements)
- [Contributing](#contributing)
- [Support](#support)
- [References](#references)

---

## Overview

The **MunicipalityApp** is a desktop application designed to bridge the gap between citizens and municipal services. It enables residents to report issues such as power failures, water leaks, potholes, and waste management problems while providing municipal staff with efficient tools to track, prioritize, and resolve these issues.

**Part 3** introduces advanced computer science concepts including Binary Search Trees, Min Heaps, and Graph traversal algorithms to optimize issue management, priority handling, and service request workflows.

---

## Features
## Youtube Link
https://youtu.be/2ZMX1A2UMSY

### Core Functionality
- 🏗 **Issue Reporting**: Citizens submit detailed reports with location, category, description, and optional file attachments
- 🔍 **Service Request Status Tracking**: Real-time tracking of issues through three stages: *Pending*, *In Progress*, and *Completed*
- 📂 **File Attachments**: Upload images or supporting documents with each report
- ⚡ **Intelligent Prioritization**: Uses **Min Heap** to automatically prioritize urgent issues based on category and severity
- 🗂 **Local Events and Announcements**: Browse municipal events with advanced filtering, search, and AI-like recommendations
- 📊 **Graph-Based Dependencies**: Visualizes relationships between service departments for efficient task delegation

### User Interface
- 🖥 **Modern Windows Forms UI**: Clean, intuitive interface with organized menu navigation
- ✅ **Comprehensive Input Validation**: User-friendly error messages and field validation
- 🔄 **Real-Time Feedback**: Instant confirmation messages and automatic form reset after submissions
- 🎯 **Smart Search**: Filter events by category, date range, and priority level
- 📱 **Responsive Design**: Optimized layouts for different screen sizes

### Administrative Features
- 👨‍💼 **Staff Dashboard**: Simulated municipal staff interface for issue management
- 🔄 **Status Updates**: Staff can progress issues through workflow stages
- 📈 **Priority Management**: View and sort issues by urgency
- 🗺 **Department Relationships**: Graph visualization of inter-department dependencies

---

## What's New in Part 3

### 🚀 Major Enhancements

#### 1. Advanced Data Structures Implementation
- **Binary Search Tree (BST)**: Efficiently organizes service requests by unique identifiers for O(log n) search complexity
- **Min Heap**: Manages request prioritization ensuring critical issues (burst pipes, power outages) are addressed first
- **AVL Tree**: Self-balancing tree for optimal search and retrieval performance
- **Graph with BFS/DFS Traversal**: Represents service area dependencies and department relationships
- **Enhanced Queue System**: Manages issue workflow progression (Pending → In Progress → Completed)

#### 2. Service Request Status Tracking
- Three-stage workflow system with automatic status transitions
- Real-time status updates visible to both citizens and staff
- Timestamp tracking for each status change
- Expected completion time estimation based on priority

#### 3. Staff Management System
- Simulated staff dashboard for municipal employees
- Ability to update issue statuses and add progress notes
- Department-based issue assignment visualization
- Priority-based work queue management

#### 4. Events and Announcements Redesign
- **Stack Implementation**: Displays announcements in LIFO order (most recent first)
- **Queue Implementation**: Shows events chronologically in FIFO order
- Clear separation between announcements and events
- Improved filtering and recommendation algorithms

#### 5. Performance Optimizations
- Reduced average issue lookup time from O(n) to O(log n)
- Optimized memory usage through efficient data structure selection
- Improved UI responsiveness with dynamic data binding
- Enhanced database query performance with proper indexing

#### 6. User Experience Improvements
- Clearer button labels and navigation structure
- Enhanced tooltips and help text
- Improved error messages and validation feedback
- Fixed UI refresh issues for dynamic data updates
- Added visual status indicators and progress bars

---

## Technologies Used

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 8.0 | Application framework |
| C# | 12.0 | Primary programming language |
| Windows Forms | .NET 8.0 | Desktop UI framework |
| SQLite | 3.x | Local database storage |
| Microsoft.Data.Sqlite | Latest | SQLite ADO.NET provider |
| MSBuild | .NET 8.0 | Build automation |
| Git | 2.x | Version control |

### Design Patterns & Architecture
- **MVC Pattern**: Separation of concerns between Models, Views, and Controllers
- **Repository Pattern**: Abstracted data access layer
- **Singleton Pattern**: Database connection management
- **Factory Pattern**: Data structure instantiation

---

## Data Structures Implemented

### 1. Binary Search Tree (BST)
**Purpose**: Organize and sort service requests by unique identifiers  
**Benefits**: O(log n) search, insertion, and retrieval operations  
**Use Case**: Quick lookup of specific service requests without scanning entire lists

### 2. Min Heap
**Purpose**: Priority-based issue management  
**Benefits**: O(1) access to highest priority item, O(log n) insertion/deletion  
**Use Case**: Ensures critical issues (burst pipes, power outages) are addressed before minor requests

### 3. AVL Tree
**Purpose**: Self-balancing search tree for optimal performance  
**Benefits**: Guaranteed O(log n) operations with automatic balancing  
**Use Case**: Maintains sorted issue list while preventing tree degradation

### 4. Graph
**Purpose**: Represents relationships between service departments  
**Benefits**: Visualizes dependencies between municipal operations  
**Use Case**: Breadth-First Search (BFS) to trace service dependencies (e.g., fix pipeline before road repair)

### 5. Queue (FIFO)
**Purpose**: Event display and workflow management  
**Benefits**: Maintains chronological order  
**Use Case**: Display events in order of occurrence, manage issue workflow stages

### 6. Stack (LIFO)
**Purpose**: Announcement display  
**Benefits**: Most recent items accessible first  
**Use Case**: Show latest announcements at the top of the list

---

## Prerequisites

- **Operating System**: Windows 10 (version 1809) or later
- **Runtime**: .NET 8.0 SDK or Runtime
- **Disk Space**: 100 MB free space
- **Memory**: 2 GB RAM (recommended)
- **Display**: 1280x720 minimum resolution

---

## Installation

### Option 1: From Source Code

1. **Clone the repository**
   ```bash
   git clone https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658.git
   cd MunicipalityApp
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Build the application**
   ```bash
   dotnet build --configuration Release
   ```

4. **Run the application**
   ```bash
   dotnet run --project MunicipalityApp
   ```

### Option 2: From Release Package

1. Download the latest release from the [Releases](https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658/releases) page
2. Extract the ZIP file to your desired location
3. Run `MunicipalityApp.exe`

### First-Time Setup

The application will automatically:
- Create the SQLite database in `%AppData%\MunicipalityApp\`
- Initialize required tables and sample data
- Configure default settings

---

## Usage

### For Citizens

#### Reporting an Issue
1. Launch MunicipalityApp
2. Click **"Report Issue"** from the main menu
3. Complete the form:
   - **Location**: Enter address or area description
   - **Category**: Select from dropdown (Water, Electricity, Roads, Sanitation, Waste Management)
   - **Description**: Provide detailed description of the issue
   - **Attachment** (Optional): Click "Attach File" to add images or documents
4. Click **"Submit"**
5. Note your unique **Report Number** for future reference

#### Tracking Issue Status
1. Click **"Service Request Status"** from the main menu
2. Enter your Report Number or browse all issues
3. View current status:
   - 🟡 **Pending**: Issue logged, awaiting assignment
   - 🔵 **In Progress**: Municipal staff actively working on resolution
   - 🟢 **Completed**: Issue resolved

#### Browsing Events and Announcements
1. Click **"Local Events and Announcements"** from the main menu
2. Browse events chronologically or filter by:
   - Category (Sports, Culture, Education, Health, etc.)
   - Date range
   - Priority level
3. View AI-powered recommendations based on your interests

### For Municipal Staff

#### Accessing Staff Dashboard
1. Launch MunicipalityApp
2. Toggle **Staff Mode** from the Settings menu
3. View prioritized issue queue

#### Managing Issues
1. Select an issue from the priority queue
2. Update status:
   - Move to "In Progress" when starting work
   - Add progress notes and estimated completion time
   - Mark as "Completed" when resolved
3. Changes automatically sync to citizen view

#### Viewing Department Dependencies
1. Navigate to **"Department Relationships"**
2. View graph visualization of inter-department connections
3. Trace service dependencies using BFS traversal

---

## Architecture

### Project Structure

```
MunicipalityApp/
│
├── DataStructures/              # Custom data structure implementations
│   ├── BinarySearchTree.cs      # BST for service request storage
│   ├── AVLTree.cs               # Self-balancing tree implementation
│   ├── MinHeap.cs               # Priority queue for urgent issues
│   ├── Graph.cs                 # Department relationship graph
│   └── GraphTraversal.cs        # BFS/DFS algorithms
│
├── Models/                      # Data models
│   ├── ServiceRequest.cs        # Issue report model (implements IComparable)
│   ├── Event.cs                 # Event data model
│   └── Department.cs            # Municipal department model
│
├── Forms/                       # UI Forms
│   ├── MainForm.cs              # Main application window with MenuStrip
│   ├── ReportIssueForm.cs       # Issue reporting interface
│   ├── ServiceRequestStatusForm.cs  # Status tracking view
│   ├── LocalEventsForm.cs       # Events and announcements display
│   └── StaffDashboardForm.cs    # Staff management interface
│
├── Data/                        # Data access layer
│   ├── DataStorage.cs           # SQLite operations for issues
│   ├── EventsDataStorage.cs     # SQLite operations for events
│   └── MunicipalDB.cs           # Database initialization and management
│
├── Utils/                       # Utility classes
│   ├── ValidationHelper.cs      # Input validation
│   └── DateTimeHelper.cs        # Date/time utilities
│
├── Assets/                      # Static resources
│   └── Images/                  # Application icons and images
│
├── MunicipalityApp.csproj       # Project configuration
└── Program.cs                   # Application entry point
```

### Design Principles

- **Separation of Concerns**: Clear boundaries between UI, business logic, and data access
- **DRY (Don't Repeat Yourself)**: Reusable components and helper methods
- **Single Responsibility**: Each class has one well-defined purpose
- **Interface Segregation**: IComparable implementation for type-safe comparisons
- **Dependency Injection**: Loose coupling between components

---

## Database Schema

### Issues Table
```sql
CREATE TABLE Issues (
    Id TEXT PRIMARY KEY,
    Location TEXT NOT NULL,
    Category TEXT NOT NULL,
    Description TEXT NOT NULL,
    FilePath TEXT,
    SubmittedAt TEXT NOT NULL,
    Status TEXT NOT NULL DEFAULT 'Pending',
    UpdatedAt TEXT,
    ReportNumber TEXT NOT NULL UNIQUE,
    Priority INTEGER DEFAULT 2,
    AssignedDepartment TEXT,
    EstimatedCompletion TEXT
);

CREATE INDEX idx_status ON Issues(Status);
CREATE INDEX idx_priority ON Issues(Priority DESC);
CREATE INDEX idx_report_number ON Issues(ReportNumber);
```

### Events Table
```sql
CREATE TABLE Events (
    Id TEXT PRIMARY KEY,
    Title TEXT NOT NULL,
    Description TEXT NOT NULL,
    Date TEXT NOT NULL,
    Category TEXT NOT NULL,
    Priority INTEGER NOT NULL,
    ImagePath TEXT,
    Tags TEXT
);

CREATE INDEX idx_event_date ON Events(Date);
CREATE INDEX idx_event_category ON Events(Category);
```

### Field Descriptions

#### Issues Table
| Field | Type | Description |
|-------|------|-------------|
| Id | TEXT | GUID primary key |
| Location | TEXT | Issue location/address |
| Category | TEXT | Issue category (Water/Electricity/Roads/etc.) |
| Description | TEXT | Detailed issue description |
| FilePath | TEXT | Path to attached file (optional) |
| SubmittedAt | TEXT | ISO 8601 timestamp of submission |
| Status | TEXT | Current status (Pending/In Progress/Completed) |
| UpdatedAt | TEXT | Last status update timestamp |
| ReportNumber | TEXT | Unique human-readable identifier |
| Priority | INTEGER | Priority level (1=High, 2=Medium, 3=Low) |
| AssignedDepartment | TEXT | Department handling the issue |
| EstimatedCompletion | TEXT | Estimated resolution date |

---

## Screenshots

### Main Application Window
![Main Window](assets/muncipality%20app.png)
*Clean, intuitive main interface with organized menu navigation*

### Service Request Status Tracking
*Real-time status updates showing issue progression through workflow stages*

### Staff Dashboard
*Priority-based issue queue for municipal staff with filtering options*

---

## Changelog

### Version 3.0.0 – Part 3 (Current)
**Release Date**: November 12, 2025

#### ✨ New Features
- Implemented Binary Search Tree for efficient service request organization
- Added Min Heap for priority-based issue management
- Integrated Graph structure with BFS/DFS traversal for department dependencies
- Created AVL Tree for self-balancing search operations
- Developed staff dashboard with simulated management capabilities
- Added three-stage status tracking (Pending → In Progress → Completed)

#### 🔧 Improvements
- Enhanced Events and Announcements page with separate Stack and Queue implementations
- Improved UI data binding with dynamic refresh mechanism
- Optimized search performance from O(n) to O(log n)
- Added timestamp tracking for status changes
- Implemented IComparable interface for ServiceRequest model
- Enhanced input validation and error messaging

#### 🐛 Bug Fixes
- Fixed UI refresh issues after data insertion/deletion
- Resolved compatibility issues with custom classes in generic data structures
- Corrected event and announcement display separation
- Fixed status update logic for workflow progression

#### 📚 Documentation
- Updated README with comprehensive Part 3 documentation
- Added data structure implementation explanations
- Included architecture diagrams and database schema
- Enhanced code comments and inline documentation

### Version 2.0.1
**Release Date**: October 2025

#### 🐛 Bug Fixes
- Fixed SQLite schema issue: Modified EventsDataStorage.cs to properly handle Tags column
- Updated Service Status message in MainForm.cs

### Version 2.0.0 – Part 2
**Release Date**: September 2025

#### ✨ New Features
- Added Local Events and Announcements feature
- Implemented advanced data structures (SortedDictionary, Dictionary, HashSet, PriorityQueue)
- Enhanced main menu with organized MenuStrip
- Added event search and filtering capabilities
- Implemented AI-like recommendation system

### Version 1.0.0 – Part 1 (Initial Release)
**Release Date**: August 2025

#### ✨ Initial Features
- Core issue reporting functionality
- SQLite database integration
- File attachment support
- Input validation and error handling
- Unique report number generation

---

## Future Improvements

### Short-Term Enhancements
- 🔐 **User Authentication**: Add login system for citizens and staff
- 📧 **Email Notifications**: Send status updates to issue reporters
- 📱 **SMS Alerts**: Critical issue notifications via SMS
- 🖨 **PDF Report Generation**: Printable issue reports and statistics

### Medium-Term Goals
- 🌐 **Web API Integration**: RESTful API for mobile app connectivity
- ☁ **Cloud Synchronization**: Azure/AWS integration for multi-device access
- 📊 **Data Analytics Dashboard**: Power BI integration for management insights
- 🗺 **GIS Mapping**: Interactive map showing issue locations
- 📈 **Performance Metrics**: Track department response times and resolution rates

### Long-Term Vision
- 📱 **Mobile Companion App**: Android/iOS apps using .NET MAUI
- 🤖 **AI-Powered Chatbot**: Azure Cognitive Services for issue reporting assistance
- 🔮 **Predictive Analytics**: Machine learning to predict issue hotspots
- 🌍 **Multi-Language Support**: Localization for South Africa's 11 official languages
- ♿ **Accessibility Features**: Screen reader support and enhanced accessibility

---

## Contributing

Contributions are welcome! Please follow these guidelines:

### How to Contribute

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/AmazingFeature
   ```
3. **Commit your changes**
   ```bash
   git commit -m 'Add some AmazingFeature'
   ```
4. **Push to the branch**
   ```bash
   git push origin feature/AmazingFeature
   ```
5. **Open a Pull Request**

### Development Guidelines

- Follow [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Write unit tests for new features
- Update documentation for API changes
- Ensure backward compatibility with .NET 8.0
- Add XML documentation comments for public methods
- Test on Windows 10 and Windows 11

### Code Review Process

All submissions require:
- Passing all existing unit tests
- Code review by at least one maintainer
- Updated documentation
- No breaking changes without discussion

---

## Support

### Getting Help

- 📖 **Documentation**: Check the [Wiki](https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658/wiki)
- 🐛 **Bug Reports**: [Open an issue](https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658/issues)
- 💬 **Discussions**: [GitHub Discussions](https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658/discussions)
- 📧 **Email**: support@municipalityapp.com

### Frequently Asked Questions

**Q: Where is my data stored?**  
A: The SQLite database is stored in `%AppData%\MunicipalityApp\municipal.db`

**Q: Can I use this on macOS or Linux?**  
A: Currently Windows-only due to Windows Forms. Future versions may use Avalonia UI for cross-platform support.

**Q: How do I backup my data?**  
A: Copy the database file from `%AppData%\MunicipalityApp\` to a safe location.

**Q: Is my personal information secure?**  
A: Data is stored locally on your machine. For production use, implement proper encryption and authentication.

---

## References

- Beck, K. et al. (2001) *Manifesto for Agile Software Development*. Available at: https://agilemanifesto.org/ (Accessed: 11 November 2025)

- Bonsón, E. (2012) 'Local e-Government and Transparency: Public Administrations and Citizen Engagement in the Digital Era', *International Journal of Public Administration*, 35(5), pp. 315–325

- Cormen, T.H. et al. (2009) *Introduction to Algorithms*. 3rd edn. Cambridge, MA: The MIT Press

- Department of Cooperative Governance (2009) *Integrated Development Planning Framework*. Pretoria: Government of South Africa

- Goldstuck, A. (2019) *The State of ICT in South African Municipalities*. Johannesburg: World Wide Worx

---

## License

This project is developed as part of academic coursework for PROG7312 at Varsity College.

**Academic Use Only** - Not licensed for commercial distribution.

---

---

**© 2025 Okuhle Nyawo | Student Number: ST10299658**  
*Developed as part of PROG7312 – Advanced Application Development*

**Project Timeline**: August 2025 - November 2025  
**GitHub Repository**: [prog7312-poe-part-3-ST10299658](https://github.com/VCDN-2025/prog7312-poe-part-3-ST10299658)


