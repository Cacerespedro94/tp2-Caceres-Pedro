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
    public partial class Detalle : Form
    {
        private Articulo articulo = null;
        public Detalle()
        {
            InitializeComponent();
        }
        public Detalle(Articulo detalle)
        {
            InitializeComponent();
            this.articulo = detalle;
        }


        private void imagenDetalle_Click(object sender, EventArgs e)
        {

        }

        private void Detalle_Load(object sender, EventArgs e)
        {

            
               
                try
                {
                lblCategoria.Text = articulo.Categoria.Descripcion;
                lblCodigo.Text = articulo.Codigo;
                lblDesc.Text = articulo.Descripcion;
                lblMarca.Text = articulo.Marca.Descripcion;
                lblNombre1.Text = articulo.Nombre;
                lblNombre2.Text = articulo.Nombre;
                lblPrecio.Text = Convert.ToString(articulo.Precio);
               


                    imagenDetalle.Load(articulo.ImagenUrl);
                }
                catch (Exception)
                {
                    imagenDetalle.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRvDGOPaR23jFQweGZF5vEiGftj4fOqX4mdPnLcrRBZPCLPqM4W&usqp=CAU");
                }

            }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
    }

