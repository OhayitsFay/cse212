using System.Diagnostics;

public static class Algorithms
{
    public static void Run()
    {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}", "n", "alg1-count", "alg2-count", "alg3-count",
            "alg1-time", "alg2-time", "alg3-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n < 15001; n += 1000)
        {
            int count1 = Algorithm1(n);
            int count2 = Algorithm2(n);
            int count3 = Algorithm3(n);
            double time1 = Time(Algorithm1, n, 10);
            double time2 = Time(Algorithm2, n, 10);
            double time3 = Time(Algorithm3, n, 10);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15:0.00000}{5,15:0.00000}{6,15:0.00000}", n, count1, count2,
                count3, time1, time2,
                time3);
        }
    }

    private static double Time(Func<int, int> algorithm, int input, int times)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i)
        {
            algorithm(input);
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm1(int size)
    {
        var count = 0;
        for (var i = 0; i < size; ++i)
            count += 1;

        return count;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm2(int size)
    {
        var count = 0;
        for (var i = 0; i < size; ++i)
            for (var j = 0; j < size; ++j)
                count += 1;

        return count;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm3(int size)
    {
        var count = 0;
        var start = 0;
        var end = size - 1;
        while (start <= end)
        {
            var middle = (end - start) / 2 + start;
            start = middle + 1;
            count += 1;
        }

        return count;
    }
}

/// Predict, Measure, and Compare Code
// Q1. Predict the performance (Big-O) of each method before running.
// Algorithm1 → O(n) (single loop).
// Algorithm2 → O(n²) (nested loops).
// Algorithm3 → O(log n) (repeatedly halves the range, like binary search).

// Q2. Do the actual results agree with the Big-O predictions? If not, what should the Big-O be?
// Yes, the actual results agree with the predictions.
// alg1-count ≈ n (linear).
// alg2-count ≈ n² (quadratic).
// alg3-count ≈ log₂(n) (logarithmic).
// So the experimental results confirm the theoretical Big-O values.

// Q3. Which method has the best performance and which one has the worst?
// Best performance: Algorithm3 (O(log n)) → grows the slowest.
// Worst performance: Algorithm2 (O(n²)) → grows the fastest and becomes very slow for large n.
// Algorithm1 (O(n)) is in between.

// Q4. Why do we say that Big-O only applies when n is "large"?
// When n is small, all three algorithms run in almost the same time (milliseconds or microseconds), so the difference is negligible. But as n grows:
// Algorithm2’s runtime increases dramatically,
// Algorithm1 grows steadily,
// Algorithm3 barely increases.
// This shows that Big-O describes long-term growth trends, which only become clear for large input sizes.
