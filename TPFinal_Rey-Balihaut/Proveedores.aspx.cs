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
                        string codigoURL = Request.QueryString["id"].ToString();
                        btn_alta.Text = "Modificar";

                        SupplierController negocio = new SupplierController();
                        List<Supplier> lista = negocio.GetAll();
                        Supplier aux = lista.Find(x => x.cuit == codigoURL);

                        cuit.Text = aux.cuit;
                        nombre.Text = aux.name;
                        telefono.Text = aux.phone;
                        mail.Text = aux.email;
                        direccion.Text = aux.address;
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
                if(cuit.Text != "" && cuit.Text.Length == 12 && nombre.Text != "")
                {
                    SupplierController proveedor_negocio = new SupplierController();
                    Supplier aux = new Supplier();
                    aux.cuit = cuit.Text;
                    aux.name = nombre.Text;
                    aux.phone = telefono.Text;
                    aux.email = mail.Text;
                    aux.address = direccion.Text;

                    if (Request.QueryString["id"] != null) //se esta editando un proveedor.
                    {
                        proveedor_negocio.Modify(aux);
                    }

                    else
                    {
                        proveedor_negocio.Add(aux);
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
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {   
            try
            {
                SupplierController proveedor_negocio = new SupplierController();
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    proveedor_negocio.Delete(codigoURL);
                    Response.Redirect("ListadoProveedores.aspx");
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