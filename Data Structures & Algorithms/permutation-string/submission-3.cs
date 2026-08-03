public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length == 0) return true;
        Dictionary<char,int> frequency = new();

        for (int i = 0; i < s1.Length; ++i)
        {
            frequency.TryAdd(s1[i],0);
            frequency[s1[i]]++;
        }

        for (int j = 0; j < s2.Length; ++j)
        {
            Dictionary<char,int> shallowFreq = new Dictionary<char,int>(frequency);
            int totalCount = 0;
            int s2Idx = j;
            while (s2Idx < s2.Length && shallowFreq.ContainsKey(s2[s2Idx]) && shallowFreq[s2[s2Idx]] > 0)
            {
                totalCount++;
                shallowFreq[s2[s2Idx]]--;
                ++s2Idx;
            }

            if (totalCount == s1.Length) return true;
        }

        return false;
    }
}
