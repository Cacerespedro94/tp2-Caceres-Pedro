using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
namespace CatalogoDigital
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 listar = new Form1();
                listar.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregar alta = new frmAgregar();
                alta.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmModifica Modificar = new frmModifica();
                Modificar.ShowDialog();
                Articulo mod;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                frmEliminar Modificar = new frmEliminar();
                Modificar.ShowDialog();
                Articulo mod;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
