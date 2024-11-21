using ParcialC_1V2_BA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParcialC_
{

    public partial class Form1 : Form
    {
        Productos ListaProd { get; set; } = new Productos();
       
        
        public Form1()
        {
            InitializeComponent();
            dgvStock.DataSource = ListaProd.StockDT;
            

        }
      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto Prod = new Producto();

                if (double.TryParse(txtPrecio.Text, out double valor1) &&
                    double.TryParse(txtCantidad.Text, out double valor2))
                {
                    double resultado = valor1 * valor2;
                    Prod.Agregar(comboBox1.Text, txtPrecio.Text, txtCantidad.Text, Convert.ToString(resultado));
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa números válidos en ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                if (Prod.Nombre == "Seleccione aquí..." || Prod.Precio == "" || Prod.Cantidad == "")
                {
                    MessageBox.Show("Error, debe ingresar los valores correspondientes", "ERROR");

                }
    
                else
                {

                    ListaProd.InsertarProducto(Prod);
                    LimpiarCampos();
                
            }
        }
        



        private void btnEliminar_Click(object sender, EventArgs e) {
            if (dgvStock.SelectedRows.Count > 0)
            {
                int indice = dgvStock.SelectedRows[0].Index;

                ListaProd.StockDT.Rows[indice].Delete(); 

                
                ListaProd.StockDT.AcceptChanges();
                ListaProd.StockDT.WriteXml("Productos.xml");
            }

        }

       
        private void btnVaciarCarrito_Click(object sender, EventArgs e) {

            ListaProd.StockDT.Clear();
            ListaProd.StockDT.WriteXml("Productos.xml");
        

        }
        private void LimpiarCampos()
        {
            comboBox1.Text = "Seleccione aquí...";
            txtCantidad.Clear();
            txtPrecio.Clear();
        }

        public void btnModificar_Click(object sender, EventArgs e)
        {
            Producto Prod = new Producto();
            if (dgvStock.SelectedRows.Count > 0)
            {


                if (double.TryParse(txtPrecio.Text, out double valor1) &&
                double.TryParse(txtCantidad.Text, out double valor2))
                {
                    double resultado = valor1 * valor2;
                    Prod.Agregar(comboBox1.Text, txtPrecio.Text, txtCantidad.Text, Convert.ToString(resultado));
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa números válidos en ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                int indice = dgvStock.SelectedRows[0].Index;
                
                if ( Prod.Precio == "" || Prod.Cantidad == "")
                {
                     MessageBox.Show("No ha ingresado valores nuevos", "Error");
                }
                else
                {
                    ListaProd.ModificarCarrito(Prod, indice);
                    dgvStock.Refresh();
                    LimpiarCampos();
                    ListaProd.StockDT.WriteXml("Productos.xml");
                }

            }
        }
    }

}
