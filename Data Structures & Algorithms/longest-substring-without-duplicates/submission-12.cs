// Can we optimize further? yes.
// In solution 3 - when a duplicate found we are moving the anchor point one step at a time,
// we can optimize this by storing last index of every char found till then and move anchor directly to left+1
// Asymptotic time complexity remains same at O(n) - each index is visited at the worst case
// space complexity - O(m) - number of uniq chars
// Intial submission of the program failed for few test cases - please refer to the notes
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length <= 1) return s.Length;
        Dictionary<char,int> charIndexMap = new Dictionary<char,int>(s.Length);
        int anchor = 0, end = 1;
        int maxLength = 1;
        charIndexMap[s[0]] = 0;
        while (end < s.Length)
        {
            if (charIndexMap.ContainsKey(s[end]) && charIndexMap[s[end]] >= anchor)
            {
                anchor = Math.Max(charIndexMap[s[end]]+1, anchor);
            }
            charIndexMap[s[end]] = end;
            int length = end-anchor+1;
            maxLength = Math.Max(length, maxLength);
            ++end;
        }

        return maxLength;
    }
}
