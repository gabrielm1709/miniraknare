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
        int degree = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void updateBox() 
        {
            equation = textBox1.Text;
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

        private string calculate(string eq) 
        {
            return new DataTable().Compute(eq, null).ToString();
        }

        private string parseParenthesis(int idx, string inputEquation) 
        {
            string[] trig = new string[] { "sin", "cos", "tan", "PQ" };
            string subEquation = "";
            for (int i = idx; i < inputEquation.Length; i++)
            {

                int parenthesisLevel = 0;
                subEquation = "";
                foreach (string function in trig)
                {
                    if (inputEquation.Length > i + function.Length && inputEquation.Substring(i, function.Length).ToString() == function)
                    {
                        i += function.Length;
                        while (i < inputEquation.Length)
                        {
                            subEquation += equation[i];


                            if (inputEquation[i] == ')' && parenthesisLevel == 1)
                            {
                                break;
                            }
                            if (inputEquation[i] == ')' && parenthesisLevel > 1)
                            {
                                parenthesisLevel -= 1;
                            }
                            if (inputEquation[i] == '(')
                            {
                                parenthesisLevel += 1;
                            }
                            i += 1;
                        }

                        string replace = "";
                        string toReplace = $"{function}{subEquation}";
                        try
                        {
                            replace = getFunction(subEquation, function);
                        }
                        catch
                        {
                            subEquation = parseParenthesis(1, subEquation);
                        }


                        inputEquation = inputEquation.Replace(toReplace, replace);
                        i += (replace.Length - toReplace.Length);

                    }
                }
            }
          
            

            return inputEquation;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            // Räkna ut buffer.
            equation = textBox1.Text;
            equation = equation.Replace("π", Math.PI.ToString());
            equation = parseParenthesis(0, equation);
           
            textBox1.Text = calculate(equation.Replace(',', '.'));

            updateBox();
             
            
           
        }
   
        private string getFunction(string subEquation, string function) 
        {
            switch (function) 
            {
                case "sin":
                    return Math.Sin(double.Parse(calculate(subEquation))).ToString();
                case "cos":
                    return Math.Cos(double.Parse(calculate(subEquation))).ToString();
                case "tan":
                    return Math.Tan(double.Parse(calculate(subEquation))).ToString();
                case "PQ":
                    subEquation = subEquation.Replace('(', ' ').Replace(')', ' ');
                    return PQFormula(double.Parse(subEquation.Split(',')[0]), double.Parse(subEquation.Split(',')[1]), double.Parse(subEquation.Split(',')[2]));
               

                default:
                    return "error";
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            equation += "sin(";
            updateBox();
        }

        private string PQFormula(double num1, double num2, double num3) 
        {
            if(num1 == 0) 
            {
                return "error";
            }

            double sol1 = -(num2 / (num1 * 2)) + Math.Sqrt(Math.Pow(num2 / (num1 * 2), 2) - num3);
            double sol2 = -(num2 / (num1 * 2)) - Math.Sqrt(Math.Pow(num2 / (num1 * 2), 2) - num3);
            

            return sol1.ToString();
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
            textBox1.Text += "Cr(";
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Pr(";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += "MOD(";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text += "π";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
    }
}
