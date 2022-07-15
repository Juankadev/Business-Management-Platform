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
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else if (Session["tipo"].ToString() != "ADMIN")
                {
                    Response.Redirect("Default.aspx", false);
                }


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
                    else
                    {
                        btn_eliminar.Enabled = false;
                        btn_eliminar.CssClass = "btn btn-danger btn-lg btnlogin";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_alta_Click(object sender, EventArgs e)
        {
            try
            {
                if (nombre.Text != "")
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
                    Response.Redirect("ListadoMarcas.aspx");
                }


                else
                {
                    //codigo.BackColor = System.Drawing.Color.IndianRed;
                    nombre.CssClass = "form-control is-invalid";
                }
            }

            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                if (Request.QueryString["id"] != null)
                {
                    int codigoURL = int.Parse(Request.QueryString["id"].ToString());
                    marca_negocio.eliminar(codigoURL);
                    Response.Redirect("ListadoMarcas.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}


