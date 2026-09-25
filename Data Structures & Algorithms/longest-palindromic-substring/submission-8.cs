public class Solution {
    private int longPalStart = 0;
    private int longPalEnd = 0;
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
        for (int i = 0; i < s.Length; ++i)
        {
            UpdateMax(s, Expand(s,i,i));
            UpdateMax(s, Expand(s,i,i+1));            
        }

        return s.Substring(longPalStart, longPalEnd-longPalStart+1);
    }

    public void UpdateMax(string s, (int left, int right) range)
    {
        if (range.right <= s.Length && range.left >= 0 && range.right-range.left > longPalEnd-longPalStart) //valid boundaries, max can be updated
        {
            longPalStart = range.left;
            longPalEnd = range.right;
        }
    }
}
