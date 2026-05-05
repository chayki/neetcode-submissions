public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freqMap = new Dictionary<int,int>();
        foreach (var num in nums)
        {
            if (!freqMap.ContainsKey(num)) freqMap.Add(num, 0);
            freqMap[num]+=1;
        }

        var pq = new PriorityQueue<int,int>();

        foreach (var kvp in freqMap)
        {
            if (pq.Count < k)
            {
              pq.Enqueue(kvp.Key, kvp.Value);
              continue;  
            }
            
            if (pq.TryPeek(out int num, out int freq) && kvp.Value > freq)
            {
                pq.DequeueEnqueue(kvp.Key, kvp.Value);
            }  
        }

        int[] result = new int[k];
        int i = 0;
        while (pq.TryDequeue(out int num, out int freq))
        {
            result[i++] = num;
        }

        return result;
    }
}
