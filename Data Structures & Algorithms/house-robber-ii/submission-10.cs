public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int n = nums.Length;
        return Math.Max(LinearMaxAmout(nums,0,n-2), LinearMaxAmout(nums, 1, n-1));
    }

    public int LinearMaxAmout(int[] nums, int start, int end)
    {
        int n = end-start+2;
        // int[] dp = new int[n];
        // dp[0] = 0;
        // dp[1] = nums[start];
        int maxSecondLast = 0;
        int maxLast = nums[start];
        int offset = start -1;
        for (int i = 2; i < n; ++i)
        {
            var currAmount = Math.Max(maxLast, maxSecondLast+nums[i+offset]);
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
