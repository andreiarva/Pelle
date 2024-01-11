using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProblemsWF
{
    static class Graph
    {
        public static List<Vertex> _vertices = new List<Vertex>();
        public static List<Edge> _edges = new List<Edge>();

        public static string DFS()
        {
            int[,] matrix = AdjacencyMatrix();
            return DfsHelper(matrix, _vertices[0]);
        }

        public static string BFS()
        {
            return BfsHelper(_edges, _vertices[0]);
        }

        public static string DfsHelper(int[,] graph, Vertex start)
        {
            string path = "";
            bool[] visited = new bool[_vertices.Count];

            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(start);

            while (stack.Count != 0)
            {
                Vertex current = stack.Pop();
                visited[current.Index] = true;

               path+= "Node: " + current.Index+"\n";
                for (int j = graph.GetLength(0) - 1; j >= 0; j--)
                {
                    if (graph[current.Index, j] != 0 && !visited[j])
                    {
                        stack.Push(_vertices[j]);
                    }
                }
            }
            return path;
        }


        public static string BfsHelper(List<Edge> edges, Vertex start)
        {
            string path = "";
            bool[] visited = new bool[_vertices.Count];

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                Vertex current = queue.Dequeue();
                visited[current.Index] = true;

                path += "Node: " + current.Index + "\n";

                // Traverse through edges to find neighbors
                foreach (Edge edge in edges)
                {
                    if (edge.V1.Index == current.Index && !visited[edge.V2.Index])
                    {
                        queue.Enqueue(edge.V2);
                        visited[edge.V2.Index] = true; // Mark the vertex as visited to avoid revisiting it
                    }
                    else if (edge.V2.Index == current.Index && !visited[edge.V1.Index])
                    {
                        queue.Enqueue(edge.V1);
                        visited[edge.V1.Index] = true; // Mark the vertex as visited to avoid revisiting it
                    }
                }
            }
            return path;
        }



        public static int[,] AdjacencyMatrix()
        {
            int[,] graph = new int[_vertices.Count, _vertices.Count];

            foreach (var edge in _edges)
            {
                Vertex v1 = edge.V1; 
                Vertex v2 = edge.V2; 

                graph[v1.Index, v2.Index] = edge.Weight;
                graph[v2.Index, v1.Index] = edge.Weight;
            }

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write($@"{graph[i, j]} ");
                }

                Console.WriteLine();
            }

            return graph;
        }
    }
}
