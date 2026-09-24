public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        
        int n = nums.Length;
        var dp = new int[n+1];
        dp[0] = 0;  //not robbing any house
        dp[1] = nums[0]; // max amount from robbing 1 house

        for (int i = 2; i < n+1; ++i)
        {
            dp[i] = Math.Max(dp[i-1], dp[i-2]+nums[i-1]);
        }

        return dp[n];
    }
}

/*
Recurrence relation:
MaxAmount(i) = Math.Max(MaxAmount(i-1), MaxAmout(i-2)+Amount(i));
*/
