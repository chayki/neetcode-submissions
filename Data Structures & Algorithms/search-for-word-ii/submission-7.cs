public class Solution {
    private PrefixTree trie = new PrefixTree();
    private int[] dr = new int[] {0,0,1,-1};
    private int[] dc = new int[] {1,-1,0,0};

    public List<string> FindWords(char[][] board, string[] words) {
        var result = new List<string>();
        foreach (string word in words)
        {
            trie.InsertWord(word);
        }

        int m = board.Length;
        int n = board[0].Length;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                FindWordsDFS(board, this.trie.Root, i, j, result);
            }
        }

        return result.ToList();    
    }

    public void FindWordsDFS(char[][] board, Node node, int i, int j, List<string> result)
    {
        if (node.IsEndOfWord) 
        {
            result.Add(node.Word);
            node.IsEndOfWord = false;
        }

        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length) return;

        if (!node.Children.ContainsKey(board[i][j])) return;
        // visit the node
        var cellState = board[i][j];
        board[i][j] = '#';
        // iterate through each neighbour and recurse
        for (int d = 0; d < 4; ++d)
        {
            int nr = i+dr[d];
            int nc = j+dc[d];
            FindWordsDFS(board, node.Children[cellState], nr, nc, result);
        }
        board[i][j] = cellState;
    }
}

public class PrefixTree
{
    public Node Root {get; private set;}
    
    public PrefixTree()
    {
        this.Root = new Node();
    }

    public void InsertWord(string word)
    {
        var currNode = this.Root;
        for(int i = 0; i < word.Length; ++i)
        {
            if (!currNode.Children.ContainsKey(word[i])) currNode.Children.Add(word[i], new Node());
            var childNode = currNode.Children[word[i]];
            currNode = childNode;
        }
        currNode.Word = word;
        currNode.IsEndOfWord = true;
    }
}

public class Node
{
    public bool IsEndOfWord {get; set;}
    public string Word {get; set;}
    public Dictionary<char, Node> Children {get; private set;}

    public Node()
    {
        this.Children = new Dictionary<char,Node>();
    }
}
