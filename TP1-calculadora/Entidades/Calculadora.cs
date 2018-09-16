using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// valida que el operador ingresado sea +,-,*,/
        /// </summary>
        /// <param name="operador">recibe un string como argumento, es el que valida que pertenezca al grupo de los caracteres correctos </param>
        /// <returns>string operador valido</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }
        /// <summary>
        /// recibe los operandos y el operador como argumentos
        /// </summary>
        /// <param name="num1">primer parametro Numero</param>
        /// <param name="num2">segundo parametro Numero</param>
        /// <param name="operador"> string operador</param>
        /// <returns> retorna un double-resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            string auxiliar;
            double retorno = 0;
            auxiliar = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    retorno = (num1 + num2);
                    break;
                case "-":
                    retorno = (num1 - num2);
                    break;
                case "*":
                    retorno = (num1 * num2);
                    break;
                case "/":
                    retorno = (num1 / num2);
                    break;
            }
            return retorno;
        }
    }
}
