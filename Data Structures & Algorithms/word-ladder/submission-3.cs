/*for every word we loop through all the neighbors in the word list. It will be inefficient since the cost depends on the length of the list.
I would rather generate all possible one distance neighbors and check if the neighbor is present in the list.
Each position has 25 choices, so total choices 25*L*/
public class Solution {
    char[] alphabet = new char[26] {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
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
                wordSet.Remove(neighbor);
            }
        }

        return 0;
    }

    public List<string> GenerateNeighbors(string word, HashSet<string> wordSet)
    {
        List<string> neighbors = new List<string>();
        char[] charArray = word.ToCharArray();

        for (int pos = 0; pos < charArray.Length; ++pos)
        {
            char posChar = charArray[pos];
            for (int j = 0; j < 26; ++j)
            {
                if (alphabet[j] == posChar) continue;
                charArray[pos] = alphabet[j];
                var str = new string(charArray);
                if (wordSet.Contains(str)) neighbors.Add(str);
            }

            charArray[pos] = posChar;
        }

        return neighbors;
    }
}
