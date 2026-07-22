//union find implementation - more complex implementation than HashSet based solution with the same time and space
public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length <= 1) return nums.Length;
        HashSet<int> set = new HashSet<int>(nums);
        UnionFind unionFind = new UnionFind(set);
        int maxLength = 1;

        // a single element can be connected to previous element as well as next element which are 1 distance away
        // To avoid repeated we proceed through only one direction either +1 or -1

        foreach (int num in set)
        {
            if (set.Contains(num+1))
            {
                int unionLength = unionFind.Union(num, num+1);
                maxLength = Math.Max(maxLength, unionLength);
            }
        }

        return maxLength;
    }

    public class UnionFind
    {
        int[] parent;
        int[] size;
        Dictionary<int,int> numsIndexMap = new();

        public UnionFind(HashSet<int> set)
        {
            parent = new int[set.Count];
            size = new int[set.Count];
            int i = 0;
            foreach (int num in set)
            {
                numsIndexMap.Add(num, i);
                parent[i] = i;
                size[i] = 1;
                ++i;
            }
        }

        public int Find(int num)
        {
            int x = numsIndexMap[num];
            while (parent[x] != x)
            {
                x = parent[x];
            }
            return x;
        }

        public int Union(int num1, int num2)
        {

            int xRoot = Find(num1);
            int yRoot = Find(num2);

            if (xRoot != yRoot)
            {
                parent[yRoot] = xRoot;
                size[xRoot] += size[yRoot];
            }
            
            return size[xRoot];
        }
    }
}
