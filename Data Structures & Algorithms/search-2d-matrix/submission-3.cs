public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        // find the row
        int start = 0;
        int end = matrix.Length-1;
        int row = 0;

        int mid = start + (end-start)/2;
        while (start <= end)
        {
            mid = start + (end-start)/2;
            if (target < matrix[mid][0])
            {
                end = mid-1;
            }
            else if (target > matrix[mid][cols-1])
            {
                start = mid+1;
            }
            else
            {
                row = mid;
                break;
            }
        }

        row = mid;
        // find in the row

        int left = 0;
        int right = matrix[0].Length-1;

        while (left <= right)
        {
            mid = left + (right-left)/2;
            if (target < matrix[row][mid])
            {
                right = mid-1;
            }
            else if (target > matrix[row][mid])
            {
                left = mid+1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
