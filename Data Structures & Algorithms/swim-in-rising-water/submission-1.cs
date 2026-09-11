public class Solution {
    public int SwimInWater(int[][] grid) {
        int[] dr = [0,0,1,-1];
        int[] dc = [1,-1,0,0];
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] minWaterLevel = new int[m][];
        for (int i = 0; i < m; ++i)
        {
            minWaterLevel[i] = new int[n];
        }

        for (int i =0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                minWaterLevel[i][j] = int.MaxValue;
            }
        }

        PriorityQueue<(int,int),int> pq = new();
        pq.Enqueue((0,0),grid[0][0]);

        while(pq.TryDequeue(out (int row, int col) cell, out int waterLevel))
        {
            if (cell.row == m-1 && cell.col == n-1) return waterLevel;

            for (int i = 0; i < 4; ++i)
            {
                int nr = cell.row+dr[i];
                int nc = cell.col+dc[i];
                if (nr < 0 || nr >= m || nc < 0 || nc >= n) continue;
                int newWaterLevel = Math.Max(waterLevel, grid[nr][nc]);

                if (minWaterLevel[nr][nc] <= newWaterLevel) continue;

                

                minWaterLevel[nr][nc] = newWaterLevel;
                pq.Enqueue((nr,nc), minWaterLevel[nr][nc]);
            }

        }

        return -1;
    }
}

/*
1. each grid cell represents hieight
2. Possible traversals: horiziation/vertical
3. Condition: water level should be greater than or equal to the tallest cell among the two
4. Goal is to find min water level to reach (0,0) to (n-1, n-1)
*/

/* If I know the min cost to all the 4 neighbouring nodes of the current node, then 
min cost to reach current node = min((mincost to reach neighbor-1 + edge cost), (mincost to reach neighbor-2 + edge cost), 
                                 (mincost to reach neighbor-3 + edge cost), (mincost to reach neighbor-4 + edge cost)) */

/* I will explore the grid using BFS. For any node being processed, I will check all the four neighbouring nodes and update the those if I find a lesser path */



                                 
