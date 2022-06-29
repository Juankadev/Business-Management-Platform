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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_alta.Text = "Agregar";

                if (Request.QueryString["id"] != null)
                {
                    int codigoURL = int.Parse(Request.QueryString["id"].ToString());
                    btn_alta.Text = "Modificar";

                    MarcaNegocio negocio = new MarcaNegocio();
                    List<_Marca> lista = negocio.listar();
                    _Marca aux = lista.Find(x => x.IDMarca == codigoURL);

                    nombre.Text = aux.DescripcionMarca;
                }
            }
        }

        protected void btn_alta_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                _Marca aux = new _Marca();
                aux.DescripcionMarca = nombre.Text;

                if (Request.QueryString["id"] != null) //se esta modificando un prod.
                {
                    aux.IDMarca = int.Parse(Request.QueryString["id"]);
                    marca_negocio.modificar(aux);
                }
                else //se esta agregando una marca
                {
                    marca_negocio.agregar(aux);
                    nombre.Text = "";
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marca_negocio = new MarcaNegocio();
            if (Request.QueryString["id"] != null)
            {
                int codigoURL = int.Parse(Request.QueryString["id"].ToString());
                marca_negocio.eliminar(codigoURL);
                Response.Redirect("ListadoMarcas.aspx");
            }
        }
    }
}


