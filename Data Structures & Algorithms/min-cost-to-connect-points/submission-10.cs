public class Solution {
    public int MinCostConnectPoints(int[][] points) {
       bool[] connected = new bool[points.Length];
       int connectedCount = 0;
       int nextMinCostPoint = 0;
       int[] minKnownCost = new int[points.Length];

       for (int i = 1; i < points.Length; ++i)
       {
            minKnownCost[i] = int.MaxValue; 
       }
       int totalCost = 0;

       while (connectedCount < points.Length)
       {
            int[] nextPoint = points[nextMinCostPoint];
            totalCost += minKnownCost[nextMinCostPoint];
            connected[nextMinCostPoint] = true;
            ++connectedCount;
            int minCost = int.MaxValue;
            for (int i = 0; i < points.Length; ++i)
            {
                if (connected[i]) continue;
                int pointDistance = Math.Abs(points[i][0]-nextPoint[0]) + Math.Abs(points[i][1]-nextPoint[1]);
                if (pointDistance < minKnownCost[i]) minKnownCost[i] = pointDistance;
                if (minKnownCost[i] < minCost) 
                {
                    nextMinCostPoint = i;
                    minCost = minKnownCost[i];
                }
            }
       }

       return totalCost;
    }
}

/*
1. Create a connected set to hold the node indexes alredy added to the connected component
2. Create a minKnownCost array to hold minimum cost of edges from connected to the unconnected nodes
3. Create a global variable to store next min cost node to the connected component
4. while connected count < points count
    read global next min cost node
    a. get the destination from points and get the cost from minKnownCost array
    b. add cost to the result
    c. For each unvisited node
        i. update the minKnownCost array
        ii. Update the global min */
