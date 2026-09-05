public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> visited = new(wordList.Count);
        Queue<(string,int)> queue = new();
        queue.Enqueue((beginWord,1));
        visited.Add(beginWord);

        while (queue.Count > 0)
        {
            (string word, int distance) = queue.Dequeue();
            if (word == endWord) return distance;
            foreach (var neighbor in wordList)
            {
                if (!visited.Contains(neighbor) && EditDistance(neighbor, word) == 1) 
                {
                    visited.Add(neighbor);
                    queue.Enqueue((neighbor,distance+1));
                }
            }
        }

        return 0;
    }

    public int EditDistance(string word1, string word2)
    {
        int count = 0;
        for (int i = 0; i < word1.Length; ++i)
        {
            if (word1[i] != word2[i]) ++count;
        }

        return count;
    }
}



/* I will create a graph where nodes are words and edges representing 1 edit distance. I will do a BFS to find the shortest distance from begin word to end word */
