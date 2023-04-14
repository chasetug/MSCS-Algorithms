using System.IO;

namespace MSCS_Algorithms;

public class Program
{
    static bool _debug = false;

    /* Driver Method
     * 1. Read file
     * 2. Run each algorithm on the file
     * 3. Print answers in console
     * 4. Generate random lists
     * 5. Use System clock to measure how long each algorithm takes on each of the 19 lists
     * 6. Print results
     * 7. Write to file
     */
    static void Main(string[] args)
    {
        // Header
        Console.WriteLine("Maximum Sum Contiguous Subvector Program");
        Console.WriteLine($"Current Time:  {DateTime.Now}");
        
        // Display the working directory
        string dir = Directory.GetCurrentDirectory();
        Console.WriteLine("Working Directory: " + dir);

        Console.WriteLine("----------------------------------------");

        // Store Directory and File Name
        string fileName = (OperatingSystem.IsWindows() ? "\\" : "/") + "phw_input.txt";
        string outFileName = (OperatingSystem.IsWindows() ? "\\" : "/") + "chaseluke_phw_output.txt";
                
        // Read the array from the file
        int[] fileArr = ReadFile(dir + fileName);

        // -> Ensure that the file is longer than 0
        if (fileArr.Length == 0)
            return;

        // -> Debug write the second value to ensure that the array pulled successfully
        if (_debug) Console.WriteLine(fileArr[1]);
        
        // Print out the results for the phw_input.txt
        Console.WriteLine($"Executing algorithms on file ${fileName}");
        Console.WriteLine($"algorithm-1: {MSCS.Algorithm_1(fileArr)}; " +
                          $"algorithm-2: {MSCS.Algorithm_2(fileArr)}; " +
                          $"algorithm-3: {MSCS.MaxSum(fileArr, 0, 9)}; " +
                          $"algorithm-4: {MSCS.Algorithm_4(fileArr)}");
        Console.WriteLine("----------------------------------------");

        // Create the matrix of random elements
        List<List<int>> matrix = GenerateRandomArrays(Int16.MinValue, Int16.MaxValue);

        // Creates/overrides output file
        FileStream F = new FileStream(dir + outFileName, FileMode.Create);

        // Define a stream reader to output data
        StreamWriter sw = new StreamWriter(F);
        // -> Write headers
        sw?.WriteLine("algorithm-1,algorithm-2,algorithm-3,algorithm-4,T1(n),T2(n),T3(n),T4(n)");

        // Run through each of the random lists
        matrix.ForEach(delegate(List<int> numbers)
        {
            // -> Store length of current list
            int numLength = numbers.Count;

            Console.WriteLine($"Executing algorithms on {numbers.Count} random numbers");
            // -> Algorithm 1
            Stopwatch.MarkTime(true);
            var alg1Result = MSCS.Algorithm_1(numbers.ToArray());
            string alg1Time = Stopwatch.MarkTime();
            Console.WriteLine($"algorithm-1: {alg1Result}");

            // -> Algorithm 2
            Stopwatch.MarkTime(true);
            var alg2Result = MSCS.Algorithm_2(numbers.ToArray());
            string alg2Time = Stopwatch.MarkTime();
            Console.WriteLine($"algorithm-2: {alg2Result}");

            // -> Algorithm 3
            Stopwatch.MarkTime(true);
            var alg3Result = MSCS.MaxSum(numbers.ToArray(), 0, numLength - 1);
            string alg3Time = Stopwatch.MarkTime();
            Console.WriteLine($"algorithm-3: {alg3Result}");

            // -> Algorithm 4
            Stopwatch.MarkTime(true);
            var alg4Result = MSCS.Algorithm_4(numbers.ToArray());
            string alg4Time = Stopwatch.MarkTime();
            Console.WriteLine($"algorithm-4: {alg4Result}");

            Console.WriteLine("----------------------------------------");

            // Write saved information to output file
            sw?.WriteLine($"{alg1Time},{alg2Time},{alg3Time},{alg4Time}," +
                $"{((1/24f) * (numLength * (3 * numLength * ((23 * numLength) + 34) + 199) + 134)) * 0.0001}," +
                $"{((1/6f) * ((25 * numLength * numLength) + (54 * numLength) + 35)) * 0.0005}," +
                $"{((12 * numLength) + 34) * 0.005}," +
                $"{numLength * 0.01}");
                
        });
        
        // Close stream writer
        sw?.Close();
        F.Close();
    }

    // Creates random lists of integers of size 10, 15, 20, ... 95, 100
    private static List<List<int>> GenerateRandomArrays(int lower, int upper)
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
    private static int[] ReadFile(string path)
    {
        // If the stream reader is null, return early and notify user
        if (!File.Exists(path))
        {
            Console.WriteLine($"Could not find a file at path {path}");
            return new int[0];
        }

        // Open up the file defined by path
        StreamReader sr = new(path);

        // Pull contents and cut spaces
        string fileContents = sr.ReadLine() ?? String.Empty;
        // -> If there are no contents then return
        if (fileContents == String.Empty) return new int[0];
        // -> Cut spaces
        fileContents = fileContents.Replace(" ", "");
        // -> Debug write to console
        if (_debug) Console.WriteLine(fileContents);

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
            if (_debug) Console.WriteLine($"PS: {parseString} || FC: {fileContents}");

            // -> Increment oVal
            oVal++;
        }
        // -> Send error if overflow was hit
        if (fileContents != string.Empty)
            Console.WriteLine($"File contains more than 10 values, parsing the first 10 values.\nValues left out: {fileContents}");

        // Make sure to close the stream reader
        sr.Close();

        // -> Debug out rArr
        if (_debug)
        {
            Console.Write("| ");
            for (int i = 0; i < rArr.Length; i++)
                Console.Write(rArr[i] + " | ");
            Console.Write("\n");
        }

        return rArr;
    }
}