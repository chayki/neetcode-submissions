// Brute force approach
// we can choose k chars of a string and can replace with any other upper case English character
// The goal is to find all the substrings with k+1 distinct characters and return the max length among those
// each substring starts and ends at an index
// for each anchor index, expand the right till the condition of k+1 distinct characters satisfied.
// keep track of max length
// Time complexity - O(n2)
// Space complexity = O(k+1) - number of distinct chars

// Got the brute force approach wrong.

public class Solution {
    public int CharacterReplacement(string s, int k) {
        if (s.Length <= 1) return s.Length;
        int maxLength = 1;
        
        int maxFreq = 0;

        for (int left = 0; left < s.Length; ++left)
        {
            Dictionary<char,int> freqMap = new Dictionary<char,int>();
            int right = left;
            for (; right < s.Length; ++right)
            {
               if (!freqMap.ContainsKey(s[right]))
               {
                    freqMap[s[right]] = 0;
               }
               freqMap[s[right]]+=1;

               maxFreq = Math.Max(maxFreq, freqMap[s[right]]);
               
               if ((right-left+1-maxFreq) > k)
               {
                    break;
               }
            }

            maxLength = Math.Max(maxLength, right-left);
        }
        return maxLength;
    }
}
