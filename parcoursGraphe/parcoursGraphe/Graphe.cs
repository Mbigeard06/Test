using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace parcoursGraphe
{

    class Graph
    {
        private int vertexCount; /* Ensemble des sommets */
        private Dictionary<int, List<int>> adjacencyList; /* Ensemble des arrêtes sous forme de tableau chaque identifiant=sommet et contient une liste de ses voisins*/
        private bool[] visited;/* Liste des sommets*/

        public Graph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            adjacencyList = new Dictionary<int, List<int>>(); /*Liste cotnenant à gauche le somemt source et à droite les destinations partant de ce sommet */
            visited = new bool[vertexCount]; /*Liste de boolean qui contient un bool pour chaque sommet. Bool devient vrai quand le sommet a été visité*/
            for (int i = 0; i < vertexCount; i++)
            {
                adjacencyList[i] = new List<int>(); /*Liste des voisins du sommet */
                visited[i] = false;
            }
        }

        public void AddEdge(int source, int destination)
        {
            adjacencyList[source].Add(destination);
        }
        /* parcours en profondeur*/
        public List<int> DFS(int vertex)
        {
            List<int> path = new List<int>(); /*Liste des sommets parcourus */
            DFSUtil(vertex, visited, path);
            return path;
        }

        private void DFSUtil(int vertex, bool[] visited, List<int> path)
        {
            visited[vertex] = true; /*On est sur le sommet donc devient true */
            path.Add(vertex); /* On ajoute le sommet au chemin */

            foreach (int i in adjacencyList[vertex]) /* Pour chaque voisin  du sommet, si il est pas visité on le visite*/
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited, path);
                }
            }
        }
        /*Parcours en largeur*/
        public List<int> DBS(int vertex)
        {
            List<int> path = new List<int>(); /*Liste des sommets parcourus */
            Queue<int> queue = new Queue<int>(); /*Sommet à parcourir*/

            visited[vertex] = true; /*Sommet est visité*/
            queue.Enqueue(vertex);  /*On l'ajoute en queue*/

            while (queue.Count != 0) /*Tant que la queue n'est pas vide*/
            {
                int item = queue.Dequeue(); /*On enlève le dernier élément (premier entré) */
                path.Add(item);/*On l'ajoute au chemin*/
                foreach (int sommet in adjacencyList[item])
                { if (!visited[sommet]) 
                    {
                        queue.Enqueue(sommet);  /*Si ces voisins ne sont pas visités on les ajoutes*/
                        visited[sommet] = true;
                    } 
                }
            }
            return path;
        }
    }

}
