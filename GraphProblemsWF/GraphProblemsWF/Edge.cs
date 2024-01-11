using System;

namespace GraphProblemsWF
{
    public class Edge 
    {
        private static readonly Random Random = new Random();
        public Vertex V1 { get; set; }
        public Vertex V2 { get; set; }
        public int Weight { get; set; } = Random.Next(1, 20);
    }
}