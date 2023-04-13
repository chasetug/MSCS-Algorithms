using System;

namespace MSCS_Algorithms;

public class Stopwatch
{
    // Sets up current time, pushes in current time
    static DateTime _currentTime;
    
    // Marks the current time
    // -> Outputs the time difference if reset is false
    public static string MarkTime(bool reset = false)
    {
        // -> If reset is true, set current time and return
        if (reset)
        {
            _currentTime = DateTime.Now;
            return string.Empty;
        }

        // Output the time difference
        TimeSpan timeDiff = DateTime.Now - _currentTime;
        Console.Write($"Time: {timeDiff.Microseconds}μs | ");
        // Reset current
        _currentTime = DateTime.Now;

        // Return string of time difference in microseconds
        return timeDiff.Microseconds.ToString();
    }
}
