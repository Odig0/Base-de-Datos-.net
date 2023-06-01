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
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Limpiar el DataGridView cuando se modifica el texto del TextBox
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marca = textBox1.Text;
            // Establecer la consulta SQL
            string query = "SELECT DISTINCT p.Id, p.precio, c.nombre AS categoria, pr.nombre AS proveedor " +
                           "FROM Productos p " +
                           "JOIN Marcas m ON p.id_marca = m.Id " +
                           "JOIN Categorias c ON p.id_categoria = c.Id " +
                           "JOIN Proveedor pr ON p.id_prov = pr.Id " +
                           "WHERE m.nombre = @marca";
            
            // Establecer la conexión y el comando
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GRFUNC4\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True"))
            { 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@marca", marca);

                // Abrir la conexión
                conn.Open();

                // Ejecutar el comando y obtener los resultados
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Cerrar la conexión
                    conn.Close();

                    // Mostrar los resultados en el DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
