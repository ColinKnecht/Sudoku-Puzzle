using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//COLIN KNECHT-Program 2-CPT 244
namespace Program2_Knecht
{
    class Program
    {
        static void Main(string[] args)
        {

            Sudoku test = new Sudoku();
            test.LoadPuzzle("c:/Users/lori/desktop/sudoku-bad-1.txt");
            test.PrintPuzzle(test.Puzzle);
            test.CheckRows(test.Puzzle);
            test.CheckColumns(test.Puzzle);
            test.CheckBlockTwo(test.Puzzle);
            

            Console.ReadLine();
        }
    }
}
