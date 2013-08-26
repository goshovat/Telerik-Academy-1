using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

/*
    Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
    Real numbers, e.g. 5, 18.33, 3.14159, 12.6
    Arithmetic operators: +, -, *, / (standard priorities)
    Mathematical functions: ln(x), sqrt(x), pow(x,y)
    Brackets (for changing the default priorities)
	Examples:
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) -> ~ 10.6
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) -> ~ 21.22
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
*/

class ArithmeticalExpression
{
    public static List<char> arithmeticalOperators = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };

    public static List<string> SeparateTokens(string expression)
    {
        List<string> result = new List<string>();
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '-' && (i == 0 || expression[i - 1] == ',' || expression[i - 1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                number.Append(expression[i]);
            }
            else if (!char.IsDigit(expression[i]) && expression[i] != '.' && number.Length != 0)
            {
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(expression[i]))
            {
                result.Add(expression[i].ToString());
            }
            else if (arithmeticalOperators.Contains(expression[i]))
            {
                result.Add(expression[i].ToString());
            }
            else if (expression[i] == ',')
            {
                result.Add(",");
            }
            else if (i + 1 < expression.Length && expression.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < expression.Length && expression.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < expression.Length && expression.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid token in the expression");
            }
        }

        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    public static int Precedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
    {
        Stack<string> input = new Stack<string>();
        Queue<string> output = new Queue<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            var currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                output.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                input.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!input.Contains("(") || input.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator");
                }

                while (input.Peek() != "(")
                {
                    output.Enqueue(input.Pop());
                }
            }
            else if (arithmeticalOperators.Contains(currentToken[0]))
            {
                while (input.Count != 0 && arithmeticalOperators.Contains(input.Peek()[0]) && Precedence(currentToken) <= Precedence(input.Peek()))
                {
                    output.Enqueue(input.Pop());
                }

                input.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                input.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!input.Contains("(") || input.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets position");
                }

                while (input.Peek() != "(")
                {
                    output.Enqueue(input.Pop());
                }

                input.Pop();

                if (input.Count != 0 && functions.Contains(input.Peek()))
                {
                    output.Enqueue(input.Pop());
                }
            }
        }

        while (input.Count != 0)
        {
            if (brackets.Contains(input.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position");
            }

            output.Enqueue(input.Pop());
        }

        return output;
    }

    public static double GetResultFromRPN(Queue<string> output)
    {
        Stack<double> input = new Stack<double>();

        while (output.Count != 0)
        {
            string currentToken = output.Dequeue();
            double number;

            if (double.TryParse(currentToken, out number))
            {
                input.Push(number);
            }
            else if (arithmeticalOperators.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (input.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = input.Pop();
                    double secondValue = input.Pop();

                    input.Push(firstValue + secondValue);
                }
                else if (currentToken == "-")
                {
                    if (input.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = input.Pop();
                    double secondValue = input.Pop();

                    input.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (input.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = input.Pop();
                    double secondValue = input.Pop();

                    input.Push(secondValue * firstValue);
                }
                else if (currentToken == "/")
                {
                    if (input.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = input.Pop();
                    double secondValue = input.Pop();

                    input.Push(secondValue / firstValue);
                }
                else if (currentToken == "pow")
                {
                    if (input.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = input.Pop();
                    double secondValue = input.Pop();

                    input.Push(Math.Pow(secondValue, firstValue));
                }
                else if (currentToken == "sqrt")
                {
                    if (input.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = input.Pop();

                    input.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (input.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = input.Pop();

                    input.Push(Math.Log(value));
                }
            }
        }

        if (input.Count == 1)
        {
            return input.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression");
        }
    }

    public static void Main()
    {
        Console.Title = "Arithmetical expression"; 

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter an arithmetical expression:");
        string expression = Console.ReadLine().Trim();

        string expressionWithouWhitespaces = expression.Replace(" ", string.Empty);

        try
        {
            List<string> separatedTokens = SeparateTokens(expressionWithouWhitespaces);
            Queue<string> reversePolishNotation = ConvertToReversePolishNotation(separatedTokens);
            double finalResult = GetResultFromRPN(reversePolishNotation);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n{0} = {1:F2}", expressionWithouWhitespaces, finalResult);
        }
        catch (ArgumentException exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(exception.Message);
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}