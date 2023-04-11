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
    
    public static int MaxSum(int[] X, int L, int U)
    {
        return 0;
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