public class Solution {
    public string LongestPalindrome(string s) {
        return ExpandAroundCenter(s);
    }

    public (int, int) Expand(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length)
        {
            if (s[left] != s[right]) break;
            --left;
            ++right;
        }

        return (left+1, right-1);
    }

    public string ExpandAroundCenter(string s)
    {
        int longPalStart = 0;
        int longPalEnd = 0;
        for (int i = 0; i < s.Length-1; ++i)
        {
            (int left, int right) = Expand(s, i, i);
            if (right-left > longPalEnd-longPalStart) 
            {
                longPalEnd = right;
                longPalStart = left;
            }

            (left, right) = Expand(s, i, i+1);
            if (right-left > longPalEnd-longPalStart) 
            {
                longPalEnd = right;
                longPalStart = left;
            }
        }

        return s.Substring(longPalStart, longPalEnd-longPalStart+1);
    }
}
