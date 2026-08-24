//Recursion with pruning
public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var result = new List<List<int>>();
        Array.Sort(nums);
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


        for (int i = start; i < nums.Length; ++i)
        {
            if ((prefixSum +nums[i]) > target) break;
            prefix.Add(nums[i]);
            CombinationSumDFS(nums, i, target, prefix, prefixSum + nums[i], result);
            prefix.RemoveAt(prefix.Count-1);
        }
    }
}
