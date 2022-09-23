using System.Collections;
using System.Collections.Generic;

public class MathFormulas : IEnumerable<object[]>
{
    public bool IsEven(int number) => number % 2 == 0;

    public int Diff(int x, int y) => y - x;

    public int Add(int x, int y) => x + y;

    public int Sum(params int[] numbers)
    {
        int sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
            sum += numbers[i];

        return sum;
    }

    public int Average(params int[] numbers)
    {
        int sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
            sum += numbers[i];
        return sum / numbers.Length;
    }

    public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue }
        };

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 4 };
        yield return new object[] { -4, -6, -10 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}