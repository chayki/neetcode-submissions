public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        var result = new List<List<int>>();
        Array.Sort(nums);
        SubsetsWithDupDFS(nums, 0, new List<int>(), result);
        return result;
    }

    public void SubsetsWithDupDFS(int[] nums, int start, List<int> path, List<List<int>> result)
    {
        result.Add(new List<int>(path));

        for (int i = start; i < nums.Length; ++i)
        {
            if (i > start && nums[i] == nums[i-1]) continue;
            path.Add(nums[i]);
            SubsetsWithDupDFS(nums, i+1, path, result);
            path.RemoveAt(path.Count-1);
        }
    }
}
