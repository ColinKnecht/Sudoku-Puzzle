using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
//COLIN KNECHT-Program 2-CPT 244
namespace Program2_Knecht
{
    class Sudoku
    {
        int[,] puzzle = new int[9, 9];

        public int[,] Puzzle { get => puzzle; set => puzzle = value; }

        public Sudoku() { }

        public Sudoku(int size)
        {
            int[,] puzzleOne = new int[size, size];
        }

        public void LoadPuzzle(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader input = new StreamReader(fs);
            int r = 0;
            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                string[] fields = line.Split(",".ToCharArray());

                if (fields.Length < 9)
                {
                    continue;
                }

                for (int c = 0; c < fields.Length; c++)
                {
                    Puzzle[r, c] = int.Parse(fields[c]);
                }
                r++;

            }//end while


        }

        public void PrintPuzzle(int[,] ary)
        {
            int row = ary.GetLength(0);
            int col = ary.GetLength(1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write(" " + ary[r, c]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void CheckColumns(int[,] ary)
        {
            int length = ary.GetLength(1);
            int count = 0;
            int check = 0;
            for (int col = 0; col < length; col++)
            {
                for (int i = 0; i < length; i++)
                {
                    count = 0;
                    check = ary[i, col];
                    for (int j = 0; j < length; j++)
                    {
                        if (check == ary[j, col])
                        {
                            count++;
                        }
                    }//for 3
                    if (count > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("INVALID COLUMN: " + ary[i, col] + " occurs " + count + " times at column " + col);
                        //Console.WriteLine("INVALID: Column " + col );
                        break;
                    }
                }//for 2

            }//for 1
            Console.ResetColor();
        }

        public void CheckRows(int[,] ary)
        {
            int length = ary.GetLength(0);
            int count = 0;
            int check = 0;
            int i = 0;
            int j = 0;
            int row = 0;
            for (row = 0; row < length; row++)//Checks The Rows
            {
                for (i = 0; i < length; i++)//Checks Individual Numbers in  Row
                {
                    count = 0;
                    check = ary[row, i];
                    for (j = 0; j < length; j++)//Compares Individual to all ints in array
                    {
                        if (check == ary[row, j])
                        {
                            count++;
                        }
                    }//for 3
                    if (count > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("INVALID ROW:  " + ary[row, i] + " occurs " + count + " times at row " + row);
                        break;
                    }
                }//for 2

            }//for 1
            Console.ResetColor();
        }

        public void CheckBlock(int[,] ary)
        {
            int row = 0;
            int col = 0;
            int length = ary.GetLength(0);
            int count = 0;
            int check;
            for (int block = 0; block < length - 1; block++)//checks blocks
            {
                row = (block / 3) * 3;
                col = (block % 3) * 3;
                check = ary[row, col];
                count = 0;
                for (int i = 0; i < row + 2; i++)//checks rows in blocks
                {
                    if (check == ary[row, i])
                    {
                        count++;
                    }
                    for (int j = 0; j < row + 2; j++)//checks columns
                    {
                        if (check == ary[j, i])
                        {
                            count++;
                        }
                    }//for3
                    if (count > 2)
                    {
                        Console.WriteLine("INVALID BLOCK: " + block);
                        break;
                    }
                }//for2
            }//for1
        }//end

        public void CheckBlockTwo(int[,] ary)
        {
            int row = 0;
            int col = 0;
            int length = ary.GetLength(0);
            int count = 0;
            int check;
            for (int block = 0; block < length - 1; block++)//checks blocks
            {
                row = (block / 3) * 3;
                col = (block % 3) * 3;
                check = ary[row, col];
                count = 0;
                for (int i = 0; i < row + 2; i++)//checks rows in blocks
                {
                    if (check == ary[row, i])
                    {
                        count++;
                    }
                }//for2
                for (int j = 0; j < row + 2; j++)//checks columns
                {
                    if (check == ary[j, col])
                    {
                        count++;
                    }
                }//for3
                if (count > 2)
                {
                    Console.WriteLine("INVALID BLOCK: " + block);
                    //break;
                }
            }//for1
        }//end
    }//END CLASS
}

