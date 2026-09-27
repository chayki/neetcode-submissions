public class Solution {
    int result = 0;
    public int CountSubstrings(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        for (int i = 0; i < s.Length; ++i)
        {
            Expand(s, i, i);
            Expand(s, i, i+1);
        }
        return result;
    }

    public void Expand(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            ++result;
            --left;
            ++right;
        }
    }
}

/* Every palindrome in a string starts and end at an index. Brute force method is to check palindromeness for every substring.
Every substring of the palindromic string formed by leaving equal number of chars at the beginning and at the ending is also a palindrome that needs to be counted for the overall count.
So checking palindrome for every substring would result in duplicate work 
We can reuse whether the inner substring is a palindrome, instead of checking all of its characters again*/
