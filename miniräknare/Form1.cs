using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniräknare
{
    public partial class Form1 : Form
    {
        string equation = "";
        bool degree = true;
        // Omvandla radianer till grader.
        double calculateDegree = Math.PI / 180;

        public Form1()
        {
            InitializeComponent();
        }

        // y = ax^2 + px + q -> PQ(a, p, q)
        private string PQFormula(double a, double p, double q)
        {
            if (a == 0)
            {
                return "error";
            }

            double solution = -(p / (a * 2)) + Math.Sqrt(Math.Pow(p / (a * 2), 2) - q);

            return solution.ToString();
        }

        private string getResult(string subEquation, string function)
        {
            switch (function)
            {
                case "sin":
                    return Math.Sin(double.Parse(calculate(subEquation)) * calculateDegree).ToString();
                case "cos":
                    return Math.Cos(double.Parse(calculate(subEquation)) * calculateDegree).ToString();
                case "tan":
                    return Math.Tan(double.Parse(calculate(subEquation)) * calculateDegree).ToString();
                case "PQ":
                    subEquation = subEquation.Replace('(', ' ').Replace(')', ' ');
                    return PQFormula(double.Parse(subEquation.Split(',')[0]), double.Parse(subEquation.Split(',')[1]), double.Parse(subEquation.Split(',')[2]));
                case "e^":
                    return Math.Exp(double.Parse(calculate(subEquation))).ToString();
                case "√": 
                    return Math.Sqrt(double.Parse(calculate(subEquation))).ToString();

                default:
                    return "error";
            }
        }

        private string calculate(string eq)
        {
            return new DataTable().Compute(eq.Replace(',', '.'), null).ToString();
        }

        private string parseParenthesis(string inputEquation)
        {
            string[] functionList = new string[] { "sin", "cos", "tan", "PQ", "e^" , "√" };
            int i = 0;
            // Kolla om input innehåller några specialfunktioner och räkna då ut värdet. 
            while (i < inputEquation.Length)
            {
                string subEquation = "";
                int parenthesisLevel = 0;
                foreach (string function in functionList)
                {
                    if (inputEquation.Length > i + function.Length && inputEquation.Substring(i, function.Length).ToString() == function)
                    {
                        i += function.Length;
                        while (i < inputEquation.Length)
                        {
                            subEquation += inputEquation[i];

                            if (inputEquation[i] == '(')
                            {
                                parenthesisLevel += 1;
                            }
                            if (inputEquation[i] == ')')
                            {
                                if (parenthesisLevel == 1) { break; }
                                 
                                parenthesisLevel -= 1;
                            }
                            i += 1;
                        }

                        string replace = getResult(subEquation, function);
                        string toReplace = $"{function}{subEquation}";
                        inputEquation = inputEquation.Replace(toReplace, replace);
                        i += (replace.Length - toReplace.Length);
                    }
                }
                i += 1;
            }

            return inputEquation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            textBox1.Text += "2";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear
            textBox1.Text = "";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            // Räkna ut input.
            equation = textBox1.Text;
            equation = equation.Replace("π", Math.PI.ToString());
            equation = parseParenthesis(equation);

            try 
            {
                textBox1.Text = calculate(equation);
                equation = textBox1.Text;
            }
            catch 
            {
                textBox1.Text = "error";
            }
        }
   
        
        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sin(";
        }
       
        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cos(";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text += "tan(";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "e^(";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text += "π";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text += "PQ(";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0) 
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            if (degree) 
            {
                calculateDegree = 1;
                button21.Text = "RADIANS";
                degree = false;
            }
            else 
            {
                degree = true;
                calculateDegree = Math.PI / 180;
                button21.Text = "DEGREE";
            }
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "ln(";
        }

        private void button22_Click_2(object sender, EventArgs e)
        {
            textBox1.Text += equation;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox1.Text += "√(";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
