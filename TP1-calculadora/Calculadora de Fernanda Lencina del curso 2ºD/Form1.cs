using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Calculadora_de_Fernanda_Lencina_del_curso_2ºC
{
    public partial class Form1 : Form
    {
        char binario = 'n';
        /// <summary>
        /// inicializa componentes del formulario
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// inicializa valores en cada conponente
        /// </summary>
        private void initParametros()
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperador.Text = "+";
            lblResultado.Text = " ";
        }
        /// <summary>
        /// carga valores iniciales de los componentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNumero1;
            initParametros();
            cmbOperador.Items.Clear();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
        }
        /// <summary>
        /// dialogResult provoca que se genere un messajeBox mensaje de error con datos string pasados como argumentos
        /// </summary>
        /// <param name="mensaje">mensaje del messajeBox</param>
        /// <param name="titulo">titulo del messajeBox</param>
        /// <returns> messajeBox.show completo con icono y boton</returns>
        private DialogResult MensajeError(string mensaje, string titulo)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// lee los valores cargados en los textBox y el comboBox, y al presional el bobon operar realiza la operacion que corresponda 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora calculadora = new Calculadora();
            string operador = cmbOperador.Text;
            double rdo;
            int flag = 0;

            Numero n1 = new Numero(txtNumero1.Text);
            Numero n2 = new Numero(txtNumero2.Text);
            if (operador == "/")
            {
                if (txtNumero2.ToString() == "0")
                {
                    MensajeError("No es podible realizar division por cero", "Error");
                    lblResultado.Text = "Error";
                    flag = 1;
                }
            }
            rdo = calculadora.Operar(n1, n2, operador);

            if (flag == 0)
            {
                lblResultado.Text = rdo.ToString();
            }
        }

        /// <summary>
        /// al presionar el boton limpiar vuelve a cargar en formulario los valores iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            initParametros();
        }
        /// <summary>
        /// al presionar el boton cerrar cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// al presionar boton cerrar o la x de cerrado de windows, ejecuta pregunta de control y procede
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Consulta = new DialogResult();
            Consulta = MessageBox.Show("¿Desea salir de la Calculadora?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (Consulta != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// convierte numero leido del label1 en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertir_a_Binario_Click(object sender, EventArgs e)
        {
            btnOperar_Click(sender, e);
            string retValue;
            string numero = lblResultado.Text;
            if (int.TryParse(numero, out int result))
            {
                Numero numDecimal = new Numero(numero);
                retValue = numDecimal.DecimalBinario(numero);
                lblResultado.Text = retValue;
                binario = 's';

            }
            else
            {
                MensajeError("Solo es posible convertir numeros enteros", "Error");
                lblResultado.Text = "Error";
            }
        }

        /// <summary>
        /// convierte el numero leido en label1 a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertir_a_Decimal_Click(object sender, EventArgs e)
        {
            string retValue;
            string numero = lblResultado.Text;
            if (binario == 's')
            {
                Numero numDecimal = new Numero(numero);
                retValue = numDecimal.BinarioDecimal(numero);
                lblResultado.Text = retValue;
                binario = 'n';
            }
            else
            {
                MensajeError("Solo es posible convertir numeros binarios", "Error");
                lblResultado.Text = "Error";
            }
        }
    }
}
