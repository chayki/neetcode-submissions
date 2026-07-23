// brute force
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        HashSet<(int,int,int)> set = new HashSet<(int,int,int)>();

        for (int i = 0; i < nums.Length-2; ++i)
        {
            for (int j = i+1; j < nums.Length-1; ++j)
            {
                for (int k = j+1; k < nums.Length; ++k)
                {
                    if (nums[i]+nums[j]+nums[k] == 0)
                    {
                        int[] triplet = new int[3] {nums[i], nums[j], nums[k]};
                        Array.Sort(triplet);
                        if (!set.Contains((triplet[0], triplet[1], triplet[2])))
                        {
                            set.Add((triplet[0], triplet[1], triplet[2]));
                            result.Add(new List<int>(3) { triplet[0], triplet[1], triplet[2]});
                        }
                    }
                }
            }
        }

        return result;
    }
}
