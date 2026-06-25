public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] prefixProducts = new int[nums.Length];
        int[] suffixProducts = new int[nums.Length];
        int[] result = new int[nums.Length];

        int runningPrefixProduct = 1;
        for(int i = 0; i < nums.Length; ++i)
        {
            prefixProducts[i] = runningPrefixProduct;
            runningPrefixProduct *= nums[i];
        }

        int runningSuffixProduct = 1;
        for (int i = nums.Length-1; i >= 0; --i)
        {
            suffixProducts[i] = runningSuffixProduct;
            runningSuffixProduct *= nums[i];
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            result[i] = prefixProducts[i]*suffixProducts[i];
        }

        return result;
    }
}
