using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class Graph
    {
        private readonly Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        public void AddVertex(string vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
                adjacencyList[vertex] = new List<string>();
        }

        public void AddEdge(string vertex1, string vertex2)
        {
            AddVertex(vertex1);
            AddVertex(vertex2);

            adjacencyList[vertex1].Add(vertex2);
            adjacencyList[vertex2].Add(vertex1);
        }

        public List<string> GetNeighbors(string vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
                return adjacencyList[vertex];
            return new List<string>();
        }

        public IEnumerable<string> Vertices
        {
            get { return adjacencyList.Keys; }
        }
    }
}
