public class Solution {
    public string MinWindow(string s, string t) {

        if (t.Length == 0) return string.Empty; //empty pattern
        if (s.Length < t.Length) return string.Empty; // invalid case

        string result = string.Empty;
        int minWindowLength = int.MaxValue;
        int minWindowStart = 0;

        // build dictionary
        Dictionary<char,int> patternFreq = new Dictionary<char,int>(t.Length);
        for (int i = 0;i < t.Length; ++i)
        {
            patternFreq.TryAdd(t[i],0);
            patternFreq[t[i]]++;
        }

        Dictionary<char,int> windowFreq = new();


        int matchedChars = 0;
        int left = 0;
        for (int right = 0; right < s.Length; ++right)
        {
            windowFreq.TryAdd(s[right],0);
            windowFreq[s[right]]++;

            int stringCharFreq = windowFreq[s[right]];

            if (patternFreq.ContainsKey(s[right]) && stringCharFreq <= patternFreq[s[right]]) // not all duplicate chars found yet, valid count
            {
                ++matchedChars;
            }

            while (matchedChars == t.Length) // full pattern found, shrink the left to find the minimal length window ending at right
            {
                int currWindowLength = right-left+1;

                if (currWindowLength < minWindowLength)
                {
                    minWindowLength = currWindowLength;
                    minWindowStart = left;
                }
                
                if (patternFreq.ContainsKey(s[left]) && windowFreq[s[left]] == patternFreq[s[left]])
                {
                    --matchedChars;
                }
                windowFreq[s[left]]--;
                ++left;
            }
        }

        return (minWindowLength == int.MaxValue) ? string.Empty : s.Substring(minWindowStart, minWindowLength);
    }


}
