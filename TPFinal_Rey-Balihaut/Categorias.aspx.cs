using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPFinal_Rey_Balihaut
{
    public partial class Alta_Marca_Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ninguno.Visible = false;
        }

        protected void altaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                //if(rdbmarca.Checked)
                //{
                //    MarcaNegocio marca_negocio = new MarcaNegocio();
                //    _Marca marca = new _Marca();
                //    marca.DescripcionMarca = nombre.Text;
                //    marca_negocio.agregar(marca);
                //    ninguno.Visible = false;
                //}
                //else if(rdbcategoria.Checked)
                //{
                    CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                    _Categoria categoria = new _Categoria();
                    categoria.DescripcionCategoria = nombre.Text;
                    categoria_negocio.agregar(categoria);
                nombre.Text = "";
                //    ninguno.Visible = false;
                //}
                //else
                //{
                //    ninguno.Visible=true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}