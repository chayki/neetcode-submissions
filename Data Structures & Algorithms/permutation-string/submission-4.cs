// Brute force
// A substring will be a permutation of the source string when frequencies match
// Create a frequency map of s1.
// Iterate through s2, keep building frequency map and validate against if the counts match
// assume s1 Length = m and s2 Length = n
// Time complexity - 
// m - to prepare frequency map 
// n* (m - shallow copy + m for substring check)
// total = m + mn = mn
// Space complexity - O(m) - for frequency map
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length == 0) return true;
        Dictionary<char,int> frequency1 = new();

        for (int i = 0; i < s1.Length; ++i)
        {
            frequency1.TryAdd(s1[i],0);
            frequency1[s1[i]]++;
        }

        for (int j = 0; j < s2.Length; ++j)
        {
            Dictionary<char,int> frequency2 = new Dictionary<char,int>();
            int totalCount = 0;
            int s2Idx = j;
            while (s2Idx < s2.Length && totalCount < s1.Length)
            {
                char currChar = s2[s2Idx];
                if (!frequency1.ContainsKey(currChar)) break;
                frequency2.TryAdd(currChar, 0);
                frequency2[currChar]++;
                if (frequency2[currChar] > frequency1[currChar]) break;
                totalCount++;
                ++s2Idx;
            }

            if (totalCount == s1.Length) return true;
        }

        return false;
    }
}
