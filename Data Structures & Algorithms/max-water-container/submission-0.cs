// We need to find the max amount of water that can be stored in a container. Lets disect the problem to see if we can do 
// any further optimization instead of checking each and every pair.
// Every container has a left wall and a right wall.
// Area of the container = distance between the walls * min height of the walls. So the deciding factors here are min height wall and distance between walls.
// for any container that gets formed with that min height wall (lets say height x), the max height is x, it can't go beyond that.
// So there can't be a container with greater volume for any right wall with lesser distance. So those can be ignored.
// we can optimize the solution by ignoring any other smaller width containers that can formed with the shorter wall 
// So start with max width i.e, one wall at 0th position and one wall at n-1th position.
// Compute the area and ignore the smaller wall from further computations i.e., left++ if left is shorter otherwise right++
// Keep track of the maximum container volume/area.

public class Solution {
    public int MaxArea(int[] heights) {
        int maxArea = 0;
        if (heights.Length <= 1) return maxArea;
        int left = 0;
        int right = heights.Length-1;
        while (left < right)
        {
            int area = (right-left)*Math.Min(heights[left], heights[right]);
            maxArea = Math.Max(area, maxArea);

            if (heights[left] < heights[right])
            {
                ++left;
            }
            else if (heights[left] > heights[right])
            {
                --right;
            }
            else
            {
                ++left;
                --right;
            }
        }

        return maxArea;
    }
}
