public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var result = new List<List<int>>();
        PermuteDFS(nums, new List<int>(), result, new bool[nums.Length]);
        return result;
    }

    public void PermuteDFS(int[] nums, List<int> path, List<List<int>> result, bool[] visited)
    {
        if (path.Count == nums.Length)
        {
            result.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            if (visited[i]) continue;
            path.Add(nums[i]);
            visited[i] = true;
            PermuteDFS(nums, path, result, visited);
            path.Remove(nums[i]);
            visited[i] = false;
        }
    }
}