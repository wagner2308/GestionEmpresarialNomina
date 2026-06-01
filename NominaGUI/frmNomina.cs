using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NominaGUI.Clases; 

namespace NominaGUI
{
    public partial class frmNomina : Form
    {
        
        private List<Empleado> historialNominas = new List<Empleado>();

        public frmNomina()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
  
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            if (double.TryParse(txtSalario.Text, out double salarioBase) &&
                int.TryParse(txtHorasExtras.Text, out int horasExtras))
            {
            
                Empleado nuevoEmpleado = new Empleado
                {
                    Nombre = txtNombre.Text,
                    SalarioBase = salarioBase,
                    HorasExtras = horasExtras
                };

              
                nuevoEmpleado.CalcularPagos();

                historialNominas.Add(nuevoEmpleado);
                ActualizarTabla();

                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Ingrese valores numéricos válidos en salario y horas extras.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTabla()
        {
          
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = historialNominas;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtSalario.Clear();
            txtHorasExtras.Text = "0";
            txtNombre.Focus(); 
        }
    }
}