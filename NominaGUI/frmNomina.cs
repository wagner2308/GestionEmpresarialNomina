using System;
using System.Windows.Forms;

namespace NominaGUI
{
    public partial class frmNomina : Form
    {
        public frmNomina()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Especificación SDD: Cálculo de IESS al 9.45%
            if (double.TryParse(txtSalario.Text, out double salarioBase))
            {
                double descuento = salarioBase * 0.0945;
                double salarioNeto = salarioBase - descuento;

                lblDescuento.Text = $"Descuento IESS: $ {descuento:0.00}";
                lblNeto.Text = $"Neto a Recibir: $ {salarioNeto:0.00}";
            }
            else
            {
                MessageBox.Show("Ingrese un monto válido.");
            }
        }
    }
}