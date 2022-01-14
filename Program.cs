using System;

namespace GraphColoring
{
    /* Class for Graph functionality */
    class Graph
    {
        public static int GraphSize;

        /* Method for entering graph by adjacency matrix */
        public static bool[,] EnterGraph()
        {
            // Matrix size equals to count of vertices
            Console.WriteLine("Please enter matrix size: ");
            string strGraphSize = Console.ReadLine();
            int.TryParse(strGraphSize, out GraphSize);

            int[,] graph = new int[GraphSize, GraphSize];
            bool[,] graphBool = new bool[GraphSize, GraphSize];

            Console.WriteLine("Please enter graph using adjacency matrix: ");
            for (int i = 0; i < GraphSize; i++)
            {
                for (int j = 0; j < GraphSize; j++)
                {
                    string strMatrixValue = Console.ReadLine();
                    int.TryParse(strMatrixValue, out graph[i, j]);
                    if (graph[i, j] == 0)
                        graphBool[i, j] = false;
                    else
                        graphBool[i, j] = true;
                }
            }

            return graphBool;
        }

        /* Print solution Method */
        private static void PrintSolution(int[] color)
        {
            Console.WriteLine("The Solution Exist\n" +
                              " Possible variation of graph coloring:  ");
            for (int i = 0; i < GraphSize; i++)
                Console.Write(color[i] + " ");
            Console.WriteLine();
        }

        // check if the colored
        // check graph safe / not safe
        static bool IsSafe(bool[,] graph, int[] color)
        {
            // check for every edge
            for (int i = 0; i < GraphSize; i++)
            for (int j = i + 1; j < GraphSize; j++)
                if (graph[i, j] && color[j] == color[i])
                    return false;
            return true;
        }


        /* Method using recursion to solve the Coloring task.*/
        public static bool GraphColoring(bool[,] graph, int m,
            int i, int[] color)
        {
            // If the current index is reached end
            if (i == GraphSize)
            {
                // If the coloring is safe
                if (IsSafe(graph, color))
                {
                    PrintSolution(color);
                    return true;
                }

                return false;
            }

            // Adding colors
            for (int j = 1; j <= m; j++)
            {
                color[i] = j;

                // Recursion other vertices
                if (GraphColoring(graph, m, i + 1, color))
                    return true;

                color[i] = 0;
            }

            return false;
        }
    }

/* Control Class. Menu, User Choices, User Choice Handlers */
    class Control
    {
        private static int _choice;
        private static string _strChoice = "";

        public static void MenuOutput()
        {
            Console.WriteLine("- - - Graph Coloring - - -");
            Console.WriteLine("- - - - Menu - - - -");
            Console.WriteLine("1 - New coloring");
            Console.WriteLine("2 - Output settings");
            Console.WriteLine("0 - Quit");
            Console.WriteLine("- - - - - - - - - - - -");
            Console.Write("Your choice: ");
            UserChoice();
        }

        private static void UserChoice()
        {
            while (true)
            {
                _strChoice = Console.ReadLine();
                var checkParse = int.TryParse(_strChoice, out _choice);
                if (checkParse)
                {
                    ChoiceHandler(_choice);
                    break;
                }
            }
        }

        private static void ChoiceHandler(int choice)
        {
            switch (choice)
            {
                case 0:
                    Environment.Exit(1);
                    break;
                case 1:
                    Console.WriteLine("Coloring menu");
                    ColoringSubMenuHandler();
                    break;
                case 2:
                    Console.WriteLine("Output settings");
                    Console.WriteLine("Feature not ready yet... ");
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }

        private static void ColoringSubMenuHandler()
        {
            bool[,] graph = Graph.EnterGraph();

            Console.WriteLine("Please enter count of colors: ");
            string strCount = Console.ReadLine();
            int.TryParse(strCount, out var m);
            int[] color = new int[Graph.GraphSize];
            for (int i = 0; i < Graph.GraphSize; i++)
            {
                color[i] = 0;
            }

            if (!Graph.GraphColoring(graph, m, 0, color))
                Console.WriteLine("Solution does not exist");
        }
    }

    class App
    {
        private static void Main()
        {
            while (true)
            {
                Control.MenuOutput();
            }
        }
    }
}