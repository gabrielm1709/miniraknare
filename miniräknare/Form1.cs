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
        public Form1()
        {
            InitializeComponent();
        }

        private void updateBox() 
        {
            textBox1.Text = equation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            equation += "1";
            updateBox();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            equation += "2";
            updateBox();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            equation += "3";
            updateBox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            equation += "4";
            updateBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            equation += "5";
            updateBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            equation += "6";
            updateBox();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            equation += "7";
            updateBox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            equation += "8";
            updateBox();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            equation += "9";
            updateBox();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            equation += "0";
            updateBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear
            equation = "";
            updateBox();
        }

        private string calculate(string eq) 
        {
            return new DataTable().Compute(eq, null).ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            // Räkna ut buffer.
            for(int i = 0; i < equation.Length; i++) 
            {
                
                int parenthesisLevel = 0;
                string subEquation = "";
                   
                if(equation.Length > i+3 && equation.Substring(i, i+3).ToString() == "sin") 
                {
                    i+=3;
                    while (i<equation.Length)
                    {
                        subEquation += equation[i];
                       
                        
                        if (equation[i] == ')' && parenthesisLevel == 1) 
                        {
                            break;
                        }
                        if(equation[i] == ')' && parenthesisLevel > 1)
                        {
                            parenthesisLevel -= 1;
                        }
                        if(equation[i] == '(') 
                        {
                            parenthesisLevel += 1;
                        }
                        i += 1;
                    }
                    
                    equation.Replace($"sin{subEquation}", Math.Sin(double.Parse(calculate(subEquation))).ToString());
                    
                }
            }
           
            equation = calculate(equation);

            updateBox();
             
            
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            equation += "sin(";
            updateBox();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            equation += "cos(";
            updateBox();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            equation += "tan(";
            updateBox();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            equation += "Cr(";
            updateBox();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            equation += "Pr(";
            updateBox();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            equation += "MOD(";
            updateBox();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            equation += "e^";
            updateBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            equation += "+";
            updateBox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            equation += "-";
            updateBox();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            equation += "*";
            updateBox();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            equation += "/";
            updateBox();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            equation += "(";
            updateBox();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            equation += ")";
            updateBox();
        }
    }
}
