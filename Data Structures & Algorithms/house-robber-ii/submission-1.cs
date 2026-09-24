public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int n = nums.Length;
        /* Calculate the maxAmount for the range 0..n-1*/
        int[] dp = new int[n];
        dp[0] = 0; // not robing any house
        dp[1] = nums[0]; // max amount upto one house

        for (int i = 2; i < n ; ++i)
        {
            dp[i] = Math.Max(dp[i-1], dp[i-2] + nums[i-1]);
        }
        int range1Max = dp[n-1];

        /*Calcuate the maxAmount for the range 1..n*/
        dp = new int[n];
        dp[0] = 0; // not robing any house
        dp[1] = nums[1]; // max amount upto one house

        for (int i = 2; i < n ; ++i)
        {
            dp[i] = Math.Max(dp[i-1], dp[i-2] + nums[i]);
        }
        int range2Max = dp[n-1];
        return Math.Max(range1Max, range2Max);
    }
}
/*
1. Calculate the maxAmount for the range 0..n-1
2. Calculate the maxAmount for the range 1..n
3. Return max of #1 and #2
*/
