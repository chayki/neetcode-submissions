public class Solution {
    int[] dr = new int[] {0,0,1,-1};
    int[] dc = new int[] {1,-1,0,0};
    public int OrangesRotting(int[][] grid) {
        if (grid == null) return 0;
        int m = grid.Length;
        int n = grid[0].Length;
        int freshCount = 0;
        Queue<(int row, int col)> queue = new();

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1) ++freshCount;
                else if (grid[i][j] == 2) queue.Enqueue((i,j));
            }
        }

        return ComputeMinTime(grid, queue, freshCount);
    }

    public int ComputeMinTime(int[][] grid, Queue<(int, int)> queue, int freshCount)
    {
        int rottenCount = queue.Count;
        if (freshCount == 0) return 0;
        else if (rottenCount == 0) return -1;

        int time = -1;
        while (queue.Count > 0)
        {
            int levelCount = queue.Count;
            while(levelCount > 0)
            {
                (int row, int col) cell = queue.Dequeue();
                for(int d = 0; d < 4; ++d)
                {
                    int nr = cell.row + dr[d];
                    int nc = cell.col + dc[d];

                    if (nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || grid[nr][nc] != 1) continue;
                    grid[nr][nc] = 2;
                    --freshCount;
                    queue.Enqueue((nr, nc));
                }
                --levelCount;
            }
            ++time;
        }

        return freshCount > 0 ? -1 : time;
    }
}

/*
0 - No
1 - Fresh fruit yes
2 - Rotten fruit

I will iterate through the matrix to find all the rotten cells. Since there can be more than one rotten cell, I will initiate a multi-source BFS.
As I explore the neighbors, I will mark fresh cells rotten and add those to a queue for further exploration.
BFS will be processed level by level and each level processed is equivalent to 1 min in time. 
I will keep track of level count as I progress through BFS.
Base case will be reach when there are no more nodes to be processed from the queue.
I will iterate through the grid:
if any fresh fruit found return -1
else return levelcount

Time complexity:
each cell is visited and changed once, before getting added to the queue for neighbour exploration
At the worst case all the cells are fresh fruit except one. O(m*n)

Space complexity:
Maximum number of cells in the queue waiting to be processed for neighbors at any point in time.
This is bound by number of cells in the array. O(m*n)
*/
