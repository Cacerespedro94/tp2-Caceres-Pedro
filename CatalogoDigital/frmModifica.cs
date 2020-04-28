using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace CatalogoDigital
{
    public partial class frmModifica : Form
    {
        private List<Articulo> lista;
        public frmModifica()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                lista = negocio.listar2();
                dgvModificar.DataSource = negocio.listar2();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo modificar;
            modificar = (Articulo)dgvModificar.CurrentRow.DataBoundItem;
            frmAgregar frmAgregar = new frmAgregar(modificar);
            frmAgregar.ShowDialog();
            cargarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmModifica_Load(object sender, EventArgs e)
        {
            try
            {

                cargarDatos();
              
                dgvModificar.Columns[0].Visible = false;
                dgvModificar.Columns[3].Visible = false;
                dgvModificar.Columns[5].Visible = false;
                dgvModificar.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            try
            {
                if (txtFiltro.Text == "")
                {
                    listaFiltrada = lista;
                }
                else
                {
                    listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) ||
                      k.Marca.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower()) ||
                      k.Categoria.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower()) ||
                      k.Codigo.ToLower().Contains(txtFiltro.Text.ToLower()));

                }
                dgvModificar.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvModificar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvModificar.CurrentRow.DataBoundItem;
                try
                {
                    imgLista.Load(art.ImagenUrl);
                }
                catch (Exception)
                {
                    imgLista.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRvDGOPaR23jFQweGZF5vEiGftj4fOqX4mdPnLcrRBZPCLPqM4W&usqp=CAU");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Articulo modificar;
              modificar = (Articulo)dgvModificar.CurrentRow.DataBoundItem;

               
                    modificar = (Articulo)dgvModificar.CurrentRow.DataBoundItem;
                    //Crear objeto del formulario de detalle
                    Detalle de = new Detalle(modificar);

                    de.ShowDialog();
                    cargarDatos();
             }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
