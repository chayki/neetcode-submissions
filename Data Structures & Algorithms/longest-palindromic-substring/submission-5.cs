public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length == 0) return string.Empty;

        int longPalStart = 0;
        int longPalEnd = 0;

        bool[][] dp = new bool[s.Length][];

        for (int i = 0; i < s.Length; ++i)
        {
            dp[i] = new bool[s.Length];
        }

        for (int i = 0; i < s.Length; ++i)
        {
            dp[i][i] = true;
        }

        for (int i = 0; i < s.Length-1; ++i)
        {
            if (s[i] == s[i+1]) 
            {
                dp[i][i+1] = true;
                longPalStart = i;
                longPalEnd = i+1;
            }
        }

        int length = 3;

        while (length <= s.Length)
        {
            for (int i = 0; i+length-1 < s.Length; ++i)
            {
                int start = i;
                int end = i+length-1;
                if (s[start] == s[end] && dp[start+1][end-1])
                {
                    dp[start][end] = true;
                    longPalStart = start;
                    longPalEnd = end;
                }
            }
            ++length;
        }

        return s.Substring(longPalStart, longPalEnd-longPalStart+1);
    }
}

/*
Substring is a contiguous portion of the original string.
Palindrome recurrence relation:
Substring length 1: always true
Substring length 2: true if both characters are equal.
Substring length >2: ispalindrome(i,j) = ispalindrome(i+1, j-1) && string[i] == string[j]
*/