public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount+1];
        Array.Fill(dp, amount+1);
        dp[0] = 0;

        for (int i = 1; i < dp.Length; ++i)
        {
            int currAmount = i;
            foreach (int coin in coins)
            {
                int remAmount = currAmount - coin;
                if (remAmount < 0 || dp[remAmount] == (amount+1)) continue;
                dp[currAmount] = Math.Min(dp[remAmount]+1, dp[currAmount]);
            }
        }

        return dp[amount] == amount+1 ? -1 : dp[amount];
    }
}

/* I will build the fewest coins needed for all the amounts in the range 1..amount.
Formula: 
foreach sum k in the range 1..amount
foreach coin
    remAmount = k-coin;
    remAmount < 0 continue;
    dp[k] = min of (dp[remAmount]+1, dp[k]);


return dp[amount]
*/
