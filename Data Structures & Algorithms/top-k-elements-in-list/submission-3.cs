public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var counts = new Dictionary<int,int>();
        int maxFreq = 0;
        foreach (var num in nums)
        {
            if (!counts.ContainsKey(num)) counts.Add(num, 0);
            counts[num]+=1;
            int freq = counts[num];
            if (freq > maxFreq) maxFreq = freq;
        }

        var buckets = new List<int>[nums.Length+1];
        for (int i = 0; i <= maxFreq; ++i) buckets[i] = new List<int>();


        foreach (var kvp in counts) buckets[kvp.Value].Add(kvp.Key);

        //var res = new List<int>(counts.Keys.Count);
        var res = new int[k];
        int index = 0;
        for (int i = maxFreq; i >= 1; --i)
        {
            foreach (var num in buckets[i])
            {
                res[index++] = num;
                if (index == k)
                {
                    return res;
                }
            }
        }

        return res;
    }
}
