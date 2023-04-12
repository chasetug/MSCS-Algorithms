using System;

namespace MSCS_Algorithms;

public class Stopwatch
{
    // Sets up current time, pushes in current time
    static DateTime _currentTime;
    
    // Marks the current time
    // -> Outputs the time difference if reset is false
    public static void MarkTime(bool reset = false)
    {
        // -> If reset is true, set current time and return
        if (reset)
        {
            _currentTime = DateTime.Now;
            return;
        }

        // Output the time difference
        Console.Write($"Time: {(DateTime.Now - _currentTime).Microseconds}μs | ");
        // Reset current
        _currentTime = DateTime.Now;
    }
}
