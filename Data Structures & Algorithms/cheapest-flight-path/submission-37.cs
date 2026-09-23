/*
Bellman-Ford algorithm
Repeatedly relax all the edges allowing information to propagate one flight farther per round.
Invariant:
After ith round of relaxation, we will have min cost to all the desinations reachable by <= i flights
After ith round of relaxation, dist[v] contains min cost to reach every destination v using atmose i flights
*/
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // declare minCost array to store running minimum cost to reach each reachable destination till the current iteration
        int[] currMinCost = new int[n];
        Array.Fill(currMinCost, int.MaxValue);

        currMinCost[src] = 0;
        int flightsUsed = 0;

        while (flightsUsed < k+1)
        {
            int[] nextMinCost = (int[])currMinCost.Clone();
            
            foreach (int[] flight in flights)
            {
                int source = flight[0];
                int destination = flight[1];
                int flightCost = flight[2];
                if (currMinCost[source] != int.MaxValue && currMinCost[source]+flightCost < nextMinCost[destination] )
                {
                    nextMinCost[destination] = currMinCost[source]+flightCost;
                }
            }

            currMinCost = nextMinCost;
            ++flightsUsed;
        }

        return (currMinCost[dst] == int.MaxValue) ? -1 : currMinCost[dst];
    }
}
