using System;

public static class RandomUtil
{
    private static Random Random { get; } = new Random();
    public static double GetDouble()
    {
        return Random.NextDouble();
    }
}