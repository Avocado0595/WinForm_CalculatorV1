using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV1
{
    class Calculation
    {
        //kiểm tra ưu tiên + kiểm tra toán tử hay giá trị
        private static int Priority(char op)
        {
            if (op == '+' || op == '-')
                return 0;
            else
                if (op == '*' || op == '/')
                return 1;
            else
                return -1;
        }

        private string expr;

        public string Expr { get => expr; set => expr = value; }
        public List<string> Num { get => num; set => num = value; }
        public Stack<char> Op { get => op; set => op = value; }

        public Calculation()
        { }
        public Calculation(string expr)
        {
            this.expr = expr;
        }

        //chuyển đổi trung vị
        public void ChangeExp()
        {
            for (int i = 0; i < expr.Length; i++)
            {
                string temp = "";
                int j = i;
                for (j = i; j < expr.Length; j++)
                {
                    if (Priority(expr[j]) == -1)
                    {
                        if (j != expr.Length - 1)
                            i = j + 1;
                        temp += expr[j];
                    }
                    else
                    {
                        j = expr.Length;
                    }
                }
                if (temp != "")

                    Num.Add(temp);

                while (Op.Any() && Priority(Op.Peek()) >= Priority(expr[i]))
                {
                    Num.Add(Op.Pop().ToString());

                }

                Op.Push(expr[i]);

            }

        }

        public string Domath()
        {
            Stack<double> temp = new Stack<double>();
            foreach (var item in Num)
            {
                double value;
                if (double.TryParse(item, out value))
                {
                    temp.Push(value);
                }
                else
                {
                    if (temp.Count >= 2)
                    {
                        double num2 = temp.Pop();
                        double num1 = temp.Pop();
                        string op = item;
                        double res;

                        res = Operation(num1, num2, op);
                        if (res == double.NegativeInfinity || res == double.PositiveInfinity)
                            return "Divide by 0";
                        temp.Push(res);
                        
                        
                        
                    }

                }
            }
            return String.Format("{0:.######}",decimal.Parse(temp.Peek().ToString(), System.Globalization.NumberStyles.Float));


        }

        public double Operation(double number1, double number2, string op)
        {
            double result = 0;
            switch (op)
            {
                case "+":
                    {
                        result = number1 + number2;
                        break;
                    }
                case "-":
                    {
                        result = number1 - number2;
                        break;
                    }
                case "*":
                    {
                        result = number1 * number2;
                        break;
                    }
                case "/":
                    {
                        result = number1 / number2;
                        break;
                    }
            }
            return result;
        }


        //stack lưu toán tử
        private Stack<char> op = new Stack<char>();

        //List lưu biểu thức biến đổi
        private List<string> num = new List<string>();
    }
}

