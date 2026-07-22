//Binary Search based solution
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        //Every element in the array can be one possible candidate of the pair adding upto target.
        //So for every element at index i in the array we have to check for the presence of target-i in the range i+1..n-1
        //since the array is sorted, binary search can be used to find an element in a range i..j where i >= 0 and j < n

        for (int item1Idx = 0; item1Idx < numbers.Length; ++item1Idx)
        {
            int item2Idx = BinarySearch(target-numbers[item1Idx], item1Idx+1, numbers.Length-1, numbers);
            if (item2Idx != -1)
            {
                return new int[2] {++item1Idx, ++item2Idx};
            }
        }
        return new int[2];
    }

    public int BinarySearch(int target, int left, int right, int[] numbers)
    {
        while (left <= right)
        {
            int mid = left + (right-left)/2;
            if (numbers[mid] == target) return mid;
            else if (target < numbers[mid]) right = mid-1;
            else left = mid+1;
        }
        
        return -1;
    }
}
