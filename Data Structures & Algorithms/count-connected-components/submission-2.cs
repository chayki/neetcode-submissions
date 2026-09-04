public class Solution {
    public int CountComponents(int n, int[][] edges) {
        UnionFind uf = new UnionFind(n);
        int totalComponents = n;
        foreach(var edge in edges)
        {
            if (uf.Union(edge[0], edge[1]))
            {
                totalComponents--;
            }
        }

        return totalComponents;
    }
}

public class UnionFind
{
    private int[] parent;
    private int[] size;

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];

        for (int i = 0; i < n; ++i)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public bool AreConnected(int x, int y)
    {
        int xRoot = FindRoot(x);
        int yRoot = FindRoot(y);

        return xRoot == yRoot;
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

        int xSize = size[xRoot];
        int ySize = size[yRoot];

        if (xSize > ySize)
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

/* I will use union-find approach for bringing the time complexity further down.
Total number of connected components before processing any edge would be n.
For each edge being processed, if it results in an union operation I would decrement the component count by 1 */
