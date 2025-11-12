using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a municipal announcement
    /// Used in Queue data structure for FIFO processing
    /// </summary>
    public class Announcement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; } // 1=Low, 2=Medium, 3=High

        public Announcement(string id, string title, string desc, DateTime date, int priority)
        {
            Id = id;
            Title = title;
            Description = desc;
            Date = date;
            Priority = priority;
        }
    }
}