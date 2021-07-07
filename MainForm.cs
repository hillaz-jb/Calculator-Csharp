using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatriceXPS
{
    public partial class MainForm : Form
    {
        //Création d'une nouvelle instance de la classe CalculFunction
        CalculFunction CalculFct = new CalculFunction();
        double entry1, entry2, result;
        string number1, number2, operatorSign, spec;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void numbutton_Click(object sender, EventArgs e)
        {

            if (calculBox.Text == "" || "0123456789".Any(calculBox.Text.Contains) == true)
            {
                calculBox.Text += (sender as Button).Text;
            }
            else
            {
                calculBox.Text = (sender as Button).Text;
            }

            if (hystoryTextBox.Text != "")
            {
                hystoryTextBox.Text += (sender as Button).Text;
            }
            else
            {
                hystoryTextBox.Text = Environment.NewLine + (sender as Button).Text;
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            double storNum; //Variable to store value of number
            string lastCharCalc = calculBox.Text.Substring(calculBox.Text.Length - 1, 1);
            if (calculBox.Text.Length > 0 && "0123456789".Any(lastCharCalc.Contains) == true) //If there is a number...  
            {
                storNum = double.Parse(calculBox.Text); //Store its value  
                storNum *= -1; //multiply by negative 1  
                calculBox.Text = storNum.ToString(); //put it in the textbox.
                hystoryTextBox.Text = calculBox.Text;
            }

            //Utiliser la touche signe pour inverser les opérateurs + et -
            else if (calculBox.Text == "-")
            {
                operatorSign = "+";
                calculBox.Text = operatorSign;
                hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.Length - 1, 1);
                hystoryTextBox.Text += "+";
            }
            else if (calculBox.Text == "+")
            {
                operatorSign = "-";
                calculBox.Text = operatorSign;
                hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.Length - 1, 1);
                hystoryTextBox.Text += "-";
            }
            else
            {
                hystoryTextBox.Text += "";
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (calculBox.Text.Contains(",") == false)
            {
                calculBox.Text += ",";
                hystoryTextBox.Text += ",";
            }
            else
            {
                calculBox.Text += "";
                hystoryTextBox.Text += "";
            }
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            if (hystoryTextBox.Text == "")
            {
                MessageBox.Show("entrez un nombre !");
                calculBox.Text = "";
                hystoryTextBox.Text = "";

            }
            else
            {
                string lastChar = hystoryTextBox.Text.Substring(hystoryTextBox.Text.Length - 1, 1);

                //Changement d'opérateur si opérateur déjà défini
                if ("+-x/".Any(lastChar.Contains) == true && hystoryTextBox.Text != "")
                {

                    calculBox.Text = (sender as Button).Text;
                    hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.Length - 1, 1);
                    operatorSign = (sender as Button).Text;
                    hystoryTextBox.Text += (sender as Button).Text;
                }
                else if (hystoryTextBox.Text != "")
                {

                    if (calculBox.Text == "" && "0123456789".Any(lastChar.Contains) == false)
                    {
                        entry1 = result;
                        calculBox.Text = (sender as Button).Text;
                        hystoryTextBox.Text += (Convert.ToString(result)) + (sender as Button).Text;
                        operatorSign = (sender as Button).Text;
                    }

                    else if (!double.TryParse(calculBox.Text, out entry1) && operatorSign != "")
                    {
                        MessageBox.Show("Entrez un nombre !");
                        calculBox.Clear();
                    }

                    else
                    {
                        calculBox.Text = (sender as Button).Text;
                        hystoryTextBox.Text += (sender as Button).Text;
                        operatorSign = (sender as Button).Text;

                    }
                }
            }
        }



        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (hystoryTextBox.Text != "")
            {
                string lastChar = hystoryTextBox.Text.Substring(hystoryTextBox.Text.Length - 1, 1);
                if (calculBox.Text != "" && "-+x/".Any(lastChar.Contains) == false) //empêche erreur si textBox est vide
                {
                    calculBox.Text = calculBox.Text.Remove(calculBox.Text.Length - 1);
                    //supprimer dernier caractère de la chaîne entryBox.Text
                    hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.Length - 1);
                }
            }

            else
            {
                calculBox.Text += "";
                hystoryTextBox.Text += "";
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            calculBox.Clear();
            hystoryTextBox.Clear();
            result = 0;
            entry1 = 0;
            entry2 = 0;
        }

        private void buttonSpecial_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(calculBox.Text, out entry1) || hystoryTextBox.Text == "")
            {
                MessageBox.Show("Entrez un nombre !");
                calculBox.Clear();
            }
            else
            {
                number1 = Convert.ToString(entry1);
                result = CalculFct.OperationSpecial(number1, (sender as Button).Text);
                calculBox.Clear();


                if ((sender as Button).Text == "x^2")
                {
                    //hystoryTextBox = supprimer la dernière ligne de l'historique + nouvelle ligne + nombre1 + ^2 = result + nouvelle ligne
                    hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.LastIndexOf(Environment.NewLine)) + Environment.NewLine + number1 + "^2 = " + result + Environment.NewLine;
                }
                else
                {
                    hystoryTextBox.Text = hystoryTextBox.Text.Remove(hystoryTextBox.Text.LastIndexOf(Environment.NewLine)) + Environment.NewLine + (sender as Button).Text + "(" + number1 + ")=" + result + Environment.NewLine;
                    spec = hystoryTextBox.Text;
                }
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {

            if (hystoryTextBox.Text == "")
            {
                MessageBox.Show("Entrez un nombre !");
                calculBox.Text = "";
            }

            else
            {
                string lastLine = hystoryTextBox.Lines.Last();

                //répétition touche égal
                if (calculBox.Text == "")
                {
                    number1 = Convert.ToString(result);
                    number2 = Convert.ToString(entry2);
                    result = CalculFct.OperationStandard(number1, operatorSign, number2);
                    hystoryTextBox.Text += number1 + operatorSign + number2 + "=" + (Convert.ToString(result)) + Environment.NewLine;
                }

                //vérification si deuxième opérande
                else if (!double.TryParse(calculBox.Text, out entry2))
                {
                    MessageBox.Show("Entrez un nombre !");
                    calculBox.Text = operatorSign;
                }

                else
                {
                    number1 = Convert.ToString(entry1);
                    number2 = Convert.ToString(entry2);
                    result = CalculFct.OperationStandard(number1, operatorSign, number2);
                    hystoryTextBox.Text += "=" + (Convert.ToString(result)) + Environment.NewLine;
                    calculBox.Text = "";
                    entry1 = result;
                }

            }
        }
            
    }
}
