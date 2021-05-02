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

namespace Catalogo
{
    public partial class Agregar : Form
    {

        private Articulo articulo = null;

        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Articulo artic)
        {
            InitializeComponent();
            articulo = artic;
        }

        private void btnCancelarAgregar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptarAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (articulo == null)

                    articulo = new Articulo();  //  si está vacio (porque no existe) lo crea. Sino, lo "recarga"

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.ImgURL = txtImagenUrl.Text;

                if (articulo.ID == 0)
                {
                    negocio.agregar(articulo);
                }
                else
                {
                    negocio.modificar(articulo);
                }

                MessageBox.Show("Operación realizada exitosamente", "Éxito");
                Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            cboMarca.DataSource = marca.listar();
            cboMarca.ValueMember = "ID";
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.SelectedIndex = -1;

            CategoriaNegocio negocio = new CategoriaNegocio();
            cboCategoria.DataSource = negocio.listar();
            cboCategoria.ValueMember = "ID";
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.SelectedIndex = -1;



            if (articulo != null)
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                cboMarca.SelectedValue = articulo.Marca.ID;
                cboCategoria.SelectedValue = articulo.Categoria.ID;
                Text = "Modificar artículo";
            }

        }
    }

}

