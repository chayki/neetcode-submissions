// Is there any repeated work in the brute force approach.
// Bruteforce formula: totalCharsInSubstring-topFreq <= k
// more optimal solution would be possible if topFreq is more than previous topFreq

// one a possible solution found for a left and right combination, increasing the length wont help.
// move left and right by one step until we find a greater topFreq.
// greater topFreq can expand the total string.
public class Solution {
    public int CharacterReplacement(string s, int k) {
        if (s.Length <= 1) return s.Length;
        
        int left = 0;
        int maxFreq = 0;
        int maxLength = 1;

       
        Dictionary<char,int> frequency = new();

        for (int right = 0; right < s.Length; ++right)
        {
            int windowLength = right-left+1;
            
            frequency.TryAdd(s[right],0);
            frequency[s[right]]+=1;

            maxFreq = Math.Max(maxFreq, frequency[s[right]]);

            if (windowLength - maxFreq > k)
            {
                frequency[s[left]]-=1;
                ++left;
            }
            else
            {
                maxLength = Math.Max(maxLength, windowLength);
            }
        }

        return maxLength;
    }
}
