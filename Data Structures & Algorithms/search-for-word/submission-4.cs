// DFS backtracking by modifying the array itself instead of maintaining a separate visited array
public class Solution {
    public bool Exist(char[][] board, string word) {
        // Articulation:
        // I will iterate through each cell to find the starting letter. Once found, I will do DFS to explore all the 4-directional paths recursively. To optimize I will prune the exploration if the current cell goes out of bounds or has been visited already or does not match the corresponding index in the target word. Return true, if DFS reaches full word length, otherwise if all starting positions fail return false

        // Algorithm:
        // 1. Create a visited matrix
        // 2. For each cell in the matrix
        //          if cell ne word[0] continue;
        //      if (DFS check for the word) return true;
        // 3. return false;
        int m = board.Length;
        int n = board[0].Length;
        int[] dx = new int[4] {0,1,0,-1};
        int[] dy = new int[4] {1,0,-1,0};

        for (int i = 0; i < m; ++i)
            for (int j = 0; j < n; ++j)
                {
                    if (board[i][j] == word[0])
                    {
                        if (ExistDFS(
                            board, 
                            word, 
                            i, 
                            j, 
                            dx, 
                            dy, 
                            0)) return true;
                    }
                }

        return false;
    }

    public bool ExistDFS(
        char[][] board,
        string word, 
        int row, 
        int col, 
        int[] dx, 
        int[] dy, 
        int wordIndex)
    {
        if (row < 0 || row > board.Length-1) return false;
        if (col < 0 || col > board[0].Length-1) return false;
        if (board[row][col] == '#' || board[row][col] != word[wordIndex]) return false;
        board[row][col] = '#';
        if (wordIndex == word.Length-1) return true;

        for(int i = 0; i < 4; ++i)
        {
            if (ExistDFS(board, word, row+dx[i], col+dy[i], dx, dy, wordIndex+1)) return true;
        }

        board[row][col] = word[wordIndex];
        return false;
    }
}

// Time complexity:
// We iterate through each cell for find the starting point O(R*C)
// After finding the starting cell, we launch DFS. While first step has 4 directional choices, every subsequent step will have at most 3 directional choices because we can't revisit the parent cell.
// Maximum depth of the recursion tree is bound by length of the word, the DFS takes 3^L for every starting position
// Total time complexity: O(R*C*3^L)

// Space complexity:
// Recrusion stack depth is bound by the length of the word. Therefore, auxiliary memory consumed by recursion stack is O(L)
// I will modify the grid in-place during the backtracking step to track the visited cells, avoiding O(R*C) memory penalty for external visited array.
