using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txbScreen.Text = "";
        }

        //Input number here
        private void click_input(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            if (decimal.TryParse(txbScreen.Text+btn.Text, out result))
            {
                txbScreen.Text += btn.Text.ToString();               
            }
  
        }

        //Clear button -> Clear all Screen
        private void btnClear_Click(object sender, EventArgs e)
        {
            makeClear();
            txbScreen.TabIndex = 1;
        }

        //Input operator
        private void click_op(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "x")
                btn.Text = "*";
            if (lblScreen.Text.Contains("="))
            {

                lblScreen.Text = txbScreen.Text;
            }
            else
            {
                if (txbScreen.Text != "")
                {
                    lblScreen.Text += txbScreen.Text;
                }
                else
                {
                    lblScreen.Text += "0";
                }
            }
            lblScreen.Text += btn.Text;
            txbScreen.Text = "";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lblScreen.Text.Contains("="))
                return;
            lblScreen.Text += txbScreen.Text;
            Getmath();
            lblScreen.Text += "=";
            
           // txbScreen.Text = "";



        }


        private decimal result = 0;

        void Getmath()
        {
            Calculation cal = new Calculation(lblScreen.Text);
            cal.ChangeExp();
            txbScreen.Text =  cal.Domath();
        }
        void makeClear()
        {
            txbScreen.Text = "";
            lblScreen.Text = "";
            result = 0;
        }

        private void mtsExit_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void mtsNew_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
          
            newform.Show();
        }

        private void mtsAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator version 1.0 !\nRelease on March 11, 2020\nAuthor: ttxuan0595@gmail.com","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
          
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txbScreen.Text !="")
            {
                txbScreen.Text = txbScreen.Text.Remove(txbScreen.Text.Length - 1);
            }
        }
    }
}
