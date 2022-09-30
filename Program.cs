using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
// #error version

namespace Sudoku
{
    internal class Program
    {
        static bool Check(int[,] board, int row, int col, int guess)
        {
            // Check row
            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == guess)
                {
                    return false;
                }
            } 

            // Check col
            for (int i = 0; i < 9; i++)
            {
                if (board[row,i]== guess) 
                {
                    return false;
                }
            }

            // Check Box
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[(startRow + i), (startCol + j)] == guess)
                    {
                        return false;
                    }
                }
            }
            Write("here");
            return true;
        }
        static bool Solve(int[,] board, int row, int col)
        {
            if (row == 8 && col == 9)
            {
                return true;
            }

            if (col == 9)
            {
                row += 1;
                col = 0;
            }

            if (board[row, col] != 0)
            {
                Solve(board, row, col + 1);
            }
            for (var guess = 1; guess < 10; guess++)
            {
                bool res = Check(board, row, col, guess);
                if (res)
                {
                    board[row, col] = guess;

                    if (Solve(board, row, col + 1))
                    {
                        return true;
                    }
                }
                board[row, col] = 0;    
            }
            return false;
        }
        static void Run()
        {
            // TODO Printage
            // List<string> boardList = new List<string>() {"700130086", "610590407","308060000", "090420805", "000005203", "004603091", "405870020", "006000158", "900006000"};
            int[,] boardList ={    { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
                                   { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 8, 7, 0, 0, 0, 0, 3, 1 },

                                   { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                                   { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                                   { 0, 5, 0, 0, 9, 0, 6, 0, 0 },

                                   { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                                   { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                                   { 0, 0, 5, 2, 0, 6, 3, 0, 0 } };
                            // { {7, 0, 0,    1, 3, 0,    0, 8, 6 },
                             // {6, 1, 0,    5, 9, 0,    4, 0, 7 },
                             // {3, 0, 8,    0, 6, 0,    0, 0, 0 },
// 
                             // {0, 9, 0,    4, 2, 0,    8, 0, 5 },
                             // {0, 0, 0,    0, 0, 5,    2, 0, 3 },
                             // {0, 0, 4,    6, 0, 3,    0, 9, 1 },
// 
                             // {4, 0, 5,    8, 7, 0,    0, 2, 0 },
                             // {0, 0, 6,    0, 0, 0,    1, 5, 8 },
                             // {9, 0, 0,    0, 0, 6,    0, 0, 0 }};
            WriteLine(Solve(boardList, 0, 0));
            for (int i =0; i< 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Write(boardList[i,j] + " "); 
                }
                WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Run();
            ReadLine();
        }
    }
}
