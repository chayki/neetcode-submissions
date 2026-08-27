// Brute force approach is to extract all the substrings. For each substring evaluate if its a palindrome.
// Extracting substrings: O(n) time and O(n) space since .Substring() function in c# allocates a new memory and copies the character sequence.
// Note: Using ReadOnlySpan instead of Substring will cost O(1) but that's not the essential goal of solving this problem.
// Palindome evaluation: O(n)
// Toal complexity: Total substrings * (Substring cost + palindrome evaluation)
// O(n^2) * O(n) = O(n^3)
// Key observation : IsPalindrome(size) == IsPalindrome(n-2) && (left most char) == (right most char)
// So if we know the lower size palindrome, its a constant time operation
public class Solution {
    public List<List<string>> Partition(string s) {
        //Algorithm:
        // 1. Create a grid for storing palindromeness for every (i,j)
        // 2. I will build the grid bottom up, which essentially makes the palindrome check operation O(1)
        // 3. As I am building the grid, For every (i,j) that is true I will add the substring to result
        // Total complexity: Total substrings * (Substring cost + palindrome evaluation) = O(n^2)*O(n)

        var result = new List<List<string>>();
        var grid = new bool[s.Length][];
        for (int i = 0; i < s.Length; ++i)
        {
            grid[i] = new bool[s.Length];
        }

        for (int len = 1; len <= s.Length; len++)
        {
            for (int i = 0; i <= s.Length-len; ++i)
            {
                int start = i;
                int end = start+len-1;

                switch(len)
                {
                    case 1:
                        grid[start][end] = true;
                        break;
                    case 2:
                        if (s[start] == s[end])
                        {
                            grid[start][end] = true;
                        }
                        break;
                    default:
                        grid[start][end] = grid[start+1][end-1] && s[start] == s[end]; 
                        break;           
                }
            }
        }

        PartitionDFS(s, grid, 0, new List<string>(), result);
        return result;
    }

    private void PartitionDFS(
        string s, 
        bool[][] grid, 
        int start, 
        List<string> partitionList, 
        List<List<string>> result)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(partitionList));
            return;
        }

        for (int part = start; part < s.Length; ++part)
        {
            if (grid[start][part])
            {
                partitionList.Add(s.Substring(start, part-start+1));
                PartitionDFS(s, grid, part+1, partitionList, result);
                partitionList.RemoveAt(partitionList.Count-1);
            }
        }    
    }
}
