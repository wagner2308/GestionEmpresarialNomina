using System;

namespace NominaGUI.Clases
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public double SalarioBase { get; set; }
        public int HorasExtras { get; set; }

     
        public double PagoExtras { get; private set; }
        public double DescuentoIESS { get; private set; }
        public double SalarioNeto { get; private set; }

        public void CalcularPagos()
        {
            
            double valorHoraNormal = SalarioBase / 240;
            PagoExtras = Math.Round(valorHoraNormal * 1.5 * HorasExtras, 2);

           
            double totalIngresos = SalarioBase + PagoExtras;
            DescuentoIESS = Math.Round(totalIngresos * 0.0945, 2);

      
            SalarioNeto = Math.Round(totalIngresos - DescuentoIESS, 2);
        }
    }
}