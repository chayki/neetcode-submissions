//Sorting + HashSet based approach
// Time complexity - same as that of two pointer approach O(n^2)
// space complexity - O(n)
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        Dictionary<int,int> map = new (); // we have to keep the count of elements along with the element itself because duplicate counting of element can be avoided by checking for the remaining count
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
            {
                map[num]=0;
            }
            map[num]++;
        }

        Array.Sort(nums);

        for (int i = 0; i < nums.Length-1; ++i)
        {
            map[nums[i]]--;
            if (i > 0 && nums[i] == nums[i-1]) continue;
            for (int j = i+1; j < nums.Length; ++j)
            {
                map[nums[j]]--;
                if (j > i+1 && nums[j] == nums[j-1]) continue;
                int target = -(nums[i]+nums[j]);

                if (map.ContainsKey(target) && map[target] > 0)
                {
                    result.Add(new List<int> {nums[i], nums[j], target});
                }
            }

            // replenish the counts after the exit of the inner loop
            for (int j = i+1; j < nums.Length; ++j)
            {
                map[nums[j]]++;
            }
        }

        return result;       
    }
}
