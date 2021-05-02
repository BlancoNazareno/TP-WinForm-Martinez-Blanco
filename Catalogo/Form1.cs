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
    public partial class Form1 : Form
    {
        private List<Articulo> listaOriginal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaOriginal = negocio.listar();
            dgvLista.DataSource = listaOriginal;
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[4].Visible = false;
            dgvLista.Columns[5].Visible = false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                pbArticulo.Load(articulo.ImgURL);
            }
            catch (Exception)
            {

            }

        }
    }
}
