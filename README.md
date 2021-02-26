Nakov.IO.Cin: the C# console input working as `cin` in C++
==========================================================

`Nakov.IO.Cin` is a console-based input reader for C#, which reads numbers and text in the C++ `cin` / `cout` / `iostream` style.

Install the NuGet Package
-------------------------

First, install the NuGet package [`Nakov.IO.Cin`](https://www.nuget.org/packages/Nakov.IO.Cin):

```
Install-Package Nakov.IO.Cin
```

Now you are ready to translate C++ `cin` / `cout` / `iostream` code to C#.

Sample C++ Code
---------------

```cpp
#include <iostream>
 
using namespace std;
 
int main()
{
    int n;
    cin >> n;
 
    int* numbers = new int[n];
    for (int i = 0; i < n; i++)
        cin >> numbers[i];
 
    for (int i = 0; i < n; i++)
        cout << numbers[i] << ' ';
}
```

Corresponsing C# Code
---------------------

```cs
using System;
using Nakov.IO; // see http://www.nakov.com/tags/cin
 
public class EnteringNumbers
{
    static void Main()
    {
        int n = Cin.NextInt();
 
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
            numbers[i] = Cin.NextInt();
 
        for (int i = 0; i < n; i++)
            Console.Write(numbers[i] + " ");
    }
}
```

More Detailed Example
---------------------

```cs
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

        Array.Sort(numbers);
        Console.WriteLine("The numbers in ascending order: {0}",
            string.Join(' ', numbers));

        Console.Write("Enter two strings seperated by a space: ");
        // cin >> firstStr >> secondStr;
        string firstStr = Cin.NextToken();
        string secondStr = Cin.NextToken();
        Console.WriteLine("First str={0}", firstStr);
        Console.WriteLine("Second str={0}", secondStr);
    }
}
```

This is a sample **input and output** from the above example:
```
Enter your name: Albert Einstein
Enter two integers x and y separated by whitespace:
   10
                20
Enter your age:         25
Name: Albert Einstein, Age: 25
x=10, y=20
Enter a positive integer number N:
5
Enter N decimal numbers separated by a space: 10  30 40

50
        20
The numbers in ascending order: 10 20 30 40 50
Enter two strings seperated by a space:
        Visual                  Studio
First str=Visual
Second str=Studio
```
Note that input numbers and string tokens can be separated by single space, by a new line or by a sequence of white space characters.

Learn more at: http://www.nakov.com/tags/cin.
