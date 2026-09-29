public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount+1];
        Array.Fill(dp, amount+1);
        dp[0] = 0;

        foreach (int coin in coins)
        {
            for (int i = coin; i <= amount; ++i)
            {
                dp[i] = Math.Min(dp[i-coin]+1, dp[i]);
            }
        }

        // for (int i = 1; i < dp.Length; ++i)
        // {
        //     int currAmount = i;
        //     foreach (int coin in coins)
        //     {
        //         int remAmount = currAmount - coin;
        //         if (remAmount < 0) break;
        //         if (dp[remAmount] == (amount+1)) continue;
        //         dp[currAmount] = Math.Min(dp[remAmount]+1, dp[currAmount]);
        //     }
        // }

        return dp[amount] == amount+1 ? -1 : dp[amount];
    }
}