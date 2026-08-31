public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};
    public void islandsAndTreasure(int[][] grid) {
        Queue<(int row, int col, int dist)> queue = new Queue<(int,int,int)>();
        for (int r = 0; r < grid.Length; ++r )
        {
            for (int c = 0; c < grid[0].Length; ++c)
            {
                if (grid[r][c] == 0)
                {
                    queue.Enqueue((r,c,0));
                }
            }
        }

        ComputeShortestDistances(grid, queue);
    }

    public void ComputeShortestDistances(int[][] grid, Queue<(int,int,int)> queue)
    {
        //HashSet<(int,int)> visited = new HashSet<(int,int)>();
        // (int row, int col, int dist) node = (r, c, 0);
        // Queue<(int row, int col, int dist)> queue = new Queue<(int,int,int)>();
        // queue.Enqueue(node);
        while (queue.Count > 0)
        {
            (int row, int col, int dist) node = queue.Dequeue();
            for (int d = 0; d < 4; ++d)
            {
                int nr = node.row+dr[d];
                int nc = node.col+dc[d];
                if (nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || grid[nr][nc] != int.MaxValue) continue;
                //land cell that's not visited yet
                grid[nr][nc] = node.dist+1;
                queue.Enqueue((nr, nc, node.dist+1));
            }
        }
    }
}

/* I will iterate through the gird to discover treasure cells. I will initiate a BFS traversal from each of the tresure cell. As a new land cell is visited, I will update the land cell if the distance is shorter than that of previously computed. The traversal will terminate when there are no more land cells to be visited. */

