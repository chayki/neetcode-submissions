// Sorting
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; ++i) {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;  // checks if the current num is same as the previous num

            if (nums[i] > 0) // rest of the array elements right to the element are positive so the sum can't be zero break the loop
                break;

            int left = i + 1;
            int right = nums.Length - 1;

            int target = -nums[i];
            while (left < right) {
                int pairSum = nums[left] + nums[right]; // integer overflow may occur here, safest way is to use long
                if (pairSum == target) {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    ++left;
                    --right;

                    while (left < right && nums[left] == nums[left-1]) ++left;
                    while (left < right && nums[right] == nums[right+1]) --right;
                } else if (pairSum < target) {
                    ++left;
                } else {
                    --right;
                }         
            }
        }

        return result;
    }
}
