// what is the repeated work in the bruteforce approach
// while enumerating a substring anchored at an index, if a duplicate character is encountered 
// we can ignore all other anchor indices till the duplicate char is crossed.
// once the duplicate char is crossed, we can put a new anchor there and expand the substring further to find a potential bigger one
// The above optimized approach is like a sliding window
// 1. Anchor left and expand the right till a duplicate char is encountered
// 2. Shrink the left till the duplicate char is encountered
// 3. Anchor the left at the next index and repeat the steps
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length <= 1) return s.Length;
        int maxLength = 1;
        int left = 0, right = 1;
        Dictionary<char, int> charFreq = new Dictionary<char, int>(s.Length);
        charFreq[s[left]] = 1;

        while (right < s.Length)
        {
            while (charFreq.ContainsKey(s[right]))
            {
                charFreq.Remove(s[left]);
                ++left;
            }
            charFreq[s[right]] = 1;
            int length = right-left+1;
            maxLength = Math.Max(maxLength, length);
            ++right;
        }

        return maxLength;
    }
}
