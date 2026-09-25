public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int n = nums.Length;
        return Math.Max(LinearMaxAmout(nums,0,n-2), LinearMaxAmout(nums, 1, n-1));
    }

    public int LinearMaxAmout(int[] nums, int start, int end)
    {
        int maxSecondLast = 0;
        int maxLast = nums[start];
        for (int i = start+1; i <= end; ++i)
        {
            var currAmount = Math.Max(maxLast, maxSecondLast+nums[i]);
            maxSecondLast = maxLast;
            maxLast = currAmount;
        }

        return maxLast;
    }
}
/*
1. Calculate the maxAmount for the range 0..n-1
2. Calculate the maxAmount for the range 1..n
3. Return max of #1 and #2
*/
