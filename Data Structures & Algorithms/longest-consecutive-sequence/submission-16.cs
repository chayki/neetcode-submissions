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
                unionFind.Union(num, num+1);
            }
        }

        return unionFind.MaxSize;
    }

    public class UnionFind
    {
        readonly int[] parent;
        readonly int[] size;
        readonly Dictionary<int,int> numsIndexMap = new();
        int maxSize = 1;

        public int MaxSize => maxSize;

        public UnionFind(IReadOnlyCollection<int> set)
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

        public int FindRoot(int num)
        {
            return Find(numsIndexMap[num]);
        }

        public void Union(int num1, int num2)
        {

            int xRoot = FindRoot(num1);
            int yRoot = FindRoot(num2);

            if (xRoot != yRoot)
            {
                if (size[xRoot] > size[yRoot])
                {
                    parent[yRoot] = xRoot;
                    size[xRoot] += size[yRoot];
                    maxSize = Math.Max(maxSize, size[xRoot]);
                }
                else
                {
                    parent[xRoot] = yRoot;
                    size[yRoot] += size[xRoot];
                    maxSize = Math.Max(maxSize, size[yRoot]);
                }
            }
        }

        private int Find(int index)
        {
            if (parent[index] != index)
            {
                parent[index] = Find(parent[index]);
            }

            return parent[index];
        }
    }
}
