// Brute force
// Total volume of water trapped = Sum of volume of water trapped at each position
// water trapped at position i = Min of (Max height in the range 0..i-1, max height in the range i+1..n-1) - height of position i
public class Solution {
    public int Trap(int[] height) {
        int totalWaterTrapped = 0;

        if (height.Length <= 1) return totalWaterTrapped;

        for (int pos = 0; pos < height.Length; ++pos)
        {
            totalWaterTrapped += WaterTrappAtPos(pos, height);
        }
        return totalWaterTrapped;
    }

    private int WaterTrappAtPos(int i, int[] height)
    {
        int leftMax = 0;
        for (int pos = 0; pos < i; ++pos)
        {
            leftMax = Math.Max(height[pos], leftMax);
        }
        int rightMax = 0;
        for (int pos = i+1; pos < height.Length; ++pos)
        {
            rightMax = Math.Max(height[pos], rightMax);
        }

        int minHeight = Math.Min(leftMax, rightMax);
        return minHeight > height[i] ? minHeight-height[i] : 0;
    }
}
