public class Solution {
    public int ClimbStairs(int n) {     
        if (n <= 1) return 1;
        int lastStepWays = 1;
        int secondLastStepWays = 1;

        for (int i = 2; i <= n; ++i)
        {
            var currStepWays = lastStepWays + secondLastStepWays;
            secondLastStepWays = lastStepWays;
            lastStepWays = currStepWays;
        }

        return lastStepWays;
    }
}
