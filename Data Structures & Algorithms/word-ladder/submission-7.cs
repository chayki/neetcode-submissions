/*for every word we loop through all the neighbors in the word list. It will be inefficient since the cost depends on the length of the list.
I would rather generate all possible one distance neighbors and check if the neighbor is present in the list.
Each position has 25 choices, so total choices 25*L*/
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        Queue<(string, int)> queue = new();
        queue.Enqueue((beginWord, 1));
        wordSet.Remove(beginWord);
        while (queue.Count > 0)
        {
            (var word,var distance) = queue.Dequeue();
            if (word == endWord) return distance;
            foreach (string neighbor in GenerateNeighbors(word, wordSet))
            {
                queue.Enqueue((neighbor, distance+1));
            }
        }

        return 0;
    }

    public List<string> GenerateNeighbors(string word, HashSet<string> wordSet)
    {
        List<string> neighbors = new List<string>();
        char[] chars = word.ToCharArray();

        for (int pos = 0; pos < chars.Length; ++pos)
        {
            char original = chars[pos];
            for (char c = 'a'; c <= 'z'; ++c)
            {
                if (c == original) continue;
                chars[pos] = c;
                var candidate = new string(chars);
                if (wordSet.Remove(candidate)) neighbors.Add(candidate);
            }

            chars[pos] = original;
        }

        return neighbors;
    }
}
