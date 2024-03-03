using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMk2
{
    public class OPS
    {
        public double? Num1 { get; set; }
        public double? Num2 { get; set; }
        public double TempNum { get; set; }
        public string? Operator { get; set; }
        //true is positive, false is negative
        public bool Error { get; set; }

        public double StringToDouble(string str)
        {
            //Convert string to double for calculation
            double num;
            if (double.TryParse(str, out num)) {  return num; }
            else
            {
                return double.NaN;
            }
        }
        public void NumCrunch()
        {
            //switch statement for each arithmetic operator
            //perform operations
            //set polarity to result polarity?
            //Num1 set to output
            //Num2 set to null
            Console.WriteLine($"NumCrunch initiated. Num1: {Num1} Operator: {Operator} Num2: {Num2}");

            switch (Operator)
            {
                case "+":
                    Num1 = Num1 + Num2;
                    Num2 = null;
                    break;
                case "-":
                    Num1 = Num1 - Num2;
                    Num2 = null;
                    break;
                case "x":
                    Num1 = Num1 * Num2;
                    Num2 = null;
                    break;
                case "/":
                    Num1 = Num1 / Num2;
                    Num2 = null;
                    break;
            }
            Console.WriteLine($"NumCrunch ran. Num1: {Num1} Operator: {Operator} Num2: {Num2}");


        }
        public void EqualsCrunch()
        {
            //switch statement for each arithmetic operator
            //Num1 and Num2 set to null
            //
            switch (Operator)
            {
                case "+":
                    Num1 = Num1 + Num2;
                    Operator = null;
                    Num2 = null;
                    break;
                case "-":
                    Num1 = Num1 - Num2;
                    Operator = null;
                    Num2 = null;
                    break;
                case "x":
                    Num1 = Num1 * Num2;
                    Operator = null;
                    Num2 = null;
                    break;
                case "/":
                    Num1 = Num1 / Num2;
                    Operator = null;
                    Num2 = null;
                    break;
            }
            Console.WriteLine($"EqualsCrunch ran. Num1: {Num1} Operator: {Operator} Num2: {Num2}");
        }
    }
}
