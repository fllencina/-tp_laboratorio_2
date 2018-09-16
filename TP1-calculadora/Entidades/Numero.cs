using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero


    {


        private double numero;
        //constructores
        /// <summary>
        /// consutructos no recibe parametros, inicializa atributo en cero;
        /// </summary>
        public Numero()
        {
            SetNumero = "0";
        }
        /// <summary>
        /// constructor recibe un parametro, inicializa con el valor del argumento double recibido
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {

            SetNumero = numero.ToString();

        }
        /// <summary>
        /// constructor recibe un parametro, inicializa con el valor del argumento string recibido,lo convierte a string para usar el anterior constructor
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero) 
        {
            SetNumero = strNumero;
        }
        /// <summary>
        /// setter, ingresa en el atributo privado el valor validado
        /// </summary>
        private string SetNumero
        {
            set
            {
                if (Numero.ValidarNumero(value) != 0)
                {
                    this.numero = Convert.ToDouble(value);
                }
            }
        }
        //conversiones Agregar validaciones
        /// <summary>
        /// convierte un string de  numero entero positivo que es un binario a decimal
        /// </summary>
        /// <param name="binario">string de numero binario a convertir</param>
        /// <returns>string Decimal resultado de la conversion del numero binario</returns>
        public string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();

            // Invertido pues los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(array);
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Usamos la potencia de 2, según la posición
                    sum += (int)Math.Pow(2, i);
                    continue;
                }
                if (array[i] != '0')
                {
                    return "Valor Invalido";
                }
            }

            return sum.ToString();
        }
        /// <summary>
        /// convierte un string de numero entero positivo que es un decimal a binario
        /// </summary>
        /// <param name="numero"> string decimal a convertir a binario</param>
        /// <returns>string binario resulado de la conversion</returns>
        public string DecimalBinario(string numero)//probar
        {
            if (int.TryParse(numero, out int numInt))
            {
                if (numInt > 0)
                {
                    String cadena = "";
                    while (numInt > 0)
                    {
                        if (numInt % 2 == 0)
                        {
                            cadena = "0" + cadena;
                        }
                        else
                        {
                            cadena = "1" + cadena;
                        }
                        numInt = (numInt / 2);
                    }
                    return cadena;
                }
                else
                {
                    if (numInt == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
            else
            {
                return "Valor Invalido";
            }
        }
        /// <summary>
        /// convierte un numero entero positivo que es un binario a decimal 
        /// </summary>
        /// <param name="numero">double numero a convertir a binario</param>
        /// <returns>string binario resultado de la conversion</returns>
        public string DecimalBinario(double numero)
        {
            if (numero > 0)
            {
                String cadena = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (numero / 2);
                }
                return cadena;
            }
            else
            {
                if (numero == 0)
                {
                    return "0";
                }
                else
                {
                    return "Valor Invalido.";
                }
            }
        }

        /// <summary>
        /// el metodo valida que el string que recibe como parametro sea un numero y convierte el punto en coma
        /// </summary>
        /// <param name="strNumero"> string recibido argumento y lo convierte en numero double</param>
        /// <returns>retorna la conversion del string en double o cero si no se puede convertir </returns>
        private static double ValidarNumero(string strNumero)
        {
            strNumero.Replace(".", ",");
            if (double.TryParse(strNumero, out double auxiliar))
            {
                return auxiliar;
            }
            else
            {
                return 0;
            }
        }
        //sobrecargas

        /// <summary>
        /// realiza la resta entre dos numeros recibidos como parametro
        /// </summary>
        /// <param name="n1">primero parametro Numero </param>
        /// <param name="n2">segundo parametro Numero </param>
        /// <returns>retorna un double resultado de la resta</returns> 
        public static double operator -(Numero n1, Numero n2)
        {
            double retValue = 0;
            retValue = n1.numero - n2.numero;
            return retValue;
        }

        /// <summary>
        /// realiza la suma entre dos numeros recibidos como parametro
        /// </summary>
        /// <param name="n1">primero parametro Numero </param>
        /// <param name="n2">segundo parametro Numero </param>
        /// <returns>retorna un double resultado de la suma</returns> 
        public static double operator +(Numero n1, Numero n2)
        {
            double retValue = 0;
            retValue = n1.numero + n2.numero;
            return retValue;
        }

        /// <summary>
        /// realiza la multiplicacion entre dos numeros recibidos como parametro
        /// </summary>
        /// <param name="n1">primero parametro Numero </param>
        /// <param name="n2">segundo parametro Numero </param>
        /// <returns>retorna un double resultado de la multiplicacion</returns> 
        public static double operator *(Numero n1, Numero n2)
        {
            double retValue;
            retValue = n1.numero * n2.numero;
            return retValue;
        }

        /// <summary>
        /// realiza la division entre dos numeros recibidos como parametro
        /// </summary>
        /// <param name="n1">primero parametro Numero </param>
        /// <param name="n2">segundo parametro Numero </param>
        /// <returns>retorna un double resultado de la division</returns> 
        public static double operator /(Numero n1, Numero n2)
        {
            double retValue = 0;
            retValue = n1.numero / n2.numero;
            return retValue;
        }
    }
}
