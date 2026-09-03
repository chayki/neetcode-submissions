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

/* The graph is a tree if all the nodes belong to a single connected component and there's no cycle.
If all the nodes belong to a single connected undirected graph, DFS from any node will visit all the nodes of the graph.
I will start a DFS from any one of the node and will keep track of the visited. The DFS will recurse through the neighbors except for the parent.
If a visited list contains the neighbor to be recursed there's a cycle. Otherwise, I will check if all the nodes are visited when the DFS is completed.
If all the nodes are not visited then its not a valid single tree */


/* A valid tree in an undirected graph is both connected and acyclic. I can verify acycliciy with DFS by tracking the parent and treating an already visited neighbor other than the parent as a cycle. I will verify connectivity by checking that DFS visited all n nodes */

/* Time complexity: 
building edgeList - O(V+E) and O(E) for DFS - total O(V+E)
space: Recursion can go as deep as V-1 - O(V), visited set - O(V)- edgeList - O(V+E) */

