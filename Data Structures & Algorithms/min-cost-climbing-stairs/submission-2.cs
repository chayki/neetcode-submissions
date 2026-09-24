public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] minCost = new int[cost.Length+1];
        minCost[0] = 0;
        minCost[1] = 0;

        for (int i = 2; i < minCost.Length; ++i)
        {
            minCost[i] = Math.Min(minCost[i-1] + cost[i-1], minCost[i-2] + cost[i-2]);
        }

        return minCost[minCost.Length-1];
    }
}


