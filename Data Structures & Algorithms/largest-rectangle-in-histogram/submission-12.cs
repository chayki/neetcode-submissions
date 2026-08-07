// if we think from each bar's perspective, each bar can form a rectangle of its own height. how about width?
// width == how far the same bar height stretches to the left and to the right
// pre construct the left width and right width for each position
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        if (heights.Length == 1) return heights[0];

        int[] leftMost = new int[heights.Length];
        int[] rightMost = new int[heights.Length];
 
        Stack<int> stack = new Stack<int>();
        stack.Push(-1);

        for (int i = 0; i < heights.Length; ++i)
        {
            while(stack.Peek() >= 0 && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            leftMost[i] = stack.Peek()+1;
            stack.Push(i);
        }

        stack.Clear();
        stack.Push(heights.Length);

        for (int i = heights.Length-1; i >=0; --i)
        {
            while (stack.Peek() < heights.Length && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            rightMost[i] = stack.Peek()-1;
            stack.Push(i);
        }

        int maxRectangle = 0;
        for (int i = 0; i < heights.Length; ++i)
        {
            int area = (rightMost[i]-leftMost[i]+1)*heights[i];
            maxRectangle = Math.Max(area, maxRectangle);
        }

        return maxRectangle;
    }
}
