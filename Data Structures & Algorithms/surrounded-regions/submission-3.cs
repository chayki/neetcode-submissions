// To make the solution cleaner we can avoid storing edges to revert in a separate state. Instead iterate throug the array to find temp character region
public class Solution {
    int[] dr = [0,0,1,-1];
    int[] dc = [1,-1,0,0];
    char x = 'X';
    char o = 'O';
    char temp = 'T';
    public void Solve(char[][] board) {
        int m = board.Length;
        int n = board[0].Length;

        // Mark the top and bottom edge cells as temp char
        for (int col = 0; col < n; ++col)
        {
            if (board[0][col] == o)
            {
                FloodFillConnectedRegion(board, 0, col, temp);
            }

            if (board[m-1][col] == o)
            {
                FloodFillConnectedRegion(board, m-1, col, temp);
            }
        }

        // Mark the left and right edge cells as temp char
        for (int row = 1; row < m-1; ++row)
        {
            if (board[row][0] == o)
            {
                FloodFillConnectedRegion(board, row, 0, temp);
            }

            if (board[row][n-1] == o)
            {
                FloodFillConnectedRegion(board, row, n-1, temp);
            }
        }

        // replace inner "O" regions with "X"
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

        for (int row = 0; row < m; ++row)
        {
            for (int col = 0; col < n; ++col)
            {
                if (board[row][col] == temp)
                {
                    FloodFillConnectedRegion(board, row, col, o);
                }
            }
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
