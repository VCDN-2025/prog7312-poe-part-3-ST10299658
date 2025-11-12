// ============================================================
// ServiceRequest.cs - Model for Service Requests
// ============================================================
using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a service request with tracking information
    /// Implements IComparable for use in BST, AVL, and Heap structures
    /// </summary>
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        public int Id { get; set; }
        public string ResidentName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int Priority { get; set; }

        /// <summary>
        /// Constructor for creating a service request
        /// </summary>
        public ServiceRequest(int id, string residentName, string description, string status)
        {
            Id = id;
            ResidentName = residentName ?? "Unknown";
            Description = description ?? "No description";
            Status = status ?? "Pending";
            SubmittedDate = DateTime.Now;
            Priority = CalculatePriority(status);
        }

        /// <summary>
        /// Calculate priority based on status for heap operations
        /// Lower numbers = higher priority
        /// </summary>
        private int CalculatePriority(string status)
        {
            switch (status?.ToLower())
            {
                case "pending":
                    return 1; // Highest priority
                case "in progress":
                    return 2;
                case "completed":
                    return 3; // Lowest priority
                default:
                    return 2;
            }
        }

        /// <summary>
        /// Compare by ID for BST and AVL tree operations
        /// </summary>
        public int CompareTo(ServiceRequest other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// Compare by priority for heap operations
        /// </summary>
        public int CompareByPriority(ServiceRequest other)
        {
            if (other == null) return 1;
            return this.Priority.CompareTo(other.Priority);
        }

        public override string ToString()
        {
            return $"[{Id}] {ResidentName} - {Status}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ServiceRequest other)
                return this.Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}