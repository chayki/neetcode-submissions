public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // 1. Calculate top frequency (since top frequency item is what decides the total duration while other small freq tasks fill the idle time gaps)
        // 2. calculate min slots available ; idle windows = (maxFreq-1), minSlots = (maxFreq-1)*n + maxFreq
        // 3. if total items > slots available return total items
        // 4. else return minSlots
        // Every item freq should be lesser than idle windows

        // if a task share the same maxFreq, it will extend the minSlot by 1 since it will 

        int maxFreq = int.MinValue;
        Dictionary<char,int> freq = new();
        foreach(char c in tasks)
        {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]+=1;
            maxFreq = Math.Max(maxFreq, freq[c]);
        }
        var idleWindows = maxFreq-1;

        var minSlots = (maxFreq-1)*n + maxFreq;
        int maxCount = -1;

        foreach (KeyValuePair<char,int> kvp in freq)
        {
            if (kvp.Value == maxFreq) maxCount+=1;
        }

        minSlots+=maxCount;
        return Math.Max(minSlots, tasks.Length);
    }
}
