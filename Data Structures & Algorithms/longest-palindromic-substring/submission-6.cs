public class Solution {
    public string LongestPalindrome(string s) {
        return ExpandAroundCenter(s);
    }

    public string ExpandAroundCenter(string s)
    {
        int longPalStart = 0;
        int longPalEnd = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            int left = i;
            int right= i;

            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right]) break;

                if (s[left] == s[right] && right-left > longPalEnd-longPalStart)
                {
                    longPalStart = left;
                    longPalEnd = right;    
                }

                --left;
                ++right;
            }
        }

        for (int i = 0; i < s.Length-1; ++i)
        {
            int left = i;
            int right = i+1;

            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right]) break;
                if (s[left] == s[right] && right-left > longPalEnd-longPalStart)
                {
                    longPalEnd = right;
                    longPalStart = left;
                }

                --left;
                ++right;

            }
        }

        return s.Substring(longPalStart, longPalEnd-longPalStart+1);
    }
}
