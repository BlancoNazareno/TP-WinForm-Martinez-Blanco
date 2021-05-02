using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data.SqlTypes;
        

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();

            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, M.Descripcion Marca, C.Descripcion Categoria From ARTICULOS A join CATEGORIAS C on A.IdCategoria = C.Id join MARCAS M on A.IdMarca = M.Id";
            comando.Connection = conexion;

            try
            {
                conexion.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Articulo aux = new Articulo();

                aux.ID = (int)lector["Id"];
                aux.Codigo = (string)lector["Codigo"];
                //aux.Codigo = lector.GetString(2);
                aux.Nombre = (string)lector["Nombre"];
                //aux.Nombre = lector.GetString(3);
                aux.Descripcion = (string)lector["Descripcion"];
                //aux.Descripcion = lector.GetString(4);
                aux.ImgURL = (string)lector["ImagenUrl"];
                //aux.Precio = (int)lector["Precio"];
                aux.Precio = lector.GetSqlMoney(5);
                //aux.Precio = (string)lector["Precio"];


                aux.Categoria = new Categoria();
                aux.Categoria.Descripcion = (string)lector["Categoria"];
                aux.Categoria.ID = (int)lector["ID"];

                aux.Marca = new Marca();
                aux.Marca.Descripcion = (string)lector["Marca"];
                aux.Marca.ID = (int)lector["ID"];

                lista.Add(aux);
            }

            conexion.Close();

            return lista;


            }

            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                conexion.Close();
            }
        }

    }
}
