namespace beast_in_labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------
            // LOAD INPUT
            // ------------------

            int width = int.Parse(Console.ReadLine()!);  
            int height = int.Parse(Console.ReadLine()!);

            char[,] map = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                string line = Console.ReadLine()!;

                for (int x = 0; x < width; x++)
                {
                    map[y, x] = line[x];
                }
            }

            // ------------------
            // 20 STEPS
            // ------------------

            Console.WriteLine(map);
        }

        static void Step(char[,] map)
        {
            enum StepDirection 
            { 
                Up,
                Right,
                Down,
                Left
            }

            // FIND MONSTER


            // INTERPRET ORIENTATION

            // CHECK AVAILABLE SPACE

            // MOVE
            
            // UPDATE ORIENTATION

            // PRINT
        }
    }
}
