public class Solution {
    public string MinWindow(string s, string t) {

        if (t.Length == 0) return string.Empty; //empty pattern
        if (s.Length < t.Length) return string.Empty; // invalid case

        string result = string.Empty;
        int minWindowLength = int.MaxValue;

        // build dictionary
        Dictionary<char,int> patternFreq = new Dictionary<char,int>(t.Length);
        for (int i = 0;i < t.Length; ++i)
        {
            patternFreq.TryAdd(t[i],0);
            patternFreq[t[i]]++;
        }

        Dictionary<char,int> stringFreq = new();


        int totalCount = 0;
        int left = 0;
        for (int right = 0; right < s.Length; ++right)
        {
            stringFreq.TryAdd(s[right],0);
            stringFreq[s[right]]++;

            int stringCharFreq = stringFreq[s[right]];
            int patternCharFreq = patternFreq.ContainsKey(s[right]) ? patternFreq[s[right]] : 0;

            if (stringCharFreq <= patternCharFreq) // not all duplicate chars found yet, valid count
            {
                ++totalCount;
            }

            while (totalCount == t.Length && left <= right) // full pattern found, shrink the left to find the minimal length window ending at right
            {
                if (patternFreq.ContainsKey(s[left]) && (stringFreq[s[left]] <= patternFreq[s[left]])) // window will not be valid if we shrink further
                {
                    int windowLength = right-left+1;
                    if (windowLength < minWindowLength)
                    {
                        result = s.Substring(left, windowLength);
                        minWindowLength = windowLength;
                    }
                    --totalCount;
                }
                stringFreq[s[left]]--;
                ++left;
            }
        }

        return result;
    }


}
