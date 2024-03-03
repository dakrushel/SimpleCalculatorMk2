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
            //perform operation
            //Num2 set to null
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
        }
        public void EqualsCrunch()
        {
            //switch statement for each arithmetic operator
            //Operator and Num2 set to null
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
        }
    }
}
