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

                        CategoryController negocio = new CategoryController();
                        List<Category> lista = negocio.GetAll();
                        Category aux = lista.Find(x => x.id == codigoURL);

                        nombre.Text = aux.description;
                    }
                    else
                    {
                        //btn_eliminar.Enabled = false;
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

        protected void btn_alta_Click(object sender, EventArgs e) //para agregar y modificar
        {
            try
            {
                CategoryController categoria_negocio = new CategoryController();
                Category aux = new Category();

                aux.description = nombre.Text;

                if (nombre.Text != "")
                {
                    if (Request.QueryString["id"] != null) //se esta modificando un prod.
                    {
                        aux.id = int.Parse(Request.QueryString["id"]);
                        categoria_negocio.Modify(aux);
                    }
                    else //se esta agregando un producto
                    {
                        categoria_negocio.Add(aux);
                        nombre.Text = "";
                    }

                    Response.Redirect("ListadoCategorias.aspx",false);
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
                CategoryController categoria_negocio = new CategoryController();
                if (Request.QueryString["id"] != null)
                {
                    int codigoURL = int.Parse(Request.QueryString["id"].ToString());
                    categoria_negocio.Delete(codigoURL);
                    Response.Redirect("ListadoCategorias.aspx",false);
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