namespace MSCS_Algorithms;

public class Program
{
    static void Main(string[] args)
    {

    }

    public static List<List<int>> GenerateRandomArrays(int lower, int upper)
    {
        List<List<int>> matrix = new();
        Random random = new(); 
        
        for(int i = 10; i <= 100; i += 5)
        {
            List<int> row = new();
            for (int j = 0; j < i; j++)
            {
                row.Add(random.Next(lower, upper));
            }
            matrix.Add(row);
        }
        return matrix;
    }

    // We will be reading a file named "phw_input.txt"
    public static int[] ReadFile(string path)
    {

        return new int[0];
    }
}