public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        // delay map
        Dictionary<int,int> receptionTimes = new();
        
        // build graph
        var adjList = new List<(int,int)>[n+1];
        for (int i = 1; i <= n; ++i)
        {
            adjList[i] = new List<(int,int)>();
        }

        foreach(int[] edge in times)
        {
            int source = edge[0];
            int dest = edge[1];
            int weight = edge[2];
            adjList[source].Add((dest, weight));
        }

        var pq = new PriorityQueue<int,int>();
        pq.Enqueue(k,0);
        var totalTime = 0;
        int reachedNodes = 0;
        while (pq.TryDequeue(out int node, out int receptionTime) && reachedNodes < n)
        {
            if(receptionTimes.ContainsKey(node)) continue;
            totalTime = receptionTime;
            reachedNodes++;
            receptionTimes[node] = receptionTime;
            foreach ((int nb, int nbTime) in adjList[node])
            {
                int totalNbTime = receptionTime+nbTime;
                if(!receptionTimes.ContainsKey(nb))
                {
                    pq.Enqueue(nb, totalNbTime);
                }
            }
        }

        return (reachedNodes == n) ? totalTime : -1;
    }
}

/* Its a weighted directional graph. I will start with a source node and find the next earliest reachable node.
I will traverse to that node and update the result with total time from the source node to that node.
I will keep track of the visited to not visit the node that's already visited. The total time when I visit the last unvisited node
is the total delay */

/* Repeatedly process unvisited node with smallest known distance from the source, then use it to update the neighboring distances. */
