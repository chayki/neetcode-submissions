public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;
        var result = new List<List<int>>();
        HashSet<(int,int)> pacificResult = new();
        for (int col = 0; col < n; ++col)
        {
            ReachableCellsDFS(heights, 0, col, pacificResult);
        }

        for (int row = 1; row < m; ++row)
        {
            ReachableCellsDFS(heights, row, 0, pacificResult);
        }

        HashSet<(int,int)> atlanticResult = new();

        for (int row = 0; row < m; ++row)
        {
            ReachableCellsDFS(heights, row, n-1, atlanticResult);
        }

        for (int col = 0; col < n-1; ++col)
        {
            ReachableCellsDFS(heights, m-1, col, atlanticResult);
        }


        foreach ((int row,int col) cell in pacificResult)
        {
            if (!atlanticResult.Contains(cell)) continue;
            result.Add(new List<int>() {cell.row, cell.col});
        }

        return result;
    }

    public void ReachableCellsDFS(int[][] heights, int r, int c, HashSet<(int,int)> result)
    {
        if (result.Contains((r,c))) return;
        result.Add((r,c));
        Queue<(int,int)> queue = new();
        queue.Enqueue((r,c));

        while (queue.Count > 0)
        {
            (int row, int col) cell = queue.Dequeue();
            for (int d = 0; d < 4; ++d)
            {
                int nr = cell.row + dr[d];
                int nc = cell.col + dc[d];

                if (nr < 0 || nr >= heights.Length || nc < 0 || nc >= heights[0].Length || heights[nr][nc] < heights[cell.row][cell.col] || result.Contains((nr, nc))) continue;
                result.Add((nr, nc));
                queue.Enqueue((nr,nc));
            }
        }
    }

}


/* From a cell, we can travel in four directions up, down. left and right.  A neighbour cell can only be processed if its height
is equal or lower than that of the current cell. 
A cell will be added to the result if there's a path from that cell to
1. Any cell with row = rows-1 or col = cols-1
2. Any cell with row = 0 or col = 0
3. Both will be satisfied if row = 0, col = cols-1 or row = rows-1 , cols = 0 */

/* I will start a DFS from each of the nodes from the first row and first col.
The DFS exploration can only process neighbors that are equal or greater in height to the current cell.
Add all the nodes that are reachable to a set.

I will repeat the above process from each of the nodes from the last row and last col.

I will return the intersection of the two sets */