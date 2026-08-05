public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (IsOperator(token))
            {
                int rightOperand = stack.Pop();
                int leftOperand = stack.Pop();
                var result = BinaryArithmeticEvaluator.Evaluate(leftOperand, rightOperand, token);
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Peek();
       
    }

    public bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    public static class BinaryArithmeticEvaluator
    {
        public static int Evaluate(int leftOperand, int rightOperand, string op)
        {
            switch (op)
            {
                case "+":
                    return leftOperand + rightOperand;
                case "-":
                    return leftOperand - rightOperand;
                case "*":
                    return leftOperand * rightOperand;
                case "/":
                    if (rightOperand == 0) throw new DivideByZeroException("Cannot divide by zero");
                    return leftOperand / rightOperand;
                default:
                    throw new ArgumentException($"Unsupported operator '{op}'", nameof(op));
            }
        }
    }
}
