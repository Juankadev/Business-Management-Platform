using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_Rey_Balihaut
{
    public partial class ListadoCategorias : System.Web.UI.Page
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
                    CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                    gvCategorias.DataSource = categoria_negocio.listar();
                    gvCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var codigoSelected = gvCategorias.SelectedDataKey.Value.ToString();
                Response.Redirect("Categorias.aspx?id=" + codigoSelected,false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                if (buscador.Text != "")
                {
                    gvCategorias.DataSource = categoria_negocio.listarxtexto(buscador.Text);
                }
                else
                {
                    gvCategorias.DataSource = categoria_negocio.listar();
                }
                gvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Categorias.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                gvCategorias.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}