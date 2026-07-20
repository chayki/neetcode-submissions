public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length <=1 )
            return nums.Length;
        int maxConsecutiveLength = 1;
        HashSet<int> set = new HashSet<int>(nums);
        foreach (int num in nums)
        {
            if (set.Contains(num-1)) continue;
            int length = LengthOfConsecutiveSequenceStartsWith(num, set);
            maxConsecutiveLength = Math.Max(maxConsecutiveLength, length);
        }

        return maxConsecutiveLength;
    }

    public int LengthOfConsecutiveSequenceStartsWith(int num, HashSet<int> set)
    {
        int length = 1;
        while (set.Contains(num+1))
        {
            ++length;
            ++num;
        }
        return length;
    }
}
