using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inicio
{
    public partial class Insertar : Form
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private void Insertar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.Proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.proyectoDataSet.Proveedor);
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.Marcas' Puede moverla o quitarla según sea necesario.
            this.marcasTableAdapter.Fill(this.proyectoDataSet.Marcas);
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.Categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.proyectoDataSet.Categorias);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados de los ComboBox y el valor del TextBox
            int categoriaId = 0;
            int marcaId = 0;
            decimal precio = 0;
            int proveedorId = 0;

            if (comboBox1.SelectedItem != null)
            {
                DataRowView categoriaRow = comboBox1.SelectedItem as DataRowView;
                categoriaId = Convert.ToInt32(categoriaRow["Id"]);
            }

            if (comboBox2.SelectedItem != null)
            {
                DataRowView marcaRow = comboBox2.SelectedItem as DataRowView;
                marcaId = Convert.ToInt32(marcaRow["Id"]);
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                precio = Convert.ToDecimal(textBox1.Text);
            }

            if (comboBox3.SelectedItem != null)
            {
                DataRowView proveedorRow = comboBox3.SelectedItem as DataRowView;
                proveedorId = Convert.ToInt32(proveedorRow["Id"]);
            }

            // Establecer la conexión con la base de datos
            string connectionString = "Data Source=DESKTOP-GRFUNC4\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear el comando SQL para la inserción
                    string query = "INSERT INTO Productos (id_categoria, id_marca, precio, id_prov) " +
                                   "VALUES (@categoriaId, @marcaId, @precio, @proveedorId)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Asignar los valores a los parámetros del comando
                    command.Parameters.AddWithValue("@categoriaId", categoriaId);
                    command.Parameters.AddWithValue("@marcaId", marcaId);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@proveedorId", proveedorId);

                    // Ejecutar el comando
                    command.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Registro exitoso.");

                    // Limpiar los campos después de la inserción
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    textBox1.Text = "";
                    comboBox3.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error en caso de fallo en la inserción
                    MessageBox.Show("Error al registrar el producto: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión
                    connection.Close();
                }
            }
        }
    }
}
