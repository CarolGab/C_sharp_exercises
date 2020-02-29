/*
 Carol Gabriel
 1732994
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_3
{
    class Program
    {
        enum Operation
        {
            A,
            S,
            M,
            D
        };
        static void Main(string[] args)
        {
            bool valid = false;
            do
            {
                Console.Clear();
                double num1, num2;
                string operation;
                Operation op;                
                Console.WriteLine("\t\t\t\t\t\tCALCULATOR");
                Console.Write("Enter the first number: ");
                if (Double.TryParse(Console.ReadLine(), out num1))
                {
                    valid = true;
                    Console.Write("Enter the second number: ");
                    if (Double.TryParse(Console.ReadLine(), out num2))
                    {
                        Console.Write("Enter an operation(A for addition, S for substraction, M for multiplication, D for division): ");
                        operation = Console.ReadLine();
                        if (operation == "A" || operation == "a")
                        {
                            op = Operation.A;
                        }
                        else if (operation == "S" || operation == "s")
                        {
                            op = Operation.S;
                        }
                        else if (operation == "D" || operation == "d")
                        {
                            op = Operation.D;
                        }
                        else if (operation == "M" || operation == "m")
                        {
                            op = Operation.M;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid operation.");
                            valid = false;
                            Console.ReadKey();
                            continue;
                        }
                        switch (op)
                        {
                            case Operation.A:
                                Console.WriteLine(Utility.Add(num1, num2));
                                break;
                            case Operation.D:
                                Console.WriteLine(Utility.Division(num1, num2));
                                break;
                            case Operation.M:
                                Console.WriteLine(Utility.Multiplication(num1, num2));
                                break;
                            case Operation.S:
                                Console.WriteLine(Utility.Substraction(num1, num2));
                                break;
                            default: break;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                        valid = false;
                        Console.ReadKey();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                    continue;
                }
            } while (!valid);
        }

        public static class Utility
        {
            public static double Add(double number1, double number2)
            {
                return number1 + number2;
            }
            public static double Substraction(double number1, double number2)
            {
                return number1 - number2;
            }
            public static double Multiplication(double number1, double number2)
            {
                return number1 * number2;
            }
            public static double Division(double number1, double number2)
            {
                return number1 / number2;
            }
        }
    }
}
