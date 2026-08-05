// Brute force:
// for each position i in the array loop through i+1..n to get the element > temperatures[i]
//
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int[] result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; ++i)
        {
            result[i] = ComputeDistanceToNextWarmerTemp(i, temperatures);
        }
        return result;
    }

    public int ComputeDistanceToNextWarmerTemp(int currIdx, int[] temperatures)
    {
        int currTemp = temperatures[currIdx];
        int distance = 1;
        int i = currIdx+1;
        while (i < temperatures.Length && currTemp >= temperatures[i])
        {
            ++distance;
            ++i;
        }
        return i == temperatures.Length ? 0 : distance;
    }
}
