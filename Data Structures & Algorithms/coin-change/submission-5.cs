public class Solution {
    public int CoinChange(int[] coins, int amount) {
        Dictionary<int,int> amountFewestCoins = new();
        return CoinChangeRecursion(
            coins,
            amount,
            amountFewestCoins);
    }

    public int CoinChangeRecursion(
        int[] coins,
        int amount,
        Dictionary<int,int> amountFewestCoins)
    {
        if (amountFewestCoins.TryGetValue(amount, out int coinCount))
        {
            return coinCount;
        }

        if (amount == 0) return 0;
        if (amount < 0) return -1;
        int fewestCoins = int.MaxValue;
        for (int i = 0; i < coins.Length; ++i)
        {
            int coinChange = CoinChangeRecursion(
                coins,
                amount-coins[i],
                amountFewestCoins);
            if (coinChange >= 0)
            {
                fewestCoins = Math.Min(fewestCoins, 1 + coinChange);
            }
        }

        if (fewestCoins == int.MaxValue)
        {
            amountFewestCoins.Add(amount, -1);            
        }
        else
        {
            amountFewestCoins.Add(amount, fewestCoins);
        }

        return amountFewestCoins[amount];
    }
}