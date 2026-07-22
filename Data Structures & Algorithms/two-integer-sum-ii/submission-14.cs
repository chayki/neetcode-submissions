// HashMap based solution
// For each element , we need to find if the second element is present in the array which added together can sum upto target
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        Dictionary<int,int> numIndexMap = new Dictionary<int,int>(numbers.Length);
        for (int i = 0; i < numbers.Length; ++i)
        {
            int item2 = target - numbers[i];
            if (numIndexMap.ContainsKey(item2))
            {
                return new int[2] {numIndexMap[item2], i+1};
            }
            else
            {
                numIndexMap.Add(numbers[i], i+1);
            } 
        }
        return new int[2];
    }
}
