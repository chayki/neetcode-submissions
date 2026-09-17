public class Solution {
    Dictionary<char, List<char>> incomingEdges = new();
    Dictionary<char,int> outDegree = new();
    HashSet<char> uniqueChars = new();

    public string foreignDictionary(string[] words) {
        if (words.Length == 1) return words[0];
        if(ExtractAndMapEdges(words, incomingEdges, outDegree))
        {
            return TopologicalOrdering(incomingEdges, outDegree);
        }
        return string.Empty;       
    }

    public bool ExtractAndMapEdges(
        string[] words,
        Dictionary<char,List<char>> incomingEdges,
        Dictionary<char,int> outDegree)
    {
        int n = words.Length;
        for (int i = 0; i < n-1; ++i)
        {
            int minLength = Math.Min(words[i].Length, words[i+1].Length);
            string currWord = words[i];
            string nextWord = words[i+1];
            bool firstDifferentLetter = true;
            if (currWord.Length > nextWord.Length && currWord.StartsWith(nextWord)) return false;
            for (int j = 0; j < Math.Max(currWord.Length, nextWord.Length); ++j)
            {
                if (j < currWord.Length && j < nextWord.Length && currWord[j] != nextWord[j] && firstDifferentLetter)
                {
                    CreateEdgeAndUpdateDegrees(currWord[j], nextWord[j]);
                    firstDifferentLetter = false;
                }
                else if (j < currWord.Length && !outDegree.ContainsKey(currWord[j]))
                {
                    outDegree.Add(currWord[j], 0);
                }
                else if (j < nextWord.Length && !outDegree.ContainsKey(nextWord[j]))
                {
                    outDegree.Add(nextWord[j],0);
                }
            }
        }

        return true;
    }

    public void CreateEdgeAndUpdateDegrees(char source, char target)
    {
        if (!incomingEdges.ContainsKey(target)) incomingEdges.Add(target, new List<char>());
        incomingEdges[target].Add(source);
        if (!outDegree.ContainsKey(source)) outDegree.Add(source,0);
        if (!outDegree.ContainsKey(target)) outDegree.Add(target,0);
        outDegree[source]++;
    }

    public string TopologicalOrdering(
        Dictionary<char, List<char>> incomingEdges,
        Dictionary<char,int> outDegree)
    {
        Queue<char> queue = new();
        int totalChars = 0;

        foreach (KeyValuePair<char,int> kvp in outDegree)
        {
            if (kvp.Value == 0) queue.Enqueue(kvp.Key);
            if (kvp.Value != -1) totalChars++;
        }

        int processedCount = 0;
        List<char> charList = new List<char>();
        while (queue.Count > 0)
        {
            char currChar = queue.Dequeue();
            charList.Add(currChar);
            processedCount++;
            if (incomingEdges.TryGetValue(currChar, out List<char> sourceChars))
            {
                foreach (char sourceChar in sourceChars)
                {
                    outDegree[sourceChar]--;
                    if (outDegree[sourceChar] == 0) queue.Enqueue(sourceChar);
                }
            }
            
        }
        charList.Reverse();

        return (processedCount == totalChars) ? new string(charList.ToArray()) : string.Empty;
    }
}

/* I will iterate through the words list, compare neighboring words, extract the first unmatched char. 
I will create an adjacency list for storing incoming edges.
I will create an array for size 26 for storing outdegree for every character.
I will add an edge from unmatched char in i+1th word to the unmatched char in ith word.
I will increment outdegree of unmatched char in the ith word by 1.
I will try to create topological ordering of characters in the adjacency list.
If topological ordering is possible return the output otherwise return empty string */
