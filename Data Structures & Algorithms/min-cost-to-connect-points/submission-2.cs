public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        HashSet<int> connected = new();
        PriorityQueue<int,int> pq = new();
        int totalCost = 0;
        pq.Enqueue(0,0);
        while (connected.Count < points.Length)
        {
            if (pq.TryDequeue(out int destIndex, out int cost) && !connected.Contains(destIndex))
            {
                connected.Add(destIndex);
                totalCost+=cost;
                for(int i = 0; i < points.Length; ++i)
                {
                    if (connected.Contains(i)) continue;
                    int edgeCost = Math.Abs(points[i][0]-points[destIndex][0]) + Math.Abs(points[i][1]-points[destIndex][1]);
                    pq.Enqueue(i, edgeCost);
                }
            }
        }

        return totalCost;
    }
}
