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
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    string codigoURL = Request.QueryString["id"].ToString();
                    btn_alta.Text = "Modificar";

                    ProveedorNegocio negocio = new ProveedorNegocio();
                    List<_Proveedor2> lista = negocio.listar();
                    _Proveedor2 aux = lista.Find(x => x.CUIT == codigoURL);

                    cuit.Text = aux.CUIT;
                    nombre.Text = aux.Nombre;
                    telefono.Text = aux.Telefono;
                    mail.Text = aux.Mail;
                    direccion.Text = aux.Direccion;
                }
                else
                {
                    btn_eliminar.Enabled = false;
                    btn_eliminar.CssClass = "btn btn-danger btn-lg btnlogin";
                }
            }
        }

        protected void btn_alta_Click(object sender, EventArgs e)
        {
            try
            {
                if(cuit.Text != "" && cuit.Text.Length == 12 && nombre.Text != "")
                {
                    ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                    _Proveedor2 aux = new _Proveedor2();
                    aux.CUIT = cuit.Text;
                    aux.Nombre = nombre.Text;
                    aux.Telefono = telefono.Text;
                    aux.Mail = mail.Text;
                    aux.Direccion = direccion.Text;

                    if (Request.QueryString["id"] != null) //se esta editando un proveedor.
                    {
                        proveedor_negocio.modificar(aux);
                    }

                    else
                    {
                        proveedor_negocio.agregar(aux);
                    }

                    Response.Redirect("ListadoProveedores.aspx");
                }


                if (cuit.Text == "" || cuit.Text.Length >= 10 && cuit.Text.Length <= 12)
                {
                    cuit.CssClass = "form-control is-invalid";
                }
                else
                {
                    cuit.CssClass = "form-control is-valid";
                }


                if (nombre.Text == "")
                {
                    nombre.CssClass = "form-control is-invalid";
                }
                else
                {
                    nombre.CssClass = "form-control is-valid";
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    proveedor_negocio.eliminar(codigoURL);
                    Response.Redirect("ListadoProveedores.aspx");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}