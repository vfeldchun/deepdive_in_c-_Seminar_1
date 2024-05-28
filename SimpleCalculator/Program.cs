using System.Globalization;

namespace SimpleCalculator {
    class Programm 
    {
        static void Main(string[] args) 
        {
            string mathOperators = "+-/*";

            double firstValue;
            double secondValue;

            var style = NumberStyles.Number;
            var culture = CultureInfo.CreateSpecificCulture("ru");

            if (args.Length == 3)
            {
                if (!IsDouble(args[0]) || !IsDouble(args[2]) ||
                    !mathOperators.Contains(args[1]))
                {
                    PrintHelp();
                }
                else
                {
                    if (double.TryParse(args[0], style, culture, out firstValue) &&
                        double.TryParse(args[2], style, culture, out secondValue))
                    {
                        Console.WriteLine("Результат математической операции:");
                        Console.WriteLine($"\t{args[0]} {args[1]} {args[2]} = " +
                            $"{Math.Round(GetMathOperationsResult(firstValue, secondValue, args[1]), 2)}");
                    }                        
                    else
                    {
                        PrintHelp();
                    }   

                }                
            }
            else
            {
                PrintHelp();    
            }
        }

        static bool IsDouble(string number)
        {
            bool result = true;

            if (number.Split(',').Length < 2) return false;

            foreach (char c in number)
            {
                if (!(Char.IsDigit(c) || c == ','))
                {
                    result = false;
                    break;
                }
                    
            }

            return result;
        }

        static double GetMathOperationsResult(double first, double second, string mathOperation)
        {
            double result = 0;

            if (mathOperation.Equals("+")) return result = first + second;
            if (mathOperation.Equals("-")) return result = first - second;
            if (mathOperation.Equals("/")) return result = first / second;
            return result = first * second;
        }

        static void PrintHelp()
        {
            Console.WriteLine("Для работы программы необходимы параметры вводимые через пробел:");
            Console.WriteLine("\tПервый параметр: число (Например: 12 или 7,5)");
            Console.WriteLine("\tВторой параметр: математический оператор (+, -, /, *)");
            Console.WriteLine("\tТретий параметр: число (Например: 2 или 1,1)");
        }
    }
}
