public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        
        int maxAmountLast = Math.Max(nums[0], nums[1]);
        int maxAmountSecondLast = nums[0];

        for (int i = 2; i < nums.Length; ++i)
        {
            var currMaxAmount = Math.Max(maxAmountLast, maxAmountSecondLast+nums[i]);
            maxAmountSecondLast = maxAmountLast;
            maxAmountLast = currMaxAmount;
        }

        return maxAmountLast;
    }
}

/*
Recurrence relation:
MaxAmount(i) = Math.Max(MaxAmount(i-1), MaxAmout(i-2)+Amount(i));
*/
