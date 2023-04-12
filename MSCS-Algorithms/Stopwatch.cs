using System;

namespace MSCS_Algorithms;

public class Stopwatch
{
    // Sets up current time, pushes in current time
    static DateTime currentTime = DateTime.Now;
    
    // Marks the current time
    // -> Outputs the time difference if reset is false
    public static void MarkTime(bool reset = false)
    {
        // -> If reset is true, set current time and return
        if (reset)
        {
            currentTime = DateTime.Now;
            return;
        }

        // Output the time difference
        Console.Write($"Time: {(DateTime.Now - currentTime).Microseconds}us | ");
        // Reset current
        currentTime = DateTime.Now;
    }
}
