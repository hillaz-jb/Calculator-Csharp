using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceXPS
{
    public class CalculFunction
    {
        /// <summary>
        /// Cette fonction sert à exécuter des opérations
        /// </summary>
        /// <param name="number1">Valeur numéro 1</param>
        /// <param name="number2">Valeur numéro 2</param>
        /// <param name="operation">Signe de l'opération</param>
        /// <returns>Résult de l'opération</returns>

        #region Définition du calcul pour les opérations standards

        public double OperationStandard(string number1, string operatorSign, string number2)
        {
            double result;
            switch (operatorSign)

            {
                case "+":
                    result = Convert.ToDouble(number1) + Convert.ToDouble(number2);
                    return result;

                case "-":
                    result = Convert.ToDouble(number1) - Convert.ToDouble(number2);
                    return result;

                case "x":
                    result = Convert.ToDouble(number1) * Convert.ToDouble(number2);
                    return result;

                case "*":
                    result = Convert.ToDouble(number1) * Convert.ToDouble(number2);
                    return result;

                case "/":
                    if (number2 != "0")
                    {
                        result = Convert.ToDouble(number1) / Convert.ToDouble(number2);
                        return result;
                    }
                    else
                    {
                        return double.NaN;
                    }

                case "^":
                    result = System.Math.Pow(Convert.ToDouble(number1), Convert.ToDouble(number2));
                    return result;

                default:
                    return double.NaN;
            }
        }
        #endregion

        public double OperationSpecial(string number, string functionMath)
        {
            double angleRad = Convert.ToDouble(number) * Math.PI / 180;
            double resultSpecial;


            switch (functionMath)
            {
                case "sin":
                    resultSpecial = System.Math.Sin(angleRad);
                    return resultSpecial;

                case "cos":
                    resultSpecial = System.Math.Cos(angleRad);
                    return resultSpecial;

                case "tan":
                    resultSpecial = System.Math.Tan(angleRad);
                    return resultSpecial;

                case "√":
                    resultSpecial = System.Math.Sqrt(Convert.ToDouble(number));
                    return resultSpecial;

                case "x^2":
                    resultSpecial = System.Math.Pow(Convert.ToDouble(number), 2);
                    return resultSpecial;


                default:
                    return double.NaN;
            }

        }
    }
}