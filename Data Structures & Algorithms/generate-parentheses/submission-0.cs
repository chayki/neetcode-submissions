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
