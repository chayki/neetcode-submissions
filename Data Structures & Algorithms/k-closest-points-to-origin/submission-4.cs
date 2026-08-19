public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        if (k == 0) return new int[0][];
        var result = new int[k][];
        // create a max heap of capacity k
        PriorityQueue<int,long> maxHeap = new PriorityQueue<int,long>(Comparer<long>.Create((x,y) => y.CompareTo(x)));
        // add distances of the points 0..k-1 to the heap
        for (int i = 0; i < k; ++i)
        {
            maxHeap.Enqueue(i,Distance(points[i][0], points[i][1]));
        }

        // for the points from k to n
        for (int i = k; i < points.Length; ++i)
        {
            var distance = Distance(points[i][0], points[i][1]);
            if (maxHeap.TryPeek(out int key, out long maxDistance) && distance < maxDistance)
            {
                maxHeap.Dequeue();
                maxHeap.Enqueue(i, distance);
            }
        }
        // iterate through heap and add the points to result and return;

        int index = 0;
        while (maxHeap.TryDequeue(out int item, out _))
        {
            result[index] = points[item];
            ++index;
        }
        return result;
    }

    private long Distance(int x, int y)
    {
        return (((long)x*x) + ((long)y*y));
    }
}
