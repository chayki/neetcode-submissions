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
            NumIslandsDFS(grid, nr, nc);
        }
    }
}

// Time complexity:
// The DFS algo visits each and every cell at the worst case. Hence total time complexity  is O(mn)
// No cell is ever processed by the DFS loop more than once.
// Space:
// Recursion tree can go as deep as the longest path in the worst case array i.e., all the 1s
// ["0" -> "1" -> "1"-> "1" -> "0"
//                               |
//  "0" <- "1" <-  "0"<- "1" <- "0"
//  |
//  "1" -> "1" -> "0" -> "0" -> "0"
//                              |
//  "0" <- "0" <- "0" <- "0" <-"0"]
// O(m*n)