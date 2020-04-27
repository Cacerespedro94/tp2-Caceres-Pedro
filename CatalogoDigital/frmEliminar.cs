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
    public partial class frmEliminar : Form
    {
        
        public frmEliminar()
        {
            InitializeComponent();
        }
        private List<Articulo> lista;
        private void cargarDatos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                lista = negocio.listar2();
                dgvEliminar.DataSource = negocio.listar2();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmEliminar_Load(object sender, EventArgs e)


        {
            try
            { 
            cargarDatos();
            dgvEliminar.Columns[0].Visible = false;
            dgvEliminar.Columns[3].Visible = false;
            dgvEliminar.Columns[5].Visible = false;
            dgvEliminar.Columns[6].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = ((Articulo)dgvEliminar.CurrentRow.DataBoundItem).Id;
                    negocio.eliminar(id);
                    cargarDatos();
                    MessageBox.Show("Se ha eliminado correctamente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvEliminar.CurrentRow.DataBoundItem;
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
                dgvEliminar.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Articulo eliminar;
                eliminar = (Articulo)dgvEliminar.CurrentRow.DataBoundItem;

                
                //Crear objeto del formulario de detalle
                Detalle de = new Detalle(eliminar);

                de.ShowDialog();
                cargarDatos();
                
                
                
     
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void imgLista_Click(object sender, EventArgs e)
        {

        }
    }
    
}
