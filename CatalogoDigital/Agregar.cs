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
        ArticuloNegocio negocio = new ArticuloNegocio();
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

                    ValidarDatos();
                   

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

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCategoria.ForeColor = Color.Black;

        }

        private void cboCategoria_DropDown(object sender, EventArgs e)
        {
            cboCategoria.ForeColor = Color.Black;
            cboCategoria.Text = "";
        }
   
      private void ValidarDatos ()
        {

            bool b = false;

           
           
                if (txtBoxNombre.Text.Length == 0 || txtBoxNombre.Text == "¡Ingrese un nombre!")
                {
                    txtBoxNombre.Text = "¡Ingrese un nombre!";
                    txtBoxNombre.ForeColor = Color.White;
                    txtBoxNombre.BackColor = Color.Firebrick;

                     b = true;
                }


                if (txtBoxDescripcion.Text.Length == 0 || txtBoxDescripcion.Text == "¡Ingrese una descripcion!")
                {
                    txtBoxDescripcion.ForeColor = Color.White;
                    txtBoxDescripcion.Text = "¡Ingrese una descripcion!";
                    txtBoxDescripcion.BackColor = Color.Firebrick;
                     b = true;
                }


                if (txtBoxCodigo.Text.Length == 0 || txtBoxCodigo.Text == "¡Ingrese un codigo!")
                {
                    txtBoxCodigo.ForeColor = Color.White;
                    txtBoxCodigo.Text = "¡Ingrese un codigo!";
                    txtBoxCodigo.BackColor = Color.Firebrick;
                    b = true;
                }

                if (cboCategoria.Text.Length == 0 || cboCategoria.Text == "¡Seleccione una categoria!")
                {
                    cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                    cboCategoria.Text = "¡Seleccione una categoria!";

                    cboCategoria.ForeColor = Color.Firebrick;
                 b = true;
                }

                if (cboMarca.Text.Length == 0 || cboMarca.Text == "¡Seleccione una marca!")
                {
                cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cboMarca.Text = "¡Seleccione una marca!";
                    cboMarca.ForeColor = Color.Firebrick;
                b = true;
                }

            if(b==false)
            { 
            if (MessageBox.Show("¿Finalizar agregar?", "Alta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                negocio.Agregar(articulo);
                MessageBox.Show("Se ha cargado con exito");
                Dispose();

            }
            }



        }
        private void cboCategoria_DropDownClosed(object sender, EventArgs e)
        {
            cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void txtBoxNombre_TextChanged(object sender, EventArgs e)
        {
            txtBoxNombre.BackColor = Color.White;
        }

        private void txtBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtBoxDescripcion.BackColor = Color.White;
        }

        private void txtBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            txtBoxCodigo.BackColor = Color.White;
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMarca.ForeColor = Color.Black;
        }

        private void cboMarca_DropDown(object sender, EventArgs e)
        {
            cboMarca.ForeColor = Color.Black;
            cboMarca.Text = "";
        }

        private void cboMarca_DropDownClosed(object sender, EventArgs e)
        {
          cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void txtBoxNombre_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtBoxNombre.BackColor == Color.Firebrick)
            {
                txtBoxNombre.ForeColor = Color.Black;
                txtBoxNombre.Text = "";
                txtBoxNombre.BackColor = Color.White;

            }
        }

        private void txtBoxDescripcion_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBoxDescripcion.BackColor == Color.Firebrick)
            {
                txtBoxDescripcion.ForeColor = Color.Black;
                txtBoxDescripcion.Text = "";
                txtBoxDescripcion.BackColor = Color.White;

            }
        }

        private void txtBoxCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBoxCodigo.BackColor == Color.Firebrick)
            {
                txtBoxCodigo.ForeColor = Color.Black;
                txtBoxCodigo.Text = "";
                txtBoxCodigo.BackColor = Color.White;

            }
        }
    }
}
