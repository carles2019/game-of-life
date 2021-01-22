using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameoflife
    {
    class Program
    {
        static int[,] currentgeneration = new int[Console.LargestWindowHeight + 1, Console.LargestWindowWidth + 1];
        static int[,] nextgeneration = new int[Console.LargestWindowHeight + 1, Console.LargestWindowWidth + 1];

        static void Main(string[] args)
        {
            ConsoleColor cellcolour = ConsoleColor.Green;
            ConsoleColor backgroundcolour = ConsoleColor.Black;

            Introduction();

            Console.Title = "GAME OF LIFE SIMULATION";
            int worldwidth = Console.LargestWindowWidth;
            int worldheight = Console.LargestWindowHeight;
            Console.SetWindowSize(worldwidth, worldheight);
            Console.SetWindowPosition(0, 0);




            setupworld(worldwidth, worldheight, cellcolour, backgroundcolour);




            int generation = 0;
            DrawWorld(worldwidth, worldheight, cellcolour, backgroundcolour, generation);
            for (int row = 1; row < worldheight; row++)
            {

                for (int col = 1; col < worldwidth; col++)
                {
                    if (IsAlive(row, col))
                        nextgeneration[row, col] = 1;
                    else
                        nextgeneration[row, col] = 0;
                }
            }

                    // SIMULATION CODE HERE!



                    generation++;
            for (int row = 1; row < worldheight; row++)
            {

                for (int col = 1; col < worldwidth; col++)

                {

                    currentgeneration[row, col] = nextgeneration[row, col];

                }

            }
            DrawWorld(worldwidth, worldheight, cellcolour, backgroundcolour, generation);

        }






        //---------------------------------------------------------------------------------------------------

        static void Introduction()
        {
            Console.WriteLine("CONWAY'S GAME OF LIFE");
            Console.WriteLine();
            Console.WriteLine("To set up your starting world use the following keys..");
            Console.WriteLine("Arrow keys  - move around the screen");
            Console.WriteLine("Space Bar   - places a cell in that location");
            Console.WriteLine("Escape key  - To end setup");
            Console.WriteLine();
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
            Console.Clear();
        }




        //-------------------------------------------------------------------------------------------------

        static void setupworld(int worldwidth, int worldheight, ConsoleColor cellcolour, ConsoleColor backgroundcolour)
        {
            Boolean setupcomplete = false;
            int cursorx = 1;
            int cursory = 1;
            Console.SetCursorPosition(cursorx, cursory);
            while (!setupcomplete)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (cursory > 1)
                            {
                                cursory = cursory - 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (cursory < Console.LargestWindowHeight - 1)
                            {
                                cursory = cursory + 1;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (cursorx > 1)
                            {
                                cursorx = cursorx - 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (cursorx < Console.LargestWindowWidth - 1)
                            {
                                cursorx = cursorx + 1;
                            }
                            break;

                        case ConsoleKey.Spacebar:
                            currentgeneration[cursory, cursorx] = 1;
                            break;

                        case ConsoleKey.Escape:
                            setupcomplete = true;
                            break;
                    }
                    DrawWorld(worldwidth, worldheight, cellcolour, backgroundcolour, 0);
                    Console.SetCursorPosition(cursorx, cursory);
                }

            }
            Console.SetCursorPosition(15, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Press Any key to now start the simulation");
            Console.ReadKey();
        }


        //-----------------------------------------------------------------------------------------------------

        static void DrawWorld(int worldwidth, int worldheight, ConsoleColor cellcolour, ConsoleColor backgroundcolour, int generation)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("Generation: {0}", generation);
            for (int r = 0; r < worldheight; r++)
            {
                for (int c = 0; c < worldwidth; c++)
                {
                    if (currentgeneration[r, c] == 1)
                    {
                        Console.SetCursorPosition(c, r);
                        Console.BackgroundColor = cellcolour;
                        Console.Write(" ");
                        Console.BackgroundColor = backgroundcolour;
                    }
                }
            }

            

              
        }

           static bool IsAlive(int r, int c)
            {
                var count = currentgeneration[r - 1, c - 1]
                          + currentgeneration[r - 1, c]
                          + currentgeneration[r - 1, c + 1]
                          + currentgeneration[r, c - 1]
                          //+ currentgeneration[r, c]
                          + currentgeneration[r, c + 1]
                          + currentgeneration[r + 1, c - 1]
                          + currentgeneration[r + 1, c]
                          + currentgeneration[r + 1, c + 1];
                var wasAlive = (currentgeneration[r, c] == 1);
            if (wasAlive && (count == 2 || count == 3)) return true; // Any live cell with two or three live neighbors lives on to the next generation.
                                                                     //if (wasAlive && count >= 3) return false;                // Any live cell with more than three live neighbors dies, as if by overpopulation.
            if (!wasAlive && count == 3) return true;              // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
            return false;
            //return IsAlive==(isAlive, count);
            }
        }
    }


            
    


