public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        LinkedList<(int,int)> deque = new LinkedList<(int,int)>();
        int[] result = new int[temperatures.Length];

        int right = temperatures.Length-1;
        result[right] = 0;
        deque.AddFirst((right, temperatures[right]));

        for (int j = right-1; j >=0; --j)
        {
            // remove lesser bars from the deque
            while (deque.Count > 0 && deque.First.Value.Item2 <= temperatures[j])
            {
                deque.RemoveFirst();
            }

            int distance = deque.Count == 0 ? 0 : deque.First.Value.Item1-j;
            result[j] = distance;
            deque.AddFirst((j, temperatures[j]));
        }

        return result;
    }
}
