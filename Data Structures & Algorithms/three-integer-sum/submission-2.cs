// Sorting
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; ++i) {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;  // checks if the current num is same as the previous num

            int left = i + 1;
            int right = nums.Length - 1;

            int remainingSum = 0 - nums[i];
            while (left < right) {
                if (left > i+1 && nums[left] == nums[left - 1]) {
                    ++left;
                    continue;
                } else if (right < nums.Length -1 && nums[right] == nums[right + 1]) {
                    --right;
                    continue;
                }
                int pairSum = nums[left] + nums[right];
                if (pairSum == remainingSum) {
                    result.Add(new List<int>(3) { nums[i], nums[left], nums[right] });
                    ++left;
                    --right;
                } else if (pairSum < remainingSum) {
                    ++left;
                } else {
                    --right;
                }
            }
        }

        return result;
    }
}
