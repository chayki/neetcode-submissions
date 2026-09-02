public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var outDegree = new int[numCourses];
        var incoming = new List<int>[numCourses];
        List<int> result = new List<int>();
        for (int i = 0; i < numCourses; ++i)
            incoming[i] = new List<int>();

        foreach (var prereq in prerequisites)
        {
            int course = prereq[0];
            int prerequisite = prereq[1];
            incoming[prerequisite].Add(course);
            outDegree[course]++;
        }

        Queue<int> queue = new();
        for (int i = 0; i < numCourses; ++i)
            if (outDegree[i] == 0) queue.Enqueue(i);

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            result.Add(course);
            foreach (var predecessor in incoming[course])
            {
                outDegree[predecessor]--;
                if (outDegree[predecessor] == 0) queue.Enqueue(predecessor);
            }
        }

        return result.Count == numCourses ? result.ToArray() : [];
    }
}
/* Space complexity: O(V+E)
O(V) to store outdegree
O(V+E) to store incoming edges

Time complexity:
O(V+E)*/
