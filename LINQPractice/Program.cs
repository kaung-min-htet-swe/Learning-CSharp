using System.Collections;

int[] input = [1, 2, 1];
var result = new int[input.Length*2];
Console.WriteLine(result.Length);
for (int i = 0; i < result.Length; i++)
{
    if (i == 0)
    {
        result[0] = input[0];
        Console.WriteLine(i);
    }
    else
    {
        var idx = i % input.Length;
        result[i] = input[idx];
        Console.WriteLine(idx);
    }
}

foreach (var r in result)
{
    Console.Write($"{r} ");
}