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
    public partial class frmAgregar : Form
    {
        private Articulo articulo = null;
        frmModifica modifica = new frmModifica();
        public frmAgregar()
        {
            InitializeComponent();
        }
        public frmAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            MarcaNegocio mar = new MarcaNegocio();
            CategoriaNegocio cat = new CategoriaNegocio();
     
           
            try
            {

                cboMarca.DataSource = mar.ListarMarca();

                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = cat.ListarCategoria();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.SelectedIndex = -1;
                cboMarca.SelectedIndex = -1;


                if (articulo != null)
                {
                    txtBoxNombre.Text = articulo.Nombre;
                    txtBoxDescripcion.Text = articulo.Descripcion;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    txtBoxCodigo.Text = articulo.Codigo;
                    txtBoxImagen.Text = articulo.ImagenUrl;
                    txtBoxPrecio.Text = Convert.ToString(articulo.Precio);
                    lblTitulo.Text = "Modificar Articulo";
            



                }
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
                if (articulo == null)
                    articulo = new Articulo();
                articulo.Descripcion = txtBoxDescripcion.Text.Trim();
                articulo.Codigo = txtBoxCodigo.Text.Trim();
                 articulo.Marca = (Marca)cboMarca.SelectedItem; 
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(txtBoxPrecio.Text.Trim());
                articulo.Nombre = txtBoxNombre.Text.Trim();
                articulo.ImagenUrl = txtBoxImagen.Text.Trim();

                if (articulo.Id != 0)
                {
                    if (MessageBox.Show("¿Moidificar articulo?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        negocio.modificar(articulo);
                        MessageBox.Show("Se ha modificado con exito");
                        Dispose();
                    }
                }
                else
                { 
                     if(MessageBox.Show("¿Finalizar agregar?", "Alta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                     {
                        negocio.Agregar(articulo);
                        MessageBox.Show("Se ha cargado con exito");
                        Dispose();
        
                     }

                }

            }   
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
