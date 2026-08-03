// Can we optimize further?
// Substring frequencies are repeatedly computed for every start index in s2.
// Since its a fixed length substring check, the freq map needs to be update to discount the char freq moving out of the window and to increase/add the char freq coming into the window.
// Since the charset is limited, we can use freq array of size 26
// As the window slides, update the charset array (constant time) and check for match (constant) time

// Total time complexity - O(n) to slide the window - O(1) to check for the match
// Total space complexity - O(1) for frequency array of size 26
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length == 0) return true;
        if (s1.Length > s2.Length) return false;

        int[] freqArray1 = new int[26];
        int[] freqArray2 = new int[26];

        for (int i = 0; i < s1.Length; ++i)
        {
            freqArray1[s1[i]-'a']++;
            freqArray2[s2[i]-'a']++;
        }

        if (AreMatching(freqArray1, freqArray2)) return true;
        
        int left = 1;
        int right = s1.Length;

        while (right < s2.Length)
        {
            freqArray2[s2[left-1]-'a']--;
            freqArray2[s2[right]-'a']++;
            if (AreMatching(freqArray1, freqArray2)) return true;
            ++left;
            ++right;
        }

        return false;
    }

    public bool AreMatching(int[] first, int[] second)
    {
        for (int i = 0; i < first.Length; ++i)
        {
            if (first[i] != second[i]) return false;
        }
        return true;
    }
}
