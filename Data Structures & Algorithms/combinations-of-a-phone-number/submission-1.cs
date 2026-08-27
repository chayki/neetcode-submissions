public class Solution {
    public List<string> LetterCombinations(string digits) {
        // I will create a cache dictionary to store digit mapping to character set.
        // I will launch a recursive backtracking DFS to chose one of the character from the set at each recursive step. Base case will be reached when the digit string is completely processed.
        var result = new List<string>();
        if (string.IsNullOrEmpty(digits)) return result;
        Dictionary<char,char[]> digitCharSet = new() {
            {'2', new char[] {'a','b','c'}},
            {'3', new char[] {'d','e','f'}},
            {'4', new char[] {'g','h','i'}},
            {'5', new char[] {'j','k','l'}},
            {'6', new char[] {'m','n','o'}},
            {'7', new char[] {'p','q','r','s'}},
            {'8', new char[] {'t', 'u', 'v'}},
            {'9', new char[] {'w', 'x', 'y', 'z'}}
        };
        
        LetterCombinationsDFS(digits, 0, digitCharSet, new StringBuilder(), result);
        return result;
    }

    private void LetterCombinationsDFS(
        string digits,
        int i, 
        Dictionary<char,char[]> digitCharSet, 
        StringBuilder sb,
        List<string> result)
        {
            if (sb.Length == digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            foreach (char c in digitCharSet[digits[i]])
            {
                sb.Append(c);
                LetterCombinationsDFS(digits, i+1, digitCharSet, sb, result);
                sb.Length--;
            }   
        }
}
