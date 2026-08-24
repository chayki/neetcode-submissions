public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        // for each element i, there are two choices i can be included or not included
        // for all the subsets of the set [0, i-1], include i and not include i

        var result = new List<List<int>>() { new List<int>() };

        foreach (int num in nums)
        {
            int size = result.Count;
            for(int i = 0; i < size; ++i)
            {
                var clonedSubset = new List<int>(result[i]);
                clonedSubset.Add(num);
                result.Add(clonedSubset);
            }
        }

        return result;
    }
}
