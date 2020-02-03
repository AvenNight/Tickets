using System;
using System.Numerics;

class Program
{
    static void MainX()
    {
        var input = Console.ReadLine().Split();
        var result = Solve(int.Parse(input[0]), int.Parse(input[1]));
        Console.WriteLine(result);
    }

    public static BigInteger Solve(int totalLen, int totalSum)
    {
        if (totalSum % 2 != 0) return 0;

        var halfSum = totalSum / 2;
        var opt = new BigInteger[totalLen + 1, halfSum + 1];
        for (int i = 1; i <= totalLen; i++) opt[i, 0] = 1;
        for (int i = 0; i <= halfSum; i++) opt[0, i] = 0;

        for (int i = 1; i <= totalLen; i++)
            for (int j = 1; j <= halfSum; j++)
                if (j > i * 9)
                    opt[i, j] = 0;
                else
                    opt[i, j] = opt[i - 1, j] + opt[i, j - 1] - (j > 9 ? opt[i - 1, j - 10] : 0);

        return opt[totalLen, halfSum] * opt[totalLen, halfSum];
    }
}