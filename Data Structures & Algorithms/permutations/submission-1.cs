public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var result = new List<List<int>>();
        PermuteDFS(nums, new HashSet<int>(), result);
        return result;
    }

    public void PermuteDFS(int[] nums, HashSet<int> set, List<List<int>> result)
    {
        if (set.Count == nums.Length)
        {
            result.Add(set.ToList());
            return;
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            if (set.Contains(nums[i])) continue;
            set.Add(nums[i]);
            PermuteDFS(nums, set, result);
            set.Remove(nums[i]);
        }
    }
}
