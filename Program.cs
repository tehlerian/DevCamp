using System;
using System.Linq;

namespace RedvsGreen
{
    class Program
    {
        public static int[] pointAndGenerations;
        public static int[,] currentState;
        public static int[,] newState;
        public static int x = 0;
        public static int y = 0;
        public static int pointGreens = 0;

        static void Main(string[] args)
        {
            InputData();
            CalculateGenerations();
            Console.WriteLine(pointGreens);
        }

        private static void InputData()
        {

            while (true)  //Get matrix size
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                x = input[1];
                y = input[0];

                if (x <= y && y < 1000 && x > 0) //Checking matrix size
                {
                    break;
                }
            }

            currentState = new int[x, y];
            newState = new int[x, y];

            for (int row = 0; row < x; row++)  //Get & Set matrix data
            {
                int[] input = new int[y];
                bool checkValues = true;
                while (checkValues)
                {
                    checkValues = false;

                    int rawInput = int.Parse(Console.ReadLine());
                    for (int k = 0; k < input.Length; k++)
                    {
                        input[k] = rawInput % 10;
                        rawInput /= 10;
                    }

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 0 || input[i] == 1) //Checking matrix data
                        {
                            continue;
                        }
                        else
                        {
                            checkValues = true;
                            break;
                        }
                    }
                }

                for (int col = 0; col < y; col++)
                {
                    currentState[row, col] = input[col]; //Filling data
                }
            }

            pointAndGenerations = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        }
        
        private static void CalculateGenerations()
        {
            int pointX = pointAndGenerations[1];
            int pointY = pointAndGenerations[0];
            int generations = pointAndGenerations[2];

            if (currentState[pointX, pointY] == 1)
                pointGreens++;

            for (int i = 0; i < generations; i++)  //Calculate every new generation
            {
                for (int row = 0; row < x; row++)  //Calculate every new state
                {
                    for (int col = 0; col < y; col++)
                    {
                        int numberOfGreens = 0;
                        if(row -1 >= 0 && col - 1 >= 0)
                        {
                            if (currentState[row - 1, col - 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (row - 1 >= 0)
                        {
                            if (currentState[row - 1, col] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (row - 1 >= 0 && col + 1 < y)
                        {
                            if (currentState[row - 1, col + 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (col - 1 >= 0)
                        {
                            if (currentState[row, col - 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (col + 1 < y)
                        {
                            if (currentState[row, col + 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (row + 1 < x && col - 1 >= 0)
                        {
                            if (currentState[row + 1, col - 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (row + 1 < x)
                        {
                            if (currentState[row + 1, col] == 1)
                            {
                                numberOfGreens++;
                            }
                        }
                        if (row + 1 < x && col + 1 < y)
                        {
                            if (currentState[row + 1, col + 1] == 1)
                            {
                                numberOfGreens++;
                            }
                        }

                        if(currentState[row, col] == 0)
                        {
                            if(numberOfGreens == 3 || numberOfGreens == 6)
                            {
                                newState[row, col] = 1;
                            }
                            else
                            {
                                newState[row, col] = 0;
                            }
                        }
                        else if(currentState[row, col] == 1)
                        {
                            if (numberOfGreens == 2 || numberOfGreens == 3 || numberOfGreens == 6)
                            {
                                newState[row, col] = 1;
                            }
                            else
                            {
                                newState[row, col] = 0;
                            }
                        }
                    }
                }

                if (newState[pointX, pointY] == 1)
                    pointGreens++;

                for (int row = 0; row < x; row++)
                {
                    for (int col = 0; col < y; col++)
                    {
                        currentState[row, col] = newState[row, col];
                    }
                }
            }

        }
    }
}
