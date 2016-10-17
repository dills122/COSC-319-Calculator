using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;
using System.Windows.Forms;



namespace COSC_Calculator
{
    public partial class Form1 : Form
    {
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        //Double result;
        //char operation;
        List<String> HistoryStr = new List<string>();

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deals with Number button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Text)
            {
                case "1":
                    EquationTxt.Text += btn.Text;
                    break;
                case "2":
                    EquationTxt.Text += btn.Text;
                    break;
                case "3":
                    EquationTxt.Text += btn.Text;
                    break;
                case "4":
                    EquationTxt.Text += btn.Text;
                    break;
                case "5":
                    EquationTxt.Text += btn.Text;
                    break;
                case "6":
                    EquationTxt.Text += btn.Text;
                    break;
                case "7":
                    EquationTxt.Text += btn.Text;
                    break;
                case "8":
                    EquationTxt.Text += btn.Text;
                    break;
                case "9":
                    EquationTxt.Text += btn.Text;
                    break;
                case "0":
                    EquationTxt.Text += btn.Text;
                    break;
                case ".":
                    //Boolean bol = EquationTxt.Text.Contains('.');
                    //if (bol == false)
                    //{
                    EquationTxt.Text += btn.Text;
                    //}
                    break;
                case "(":
                    char[] equationarry = EquationTxt.Text.ToCharArray();
                    char[] badCharacters = { ')', '+', '*', '-', '/' };
                    if (equationarry.Length != 0)
                    {
                        char c = equationarry[EquationTxt.Text.Length - 1];
                        bool bad = badCharacters.Contains(c);
                        bool num = Char.IsNumber(c);
                        if (bad == true && num == true)
                        {
                            EquationTxt.Text += btn.Text;
                        }
                    }
                    break;
                case ")":
                    equationarry = EquationTxt.Text.ToCharArray();
                    if (equationarry.Length != 0)
                    {

                        char c = equationarry[EquationTxt.Text.Length - 1];
                        if (Char.IsNumber(c) == true || c != '(')
                        {
                            EquationTxt.Text += btn.Text;
                        }
                    }

                    break;
            }
        }

        private void Squared_Click(object sender, EventArgs e)
        {
            EquationTxt.Text += "^2";

        }
        /// <summary>
        /// Deals with the Opeator Button Click Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operator_Click(object sender, EventArgs e)
        {



            Button btn = sender as Button;

            switch (btn.Text)
            {
                case "+":
                    EquationTxt.Text += btn.Text;
                    break;
                case "-":
                    EquationTxt.Text += btn.Text;
                    break;
                case "X":
                    EquationTxt.Text += "*";
                    break;
                case "/":
                    EquationTxt.Text += btn.Text;
                    break;

            }
        }

        private void Equals_Click(object sender, EventArgs e)
        {

            //Grabs Text from Textbox 
            string expressionStr = EquationTxt.Text.ToString();
            //Generates Expression
            Expression ex = new Expression(expressionStr);

            //Calculates the expression
            double result = ex.calculate();
            //Sets the Textbox equal to the result
            EquationTxt.Text = result.ToString();

            HistoryStr.Add(expressionStr + " = " + result.ToString());

            //For two operator values 
            //operand2 = EquationTxt.Text;
            //EquationTxt.Text = "";
            //    Double numOne = Convert.ToDouble(operand1);
            //    Double numTwo = Convert.ToDouble(operand2);

            //    switch (operation)
            //    {
            //        case '+':
            //            result = numOne + numTwo;
            //            break;
            //        case '-':
            //            result = numOne - numTwo;
            //            break;
            //        case '*':
            //            result = numOne * numTwo;
            //            break;
            //        case '/':
            //            //Need to deal with carry over to get correct values
            //            result = numOne + numTwo;
            //            break;
            //    }
            //    EquationTxt.Text = result.ToString();
        }
        /// <summary>
        /// Clear button event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            EquationTxt.Text = "";
        }

        /// <summary>
        /// Delete Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            //char[] equationarry = EquationTxt.Text.ToCharArray();
            if (EquationTxt.Text.Length != 0)
            {
                string Equation = EquationTxt.Text;
                string result = Equation.Remove((EquationTxt.Text.Length - 1));
                EquationTxt.Text = "";
                EquationTxt.Text = result;
            }     
        }
        /// <summary>
        /// History Panel Openning 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            //Makes sure there is history to show 
            if (HistoryStr.Count != 0)
            {
                History hist = new History(HistoryStr);
                hist.Show();
            }
            
        }

        /// <summary>
        /// Panel View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button23_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        /// <summary>
        /// Used to handle the Scientific panels button clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScientificFunctions(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch(btn.Text)
            {
                case "Mod":
                    EquationTxt.Text += "%";
                    break;
                case "Sin":
                    EquationTxt.Text += "sin(";
                    break;
                case "Cos":
                    EquationTxt.Text += "cos(";
                    break;
                case "Tan":
                    EquationTxt.Text += "tan(";
                    break;
                case "Sqrt":
                    EquationTxt.Text += "sqrt(";
                    break;
                case "Log":
                    EquationTxt.Text += "log(";
                    break;
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dssteele.com/help.aspx");
        }
    }
}
