// I can optimize the performance futher by using bit vectors instead of arrays
public class Solution {
    private int acuteDiagOccupancy;
    private int obtuseDiagOccupancy;
    bool[] columnOccupancy;
    private char[][] rowFormation;
    
    public List<List<string>> SolveNQueens(int n) {
        var result = new List<List<string>>();
        columnOccupancy = new bool[n];
       rowFormation = new char[n][];

        for (int r = 0; r < n; ++r)
        {
            rowFormation[r] = new char[n];
            for (int c = 0; c < n; ++c)
                {
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
            if(!IsValidPosition(row, col,n)) continue;
            OccupyPosition(row, col, n);
            SolveNQueensDFS(n, row+1, result);
            UnOccupyPosition(row, col, n);
        }
    }

    private bool IsValidPosition(int row, int col, int n)
    {
        return (((acuteDiagOccupancy & (1 << (row+col+1))) == 0)) && ((obtuseDiagOccupancy & (1 << (row-col+n))) ==0) && !columnOccupancy[col];
    }

    private void OccupyPosition(int row, int col, int n)
    {
        acuteDiagOccupancy |= (1 << (row+col+1));
        obtuseDiagOccupancy |= (1 << (row-col+n));
        columnOccupancy[col] = true;
        rowFormation[row][col] = 'Q';
    }

    private void UnOccupyPosition(int row, int col, int n)
    {
        acuteDiagOccupancy ^= (1 << (row+col+1));
        obtuseDiagOccupancy ^= (1 << (row-col+n));
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