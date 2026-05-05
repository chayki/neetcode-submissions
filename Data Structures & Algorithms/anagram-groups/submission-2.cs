public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> result = new List<List<string>>();
        if (strs.Length == 0 ) return result;
        Dictionary<string, List<string>> anagramsMap = new Dictionary<string, List<string>>(strs.Length);
        foreach (string str in strs)
        {
            string key = GetFreqVector(str);
            if (!anagramsMap.ContainsKey(key))
            {
                anagramsMap.Add(key, new List<string>());
            }
            anagramsMap[key].Add(str);
        }

        foreach (List<string> anagrams in anagramsMap.Values)
        {
            result.Add(anagrams);
        }

        return result;
    }

    private string GetFreqVector(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        int[] charFreq = new int[26];
        for (int i = 0; i < str.Length; ++i)
        {
            int charIndex = str[i] - 'a';
            charFreq[charIndex] += 1;
        }
        return string.Join('-', charFreq);
    }
}
