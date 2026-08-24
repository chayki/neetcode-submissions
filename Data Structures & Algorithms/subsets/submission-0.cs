public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        // 1. Subset can contain elements in any order - order does not matter
        // Algo:
        // 1. fix an element in the subset and add that to result
        // 2. Build subsets from the remaining elements along with fixed element and add to the result. 

        var result = new List<List<int>>();
        if (nums.Length == 0) return result;
        SubsetsBackTracking(nums, 0, new List<int>(), result);
        return result;
    }

    public void SubsetsBackTracking(int[] nums, int start, List<int> prefix, List<List<int>> result)
    {
        result.Add(new List<int>(prefix));
        if (start >= nums.Length) return;
        for (int i = start; i < nums.Length; ++i)
        {
            prefix.Add(nums[i]);
            SubsetsBackTracking(nums, i+1, prefix, result);
            prefix.RemoveAt(prefix.Count-1);
        }
    }
}
