// brute force - sliding window
// every substring has a start and end
// for every start position try expanding the end till we find a duplicate character
// we can break there since we can't find a longer substring anchored at that index.
// advance the anchor by one and repeat the process.
// what is the worst case? if the string contains all the unique chars
// in the worst case, the window will expand to the length of number of uniq chars in the string.
// time complexity - computation equal to the number of uniq chars for each anchor i.e., O(nm) where n is the length,
// m is the number of uniq chars
// space complexity - m (number of uniq chars)
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length <= 1) return s.Length;
        int maxLength = 1;
        //HashSet<char> set = new HashSet<char>(s.Length);
        for (int left = 0; left < s.Length-1; ++left)
        {
            HashSet<char> set = new HashSet<char>(s.Length-left+1);
            set.Add(s[left]);
            int right= left+1;
            for (; right < s.Length; ++right)
            {
                if (set.Contains(s[right]))
                {
                    break;
                }
                set.Add(s[right]);
            }
            int length = right-left;
            maxLength = Math.Max(length, maxLength);
        }
        return maxLength;
    }
}
