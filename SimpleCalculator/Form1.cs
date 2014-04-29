//Michael Grammer - 06/05/2013
//Updated logic March 2014

//Very simple calculator program, modeled after the Windows built-in calculator. Will have sqrrt and other functions later.
//As of now, only handles addition, sub, multi and division, as well as decimals.
//DONE - Need to add better visiuals, such as what function key was pressed, i.e. "+" or "/"
//Adding a form that displays the most recent entries/answers may be nice

//Fixed/changed since:
//    Tested and found 1 bug: If a function key is pressed with a null textBox, throws exception due to an attempt at converting oldNum (a null val) toDouble.
//    To fix this, added if (textExists) conditional to oldNum toDouble conversion under function buttons

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        #region Globals
        bool clearTB = false;
        bool functionPressed = false;

        int functionSwitch = 0;
        double oldNum = 0; //First number entered
        double newNum = 0; //Second number entered
        double answer = 1337;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyPress) //Handles keyboard input
        {
            //Function buttons and period button
            if (keyPress == Keys.Add)
            {
                addButton.PerformClick();
            }
            if (keyPress == Keys.Subtract)
            {
                subButton.PerformClick();
            }
            if (keyPress == Keys.Multiply)
            {
                multiButton.PerformClick();
            }
            if (keyPress == Keys.Divide)
            {
                divideButton.PerformClick();
            }
            if (keyPress == Keys.Enter) //Rarely acts funny/doesn't work as it should.
            {
                equalButton.PerformClick();
            }
            if (keyPress == Keys.OemPeriod || keyPress == Keys.Decimal)
            {
                periodButton.PerformClick();
            }
            if (keyPress == Keys.Back)
            {
                backspaceButton.PerformClick();
            }
            if (keyPress == Keys.Delete)
            {
                backspaceButton.PerformClick();
            }

            //Number buttons
            if (keyPress == Keys.NumPad0 || keyPress == Keys.D0)
            {
                num0Button.PerformClick();
            }
            if (keyPress == Keys.NumPad1 || keyPress == Keys.D1)
            {
                num1Button.PerformClick();
            }
            if (keyPress == Keys.NumPad2 || keyPress == Keys.D2)
            {
                num2Button.PerformClick();
            }
            if (keyPress == Keys.NumPad3 || keyPress == Keys.D3)
            {
                num3Button.PerformClick();
            }
            if (keyPress == Keys.NumPad4 || keyPress == Keys.D4)
            {
                num4Button.PerformClick();
            }
            if (keyPress == Keys.NumPad5 || keyPress == Keys.D5)
            {
                num5Button.PerformClick();
            }
            if (keyPress == Keys.NumPad6 || keyPress == Keys.D6)
            {
                num6Button.PerformClick();
            }
            if (keyPress == Keys.NumPad7 || keyPress == Keys.D7)
            {
                num7Button.PerformClick();
            }
            if (keyPress == Keys.NumPad8 || keyPress == Keys.D8)
            {
                num8Button.PerformClick();
            }
            if (keyPress == Keys.NumPad9 || keyPress == Keys.D9)
            {
                num9Button.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyPress);
        }

        #region Operator Button Events
        private void addButton_Click(object sender, EventArgs e)
        {
            functionSwitch = 1;
            OperatorFunction(" + ");
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            functionSwitch = 2;
            OperatorFunction(" - ");
        }

        private void multiButton_Click(object sender, EventArgs e)
        {
            functionSwitch = 3;
            OperatorFunction(" * ");
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            functionSwitch = 4;
            OperatorFunction(" / ");
        }
        #endregion

        #region Mathematics
        private void equalButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text += textBox.Text;

            if (functionPressed)
            {
                if (functionPressed && textBox.Text != "")
                {
                    newNum = Convert.ToDouble(textBox.Text);
                }
                else if (textBox.Text != "")
                {
                    oldNum = Convert.ToDouble(textBox.Text);
                }

                if (newNum != 0 && oldNum != 0)
                {
                    DoMath();

                    displayLabel.Text += " = " + answer.ToString();
                    newNum = 0;
                }

                functionPressed = false;
            }
        }

        private void DoMath()
        {
            if (textBox.Text != null)
            {
                switch (functionSwitch)
                {
                    case 1: //Add
                        answer = oldNum + newNum;
                        break;

                    case 2: //Sub
                        answer = oldNum - newNum;
                        break;

                    case 3: //Multi
                        answer = oldNum * newNum;
                        break;

                    case 4: //Divide
                        answer = oldNum / newNum;
                        break;

                    default:
                        break;
                }
                textBox.Text = answer.ToString();
                clearTB = true;
            }
        }

        private void OperatorFunction(string operatorKey)
        {
            if (functionPressed && textBox.Text != "")
            {
                newNum = Convert.ToDouble(textBox.Text);
                displayLabel.Text += newNum + operatorKey;
            }
            else if (textBox.Text != "")
            {
                oldNum = Convert.ToDouble(textBox.Text);
                displayLabel.Text = oldNum + operatorKey;
            }

            if (newNum == 0)
            {
                textBox.Clear();
            }
            else
            {
                DoMath();
                oldNum = answer;
            }

            functionPressed = true;
        }

        private void Numbers(int numSelection)
        {
            if (clearTB)
            {
                textBox.Text = numSelection.ToString();
                clearTB = false;
            }
            else
            {
                textBox.Text += numSelection.ToString();
            }
        }
        #endregion

        #region Number Button Events
        private void num1Button_Click(object sender, EventArgs e)
        {
            Numbers(1);
        }

        private void num2Button_Click(object sender, EventArgs e)
        {
            Numbers(2);
        }

        private void num3Button_Click(object sender, EventArgs e)
        {
            Numbers(3);
        }

        private void num4Button_Click(object sender, EventArgs e)
        {
            Numbers(4);
        }

        private void num5Button_Click(object sender, EventArgs e)
        {
            Numbers(5);
        }

        private void num6Button_Click(object sender, EventArgs e)
        {
            Numbers(6);
        }

        private void num7Button_Click(object sender, EventArgs e)
        {
            Numbers(7);
        }

        private void num8Button_Click(object sender, EventArgs e)
        {
            Numbers(8);
        }

        private void num9Button_Click(object sender, EventArgs e)
        {
            Numbers(9);
        }

        private void num0Button_Click(object sender, EventArgs e)
        {
            Numbers(0);
        }

        private void periodButton_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.Contains(".")) //Makes sure user can't type "47.....53567...0" for example.
            textBox.Text = textBox.Text.ToString() + ".";
        }
        #endregion

        #region Other Events
        private void clearButton_Click(object sender, EventArgs e) //Returns everything to default for new entry and returns focus
        {
            textBox.Clear();
            displayLabel.Text = "";

            functionPressed = false;
            clearTB = false;
            functionSwitch = 0;
            newNum = 0;
            oldNum = 0;
            answer = 0;
        }

        private void gtfoButton_Click(object sender, EventArgs e)  //Opens msgbox when pressing "Esc" and works fine, but does not work when "Visible" property of btn set to false
        {
            DialogResult result = MessageBox.Show("Close Calculator?", "Close", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (textBox.TextLength > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);

                if (textBox.Text == "")
                {
                    functionPressed = false;
                    clearTB = false;
                    functionSwitch = 0;
                    newNum = 0;
                    oldNum = 0;
                    answer = 0;
                }
            }
        }
        #endregion
    }
}
