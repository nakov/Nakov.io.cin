using System;
using Nakov.IO; // See http://www.nakov.com/tags/cin

public class CinExample
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter two integers x and y separated by whitespace: ");
        // cin >> x >> y;
        int x = Cin.NextInt();
        double y = Cin.NextDouble();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Name: {0}, Age: {1}", name, age);
        Console.WriteLine("x={0}, y={1}", x, y);

        Console.Write("Enter a positive integer number N: ");
        // cin >> n;
        int n = Cin.NextInt();

        Console.Write("Enter N decimal numbers separated by a space: ");
        decimal[] numbers = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            // cin >> numbers[i];
            numbers[i] = Cin.NextDecimal();
        }

        Console.Write("The numbers in ascending order: ");
        Array.Sort(numbers);
        for (int i = 0; i < n; i++)
        {
            Console.Write(numbers[i]);
            Console.Write(' ');
        }
        Console.WriteLine();

        Console.WriteLine("Enter two strings seperated by a space: ");
        // cin >> firstStr >> secondStr;
        string firstStr = Cin.NextToken();
        string secondStr = Cin.NextToken();
        Console.WriteLine("First str={0}", firstStr);
        Console.WriteLine("Second str={0}", secondStr);
    }
}
