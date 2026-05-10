public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder sb = new StringBuilder();
        foreach (string str in strs)
        {
            string prefix = str.Length + "#";
            sb.Append(prefix+str);
        }
        return sb.ToString();
    }

    public List<string> Decode(string s) {
        int i = 0;
        var result = new List<string>();
        while (i < s.Length)
        {
            int hashIdx = s.IndexOf('#', i);
            int length = int.Parse(s.Substring(i, hashIdx - i));
            i = hashIdx + 1;
            result.Add(GetSubstring(i, length, s));
            i += length;
        }
        
        return result;
    }

    private string GetSubString(int startIdx, int endIdx, string s)
    {
        var result = string.Empty;
        if (startIdx <= endIdx)
        {
            int length = endIdx-startIdx+1;
            result = s.Substring(startIdx, length);
        }
        return result;
    }

    private string GetSubstring(int startIdx, int length, string s)
    {
        var result = string.Empty;
        if (length > 0)
        {
            result = s.Substring(startIdx, length);
        }
        return result;
    }

}