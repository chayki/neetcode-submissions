public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};
    public int NumIslands(char[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int numIslands = 0;

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == '1')
                {
                    numIslands += 1;
                    NumIslandsDFS(grid, i, j);
                }
            }
        }

        return numIslands;
    }

    public void NumIslandsDFS(char[][] grid, int i, int j)
    {
        // state represents the next call to be visited i,j
        // validate the state
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;

        grid[i][j] = '0';

        // iterate through all the possible choices
        for (int d = 0; d < 4; ++d)
        {
            int nr = i+dr[d];
            int nc = j+dc[d];
            if (nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || grid[nr][nc] == '0') continue;
            NumIslandsDFS(grid, nr, nc);
        }
    }
}
