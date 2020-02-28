using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**********************************\
*            2/20/2020             *
*                                  *
*        Andrew Terwilliger        *
*         Group 4 Lab with:        *
*          Jordan Hughes           *
*          Isse, Mohamud           *
*           Omar Mohamud           *
*        Minneapolis College       *
*    ITEC 2505-60 C# Programming   *
*                                  *
\**********************************/

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Calculate button Method.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Non-Null assignment of tip variable.
            double tip;

            /*
             * Here we're sending out each provided string to their respective validation method to
             * return a valid form, such as the total bill as a double - and the number of Guests as an int.
             */
            if (!ValidateString(txtName.Text, out string name, out string textError))
            {
                MessageBox.Show(textError, "Restaraunt Name Error");
                txtName.Focus();
                return;
            }
            if (!ValidateDouble(txtBill.Text, out double SubTotal, out string subError))
            {
                MessageBox.Show(subError, "Bill Total Error");
                txtBill.Focus();
                return;
            }
            if (!ValidateInt(txtGuests.Text, out int Guests, out string intError))
            {
                MessageBox.Show(subError, "Number of Guests Error");
                txtGuests.Focus();
                return;
            }
            if (!ValidatePercent(txtTipPercent.Text, out double tipPercent, out string tipError))
            {
                MessageBox.Show(subError, "Tip Percent Error");
                txtTipPercent.Focus();
                return;
            }

            // Assignment of the total with no tip for each Guest.
            double totalNoTip = SubTotal / Guests;
            txtSubtotal.Text = totalNoTip.ToString("c");

            // Quick assignment of tip before rounding.
            double subTip = SubTotal * tipPercent;

            // Checking if the tip should be rounded up.
            if (chkRound.Checked)
            {
                tip = Math.Ceiling(subTip);
            } else { tip = subTip; }
            
            // Assignment of the Tip textbox.
            txtTip.Text = tip.ToString("c");

            // Assignment of the Total with tip for each Guest.
            double total = (SubTotal + tip) / Guests;
            txtTotal.Text = total.ToString("c");

            // Assignment of Meal Total.
            txtFinal.Text = (SubTotal + tip).ToString("c");
        }

        // Input Validation, ValidateX refering to what we're validating for. i.e. ValidateString
        private bool ValidateString(string text, out string name, out string textErrorMsg)
        {
            textErrorMsg = null;
            name = text;
            if (String.IsNullOrEmpty(text))
            {
                textErrorMsg = "Please enter valid Restaraunt Name.";
                return false;
            }
            return true;
        }
        private bool ValidateDouble(string subTotal, out double SubTotal, out string subErrorMsg)
        {
            subErrorMsg = null;
            SubTotal = 0;
            try
            {
                SubTotal = Double.Parse(subTotal);
                if (SubTotal >= 0)
                {
                    return true;
                }
                else
                {
                    subErrorMsg = "Enter a positive Number";
                    return false;
                }
            }
            catch (FormatException)
            {
                subErrorMsg = "Enter numbers only.";
                return false;
            }
            catch (OverflowException)
            {
                subErrorMsg = "Enter a smaller number.";
                return false;
            }
        }
        private bool ValidateInt(string guests, out int Guests, out string intErrorMsg)
        {
            intErrorMsg = null;
            Guests = 0;
            try
            {
                Guests = int.Parse(guests);
                if (Guests >= 0)
                {
                    return true;
                }
                else
                {
                    intErrorMsg = "Enter a positive Number";
                    return false;
                }
            }
            catch (FormatException)
            {
                intErrorMsg = "Enter numbers only.";
                return false;
            }
            catch (OverflowException)
            {
                intErrorMsg = "Enter a smaller number.";
                return false;
            }
        }
        private bool ValidatePercent(string tip, out double tipPercent, out string tipErrorMsg)
        {
            tipErrorMsg = null;
            tipPercent = 0;
            try
            {
                tipPercent = Double.Parse(tip);
                if (tipPercent >= 1 && tipPercent <= 100)
                {
                    tipPercent = tipPercent / 100;
                    return true;
                } else if (tipPercent < 1 && tipPercent >= 0)
                {
                    return true;
                }
                else
                {
                    tipErrorMsg = "Enter a positive Number";
                    return false;
                }
            }
            catch (FormatException)
            {
                tipErrorMsg = "Enter numbers only.";
                return false;
            }
            catch (OverflowException)
            {
                tipErrorMsg = "Enter a smaller number.";
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
