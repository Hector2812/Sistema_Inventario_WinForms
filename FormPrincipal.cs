using SistemaInventarioWinForms.Clases;
using SistemaInventarioWinForms.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SistemaInventarioWinForms
{
    public partial class FormPrincipal : Form
    {
        private Inventario inventario = new Inventario();

        public FormPrincipal()
        {
            InitializeComponent();
            inventario.CargarDesdeJson("inventario.json");  
            ActualizarGrid();                               
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock inválido.");
                return;
            }

            var producto = new ProductoSimple(txtNombre.Text, precio, stock, txtCategoria.Text);
            inventario.AgregarProducto(producto);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var nombre = dgvProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                inventario.EliminarProducto(nombre);
                ActualizarGrid();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            inventario.GuardarEnJson("inventario.json");
            MessageBox.Show("Inventario guardado correctamente.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            try
            {
                var producto = inventario.BuscarProducto(nombre);
                MessageBox.Show($"Encontrado: {producto.Nombre} - {producto.Categoria} - S/. {producto.Precio} - Stock: {producto.Stock}");
            }
            catch (ProductoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Guardar como Excel"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Exportador.ExportarAExcel(inventario.ObtenerProductos(), sfd.FileName);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Guardar como PDF"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Exportador.ExportarAPDF(inventario.ObtenerProductos(), sfd.FileName);
            }
        }

        private void ActualizarGrid()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = inventario.ObtenerProductos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
    }
}
