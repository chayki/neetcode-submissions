public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] prefixProducts = new int[n];
        int[] suffixProducts = new int[n];
        int[] result = new int[n];

        prefixProducts[0] = 1;
        suffixProducts[n-1] = 1;
        for(int i = 1; i < nums.Length; ++i)
        {
            prefixProducts[i] = prefixProducts[i-1]*nums[i-1];
        }

        for (int i = nums.Length-2; i >= 0; --i)
        {
            suffixProducts[i] = suffixProducts[i+1]*nums[i+1];
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            result[i] = prefixProducts[i]*suffixProducts[i];
        }

        return result;
    }
}
