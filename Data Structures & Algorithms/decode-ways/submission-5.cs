public class Solution {
    public int NumDecodings(string s) {
        int n = s.Length; //0..n-1
        int secondLast = 1;
        int last = 0;

        if (int.TryParse(
            s.Substring(0,1),
            out int firstDigit) && 1 <= firstDigit && firstDigit <= 26)
        {
            last = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            var curr = 0;
            if (int.TryParse(s.Substring(i-1, 1), out int singleDigitLastUnit) && 1 <= singleDigitLastUnit && singleDigitLastUnit <= 9)
            {
                curr+=last;
            }

            if (int.TryParse(s.Substring(i-2, 2), out int doubleDigitLastUnit) && 10 <= doubleDigitLastUnit && doubleDigitLastUnit <= 26)
            {
                curr+=secondLast;
            }
            secondLast = last;
            last = curr;
        }

        return last;
    }
}

/* Number of valid ways I can partition the string. Imagine an empty cell between every pair of consecutive cells.
For any prefix of the string, every valid decoding must end in exactly one of two ways
1. The last encoded unit contains 1 digit:
if that 1 digit is valid,then every valid decoding of the preifx before that digit can be extended with this digit. Therefore, this case contributes the number of valid decodings of that smaller prefix

2. That last encoded unit contains 2 digits:
If those two digits form a valid unit, then every valid decoding of the prefix before that digit can be extended with this two digit unit. Therefore, this case contributes the number of valid decodings of that smaller prefix*/

/* Recursion Tree:

                                                    (0,n-1)

                            (0,n-2)                                                (0,n-3)
            
            (0,n-3)                      (0,n-4)                       (0,n-4)                  (0,n-5)


Notice overlapping subproblems

*/
/* Recursion relation for any prefix of length k
no of ways(k) = no of ways(k-1) if (last encoded 1 unit is valid) + no of ways(k-2) + if (last encoded 2 unit is valid) */
/* base case dp[1] = 1 if 1 length prefix is valid
dp[0] = 1 : this will be used when computing dp[2] = dp[1] + dp[0] if two digit is valid */

/* Time complexity: each element is processed for work once and amount of work is constant O(n)
Space: O(n) for storing previous valid partition counts of prefixes */


