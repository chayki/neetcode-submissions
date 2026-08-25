public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        // n pairs of paranthesis results in (2n)! permutations each of length 2n
        // At each position (recursion step) make a choice to choose one of paranthesis i.e., ( or )
        // Recurse to the next position (DFS)
        // Break the recursion branch when closed paranthesis > open paranthesis

        // Algorithm:
        // 1. Create an array to store possible paranthesis
        // 2. Invoke the recursive DFS function by passing open paranthesis count and closed paranthesis count in the parameters
        // 3. Base condition when recursion branch length == 2n, add to the result
        // 4. Pruning condition - when closed paranthesis > open paranthesis
        var result = new List<string>();
        var paranthesis = new char[2] { '(', ')'};
        GenerateParenthesis(
            n,
            paranthesis,
            0,
            0,
            new StringBuilder(),
            result
        );
        return result;
    }

    public void GenerateParenthesis(
        int n,
        char[] paranthesis,
        int openCount,
        int closeCount, 
        StringBuilder path, 
        List<string> result)
    {
        if (openCount > n || closeCount > n || closeCount > openCount) return;

        if (path.Length == 2*n)
        {
            result.Add(path.ToString());
            return;
        }

        for (int i = 0; i < paranthesis.Length; ++i)
        {
            path.Append(paranthesis[i]);
            GenerateParenthesis(
                n, 
                paranthesis, 
                paranthesis[i] == '(' ? openCount+1 : openCount, 
                paranthesis[i] == ')' ? closeCount+1 : closeCount, 
                path, 
                result);
            path.Length--;
        }   
    }
}

// Time complexity:
// To find the upper bound, we can look at this as a binary decision tree. At each position, we make 2 choises - either an open or a closed paranthesis
// we repeat this for a maximum string length of 2n steps.
// This gives us an upper bound of 2^2n == 4^n total paths.
// At the end of every path we spend O(n) time to convert out stringbuilder to string.
// Strict upper bound = O(n.4^n). However because of purning, the actual runtime will be significantly tighter than this.

// Space complexity:
// Recursion stack goes 2n layers deep before hitting base case and rewinding. The call stack uses O(2n) = O(n)
// StringBuilder grows to a maximum size of 2n so O(2n) = O(n)
// output space: O(4^n) total paths * O(2n) for storing each string
// O(4^n * 2n)

// In reality our pruning ensures that the actual memory footprint is much lower than this
