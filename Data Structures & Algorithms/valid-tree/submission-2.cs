public class Solution {
    List<int>[] edgeList;
    public bool ValidTree(int n, int[][] edges) {
        edgeList = new List<int>[n];
        for (int i = 0; i < n; ++i)
        {
            edgeList[i] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            var node1 = edge[0];
            var node2 = edge[1];
            edgeList[node1].Add(node2);
            edgeList[node2].Add(node1);
        }

        HashSet<int> visited = new();
        visited.Add(0);
        if (IsCyclicDFS(edges, -1, 0, visited)) return false;
    

        return visited.Count == n;
    }

    public bool IsCyclicDFS(int[][] edges, int parent, int current, HashSet<int> visited)
    {
        //Iterated through each neighbor of the current node and if its equal to parent dont recurse, if not check if its visited if yes true else continue recursing.

        foreach (int neighbor in edgeList[current])
        {
            if (neighbor == parent) continue;
            if (visited.Contains(neighbor)) return true;
            visited.Add(neighbor);
            if (IsCyclicDFS(edges, current, neighbor, visited)) return true; 
        }

        return false;
    }
}

/* Intuition: A graph becomes a tree if there are no cycles in it. Topological sorting can be used to detect if there's any cycle
in the graph. Topo sort works only on dependency graph (DAG) but undirected edges wont work */

/* I need to explore all the paths in the graph to know if there's any cycle. I will start with every node and execute DFS.
I will keep track of the visited nodes as I recurse through. If I encounter any neighbor that's already visited but not a parent to the current node, will return false.
End of program will return true */


