// Repeated work int he brute force approach: maximum on each side of the position is repeatedly computed.
// Instead of repeatedly computing, keep the leftMax and rightMax precomputed at each position
// When started at pos 0, leftMax = 0 and rightMax = max of the array
// Time complexity is O(n) since we are not repeatedly computing the leftMax and rightMax
// Space complexity is O(n) since we are precomputing and storing leftMax, rightMax at each position
public class Solution {
    public int Trap(int[] height) {
        int totalWaterTrapped = 0;
        if (height.Length <= 1) return totalWaterTrapped;
        int[] leftMaxHeights = new int[height.Length];
        int[] rightMaxHeights = new int[height.Length];

        int leftMaxHeight = 0;
        for (int i = 0; i < height.Length; ++i)
        {
            leftMaxHeights[i] = leftMaxHeight;
            leftMaxHeight = Math.Max(leftMaxHeight, height[i]);
        }

        int rightMaxHeight = 0;
        for (int i = height.Length-1; i >= 0; --i)
        {
            rightMaxHeights[i] = rightMaxHeight;
            rightMaxHeight = Math.Max(rightMaxHeight, height[i]);
        }

        for (int pos = 0; pos < height.Length; ++pos)
        {
            totalWaterTrapped += WaterTrappedAtPos(pos, height, leftMaxHeights, rightMaxHeights);
        }

        return totalWaterTrapped;
    }

    private int WaterTrappedAtPos(
        int pos,
        int[] height,
        int[] leftMaxHeights, 
        int[] rightMaxHeights)
    {
        int netVolume = Math.Min(leftMaxHeights[pos], rightMaxHeights[pos]) - height[pos];
        return netVolume > 0 ? netVolume : 0;
    }
}
