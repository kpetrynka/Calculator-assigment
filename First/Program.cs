﻿using Queue = First.Queue;
using Stack = First.Stack;

//Input the calculation
var stage = true;
while (stage)
{
    Console.WriteLine("Enter expression: ");
    var expression = Console.ReadLine() ?? throw new InvalidOperationException();
    var token = ToToken(expression);
    var transformed = PostFix(token);
    var result = CalculationPerformed(transformed);
    Console.WriteLine(transformed);
    Console.WriteLine("Try again? +/-");
    string answer = Console.ReadLine() ?? throw new InvalidOperationException();
    if (answer != "+")
    {
        stage = false;
    }
}


//do the tokens;
Queue ToToken(string inputed)
{
    string number = string.Empty;
    foreach (char i in string expression)
    {
        var success = int.TryParse(i, out int result); // i'm not sure if the thing works
        ArrayList? tokens = null;
        switch (success)
        {
            case true:
            {
                number += result.ToString();
            }
                break;
            case false:
            {
                tokens.Add(number);
                number = string.Empty;
                if (i != null)
                {
                    tokens.Add(i.ToString());
                }

                break;
            }
        }
    }
}

// write the polish notation of the expression
// so here is already created PolishNotation which is queue
Queue PostFix(Queue tokens)
{
    
}

string CalculationPerformed(Queue postFixed)
{
    var numbers = new Stack();
    var index = 0;
    while (postFixed != null) // here we can use OutOfQueue
    {
        string character = postFixed[index];
        if (int.TryParse(character, out int num))
        {
            numbers.Push(num.ToString());
        }
        else
        {
            //Calculation()
            var num1 = int.Parse(numbers.Pull());
            var num2 = int.Parse(numbers.Pull());
            numbers.Push(ProcessCalculation(postFixed[1], num1, num2));
        }
    
        index += 1;
    }
}


int output = int.Parse(numbers[0]);
Console.WriteLine("Result" + output);

// Classes that we need
Dictionary<string, int> priority = new Dictionary<string, int>() //we will need it for polish notation
{
    { "+", 1 },
    { "-", 1 },
    { "*", 2 },
    { "/", 2 },
    { "^", 2 },
    { "(", 3 },
};

int ProcessCalculation(string oper, int num1, int num2)
{
    var result = new int();
    if (oper == "+")
    {
        result = num1 + num2;
    }
    if (oper == "-")
    {
        result = num1 - num2;
    }
    if (oper == "*")
    {
        result = num1 * num2;
    }
    if (oper == "/")
    {
        result = num1 / num2;
    }
    if (oper == "^")
    {
        result = num1 ^ num2;
    }
    return result;
}
public abstract class ArrayList // maybe if the stack is written well we won't use it
{
    private string?[] _array = new string?[10];

    private int _pointer = 0;
    public void Add(string element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            string?[] extendedArray = new string[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
        }
    }
}