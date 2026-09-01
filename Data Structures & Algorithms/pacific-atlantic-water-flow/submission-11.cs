public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};

    public List<List<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;
        var result = new List<List<int>>();

        HashSet<(int,int)> pacificReachable = new();
        Queue<(int,int)> queue = new();
        for (int col = 0; col < n; ++col)
        {
            pacificReachable.Add((0, col));
            queue.Enqueue((0,col));
        }

        for (int row = 1; row < m; ++row)
        {
            pacificReachable.Add((row, 0));
            queue.Enqueue((row,0));
        }

        FindReachableCells(heights, queue, pacificReachable);
        queue.Clear();
        HashSet<(int,int)> atlanticReachable = new();
        
        for (int col = 0; col < n; ++col)
        {
            atlanticReachable.Add((m-1, col));
            queue.Enqueue((m-1, col));
        }

        for (int row = 0; row < m-1; ++row)
        {
            atlanticReachable.Add((row, n-1));
            queue.Enqueue((row,n-1));
        }

        FindReachableCells(heights, queue, atlanticReachable);

        foreach ((int row, int col) cell in pacificReachable)
        {
            if (!atlanticReachable.Contains(cell)) continue;
            result.Add(new List<int>() { cell.row, cell.col});
        }

        return result;

    }

    public void FindReachableCells(int[][] heights, Queue<(int,int)> queue, HashSet<(int,int)> result)
    {
        while (queue.Count > 0)
        {
            (int row, int col) cell = queue.Dequeue();
            for (int d = 0; d < 4; ++d)
            {
                int nr = cell.row+dr[d];
                int nc = cell.col+dc[d];
                if (nr < 0 || nr >= heights.Length 
                    || nc < 0 || nc >= heights[0].Length
                    || result.Contains((nr, nc))
                    || heights[nr][nc] < heights[cell.row][cell.col]) continue;
                result.Add((nr, nc));
                queue.Enqueue((nr,nc));
            }
        }
    }
}
