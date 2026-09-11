public class Solution {
    public int SwimInWater(int[][] grid) {
        int[] dr = [0,0,1,-1];
        int[] dc = [1,-1,0,0];
        int m = grid.Length;
        int n = grid[0].Length;
        UnionFind uf = new UnionFind(m*n);
        // nodeId = r*n + c;
        Dictionary<int, List<(int,int)>> map = new();
        for (int i = 0; i < m; ++i)
            for (int j = 0; j < n; ++j)
            {
                int elevation = grid[i][j];
                if (!map.ContainsKey(elevation)) map.Add(elevation, new List<(int,int)>());
                map[elevation].Add((i,j));
            }

        var elevations = map.Keys.ToList();
        elevations.Sort();

        for (int i = 0; i < elevations.Count; ++i)
        {
            foreach ((int row, int col) in map[elevations[i]])
            {
                for (int d =0; d < 4; ++d)
                {
                    int nr = row+dr[d];
                    int nc = col+dc[d];

                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) continue;
                    if (grid[nr][nc] <= grid[row][col])
                    {
                        uf.Union(nr*n+nc, row*n+col);
                    }
                }
            }
            if (uf.FindRoot(0) == uf.FindRoot(m*n-1)) return elevations[i];
        }

        return -1;
    }

    public class UnionFind
    {
        int[] parent;
        int[] size;
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

            if (xSize >= ySize)
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
}
