using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class GraphTraversal
    {
        public static List<string> BFS(Graph graph, string start)
        {
            var visited = new List<string>();
            var queue = new Queue<string>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string vertex = queue.Dequeue();
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    foreach (var neighbor in graph.GetNeighbors(vertex))
                        queue.Enqueue(neighbor);
                }
            }

            return visited;
        }
    }
}
