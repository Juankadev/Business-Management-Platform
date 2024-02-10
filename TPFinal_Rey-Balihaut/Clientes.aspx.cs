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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                //else if (Session["tipo"].ToString() != "ADMIN")
                //{
                //    Response.Redirect("Default.aspx", false);
                //}

                dni.MaxLength = 10; //contar cantidad de caracteres de la caja de texto con length

                if (!IsPostBack)
                {
                    btn_alta.Text = "Agregar";

                    if (Request.QueryString["id"] != null)
                    {
                        string codigoURL = Request.QueryString["id"].ToString();
                        btn_alta.Text = "Modificar";

                        CustomerController negocio = new CustomerController();
                        List<Customer> lista = negocio.GetAll();
                        Customer aux = lista.Find(x => x.id == codigoURL);

                        dni.Text = aux.id;
                        nombre.Text = aux.name;
                        apellido.Text = aux.lastName;
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
                if(dni.Text != "" && nombre.Text != "" && dni.Text.Length == 8)
                {
                    CustomerController cliente_negocio = new CustomerController();
                    Customer aux = new Customer();
                    aux.id = dni.Text;
                    aux.name = nombre.Text;
                    aux.lastName = apellido.Text;
                    aux.phone = telefono.Text;
                    aux.email = mail.Text;
                    aux.address = direccion.Text;

                    if (Request.QueryString["id"] != null) //se esta editando un cliente.
                        cliente_negocio.Modify(aux);

                    else
                        cliente_negocio.Add(aux);

                    Response.Redirect("ListadoClientes.aspx",false);
                }


                if (dni.Text == "" || dni.Text.Length != 8)
                {
                    dni.CssClass = "form-control is-invalid";
                }
                else
                {
                    dni.CssClass = "form-control is-valid";
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
                CustomerController cliente_negocio = new CustomerController();
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    cliente_negocio.Delete(codigoURL);
                    Response.Redirect("ListadoClientes.aspx",false);
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