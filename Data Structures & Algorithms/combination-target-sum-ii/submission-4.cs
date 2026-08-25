public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        
        var result = new List<List<int>>();
        Array.Sort(candidates);
        CombinationSum2DFS(candidates, 0, target, new List<int>(), 0, result);
        return result;
    }

    public void CombinationSum2DFS(int[] candidates, int start, int target, List<int> prefix, int prefixSum, List<List<int>> result)
    {
        if (prefixSum == target)
        {
            result.Add(new List<int>(prefix));
            return;
        }

        if (prefixSum > target) return;

        for (int i = start; i < candidates.Length; ++i)
        {
            if (i > start &&candidates[i] == candidates[i-1]) continue; // ignore duplicate twin element, since this results in duplicate sets in the result. 
            if (prefixSum + candidates[i] > target) break;
            prefix.Add(candidates[i]);
            CombinationSum2DFS(candidates, i+1, target, prefix, prefixSum+candidates[i], result);
            prefix.RemoveAt(prefix.Count-1);
        }
    }
}
