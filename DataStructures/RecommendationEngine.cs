using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    public class RecommendationEngine
    {
        private Dictionary<string, int> categorySearchCount = new Dictionary<string, int>();
        private Dictionary<DateTime, int> dateSearchCount = new Dictionary<DateTime, int>();
        private Dictionary<string, int> textSearchCount = new Dictionary<string, int>();
        private int totalSearchCount = 0;

        // Main method to record any search
        public void RecordSearch(string searchText = null, string category = null, DateTime? date = null)
        {
            totalSearchCount++;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string normalizedText = searchText.ToLower().Trim();
                if (!textSearchCount.ContainsKey(normalizedText))
                    textSearchCount[normalizedText] = 0;
                textSearchCount[normalizedText]++;
            }

            if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
            {
                TrackCategorySearch(category);
            }

            if (date.HasValue)
            {
                TrackDateSearch(date.Value);
            }
        }

        // Track category searches
        public void TrackCategorySearch(string category)
        {
            if (string.IsNullOrEmpty(category)) return;
            if (category == "All Categories") return;

            if (!categorySearchCount.ContainsKey(category))
                categorySearchCount[category] = 0;
            categorySearchCount[category]++;
        }

        // Track date searches
        public void TrackDateSearch(DateTime date)
        {
            DateTime dateOnly = date.Date;
            if (!dateSearchCount.ContainsKey(dateOnly))
                dateSearchCount[dateOnly] = 0;
            dateSearchCount[dateOnly]++;
        }

        // Recommend events based on search history
        public List<Event> GetRecommendedEvents(IEnumerable<Event> allEvents, int maxRecommendations = 6)
        {
            var eventsList = allEvents.ToList();
            List<Event> recommended = new List<Event>();

            // If no searches, return upcoming high-priority events
            if (categorySearchCount.Count == 0 && dateSearchCount.Count == 0 && textSearchCount.Count == 0)
            {
                return eventsList
                    .Where(e => e.Date >= DateTime.Now)
                    .OrderByDescending(e => e.Priority)
                    .ThenBy(e => e.Date)
                    .Take(maxRecommendations)
                    .ToList();
            }

            // Score-based recommendation system
            var scoredEvents = new Dictionary<Event, double>();

            foreach (var evt in eventsList.Where(e => e.Date >= DateTime.Now))
            {
                double score = 0;

                // Category match (40 points)
                if (categorySearchCount.ContainsKey(evt.Category))
                {
                    score += categorySearchCount[evt.Category] * 40;
                }

                // Date match (30 points)
                if (dateSearchCount.ContainsKey(evt.Date.Date))
                {
                    score += dateSearchCount[evt.Date.Date] * 30;
                }

                // Text search match (30 points)
                foreach (var searchTerm in textSearchCount.Keys)
                {
                    if (evt.Title.ToLower().Contains(searchTerm) ||
                        evt.Description.ToLower().Contains(searchTerm) ||
                        evt.Location.ToLower().Contains(searchTerm))
                    {
                        score += textSearchCount[searchTerm] * 30;
                    }
                }

                // Priority bonus (10 points per priority level)
                score += evt.Priority * 10;

                // Recency bonus (closer dates get bonus)
                int daysUntilEvent = (evt.Date.Date - DateTime.Now.Date).Days;
                if (daysUntilEvent >= 0 && daysUntilEvent <= 30)
                {
                    score += (30 - daysUntilEvent) * 2; // Closer events get higher scores
                }

                if (score > 0)
                {
                    scoredEvents[evt] = score;
                }
            }

            // Get top recommendations
            recommended = scoredEvents
                .OrderByDescending(kv => kv.Value)
                .Take(maxRecommendations)
                .Select(kv => kv.Key)
                .ToList();

            // If we don't have enough recommendations, fill with high-priority upcoming events
            if (recommended.Count < maxRecommendations)
            {
                var additionalEvents = eventsList
                    .Where(e => e.Date >= DateTime.Now && !recommended.Contains(e))
                    .OrderByDescending(e => e.Priority)
                    .ThenBy(e => e.Date)
                    .Take(maxRecommendations - recommended.Count)
                    .ToList();

                recommended.AddRange(additionalEvents);
            }

            return recommended;
        }

        // Return search statistics
        public string GetSearchStatistics()
        {
            var stats = "🔍 Search Statistics:\n\n";

            if (categorySearchCount.Count > 0)
            {
                stats += "📁 Top Categories:\n";
                foreach (var kv in categorySearchCount.OrderByDescending(kv => kv.Value).Take(5))
                    stats += $"   • {kv.Key}: {kv.Value} searches\n";
                stats += "\n";
            }

            if (textSearchCount.Count > 0)
            {
                stats += "🔤 Recent Searches:\n";
                foreach (var kv in textSearchCount.OrderByDescending(kv => kv.Value).Take(5))
                    stats += $"   • \"{kv.Key}\": {kv.Value} times\n";
                stats += "\n";
            }

            if (dateSearchCount.Count > 0)
            {
                stats += "📅 Top Dates:\n";
                foreach (var kv in dateSearchCount.OrderByDescending(kv => kv.Value).Take(5))
                    stats += $"   • {kv.Key:dd MMM yyyy}: {kv.Value} searches\n";
                stats += "\n";
            }

            if (categorySearchCount.Count == 0 && dateSearchCount.Count == 0 && textSearchCount.Count == 0)
            {
                stats = "🔍 No search history yet.\n\n";
                stats += "Start searching to get personalized recommendations!\n";
                stats += "Showing trending upcoming events based on priority.";
            }
            else
            {
                stats += $"📊 Total Searches: {totalSearchCount}";
            }

            return stats;
        }

        // Helper method to check if user has search history
        public int GetTotalSearchCount()
        {
            return totalSearchCount;
        }

        // Clear all search history
        public void ClearHistory()
        {
            categorySearchCount.Clear();
            dateSearchCount.Clear();
            textSearchCount.Clear();
            totalSearchCount = 0;
        }

        // Get most searched category
        public string GetMostSearchedCategory()
        {
            if (categorySearchCount.Count == 0)
                return null;

            return categorySearchCount
                .OrderByDescending(kv => kv.Value)
                .First()
                .Key;
        }

        // Get most searched date
        public DateTime? GetMostSearchedDate()
        {
            if (dateSearchCount.Count == 0)
                return null;

            return dateSearchCount
                .OrderByDescending(kv => kv.Value)
                .First()
                .Key;
        }
    }
}