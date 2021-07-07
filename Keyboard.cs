using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatriceXPS
{
    partial class MainForm : Form
    {
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button buttonpress = new Button();

            //convertir touche en texte sauf pour "*" converti en "x"
            if (e.KeyChar == (char)42)
            {

                buttonpress.Text = "x";
            }
            else
            {
                buttonpress.Text = e.KeyChar.ToString();
            }

            //codes ASCII des chiffres de 0 à 9 : de 48 à 57 (cf table ASCII)
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                // Simuler un click sur un bouton chiffre
                numbutton_Click(buttonpress, e);
                e.Handled = true;
            }

            switch (e.KeyChar)
            {
                case (char)43:
                    buttonOperator_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)45:
                    buttonOperator_Click(buttonpress, e);
                    e.Handled = true;

                    break;

                case (char)42:
                    buttonOperator_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)47:
                    buttonOperator_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)44:
                    buttonDot_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)46:
                    buttonDot_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)61:
                    buttonEqual_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                case (char)13:
                    buttonEqual_Click(buttonpress, e);
                    //char textbutton = (char)61;
                    //buttonpress.Text = textbutton.ToString(); ;
                    e.Handled = true;
                    break;

                /*//Touche "S" pour inversion de signe (-/+)
                case (char)83:
                    buttonSign_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                //Touche "s" pour inversion de signe (-/+)
                case (char)115:
                    buttonSign_Click(buttonpress, e);
                    e.Handled = true;
                    break;*/


                //Touche "r" permet de reset la calculatrice
                case (char)114:
                    buttonReset_Click(buttonpress, e);
                    e.Handled = true;
                    break;

                //Touche "R" permet de reset la calculatrice
                case (char)82:
                    buttonReset_Click(buttonpress, e);
                    e.Handled = true;
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Button buttonDown = new Button();

            switch (e.KeyCode)
            {
                case Keys.Back:
                    buttonCE_Click(buttonDown, e);
                    e.Handled = true;
                    break;

                case Keys.Delete:
                    buttonReset_Click(buttonDown, e);
                    e.Handled = true;
                    break;
            }
        }
    }
}
