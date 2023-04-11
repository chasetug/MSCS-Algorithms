namespace MSCS_Algorithms;

public class MSCS
{
    private List<int> _debugList = new()
    {
        7,
        -8,
        5,
        -3,
        -4,
        11,
        3,
        4,
        5,
        9,
        0
    };

    public static int Algorithm_1(int[] X)
    {
        int maxSoFar = 0;
        return maxSoFar;
    }
    
    public static int Algorithm_2(int[] X)
    {
        int maxSoFar = 0;
        return maxSoFar;
    }
    
    // Algorithm 3
    // -> Written by Luke Wittbrodt
    // Recursive function that calculates MSCS
    public static int MaxSum(int[] X, int L, int U)
    {
        // Check if the lower bound is greater than the upper bound
        // -> True: return 0
        if (L > U)
            return 0;

        // Check if the lower bound is equal to the upper bound
        // -> True: return max value between lower value and 0
        if (L == U)
            return Math.Max(0, X[L]);

        // Defines midpoint of the array
        int M = (L + U) / 2f;
        // Define current sum and max of left side of the array
        int sum = 0;
        int maxToLeft = 0;
        // Find maxToLeft
        for(int I = M; I >= L; I--)
        {
            // Get the current sum & set maxToLeft
            sum += X[i];
            maxToLeft = Math.Max(maxToLeft, sum);
        }

        // Reset sum and define the max of right side of the array
        sum = 0;
        int maxToRight = 0;
        // Find maxToRight
        for(int I = M + 1; I <= U; I++)
        {
            // Get current sum & set maxToRight
            sum += sum + X[I];
            maxToRight = Math.Max(maxToRight, sum);
        }

        // Defines the sum of the max of both sides of the array
        int maxCrossing = maxToLeft + maxToRight;

        // Gets max sum for both sides of the array, defining both sides as independent arrays
        // -> A = X[L..M]
        // -> B = X[M+1..U]
        int maxInA = MaxSum(X, L, M);
        int maxInB = MaxSum(X, M + 1, U);

        // Returns the max sum found across A, B, and Crossing
        return Math.Max(maxCrossing, Math.Max(maxInA, maxInB));
    }
    
    public static int Algorithm_4(int[] X)
    {
        int maxSoFar = 0;
        return maxSoFar;
    }
}