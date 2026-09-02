public class Solution {
    int[] dr = [0,0,1,-1];
    int[] dc = [1,-1,0,0];
    char x = 'X';
    char o = 'O';
    char temp = 'T';
    public void Solve(char[][] board) {
        int m = board.Length;
        int n = board[0].Length;
        var edgeIndexToRevert = new List<(int,int)>();

        for (int col = 0; col < n; ++col)
        {
            if (board[0][col] == o)
            {
                edgeIndexToRevert.Add((0,col));
                FloodFillConnectedRegion(board, 0, col, temp);
            }

            if (board[m-1][col] == o)
            {
                edgeIndexToRevert.Add((m-1,col));
                FloodFillConnectedRegion(board, m-1, col, temp);
            }
        }

        for (int row = 1; row < m-1; ++row)
        {
            if (board[row][0] == o)
            {
                edgeIndexToRevert.Add((row, 0));
                FloodFillConnectedRegion(board, row, 0, temp);
            }

            if (board[row][n-1] == o)
            {
                edgeIndexToRevert.Add((row, n-1));
                FloodFillConnectedRegion(board, row, n-1, temp);
            }
        }

        for (int row = 1; row < m-1; ++row)
        {
            for (int col = 1; col < n-1; ++col)
            {
                if (board[row][col] == o)
                {
                    FloodFillConnectedRegion(board, row, col, x);
                }
            }
        }

        foreach (var (row, col) in edgeIndexToRevert)
        {
            FloodFillConnectedRegion(board, row, col, o);
        }
    }

    public void FloodFillConnectedRegion(char[][] board, int r, int c, char replacement)
    {
        var original = board[r][c];
        var queue = new Queue<(int,int)>();
        queue.Enqueue((r,c));
        board[r][c] = replacement;

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            for (int i = 0; i < 4; ++i)
            {
                int nr = row + dr[i];
                int nc = col + dc[i];

                if (nr < 0 || nr >= board.Length || nc < 0 || nc >= board[0].Length || board[nr][nc] != original) continue;
                board[nr][nc] = replacement;
                queue.Enqueue((nr,nc));
            }
        }
    }
}

/* I will iterate through edges of the board to find "O" cells. From those cells I will initiate a flood fill to mark all those cells with a different character other than "X" or "O".
I will iterate through the inner grid for find "O" cells and I will initiate a flood fill to turn those into "X".
I will iterate through the grid to find new character cells and turn those back to "O" */


