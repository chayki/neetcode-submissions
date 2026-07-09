public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length <= 1) return nums.Length;
        HashSet<int> set = new HashSet<int>(nums);
        int max = int.MinValue;
        int maxLength = int.MinValue;
        int min = int.MaxValue;

        foreach (int i in nums)
        {
            if (i >= min && i <= max) continue;
            int curr = i;
            while (set.Contains(curr-1)) --curr;
            min = Math.Min(min, curr);
            int length = ConsecutiveLengthStartsWith(curr, set, ref max);
            maxLength = Math.Max(length, maxLength);

        }
        return maxLength;
    }

    public int ConsecutiveLengthStartsWith(int start, HashSet<int> set, ref int max)
    {
        int length = 1;
        while (set.Contains(start+1)) {
            ++start;
            ++length;
        }
        max = start;
        return length;
    }
}
