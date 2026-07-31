// Is there any repeated work in the brute force approach.
// Bruteforce formula: totalCharsInSubstring-topFreq <= k
// more optimal solution would be possible if topFreq is more than previous topFreq

// one a possible solution found for a left and right combination, increasing the length wont help.
// move left and right by one step until we find a greater topFreq.
// greater topFreq can expand the total string.
public class Solution {
    public int CharacterReplacement(string s, int k) {
        if (s.Length <= 1) return s.Length;
        
        int maxLength = 1;
        
        int maxFreq = 0;

        int left = 0, right = 0;
        Dictionary<char,int> freqMap = new Dictionary<char,int>();
        while (right < s.Length)
        {
            // update the freq map
            if (!freqMap.ContainsKey(s[right]))
            {
                freqMap[s[right]] = 0;
            }
            freqMap[s[right]]+=1;

            maxFreq = Math.Max(freqMap[s[right]], maxFreq); // updates maxFreq in the current window.

            // Check window for validity
            if (right-left+1-maxFreq <= k) //valid window, update maxLength
            {
                maxLength = Math.Max(maxLength, right-left+1);
            }
            else // not a valid window
            {
                //shrink left and revise freq
                freqMap[s[left]]-=1;
                ++left;
            }

            ++right;
        }

        return maxLength;
    }
}
