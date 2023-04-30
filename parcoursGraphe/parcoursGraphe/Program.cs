// See https://aka.ms/new-console-template for more information
using parcoursGraphe;

Console.WriteLine("Hello, World!");

Graph graph = new Graph(5);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 0);
graph.AddEdge(1, 3);
graph.AddEdge(2, 4);
graph.AddEdge(2, 0);
graph.AddEdge(3, 1);
graph.AddEdge(3, 4);
graph.AddEdge(4, 3);
graph.AddEdge(4, 2);

List<int> path = graph.DBS(0);

foreach (int vertex in path)
{
    Console.Write(vertex + " ");
}
