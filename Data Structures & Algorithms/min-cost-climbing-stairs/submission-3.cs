public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        //int[] minCost = new int[cost.Length+1];
        int minCostLastStep = 0;
        int minCostSecondLastStep = 0;

        for (int i = 2; i < cost.Length+1; ++i)
        {
            var currCost = Math.Min(minCostLastStep + cost[i-1], minCostSecondLastStep + cost[i-2]);
            minCostSecondLastStep = minCostLastStep;
            minCostLastStep = currCost;
        }

        return minCostLastStep;
    }
}


