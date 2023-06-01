using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class Form1 : Form
    {
        private Busqueda busquedaForm;
        private Insertar insertarForm;
        private Principal principalForm;

        public Form1()
        {
            InitializeComponent();
            principalForm = new Principal();
            principalForm.TopLevel = false;
            principalForm.FormBorderStyle = FormBorderStyle.None;
            principalForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(principalForm);
            principalForm.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (insertarForm == null)
            {
                insertarForm = new Insertar();
                insertarForm.FormClosed += (s, args) => insertarForm = null; // Para liberar la instancia después de cerrar el formulario
            }

            insertarForm.TopLevel = false;
            insertarForm.FormBorderStyle = FormBorderStyle.None;
            insertarForm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(insertarForm);
            insertarForm.Show();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (busquedaForm == null)
            {
                busquedaForm = new Busqueda();
                busquedaForm.FormClosed += (s, args) => busquedaForm = null; // Para liberar la instancia después de cerrar el formulario
            }

            busquedaForm.TopLevel = false;
            busquedaForm.FormBorderStyle = FormBorderStyle.None;
            busquedaForm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(busquedaForm);
            busquedaForm.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(principalForm);
            principalForm.Show();
        }
    }
}
