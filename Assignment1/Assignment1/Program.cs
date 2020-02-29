/*
 Author: Carol Gabriel
 Student ID: 1732994
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                int option;
                Console.WriteLine("\t\t\t\tAssignment 1\n\n");
                Console.WriteLine("1 - Find Primes");
                Console.WriteLine("2 - Character Occurences in a String");
                Console.WriteLine("3 - Find Minimum of 3 Integers");
                Console.WriteLine("4 - Draw a Chessboard");
                Console.Write("\n\nChoose an option: ");
                if(Int32.TryParse(Console.ReadLine(), out option))
                {
                    if (0 < option && option < 5)
                    {
                        switch (option)
                        {
                            case 1:
                                Primes();
                                break;
                            case 2:
                                CharacterinString();
                                break;
                            case 3:
                                Console.Clear();
                                int num1, num2, num3;
                                Console.Write("Input the first number: ");
                                if(Int32.TryParse(Console.ReadLine(), out num1))
                                {
                                    Console.Write("\nInput the second number: ");
                                    if (Int32.TryParse(Console.ReadLine(), out num2))
                                    {
                                        Console.Write("\nInput the third number: ");
                                        if (Int32.TryParse(Console.ReadLine(), out num3))
                                        {
                                            Console.WriteLine("\n\nThe smallest of the three numbers is: " + SmallestInt(num1, num2, num3));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please input a valid number.");
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please input a valid number.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please input a valid number.");
                                    continue;
                                }
                                break;
                            case 4:
                                ChessBoard();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Press enter to enter a valid option or Q to exit.");                        
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Press enter to enter a valid option or Q to quit.");
                    continue;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }

        //void function to take user input and display the prime numbers
        static void Primes()
        {
            Console.Clear();
            int number;
            bool prime = true;
            Console.Write("Enter a number: ");
            if (Int32.TryParse(Console.ReadLine(), out number))
            {
                for (int i = 2; i <= number; i++)
                {
                    for (int j = 2; j <= number; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            prime = false;
                            break;
                        }
                        else
                        {
                            prime = true;
                        }
                    }
                    if (prime == true)
                    {
                        Console.WriteLine(i);                        
                    }                    
                }
            }
            else
            {
                Console.WriteLine("Press enter to enter a valid number or Q to quit.");
            }
        }

        //void function to display count of characters in each string
        static void CharacterinString()
        {
            Console.Clear();
            string sentence1 = "To Be Or Not To Be That Is The Question?";
            string sentence2 = "ASK NOT WHAT YOUR COUNTRY CAN DO FOR YOU - ASK WHAT YOU CAN DO FOR YOUR COUNTRY";
            int counte = 0, countC = 0, countl = 0;
            char chare = 'e';
            char charC = 'C';
            char charl = 'l';
            foreach (char e in sentence1)
            {
                if (e == chare)
                {
                    counte++;
                }
            }
            foreach (char c in sentence1)
            {
                if (c == charC)
                {
                    countC++;
                }
            }
            foreach (char l in sentence1)
            {
                if (l == charl)
                {
                    countl++;
                }
            }
            Console.WriteLine("\t\t" + sentence1);
            Console.WriteLine("\nCharacter e: " + counte);
            Console.WriteLine("Character I: " + countl);
            Console.WriteLine("Character C: " + countC);
            counte = 0;
            countC = 0;
            countl = 0;
            foreach (char e in sentence2)
            {
                if(e == chare)
                {
                    counte++;
                }
            }
            foreach (char c in sentence2)
            {
                if (c == charC)
                {
                    countC++;
                }
            }
            foreach (char l in sentence2)
            {
                if (l == charl)
                {
                    countl++;
                }
            }
            Console.WriteLine("\t\t" + sentence2);
            Console.WriteLine("\nCharacter e: " + counte);
            Console.WriteLine("Character I: " + countl);
            Console.WriteLine("Character C: " + countC);
            Console.ReadKey();
        }
        
        //int fucntion that returns smallest int
        static int SmallestInt(int x, int y, int z)
        {
            if (x < y && x < z)
            {
                return x;
            }
            else if (y < x && y < z)
            {
                return y;
            }
            else
            {
                return z;
            }
        }

        //void function to display the chess board
        static void ChessBoard()
        {
            Console.Clear();
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (j % 2 == i % 2)
                    {
                        Console.Write('\u2588');
                    }
                    else
                    {
                        Console.Write('\u2591');
                    }
                }
                Console.WriteLine();                
            }
            Console.ReadKey();
        }
    }
}
