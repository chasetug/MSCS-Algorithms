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
    
    // Algorithm-1(X:array[P..Q] of integer)
    public static int Algorithm_1(int[] X)
    {
        // Get locations of P and Q
        int P = 0, Q = X.Length-1;
        
        // Initialize our tracker
        int maxSoFar = 0;
        
        // Loop through array and find the biggest sum
        for(int L = P; L <= Q; L++)
        {
            for(int U = L; U <= Q; U++)
            {
                int sum = 0;
                for (int I = L; I <= U; I++)
                {
                    sum = sum + X[I];
                    /* sum now contains the sum of X[L..U] */
                }
                // Swap the tracker for the biggest
                maxSoFar = Int32.Max(maxSoFar, sum);
            }
        }
        
        return maxSoFar;
    }
    
    // Algorithm-2(X:array[P..Q] of integer)
    public static int Algorithm_2(int[] X)
    {
        // Get locations of P and Q
        int P = 0, Q = X.Length-1;

        // Initialize our tracker
        int maxSoFar = 0;

        // Loop through the array and find the max sum
        for (int L = P; L <= Q; L++)
        {
            int sum = 0;
            for (int U = L; U <= Q; U++)
            {
                sum = sum + X[U];
                /* sum now contains the sum of X[L..U] */
                maxSoFar = Int32.Max(maxSoFar, sum);
            }
        }
        
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
        int M = (L + U) / 2;
        // Define current sum and max of left side of the array
        int sum = 0;
        int maxToLeft = 0;
        // Find maxToLeft
        for(int I = M; I >= L; I--)
        {
            // Get the current sum & set maxToLeft
            sum += X[I];
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
    
    // Algorithm-4(X:array[P..Q] of integer)
    public static int Algorithm_4(int[] X)
    {
        // Get locations of P and Q
        int P = 0, Q = X.Length-1;
        
        // Initialize our trackeres
        int maxSoFar = 0;
        int maxEndingHere = 0;
        
        // Loop through array and find the max
        for (int I = P; I <= Q; I++)
        {
            maxEndingHere = Int32.Max(0, maxEndingHere + X[I]);
            maxSoFar = Int32.Max(maxSoFar, maxEndingHere);
        }
        
        return maxSoFar;
    }
}