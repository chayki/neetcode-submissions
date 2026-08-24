public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var result = new List<List<int>>();
        CombinationSumDFS(nums, 0, target, new List<int>(), 0, result);
        return result;
    }

    public void CombinationSumDFS(int[] nums, int start, int target, List<int> prefix, int prefixSum, List<List<int>> result)
    {
        if (prefixSum == target)
        {
            result.Add(new List<int>(prefix));
            return;
        }

        if (prefixSum > target) return;
        

        for (int i = start; i < nums.Length; ++i)
        {
            prefix.Add(nums[i]);
            CombinationSumDFS(nums, i, target, prefix, prefixSum + nums[i], result);
            prefix.RemoveAt(prefix.Count-1);
        }
    }
}
