using System.IO;

namespace MSCS_Algorithms;

public class Program
{
    static bool debug = true;

    static void Main(string[] args)
    {
        // -> Debug write working directory
        if (debug) Console.WriteLine("Working Directory: " + Directory.GetCurrentDirectory());

        // Pull array from contained file
        int[] pulledArr = ReadFile(Directory.GetCurrentDirectory() + (OperatingSystem.IsWindows() ? "\\" : "/") + "phw_input.txt");
        // -> Debug write the second value to ensure that the array pulled successfully
        if (debug) Console.WriteLine(pulledArr[1]);

        // Print out the results for the phw_input.txt
        Console.WriteLine($"Algorithm 1: {MSCS.Algorithm_1(pulledArr)}, " +
                          $"Algorithm 2: {MSCS.Algorithm_2(pulledArr)}, " +
                          $"Algorithm 3: {MSCS.MaxSum(pulledArr, 0, 9)}, " +
                          $"Algorithm 4: {MSCS.Algorithm_4(pulledArr)}");

        var matrix = GenerateRandomArrays(-100, 100);
        matrix.ForEach(delegate(List<int> numbers)
        {
            List<int> results = new();
            results.Add(MSCS.Algorithm_1(numbers.ToArray()));
            results.Add(MSCS.Algorithm_2(numbers.ToArray()));
            results.Add(MSCS.MaxSum(numbers.ToArray(), 0, numbers.Count - 1));
            results.Add(MSCS.Algorithm_4(numbers.ToArray()));
            
            Console.WriteLine($"Case {numbers.Count}: " +
                              $"Algorithm 1: {results[0]}, " +
                              $"Algorithm 2: {results[1]}, " +
                              $"Algorithm 3: {results[2]}, " +
                              $"Algorithm 4: {results[3]} " +
                              $"Correct: {results.Distinct().Count() == 1}");
        });
    }

    // Creates 20 random lists of integers of size 10, 15, 20, ... 95, 100
    public static List<List<int>> GenerateRandomArrays(int lower, int upper)
    {
        // Initialize the matrix
        List<List<int>> matrix = new();
        // Initialize our RNG
        Random random = new(); 
        
        // Counter for our list sizes
        for(int i = 10; i <= 100; i += 5)
        {
            // Initialize the row
            List<int> row = new();
            // Create a new row with i elements
            for (int j = 0; j < i; j++)
            {
                // Add i random elements to the row
                row.Add(random.Next(lower, upper));
            }
            // When done, add the row to the matrix
            matrix.Add(row);
        }
        // Return our matrix of random numbers
        return matrix;
    }

    // We will be reading a file named "phw_input.txt"
    // -> File is comma delimited
    // -> Will always be of length 10
    public static int[] ReadFile(string path)
    {
        // Open up the file defined by path
        StreamReader sr = new(path);
        // Pull contents and cut spaces
        string fileContents = sr.ReadLine();
        // -> If there are no contents then return
        if (fileContents == null) return new int[0];
        // -> Cut spaces
        fileContents = fileContents.Replace(" ", "");
        // -> Debug write to console
        if (debug) Console.WriteLine(fileContents);

        // Create the return array
        int[] rArr = new int[10];

        // Parse information into rArr
        // -> Create an overflow value
        int oVal = 0;
        // Read information until there is nothing left in file contents
        while(fileContents != string.Empty && oVal < 10)
        {
            // Pull substring of contents (between current and next comma
            int commaIndex = fileContents.IndexOf(',');
            // -> Pull parsed
            string parseString = string.Empty;
            if(commaIndex >= 0)
            {
                // -> Cut content
                parseString = fileContents.Substring(0, commaIndex);
                // -> Shorten file contents
                fileContents = fileContents.Substring(commaIndex + 1);
            }
            else
            {
                // Set parse to remaining content
                parseString = fileContents;
                // Note file contents as empty
                fileContents = string.Empty;
            }

            // Make sure value can be parsed
            if(!int.TryParse(parseString, out rArr[oVal]))
            {
                Console.WriteLine($"Value '{parseString}' is not a valid integer... skipping");
            }

            // -> Debug out both strings
            if (debug) Console.WriteLine($"PS: {parseString} || FC: {fileContents}");

            // -> Increment oVal
            oVal++;
        }
        // -> Send error if overflow was hit
        if (fileContents != string.Empty)
            Console.WriteLine($"File contains more than 10 values, parsing the first 10 values.\nValues left out: {fileContents}");

        // Make sure to close the stream reader
        sr.Close();

        // -> Debug out rArr
        if (debug)
        {
            Console.Write("| ");
            for (int i = 0; i < rArr.Length; i++)
                Console.Write(rArr[i] + " | ");
            Console.Write("\n");
        }

        return rArr;
    }
}