public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int maxFlights = k+1;
        int airports = n;

        int[][] state = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            state[i] = new int[maxFlights+1];
            Array.Fill(state[i], int.MaxValue);
        }


        // create adjacency list for the flights
        Dictionary<int,List<(int,int)>> adjList = new();

        for (int i = 0; i < n; ++i)
        {
            adjList.Add(i, new List<(int,int)>());
        }

        for (int i = 0; i < flights.Length; ++i)
        {
            int source = flights[i][0];
            int destination = flights[i][1];
            adjList[source].Add((destination, flights[i][2]));
        }

        Queue<(int destination, int flightCount, int cost)> queue = new();
        queue.Enqueue((src,0,0));

        while (queue.Count > 0)
        {
            (int currAirport, int flightCount, int cost) = queue.Dequeue();
            if (state[currAirport][flightCount] > cost) 
            {
                state[currAirport][flightCount] = cost;
                if (flightCount < k+1)
                {
                    foreach ((int nextAirport, int nextLegCost) in adjList[currAirport])
                    {
                        queue.Enqueue((nextAirport, flightCount+1, cost+nextLegCost));
                    }   
                }
            }
        }

        int minCost = int.MaxValue;
        for (int i = 0; i < state[0].Length; ++i)
        {
            if (state[dst][i] < minCost) minCost = state[dst][i];
        }

        return minCost == int.MaxValue ? -1 : minCost;
    }
}

/* k max stops (not including src and dst) => k+1 max flights
i.e., we can travel only k+1 flights from the source */
/* Recurrence relation:

*/
