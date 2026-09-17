public class Solution {
    Dictionary<char, List<char>> incomingEdges = new();
    Dictionary<char,int> outDegree = new();
    HashSet<char> uniqueChars = new();

    public string foreignDictionary(string[] words) {
        int n = words.Length;
        foreach(string word in words)
        {
            for (int i = 0; i < word.Length; ++i)
            {
                if (!outDegree.ContainsKey(word[i])) outDegree.Add(word[i], 0);
            }
        }

        for (int i = 0; i < n-1; ++i)
        {
            int minLength = Math.Min(words[i].Length, words[i+1].Length);
            string currWord = words[i];
            string nextWord = words[i+1];
            bool foundDifference = false;
            for (int j = 0; j < minLength; ++j)
            {
                if (currWord[j] != nextWord[j])
                {
                    CreateEdgeAndUpdateDegrees(currWord[j], nextWord[j]);
                    foundDifference = true;
                    break;
                }
            }

            if (!foundDifference && currWord.Length > nextWord.Length) return string.Empty;
        }

        return TopologicalOrdering(incomingEdges, outDegree);       
    }

    public void CreateEdgeAndUpdateDegrees(char source, char target)
    {
        if (!incomingEdges.ContainsKey(target)) incomingEdges.Add(target, new List<char>());
        incomingEdges[target].Add(source);
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
