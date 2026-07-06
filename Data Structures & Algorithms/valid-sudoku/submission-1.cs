public class Solution {
    public bool IsValidSudoku(char[][] board) {
        HashSet<char>[] colSetList = new HashSet<char>[9];
        HashSet<char>[] rowSetList = new HashSet<char>[9];
        HashSet<char>[] boxSetList = new HashSet<char>[9];

        for (int i = 0; i < 9; ++i)
        {
            colSetList[i] = new HashSet<char>(9);
            rowSetList[i] = new HashSet<char>(9);
            boxSetList[i] = new HashSet<char>(9);
        }

        for (int row = 0; row < 9; ++row)
         for (int col = 0; col < 9; ++col)
          {
            char currElement = board[row][col];
            if (currElement == '.') continue;
            
            if (!rowSetList[row].Add(currElement)) return false;

            if (!colSetList[col].Add(currElement)) return false;

            int boxIndex = (row/3)*3 + (col/3);
            if (!boxSetList[boxIndex].Add(currElement)) return false;
          }

        return true;
    }
}
