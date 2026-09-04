public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var visited = new HashSet<int>(n);
        var componentCount = 0;
        var edgeList = new List<int>[n];
        for (int i = 0; i < n; ++i)
        {
            edgeList[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            var node1 = edge[0];
            var node2 = edge[1];
            edgeList[node1].Add(node2);
            edgeList[node2].Add(node1);
        }

        for(int node = 0; node < n; ++node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                componentCount++;
                ExploreConnectedComponent(node, edgeList, visited);
            }
        }
        return componentCount;
    }

    public void ExploreConnectedComponent(int n, List<int>[] edgeList, HashSet<int> visited)
    {
        var queue = new Queue<int>();
        queue.Enqueue(n);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var neighbor in edgeList[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}

/* I will explore each of the connected components using graph traversal algo such as BFS/DFS. 
I will keep track of the visited list globally to skip those from traversing again. 
I will use a global counter to keep track of the component count */
