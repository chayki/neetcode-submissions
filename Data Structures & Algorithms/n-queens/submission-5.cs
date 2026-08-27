public class Solution {
    private Dictionary<int,bool> acuteDiagOccupancy = new();
    private Dictionary<int,bool> obtuseDiagOccupancy = new();
    bool[] columnOccupancy;
    private char[][] rowFormation;
    
    public List<List<string>> SolveNQueens(int n) {
       // a queen can be placed in any of the n positions on a row of the board. I will start by launching a decision tree. At each point I will iterate through all the possible positions of a queen and for each valid position I will proceed forward to the next step. At any point the positioning is invalid, will backtrack and proceed to next possible position. The base case will be reached when recursion tree depth reaches n.
       // I will launch a recurisve DFS , where at each row, I iterate through all n possible column positions. For each position, I will perform a check looking up if the current column or diagonal is already occupied. if position is invalid, I will prune the branch immediately and continue to the  next column. If valid, I will record the position in our state tracker and recurse to the next row and backtrack by removing the queen's state before loop advances.
       // The recursion terminates when our row index reaches n, meaning successfully placed all the n queens in a valid configuration.
       // I will maintain queen occupancy state of a column in a dictionary.
       // challenge: how to maintain a state for diagonal queen occupancy?
       // got it:
       // diagnoal families can be divided into two categories based on the orientation
       // acute family diagonals: r+c
       // obtuse family diagonals: r-c


        var result = new List<List<string>>();
        columnOccupancy = new bool[n];
       rowFormation = new char[n][];

        for (int r = 0; r < n; ++r)
        {
            rowFormation[r] = new char[n];
            for (int c = 0; c < n; ++c)
                {
                    if (!acuteDiagOccupancy.ContainsKey(r+c)) acuteDiagOccupancy.Add(r+c, false);
                    if (!obtuseDiagOccupancy.ContainsKey(r-c)) obtuseDiagOccupancy.Add(r-c, false);
                    rowFormation[r][c] = '.';
                }
        }

        SolveNQueensDFS(n, 0, result);
        return result;
    }

    private void SolveNQueensDFS(int n, int row, List<List<string>> result)
    {
        if (row == n)
        {
            AddSolutionToResult(result);
            return;
        }

        for (int col = 0; col < n; ++col)
        {
            if(!IsValidPosition(row, col)) continue;
            OccupyPosition(row, col);
            SolveNQueensDFS(n, row+1, result);
            UnOccupyPosition(row, col);
        }
    }

    private bool IsValidPosition(int row, int col)
    {
        return !acuteDiagOccupancy[row+col] && !obtuseDiagOccupancy[row-col] && !columnOccupancy[col];
    }

    private void OccupyPosition(int row, int col)
    {
        acuteDiagOccupancy[row+col] = true;
        obtuseDiagOccupancy[row-col] = true;
        columnOccupancy[col] = true;
        rowFormation[row][col] = 'Q';
    }

    private void UnOccupyPosition(int row, int col)
    {
        acuteDiagOccupancy[row+col] = false;
        obtuseDiagOccupancy[row-col] = false;
        columnOccupancy[col] = false;
        rowFormation[row][col] = '.';
    }

    private void AddSolutionToResult(List<List<string>> result)
    {
        var list = new List<string>(rowFormation.Length);
        for(int i = 0; i < rowFormation.Length; ++i)
        {
            list.Add(new string(rowFormation[i]));
        }

        result.Add(list);
    }
}
