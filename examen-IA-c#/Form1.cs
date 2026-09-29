using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_IA_c_
{
    public partial class form1 : Form
    {
        Dictionary<string, double> productos = new Dictionary<string, double>();
        public form1()
        {
            InitializeComponent();
            
            productos.Add("Laptop", 15000);
            productos.Add("Mouse Gamer", 500);
            productos.Add("Teclado Mecánico", 1200);
            productos.Add("Monitor", 4000);
            productos.Add("Audífonos", 800);

            cmbProducto.Items.AddRange(productos.Keys.ToArray());

            txtIVA.ReadOnly = true;
            txtTotal.ReadOnly = true;

            this.Text = "Punto de Venta Tecnología";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            double precio = productos[cmbProducto.Text];
            int cantidad = (int)nudCantidad.Value;

            double subtotal = precio * cantidad;
            double iva = subtotal * 0.16;
            double total = subtotal + iva;

            txtIVA.Text = iva.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

            dgvVentas.Rows.Add(
                txtFolio.Text,
                dtpFecha.Value.ToShortDateString(),
                txtUsuario.Text,
                txtCliente.Text,
                cmbProducto.Text,
                cantidad,
                iva,
                total
            );

            GuardarVentaTXT();
            string nombreArchivo = @"C:\Users\diazc\Documents\trabajosc#\Venta_" + txtFolio.Text + ".txt";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtFolio.Clear();
            txtUsuario.Clear();
            txtCliente.Clear();
            txtIVA.Clear();
            txtTotal.Clear();

            cmbProducto.SelectedIndex = -1;
            nudCantidad.Value = 1;
            dtpFecha.Value = DateTime.Now;
        }

        private void GuardarVentaTXT()
        {
            string nombreArchivo = "Venta_" + txtFolio.Text + ".txt";

            StreamWriter sw = new StreamWriter(nombreArchivo);

            sw.WriteLine("Folio: " + txtFolio.Text);
            sw.WriteLine("Fecha: " + dtpFecha.Text);
            sw.WriteLine("Usuario: " + txtUsuario.Text);
            sw.WriteLine("Cliente: " + txtCliente.Text);
            sw.WriteLine("Producto: " + cmbProducto.Text);
            sw.WriteLine("Cantidad: " + nudCantidad.Value);
            sw.WriteLine("IVA: " + txtIVA.Text);
            sw.WriteLine("Total: " + txtTotal.Text);

            sw.Close();

            MessageBox.Show("Venta guardada correctamente");
        }
    }
}
