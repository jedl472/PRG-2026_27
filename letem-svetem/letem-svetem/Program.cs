namespace letem_svetem
{
    internal class Program
    {
        class Vertex
        {
            public (int x, int y) loc;
        }
        class Edge
        {
            public int len;
            public Vertex v1;
            public Vertex v2;
        }
        static void Main(string[] args)
        {
            // ------------------------------------ load input
            int n = Int32.Parse(Console.ReadLine());
            List<Vertex> verticies = new List<Vertex>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Vertex vertex = new Vertex();
                vertex.loc.x = Int32.Parse(line.Split(" ")[0]);
                vertex.loc.y = Int32.Parse(line.Split(" ")[1]);
                verticies.Add(vertex);
            }
            int dolet = Int32.Parse(Console.ReadLine());
            int start = Int32.Parse(Console.ReadLine());
            int end = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Hello, World!");

            // ------------------------------------ construct graph
            foreach (int v = 0; )
            {

                for()
            }
        }
    }
}
