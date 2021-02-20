using System;

namespace _02._Re_volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int[] playerPos = { 0, 0 };

            for (int rows = 0; rows < n; rows++)
            {
                string curr = Console.ReadLine();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = curr[cols];

                    if (matrix[rows, cols] == 'f')
                    {
                        playerPos[0] = rows;
                        playerPos[1] = cols;
                    }
                }
            }

            int commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                string cmd = Console.ReadLine();

            }
        }

        public static int[] Move(int[] pos, char[,] matrix, string input)
        {
            switch (input)
            {
                case "up":
                    pos[0]--;
                    break;
                case "down":
                    pos[0]++;
                    break;
                case "left":
                    pos[1]--;
                    break;
                case "right":
                    pos[1]++;
                    break;
                default:
                    break;
            }

            if (pos[0]>=matrix.GetLength(0))
            {
                pos[0] = 0;
            }
            else if (pos[0]<0)
            {
                pos[0] = matrix.GetLength(0) - 1;
            }

            if (pos[1]>=matrix.GetLength(1))
            {
                pos[1] = 0;
            }
            else if (pos[1]<0)
            {
                pos[1] = matrix.GetLength(1) - 1;
            }

            return pos;
        }

    }
}
