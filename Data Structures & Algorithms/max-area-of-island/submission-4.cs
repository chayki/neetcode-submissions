//Should recursive state mutate the shared state or should return the answer for its subproblem
public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};
    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int maxArea = 0;

        for (int i = 0; i < grid.Length; ++i)
        {
            for (int j = 0; j < grid[0].Length; ++j)
            {
                if (grid[i][j] == 1)
                {
                    int area = MaxAreaOfIslandDFS(grid, i,j);
                    maxArea = Math.Max(area, maxArea);
                }
            }
        }

        return maxArea;
    }

    public int MaxAreaOfIslandDFS(int[][] grid, int r, int c)
    {
        // state represents area computed till the time and the next cell to be visited.
        // is valid state?
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0) return 0;

        // process the state transition
        int area=1;
        grid[r][c] = 0;

        // for every possible next step initiate a dfs
        for (int i = 0; i < 4; ++i)
        {
            int nr = r+dr[i];
            int nc = c+dc[i];
            area+=MaxAreaOfIslandDFS(grid, nr, nc);
        }
        return area;
    }
}