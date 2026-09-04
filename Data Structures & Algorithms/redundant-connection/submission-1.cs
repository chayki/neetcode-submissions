public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length +1;
        UnionFind uf = new UnionFind(n);
        var result = new int[2];
        foreach (var edge in edges)
        {
            if (!uf.Union(edge[0], edge[1])) result = edge;
        }

        return result;
    }
}

public class UnionFind
{
    private int[] size;
    private int[] parent;

    public UnionFind(int n)
    {
        this.size = new int[n];
        this.parent = new int[n];
        for (int i = 0; i < n; ++i)
        {
            this.size[i] = 1;
            this.parent[i] = i;
        }
    }

    public int FindRoot(int x)
    {
        if (parent[x] == x) return x;
        parent[x] = FindRoot(parent[x]);
        return parent[x];
    }

    public bool Union(int x, int y)
    {
        int xRoot = FindRoot(x);
        int yRoot = FindRoot(y);

        if (xRoot == yRoot) return false;

        if (size[xRoot] > size[yRoot])
        {
            parent[yRoot] = xRoot;
            size[xRoot] += size[yRoot];
        }
        else
        {
            parent[xRoot] = yRoot;
            size[yRoot] += size[xRoot];
        }

        return true;
    }
}

/* If a new edge between different vertices belonging to the same component is added, 
then that component becomes cyclic connected graph*/
/* I will use the union find algorithm to build the connected component of the edges being processed.
If I encounter any new edge added between two different vertices of the connected component that becomes cyclic.
I will maintain a global variable to hold the last edge encountered that was causing a cycle*/